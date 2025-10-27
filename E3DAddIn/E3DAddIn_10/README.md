# 🔹 E3DAddIn_10

This example focuses on **bidirectional communication between the PML Command-Line System and C#** using the `Aveva.Core.Utilities.dll` library.

It demonstrates how to **send commands from C# to PML** and how to **retrieve global PML variables back into C#**, enabling a seamless data bridge between the two environments.

---

### 🧩 Overview

The **E3DAddIn_10** example introduces a standard and generic approach for **C# ↔ PML interaction**, where variables, strings, and numerical values can be exchanged dynamically.

This integration is particularly useful when developing **C# add-ins that need to control or read existing PML-based functionalities** in AVEVA E3D.

The example consists of two commands:

| Command                                         | Description                                                                                              |
| ----------------------------------------------- | -------------------------------------------------------------------------------------------------------- |
| [`SetPMLVariablesCmd`](./SetPMLVariablesCmd.cs) | Demonstrates how to **send** commands and variable assignments from C# into the PML Command-Line system. |
| [`GetPMLVariablesCmd`](./GetPMLVariablesCmd.cs) | Demonstrates how to **retrieve** global PML variable values from the PML environment back into C#.       |

---

### ⚙️ Executing Commands in PML

The [`SetPMLVariablesCmd`](./SetPMLVariablesCmd.cs) command demonstrates how to execute PML code from C# using two key methods available in `Aveva.Core.Utilities.CommandLine`:

| Method          | Description                                                                                                                                    |
| --------------- | ---------------------------------------------------------------------------------------------------------------------------------------------- |
| **`RunInPdms`** | Executes commands directly in the **PML Command-Line**. Errors are treated as **PML runtime errors**, consistent with native PML behavior.     |
| **`Run`**       | Executes commands in the **C# context**. Any PML errors are caught and thrown as **C# exceptions**, useful for handling them programmatically. |

Example of setting PML variables from C#:

```pml
!!varString = |MyName|
!!varBool   = true
!!varReal   = 5
```

This snippet demonstrates defining three PML global variables — string, boolean, and real — which can then be accessed by any PML or C# process within the same session.

---

### 🔁 Retrieving PML Variables in C#

The [`GetPMLVariablesCmd`](./GetPMLVariablesCmd.cs) command illustrates how to fetch the values of global PML variables back into your C# program.
This is done using static helper methods provided in the `Aveva.Core.Utilities.PMLNet` or equivalent utility classes.

| Method                      | Description                                         |
| --------------------------- | --------------------------------------------------- |
| **`GetPMLVariableString`**  | Retrieves a **string**-type global PML variable.    |
| **`GetPMLVariableBoolean`** | Retrieves a **boolean**-type global PML variable.   |
| **`GetPMLVariableReal`**    | Retrieves a **real (numeric)** global PML variable. |

> 💡 **Tip:** Always ensure the variable names are passed in **UPPERCASE** when retrieving them from C#.
> Example: `GetPMLVariableString("VARSTRING")` to retrieve `!!varString`.

These methods retrieve the same variables (`!!varString`, `!!varBool`, `!!varReal`) that were previously set in PML through the C# command.

---

### 🧱 Code Flow Summary

| Step | Action               | Description                                                        |
| ---- | -------------------- | -------------------------------------------------------------------|
| 1️⃣  | `SetPMLVariablesCmd` | Defines three PML global variables from C#.                         |
| 2️⃣  | `GetPMLVariablesCmd` | Reads the same variables from the PML environment.                  |
| 3️⃣  | Display Results      | MessageBox Outputs the represents variable values for verification. |

This process ensures that the communication channel between C# and PML is **fully bidirectional** and supports **real-time variable synchronization**.

---

### 🧰 Technical Concepts Highlighted

| Concept                     | Explanation                                                                           |
| --------------------------- | ------------------------------------------------------------------------------------- |
| **PML Command Execution**   | Allows C# to issue commands directly into the PML Command-Line system.                |
| **Error Propagation**       | Demonstrates how errors are raised and handled differently via `Run` vs. `RunInPdms`. |
| **Bidirectional Data Flow** | Enables passing data from C# → PML and retrieving it back PML → C#. However, small portion for the same is highlited in [PMLNet Examples](https://github.com/shivangKheradiya/PMLNet).|
| **Global Variable Access**  | Uses global PML variables (`!!varName`) for cross-context data exchange.              |

---

### ▶️ How to Test

1. Build and register the `E3DAddIn_10` project in your E3D environment.
2. Execute the **`SetPMLVariablesCmd`** command — this will define the PML global variables.
3. Execute the **`GetPMLVariablesCmd`** command — this will fetch and display the same variables in C#.
4. Observe the MessageBox or debug output showing variable values returned from PML.
5. (Optional) Modify variable values directly in PML and re-run the C# command to see the synchronization in action.

---

### 🚀 Summary

`E3DAddIn_10` establishes a **bridge between C# and PML**, empowering developers to:

* Run native PML commands from managed .NET code.
* Read or modify global PML variables dynamically.
* Extend or automate legacy PML-based systems using modern C# code.
* Enable real-time data sharing between both environments.

This example lays the foundation for **hybrid PML–C# automation frameworks** within AVEVA E3D, combining the flexibility of PML scripting with the robustness of .NET programming.

---