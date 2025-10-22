# 🔹 E3DAddIn_6

This example demonstrates the **implementation and interaction of UI elements** such as **TextBox** and **ComboBox** implimentation in ribbon within **AVEVA E3D** using the Add-In framework.

In AVEVA E3D, when implementing UI elements, each control (like TextBox or ComboBox) must be **bound to a unique command key**.
This key acts as a communication link between the UI definition and its corresponding command class logic — enabling seamless data exchange and behavior control.

---

### 🧩 Command Architecture Overview

In this example:

* The main command class is [`OperationCmd`](./OperationCmd.cs).
* It utilizes two other supporting command classes:

  * [`TextBoxCmd`](./TextBoxCmd.cs)
  * [`ComboBoxCmd`](./ComboBoxCmd.cs)

The `OperationCmd` class defines **two overloaded Execute methods**:

| Method Type           | Description                                                                |
| --------------------- | -------------------------------------------------------------------------- |
| **Without Arguments** | Displays the current values from the TextBox and ComboBox in a MessageBox. |
| **With Arguments**    | Displays the same values along with the passed argument in the MessageBox. |

---

### ⚙️ Pre/Post-Processing Logic

If preprocessing or postprocessing is required before executing these commands, the logic can be written in the [`OperationOnArgs`](./OperationOnArgs.cs) class.
The method responsible for registering such pre-processing actions is `performOperations()`.

Internally, the **Command Manager** instance retrieves the command class using the key:

```
E3DAddIn_6.OperationCmd
```

A **`BeforeCommandExecute`** delegate is used to inject custom logic prior to execution.
In this example, it checks the TextBox value (using command key `E3DAddIn_6.TextBoxCmd`).
If the TextBox is empty, the command is aborted, and the following message is shown in the command line:

```
Text Box is Empty. Operation Aborted.
```

---

### 🧩 UIC Configuration Overview

The [UIC file](./E3DInstallationDir/MyE3DUIC/MyE3DUic.uic) is customized to include the following structure:

| Component Type | Identifier                           | Description                                                                                                 |
| -------------- | ------------------------------------ | ----------------------------------------------------------------------------------------------------------- |
| **Tab**        | `MyE3DAddIn.Tab0`                    | Main tab for custom UI elements.                                                                            |
| **Group**      | `MyE3DAddIn.MyE3DAddinGroup1`        | Container for related tools and controls.                                                                   |
| **Tool**       | `MyE3DAddIn.MyTextBox`               | TextBox control (linked with its C# command key).                                                           |
| **Tool**       | `MyE3DAddIn.MyComboBox`              | ComboBox control (linked with its C# command key) — includes values `Value0`, `Value1`, `Value2`, `Value3`. |
| **Tool**       | `MyE3DAddIn.OperationButton`         | Executes the operation command **without arguments**.                                                       |
| **Tool**       | `MyE3DAddIn.OperationButtonWithArgs` | Executes the operation command **with “MyArgs”** as argument.                                               |

This UIC Customization can be carried out using the **Customize button** available in ribbon.

---

### ▶️ How to Test

1. Enter some text into the **TextBox**.
2. Select any value from the **ComboBox**.
3. Click on either:

   * **Operation Button** (no argument)
   * **Operation Button with Args** (`MyArgs`)
4. Observe the output — it will appear in either the **MessageBox** or the **Command Line**, depending on the implementation.

---

### 💡 Summary

This example highlights the **integration of interactive UI controls with backend command logic** in AVEVA E3D.
It provides a foundation for creating **dynamic, data-driven interfaces** — where user input and command execution can be tightly coupled, opening the door to highly customizable automation and user experiences.
