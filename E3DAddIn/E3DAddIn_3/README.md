# 🔹 **E3DAddIn_3**

This example builds upon **E3DAddIn_2** and focuses on demonstrating the use of **MDI (Multiple Document Interface) windows** and other types of the possible Window UI in AVEVA™ E3D.

The core logic remains the same as in the previous example — the only change is the **window creation method**.
Instead of using `CreateDockedWindow()` to generate a docked panel, this example uses the `CreateMdiWindow()` method to open a child window within the E3D main workspace.

---

## 🧩 **Key Change**

| Feature                    | E3DAddIn_2             | E3DAddIn_3          |
| -------------------------- | ---------------------- | ------------------- |
| **Window Type**            | Docked Window          | MDI Child Window    |
| **Window Creation Method** | `CreateDockedWindow()` | `CreateMdiWindow()` |
| **Command Class**          | `DockingWindowCmd.cs`  | `MdiWindowCmd.cs`   |

Everything else — add-in registration, UI setup, and command binding — remains identical to **E3DAddIn_2**.

---

## 🪟 **Available Window Types in AVEVA Add-ins**

| **Window Type**      | **Creation Method**          | **Description**                                                        | **Use Case**                                          |
| -------------------- | ---------------------------- | ---------------------------------------------------------------------- | ----------------------------------------------------- |
| **Docked Window**    | `CreateDockedWindow()`       | Creates a side panel docked to the main interface (left/right/bottom). | Ideal for tools or property inspectors.               |
| **MDI Child Window** | `CreateMdiWindow()`          | Opens a resizable window inside the main E3D workspace.                | Best for independent views, editors, or data panels.  |
| **Floating Window**  | `CreateFloatingWindow()`     | Opens a separate floating form that can move freely.                   | Useful for dialogs or temporary popups.               |
| **Modal Window**     | `WindowManager.ShowDialog()` | Opens a blocking dialog requiring user interaction before continuing.  | Used for confirmations, settings, or short workflows. |

---

## ✅ **Summary**

* The **only change** from `E3DAddIn_2` is the use of `CreateMdiWindow()` in the command implementation.
* The **command registration**, **UI binding**, and **XML configurations** follow the same procedure.
* This pattern helps in building **multi-document interfaces** within E3D for advanced user interactions.

---