@echo off

rem ----------------------------------------------------------------
rem Start up Everything3D, allowing for AVEVA_DESIGN_EXE being a search path, and
rem some arguments to pass into the startup module
rem by default this is monitor, but another module can be given
rem via the first command line argument
rem ----------------------------------------------------------------

setlocal
set savepath=%path%

rem ----------------------------------------------------------------
rem This bat file launches the AVEVA Plant Everything3D modules
rem ----------------------------------------------------------------

set AVEVA_PRODUCT=3D

rem ----------------------------------------------------------------
rem Set AVEVA_DESIGN_INSTALLED_DIR to the folder this .bat is running in
rem This line is edited by the installer to point to your chosen folder
rem ----------------------------------------------------------------

set AVEVA_DESIGN_INSTALLED_DIR=%~dp0

rem ---------------------------------------------
rem Set evars for Everything3D
rem this sets all the project variables
rem ---------------------------------------------

call "%AVEVA_DESIGN_INSTALLED_DIR%\evars" "%AVEVA_DESIGN_INSTALLED_DIR%"

if not "%AVEVA_DESIGN_ACAD%"=="" goto acaddone
set acad_version=%AVEVA_DESIGN_ACAD%
rem echo %path%
:acaddone

rem ----------------------------------------------------------------
rem Are we starting in Monitor or another module?
rem ----------------------------------------------------------------
set moduleArg=%1
set executable=mon
if /i not "%moduleArg%"=="Admin" goto tryLex
set executable=adm
set moduleArg=
goto modEnd
:tryLex
if /i not "%moduleArg%"=="Lexicon" goto tryParagon
set executable=lex
set moduleArg=
goto modEnd
:tryParagon
if /i not "%moduleArg%"=="Paragon" goto tryPropcon
set executable=des
set moduleArg=-module=81 -modulename=Paragon
goto modEnd
:tryPropcon
if /i not "%moduleArg%"=="Propcon" goto trySpooler
set executable=des
set moduleArg=-module=27 -modulename=Propcon
goto modEnd
:trySpooler
if /i not "%moduleArg%"=="Spooler" goto tryIsoDraft
set executable=des
set moduleArg=-module=83 -modulename=Spooler
goto modEnd
:tryIsoDraft
if /i not "%moduleArg%"=="IsoDraft" goto tryDesign
set executable=iss
set moduleArg=
goto modEnd
:tryDesign
if /i not "%moduleArg%"=="Design" goto tryDraft
set executable=des
set moduleArg=
goto modEnd
:tryDraft
if /i not "%moduleArg%"=="Draft" goto tryMon
set executable=dra
set moduleArg=
goto modEnd
:tryMon
if /i "%moduleArg%"=="Monitor" set moduleArg=

:modEnd

rem ----------------------------------------------------------------
rem The rest of this is about finding a path to
rem mon.exe or supplied start module within main executables directory
rem and then running it
rem ----------------------------------------------------------------

set found=

rem ----------------------------------------------------------------
rem Next two for loops set %i to the 1st token and %j to the remaining tokens
rem  using space as a delimiter
rem ----------------------------------------------------------------

:findMon
set remains=%AVEVA_DESIGN_EXE%
:nextSP
set nextpart=
for /F "tokens=1,* delims= " %%i in ( "%remains%" ) do set nextpart=%%i
for /F "tokens=1,* delims= " %%i in ( "%remains%" ) do set remains=%%j
if "%nextpart%" equ "" goto SPdone
call aveva_design_findexe "%nextpart%" "%executable%".exe
if not "%found%"=="" goto gotMON
goto nextSP
:SPdone

rem ----------------------------------------------------------------
rem Next two for loops set %i to the 1st token and %j to the remaining tokens
rem  using space as a delimiter
rem ----------------------------------------------------------------

set remains=%AVEVA_DESIGN_EXE%
:nextSE
set nextpart=
for /F "tokens=1,* delims=;" %%i in ( "%remains%" ) do set nextpart=%%i
for /F "tokens=1,* delims=;" %%i in ( "%remains%" ) do set remains=%%j
if "%nextpart%" equ "" goto SEdone
call aveva_design_findexe "%nextpart%" "%executable%".exe
if not "%found%"=="" goto gotMON
goto nextSE
:SEdone
if "%executable%"=="mon" goto noMon

rem ----------------------------------------------------------------
rem supplied module was not found ... look instead for Monitor
rem ----------------------------------------------------------------
echo supplied entry module %executable% not found
set executable=mon
set moduleArg=""
goto findMon

:gotMON
set monexe=%found%

rem do we want a console?
set noconsole=
if not "%AVEVA_NOCONSOLE%"=="" set noconsole=noconsole

rem ----------------------------------------------------------------
rem If we have no arguments, add 'graphics' so that monitor doesn't
rem think we are coming from a module-switch
rem ----------------------------------------------------------------

set args=%moduleArg% %noconsole% %2 %3 %4 %5 %6 %7
if "%args%"=="       " set args=graphics

rem For Autocad
set AVEVA_DESIGN_ACAD=2006
set ACAD_VERSION=%AVEVA_DESIGN_ACAD%
set AVEVA_DESIGN_ACAD_PATH=C:\program files\AutoCAD 2006;C:\Program Files\Common Files\Autodesk Shared

rem ----------------------------------------------------------------
rem The following directories should contain the executables - %AVEVA_DESIGN_ACAD_PATH%
rem Alternatively, edit this macro for your own setup.
rem ----------------------------------------------------------------

set path=%AVEVA_DESIGN_EXE%\autodraftACAD;%AVEVA_DESIGN_ACAD_PATH%;%path%

rem ----------------------------------------------------------------
rem The following directory should contain AutoCAD-style fonts used
rem by Open Design Alliance libraries on machines not equipped with
rem AutoCAD.
rem ----------------------------------------------------------------

set ACAD=%AVEVA_DESIGN_INSTALLED_DIR%\AutoDraftFonts

rem Evar to workaround unwanted interaction of Everything3D launcher and PLOT input;
set AVEVA_DESIGN_CONSOLE_WINDOW=ACTIVE

rem If starting through pdms.bat instead of aveva_design.bat

rem if not "%PDMS_COMPATIBILITY%"=="" 
call set_aveva_design.bat

rem ----------------------------------------------------------------
rem Setup Bocad Steel Interface
rem ----------------------------------------------------------------

set ABSIVER=

set AVEVA_SHORTPATHS=true

rem Define AVEVA Bocad Steel Interface main directory
set BOCWORK=%AVEVA_DESIGN_WORK%
if "%AVEVA_DESIGN_WORK%"=="" set BOCWORK=%PDMSWK%\

set BOCUSER=%AVEVA_DESIGN_USER%
if "%AVEVA_DESIGN_USER%"=="" set BOCUSER=%PDMSUSER%\

if "%BOCDFLTS%"=="" set BOCDFLTS=%PDMSDFLTS%\

set BOCEXE=%BOCMAIN%
set BOCBLOCKMAPS=%BOCDFLTS%BlockMaps\
set BOCDATA=%BOCDFLTS%bocad\

rem Add AVEVA Bocad Steel Interface macros to PML search path
set PMLLIB=%PMLLIB%;%BOCDATA%

set BOCDFLTS=%BOCDATA%dflts\;%BOCDFLTS%

rem To get the old file browser form
set BOCUI=%PMLUI%
if "%AVEVA_DESIGN_DFLTS%"=="" set BOCUI=%PDMSUI%

set AVEVA_SHORTPATHS=false
rem -----------------------------------------------
rem We have found mon.exe or supplied module somewhere,
rem so start it up with any arguments the user passed us
rem -----------------------------------------------


:: StandAloneE3D Modification is starting from here
cmd/c "StandAloneE3D.exe"
:: echo running: %monexe%\%executable% %args%
:: cmd/c "%monexe%\%executable%" %args%
:: goto end
:: 
:: :noMON
:: @echo Sorry, cannot find %executable%.exe within your AVEVA_DESIGN_EXE - %AVEVA_DESIGN_EXE%
:: pause
:: goto end
:: 
:: :end
:: set path=%savepath%
:: endlocal
