# 🔹 E3DAddIn_12

This example demonstrates the **high-level object structures** available under the `DruidNet.dll` assembly — one of the core dynamic libraries used by AVEVA E3D for managing **forms, dialogs, and UI elements**.
It provides insight into how **AVEVA’s internal form-handling system** works and shows a basic reflection-based approach to inspect and interact with runtime UI objects.

---

### 🧩 Overview

The `DruidNet.dll` assembly defines several classes that AVEVA uses internally to represent its user interface (UI) components.
These objects provide control over form behavior, layout, and access to the embedded UI elements.

In this example, reflection is used to explore these objects dynamically, allowing developers to inspect form types and properties during runtime — a useful technique for **UI diagnostics**, **automation**, or **plugin integration**.

---

### ⚙️ Key Concepts Demonstrated

| Concept                | Description                                                                                                                        |
| ---------------------- | ---------------------------------------------------------------------------------------------------------------------------------- |
| **Reflection Usage**   | Demonstrates how to use .NET reflection to explore AVEVA’s internal UI object structure within `DruidNet.dll`.                     |
| **Form Hierarchy**     | All AVEVA form types are derived from the base class `UI_DruidForm`, which in turn inherits from `System.Windows.Forms.Form`.      |
| **Runtime Monitoring** | The add-in periodically (every 10 seconds) checks and prints the count of currently active PML forms within the AVEVA environment(CommandLine). |

---

### 🔧 Implementation Details

This example executes a **background timer** that triggers every **10 seconds**, scanning through AVEVA’s currently loaded forms using reflection on `DruidNet.dll`.

Each time the timer ticks:

1. The system enumerates all objects of type `UI_DruidForm`.
2. Counts the number of open AVEVA PML forms.
3. Prints the form count in the **Command-Line Output** window.

This demonstrates a simple but powerful diagnostic pattern for **monitoring UI activity** in real time.

---

### 🧩 Code Logic Summary

| Step                             | Description                                                                                          |
| -------------------------------- | ---------------------------------------------------------------------------------------------------- |
| **1. Load Assembly**             | The `DruidNet.dll` assembly is loaded dynamically at runtime.                                        |
| **2. Retrieve Type Information** | Reflection APIs (`Assembly.GetTypes()`) are used to list all available types.                        |
| **3. Filter for UI_DruidForm**   | The code identifies form-related types and instances derived from `UI_DruidForm`.                    |
| **4. Periodic Scanning**         | A 10-second timer checks the number of currently active forms and prints it in the E3D command-line. |

---

### ▶️ How to Test

1. Register and load the **E3DAddIn_12** project into your AVEVA E3D environment.
2. Open or close different forms (e.g., specification forms, element properties, model navigator, etc.).
3. Observe the **command-line output** — every 10 seconds, it will display the **current count of open PML forms**.
4. Optionally, attach a debugger to inspect the reflection calls and view which form types are being enumerated.

---

### 🧠 Technical Insights

| Concept                    | Explanation                                                                                                                                       |
| -------------------------- | ------------------------------------------------------------------------------------------------------------------------------------------------- |
| **Reflection in .NET**     | Reflection allows you to access metadata about assemblies, types, and members at runtime — useful for reverse-engineering or automation in AVEVA. |
| **UI Monitoring**          | Tracking active forms helps in debugging UI leaks, automating tests, or synchronizing external systems with UI events.                            |
| **Dynamic Type Discovery** | Using reflection with `DruidNet.dll` makes it possible to dynamically explore new or undocumented AVEVA form classes.                             |

---

### 🚀 Summary

`E3DAddIn_12` introduces a **reflection-based exploration of AVEVA’s Druid UI framework**, focusing on how to inspect and monitor form objects.
It serves as a foundation for developers aiming to:

* Understand the **internal structure of AVEVA UI forms** (`UI_DruidForm`, `UI_DruidControl`, etc.).
* Automate tasks or perform diagnostics related to **form creation and management**.
* Build **advanced UI-integrated tools** that synchronize external logic with AVEVA’s live form environment.

> 💡 *Tip:* You can extend this example to list **form names**, **control hierarchies**, or even **hook events** to specific forms for advanced UI customization or testing automation.
