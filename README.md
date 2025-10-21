# E3D_CSharp_Addin

This repository represent the standard methods to effectively use the AVEVA IAddin interface used to create the Addins for the AVEVA Application. Additional this repository covers the other dll usecase proveded with AVEVA Software installation. By the time you are reading the examples mentioned here with the repository will slightly very depending upon which aveva application you are using.

---

## 📦 Prerequisites

- Visual Studio (2019 or later)
- .NET Framework (version compatible with your AVEVA installation)
- Access to AVEVA Software & It's installation directory

For starting with this repository It's assumed that you are familar with the following key cocepts,
- C# Language
- Basic Concepts for WPF and WinForms
- [PML](https://github.com/shivangKheradiya/AVEVA_PML)
- [PMLNet](https://github.com/shivangKheradiya/PMLNet)
- AVEVA Environment Setup Process [Example](https://github.com/shivangKheradiya/AVEVAEnvironment)
- AVEVA Administration and User Fundamentals(Adds Extra value but not necessory). 

---

## 📘 Overview

Each project includes a `MyAddin.cs` class containing the core C# `IAddin` Interface implimentation into a class library. These libraries are consumed by AVEVA during application startup and all corrosponding chages required in the installation director is in the `E3DInstallationDir` folder.

To run the examples:
 
- Create a folder for placing compiled DLLs and other Addins data files such as `E3DAddins` folder Inside the AVEVA installation directory
- If required, Create a folder for placing UIC files required for addin such as `MyE3DUIC` folder Inside the AVEVA installation directory.
- Update two important files into design installation directory. 
    - `DesignAddins.xml` : Helps to register User Interface files e.g. UIC during the AVEVA Startup.
    - `DesignCustomization.xml` : Helps to register `IAddins` implimentation library files into AVEVA Startup.

These procedure will remain common irrespective of the examples mentioned in this repository.

However, depending upon the setup of the AVEVA Variables folder location may vary from company to company. and depending upon the application for which you are creating addins, the some steps and references may vary.

[`StartAPSE3D.bat`](./E3DAddIn/StartAPSE3D.bat) contains the script helps to directly open the Project within E3D. helpes to repid testing without entering the credentials in the startup form.

---

## 📂 Table of Contents

### [🔹 E3DAddIn_1](./E3DAddIn/E3DAddIn_1/README.md)

- A simple “Hello World” Add-in example for AVEVA E3D

### [🔹 E3DAddIn_2](./E3DAddIn/E3DAddIn_2/README.md)

- The project demonstrates how to extend AVEVA™ E3D functionality by integrating UI components, commands, and services using C#.

### [🔹 E3DAddIn_3](./E3DAddIn/E3DAddIn_3/README.md)

### [🔹 E3DAddIn_4](./E3DAddIn/E3DAddIn_4/README.md)

### [🔹 E3DAddIn_5](./E3DAddIn/E3DAddIn_5/README.md)

### [🔹 E3DAddIn_6](./E3DAddIn/E3DAddIn_6/README.md)

### [🔹 E3DAddIn_7](./E3DAddIn/E3DAddIn_7/README.md)

### [🔹 E3DAddIn_8](./E3DAddIn/E3DAddIn_8/README.md)

### [🔹 E3DAddIn_9](./E3DAddIn/E3DAddIn_9/README.md)

### [🔹 E3DAddIn_10](./E3DAddIn/E3DAddIn_10/README.md)

### [🔹 E3DAddIn_11](./E3DAddIn/E3DAddIn_11/README.md)

### [🔹 E3DAddIn_12](./E3DAddIn/E3DAddIn_12/README.md)

### [🔹 StandAloneE3D](./E3DAddIn/StandAloneE3D/README.md)

--- 

## 🤝 Contributing

This repository is open-source and welcomes contributions! If you have ideas, enhancements, or additional examples to share, feel free to:

- Fork the repo
- Create a new branch
- Submit a pull request

Let's build a stronger AVEVA customization community together.

---

## 📬 Contact

For questions, suggestions, or collaboration opportunities, please open an issue or start a discussion on GitHub.

---