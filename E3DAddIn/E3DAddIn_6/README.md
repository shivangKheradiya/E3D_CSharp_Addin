# 🔹 E3DAddIn_6

This example demostrates the implimentation usecase for the UI Elements such as Textbox and Combobox the E3D.

Ususally When we impliment any UI Elements, It must be binded with the Key. The same key is used into the command class and consumed in the other part where the behaviours are utilized.

Within this example, the command [`OperationCmd`](./OperationCmd.cs) is created using [`TextBoxCmd`](./TextBoxCmd.cs) and [`ComboBoxCmd`](./ComboBoxCmd.cs). `OperationCmd` has 2 execute methods,
1. Without Arguments : It will display values in messegebox for the values setup in the `TextBox` and `ComboBox` respectively. 
2. With Arguments : It will display values in messegebox for the values setup in the `TextBox` and `ComboBox` respectively with whatever argument is passed.

If there is a requirement for preprocessing or post processing some data before executing these commands then such implimentation is written into [`OperationOnArgs`](./OperationOnArgs.cs) class.
The method used for registering the preprocessing events are written `performOperations()` voice method.

Command Manager instance is used to retrive the command class instance using the key `E3DAddIn_6.OperationCmd`. and `BeforeCommandExecute` deligate is extended to run the custom logic. This Custom logic is Checking the TextBox Value using command key `E3DAddIn_6.TextBoxCmd`. If TextBox Value empty then `Text Box is Empty. Operation Aborted.` messege going to be printed in the commandline.

The [UIC file](./E3DInstallationDir/MyE3DUIC/MyE3DUic.uic) is customized in such a way that It contains,

1. Tab: `MyE3DAddIn.Tab0`
2. Group: `MyE3DAddIn.MyE3DAddinGroup1`
3. Tools:
    - `MyE3DAddIn.MyTextBox` : with the same Command Key as c#. 
    - `MyE3DAddIn.MyComboBox` :  with the same Command Key as c#. Value0, Value1 Value2 Value3 as list of values
    - `MyE3DAddIn.OperationButton` : Without any argument
    - `MyE3DAddIn.OperationButtonWithArgs` : With `MyArgs` as argument.

Write something in the TextBox and select some value in ComboBox. after that just click on the button and obsurve the output either in commandline or messegebox.

Here’s a refined and professional version of your **E3DAddIn_6** writeup, rewritten for clarity, readability, and technical precision — consistent with your previous sections’ tone and style:

---

## 🔹 E3DAddIn_6

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

---

Would you like me to include a **small visual schematic** (like a table or flow diagram) showing how `UIC → Command Key → Command Class → Preprocessing → Output` flow works? It can make the concept instantly clear to readers in documentation.
