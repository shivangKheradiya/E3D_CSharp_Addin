# 🔹 Stand-Alone E3D

This example demonstrates how to create a **.NET Framework console application** capable of opening an AVEVA project and displaying the current MDB name directly in the command line.

The key component used in this project is **`Aveva.Core.Standalone.dll`**, which enables integration of AVEVA functionalities into **independent or custom .NET applications** — effectively allowing AVEVA to operate as a standalone system outside its native UI.

---

### 🔸 Use Cases

The [example application](./Program.cs) can be extended or utilized for a variety of purposes, including:

* **Integration:** Embedding AVEVA applications with other software or custom-built tools.
* **Automation:** Performing periodic or background tasks by defining scheduled or service-based logic.
* **Database Operations:** Executing controlled modifications in project databases without any UI or TTY involvement.
* **Flexible Execution:** Acting as a generic execution environment similar to TTY, but without the limitations of PML.

---

### 🔸 Core Functionalities

The `Standalone` class from the `Aveva.Core.Standalone` namespace provides methods to manage the lifecycle of an AVEVA session programmatically:

| Method       | Description                                                  |
| ------------ | ------------------------------------------------------------ |
| **Start()**  | Initializes and starts the AVEVA environment.                |
| **Open()**   | Opens a project using the parameters provided to the method. |
| **Finish()** | Gracefully closes the opened project and releases resources. |

Between the **Open** and **Finish** calls, developers can implement their **custom business logic**, database operations, or automation routines.

---

### 🔸 Configuration & Setup

Before running this console application, it is essential to **place the executable inside the AVEVA installation directory**.
This ensures that all required **environment variables (Evars)** are properly set up via the
[`StandAloneE3D.bat`](./E3DInstallationDir/StandAloneE3D.bat) script.

At the end of this batch process, the application is launched with all necessary DLL references correctly resolved.

---

### 🔸 Alternative Setup

Alternatively, developers may choose to programmatically define and initialize all Evars using the **`Open()`** and **`Start()`** methods directly within the code using overloaded methods.
This approach offers greater flexibility, making the application portable and independent of the installation path.

---