# 🔹 E3DAddIn_1

**A simple “Hello World” Add-in example for AVEVA E3D**

This example demonstrates how to create a **basic AVEVA E3D Add-in** using C# and the **.NET Framework**.

When successfully registered and loaded, the add-in displays a **“Welcome to My Addin”** message box during startup — the perfect first step toward building advanced automation and UI integrations within AVEVA applications.

---

## 🧰 Project Setup Procedure

### 1️⃣ Create a New C# Class Library Project

* Open **Visual Studio** → **C#** → **.NET Framework Class Library**
* **Project Name:** `E3DAddIn_1`
* **Solution Name:** `E3DAddIn`

> ⚠️ Make sure to target the same **.NET Framework version** as used by your AVEVA installation (typically **.NET Framework 4.6.2** or higher for E3D 3.x+).

---

### 2️⃣ Add Required AVEVA References

To integrate with E3D’s APIs, add the following DLLs from your **AVEVA installation directory** (usually under `C:\Program Files\AVEVA\E3D3D\Aveva` or similar).

| DLL Name                                        | Purpose                                                                                                       |
| ----------------------------------------------- | --------------------------------------------------------------------------------------------------------------|
| **Aveva.ApplicationFramework.dll**              | Provides access to the AVEVA application core and base `IAddin` or `IAddinInjected` interfaces and many more. |
| **Aveva.ApplicationFramework.Presentation.dll** | Enables UI integration such as Ribbons, Toolbar Manager, and windows etc.                                     |
| **Aveva.Core.Database.dll**                     | Supports working with DBElements, database CRUD operations as well as events                                  |
| **Aveva.Core.Database.Filters.dll**             | Allows filtering and helps during collection-based data queries in E3D.                                       |
| **Aveva.Core.Utilities.dll**                    | Provides utility functions including interaction with Dabacon and PML commands.                               |
| **Aveva.E3D.Standalone.dll**                    | Supports to create own standalone application for non-interactive operations.                                 |
| **Aveva.Core.PMLPseudos.dll**                   | Manages pseudo-attributes and custom objects and events.                                                      |
| **GridControl.dll**                             | Provides `.NET GridControl` for PML integration via `PMLNetCallable`.                                         |
| **DruidNet.dll**                                | Enables communication between C# and PML Forms (PML UI).                                                      |

---

### 3️⃣ Implement the Add-in Class

Rename the default class to **`MyAddIn.cs`** and implement the `IAddinInjected` interface.

If you are targeting **legacy PDMS**, use `IAddin` instead. It will use `Start(ServiceManager serviceManager)` method during startup.

> ⚠️ For newer versions (E3D 3.x+), **`IAddinInjected`** is the preferred interface since `IAddin` is deprecated. It will use `Start(IDependencyResolver resolver)` method during startup.

A minimal implementation looks like this:
([View Full Example → `MyAddIn.cs`](./MyAddIn.cs))

| Method / Property                          | Description                                                                   |
| ------------------------------------------ | ----------------------------------------------------------------------------- |
| **`Name`**                                 | Returns the name of your Add-in (metadata).                                   |
| **`Description`**                          | Returns a short description for the Add-in (metadata).                        |
| **`Start(IDependencyResolver resolver)`**  | Called during startup; used to resolve dependencies required for your Add-in. |
| **`Start(ServiceManager serviceManager)`** | Alternative startup entry point used to access application-level services.    |
| **`Stop()`**                               | Called when the Add-in is unloaded or the application shuts down.             |

When the Add-in loads, the `Start()` method executes and displays “Welcome To My Addin” MessageBox :

---

### 4️⃣ Create Add-in Output Folder

Create a folder to store the Add-in binaries.
Example:

```
C:\Program Files\AVEVA\E3D3D\E3DAddIns\E3DAddIn_1\
```

Place the **compiled DLL** and its dependencies here after building the project.

---

### 5️⃣ Register the Add-in with E3D

Add your Add-in path to the **DesignAddins.xml** file in the AVEVA installation directory.
This ensures the Add-in is automatically loaded when E3D starts.

```xml
<string>C:\Program Files\AVEVA\E3D3D\E3DAddIns\E3DAddIn_1</string>
```

Alternatively, if your environment defines **`CAF_ADDINS_PATH`** or **`CAF_UIC_PATH`**,
you can place your custom XML configuration in those directories for better modular control.

---

### 6️⃣ Launch and Verify

Start **AVEVA E3D**.
If everything is configured correctly, you should see the **“Welcome To My Addin”** MessegeBox on startup.

This confirms that your Add-in has been successfully registered and executed. Morover you can attach the debugger and debug line by lines.

---

## 💡 Tips & Best Practices

* Always match the **.NET Framework version** used by your E3D installation.
* Keep **Add-in folder names** unique to avoid load conflicts.
* Use **try/catch** inside your `Start()` method to handle unexpected initialization issues gracefully.
* For version control, include a simple **version.txt** or **manifest.xml** with build details.

---

## ✅ Summary

This `E3DAddIn_1` example introduces the **foundation for developing C# add-ins** for AVEVA E3D.
It demonstrates:

* How to **set up your environment**,
* **Register an Add-in**, and
* Execute **basic functionality** via the E3D Add-in framework.

From here, you can extend it with custom commands, database access, PML integration, and UI enhancements — unlocking the full potential of **AVEVA’s extensible framework**.

---
