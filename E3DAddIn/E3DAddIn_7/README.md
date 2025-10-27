# 🔹 E3DAddIn_7

This example demonstrates how to **handle exceptions** — specifically **PDMS-specific exceptions (`PdmsException`)** and **general system exceptions** — within the AVEVA E3D Add-In environment.

It builds upon the `TextBoxCmd` functionality from the previous example (`E3DAddIn_6`) to capture an element name entered by the user, then attempts to retrieve and display its attributes. Through this, it showcases proper **error handling and exception segregation** when interacting with the AVEVA database.

---

### 🧩 Overview

A new command class, [`ExceptionCmd`](./ExceptionCmd.cs), is created to demonstrate structured exception handling while querying E3D database elements.

This command:

1. Fetches the **element name** entered in the `TextBox` (using `TextBoxCmd`).
2. Retrieves the corresponding **DbElement** object.
3. Attempts to access one of its attributes (`PSPE`).
4. Demonstrates how to **gracefully handle both PDMS-level and system-level exceptions**.

---

### 🧠 Key Concepts

| Concept                       | Description                                                                                                                    |
| ----------------------------- | ------------------------------------------------------------------------------------------------------------------------------ |
| **TextBoxCmd Integration**    | The command retrieves the element name from the TextBox input using the previously defined `TextBoxCmd`.                       |
| **PDMS Exception Handling**   | `PdmsException` is caught separately to manage AVEVA-specific database or attribute-related errors.                            |
| **System Exception Handling** | Any unexpected or general .NET runtime errors are caught under `System.Exception`.                                             |
| **Robust Error Feedback**     | Both exception types display user-friendly messages via `MessageBox.Show()`, helping developers diagnose issues interactively. |
| **Execution Flow**            | `base.Execute()` ensures the standard command execution flow is preserved.                                                     |

---

### ▶️ How to Test

1. Launch E3D with the add-in loaded.
2. Type a valid or invalid element name into the TextBox.
3. Execute the **Exception Command** button (linked with `E3DAddIn_7.ExceptionCmd`).
4. Observe the following behaviors:

   * If the element and its attributes exist → shows `Pspec : <value>` in a message box.
   * If the element exists but attribute access fails → a **PDMS Exception** message appears.
   * If any other error occurs (e.g., invalid syntax or null reference) → a **System Exception** message may appears.

---

### 💡 Summary

This example highlights the **importance of structured exception handling** within E3D add-in development.

By distinguishing between **PDMS-specific** and **system-level exceptions**, developers can ensure:

* More reliable and predictable code behavior,
* Easier debugging during automation tasks, and
* Improved user experience through clear, meaningful feedback.

This pattern forms the foundation for **robust, production-grade customization** within AVEVA E3D’s extensibility framework.