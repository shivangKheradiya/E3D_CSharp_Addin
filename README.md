# 🧩 E3D_CSharp_Addin

This repository represents a **comprehensive collection of examples** demonstrating how to effectively use the **AVEVA `IAddin`/`IAddinInjected` interface** to develop C# Add-Ins for AVEVA™ applications such as **E3D (Everything3D)**.

In addition, it includes practical **use cases for other key AVEVA DLLs** commonly distributed with the AVEVA software installation.
Depending on your AVEVA version and configuration, some examples may differ slightly — but the concepts remain universally applicable.

---

## 📦 Prerequisites

Before getting started, ensure you have the following:

* **Visual Studio 2019 or later**
* **.NET Framework** (compatible with your AVEVA installation)
* **Access to an AVEVA software installation directory**

### Familiarity Recommended

This repository assumes basic familiarity with:

* 🧠 **C# Language**
* 🪟 **WPF and WinForms**
* ⚙️ [**PML**](https://github.com/shivangKheradiya/AVEVA_PML)
* 🔗 [**PMLNet**](https://github.com/shivangKheradiya/PMLNet)
* 🧰 [**AVEVA Environment Setup**](https://github.com/shivangKheradiya/AVEVAEnvironment)
* 🧾 AVEVA Administration & User Fundamentals *(recommended but optional)*

---

## 📘 Overview

Each example project includes a **`MyAddin.cs`** class implementing the **C# `IAddin`/`IAddinInjected` interface**, packaged as a **Class Library**.
These Add-In libraries are automatically **loaded by AVEVA during startup**. All necessary configuration changes for registration are located in the **`E3DInstallationDir`** folder.

### ⚙️ Setup Steps

To run or test the examples:

1. **Create folders** inside your AVEVA installation directory:

   * `E3DAddins` → for compiled DLLs and Add-In data files.
   * `MyE3DUIC` → for any UIC (User Interface Configuration) files used by the Add-In.

2. **Update the following XML files** in your design installation directory:

   * **`DesignAddins.xml`** → registers UI (UIC) files for AVEVA startup.
   * **`DesignCustomization.xml`** → registers `IAddin`/`IAddinInjected` libraries for AVEVA startup.

3. Use the provided startup helper script:
   [`StartAPSE3D.bat`](./E3DAddIn/StartAPSE3D.bat)
   This script launches your E3D project directly, bypassing manual credential entry for rapid testing.

> 🧩 **Note:**
> Folder structure and environment variable locations may differ between organizations and AVEVA versions.
> Adjust paths and configurations accordingly.

---

## 📂 Table of Contents

This repository follows a **progressive structure**, where each example builds upon concepts introduced in the previous one for a clearer understanding of AVEVA Add-In integration.

| Example                                                    | Description                                                                                              |
| ---------------------------------------------------------- | -------------------------------------------------------------------------------------------------------- |
| [🔹 **E3DAddIn_1**](./E3DAddIn/E3DAddIn_1/README.md)       | Basic “Hello World” Add-In for AVEVA E3D.                                                                |
| [🔹 **E3DAddIn_2**](./E3DAddIn/E3DAddIn_2/README.md)       | Extending AVEVA E3D functionality using UI components, commands, and services.                           |
| [🔹 **E3DAddIn_3**](./E3DAddIn/E3DAddIn_3/README.md)       | Demonstrates **MDI windows** and other available UI form types.                                          |
| [🔹 **E3DAddIn_4**](./E3DAddIn/E3DAddIn_4/README.md)       | Integration of **WPF `UserControl`** with **MDI Windows** for modern UI design.                          |
| [🔹 **E3DAddIn_5**](./E3DAddIn/E3DAddIn_5/README.md)       | Handling and customizing **database-driven events** using the `DbEvent` class.                           |
| [🔹 **E3DAddIn_6**](./E3DAddIn/E3DAddIn_6/README.md)       | Implementing **UI elements (TextBox, ComboBox)** in the AVEVA Ribbon via Add-Ins.                        |
| [🔹 **E3DAddIn_7**](./E3DAddIn/E3DAddIn_7/README.md)       | Managing **exceptions** — both `PdmsException` and general system exceptions — within E3D Add-Ins.       |
| [🔹 **E3DAddIn_8**](./E3DAddIn/E3DAddIn_8/README.md)       | Extending native **AVEVA UserControls** like `NetGridControl` to build enhanced custom UIs.              |
| [🔹 **E3DAddIn_9**](./E3DAddIn/E3DAddIn_9/README.md)       | Demonstrates **element collection and filtering** using various database query methods.                  |
| [🔹 **E3DAddIn_10**](./E3DAddIn/E3DAddIn_10/README.md)     | Enables **bidirectional communication** between C# and PML via `Aveva.Core.Utilities.dll`.               |
| [🔹 **E3DAddIn_11**](./E3DAddIn/E3DAddIn_11/README.md)     | Explores **database tables** from `Aveva.Core.Database.dll` (e.g., `RefTable`, `NameTable`, `IntTable`). |
| [🔹 **E3DAddIn_12**](./E3DAddIn/E3DAddIn_12/README.md)     | Explains **high-level form and UI object structures** under `DruidNet.dll` using reflection.             |
| [🔹 **StandAloneE3D**](./E3DAddIn/StandAloneE3D/README.md) | Builds a **.NET Console App** using `Aveva.Core.Standalone.dll` to run AVEVA standalone.                 |

---

## 🧠 Additional Notes

The AVEVA installation directory often includes a **`Samples.zip`** file containing additional **C#.NET examples**.
These official samples can further help you explore the AVEVA API ecosystem in depth.

There are **endless possibilities** when combining **C#**, **PML**, and **AVEVA’s extensibility features**.
However, the true power lies in **how an organization defines its customization strategy** — shaping a strong, scalable, and efficient AVEVA ecosystem tailored to its workflows.

---

## 🤝 Contributing

Contributions are welcome!
If you have ideas, improvements, or additional Add-In examples to share:

1. **Fork** the repository
2. **Create** a new feature branch
3. **Submit** a pull request

Together, we can build a stronger and more collaborative **AVEVA customization community**.

---

## 📬 Contact

For questions, feedback, or collaboration opportunities,
please **open an issue** or start a **GitHub discussion**.

---
