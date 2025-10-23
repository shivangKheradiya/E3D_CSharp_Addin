# 🔹 E3DAddIn_8

This example demonstrates how to **utilize and extend existing AVEVA UserControls**, particularly focusing on the `NetGridControl` available within AVEVA’s `GridControl.dll`.

The purpose of this example is to showcase how developers can **integrate AVEVA-native UI controls** directly into their own C# WinForms-based add-ins, while also adding **custom behaviors and interactions**.

---

### 🧩 Overview

The command class [`GridCmd`](./GridCmd.cs) serves as the entry point for launching a custom grid interface.

Within this example, a new `UserControl` named [`NetGridAddinControl`](./NetGridAddinControl.cs) is implemented, which extends the base functionality of `NetGridControl`.

This control is embedded inside a WinForms `Panel` (`panel1`) and dynamically populated with E3D element data through a **custom data-binding mechanism**.

---

### ⚙️ Implementation Workflow

The integration logic follows these core steps:

```csharp
// Define the Grid Control and add into UI
this.netGridControl = new NetGridControl();
this.panel1.Controls.Add(this.netGridControl);

// Define Table name, Columns Heading and Expressions
tableName = "Member Info";
atts = new Hashtable();
atts[1.0] = "Name";
atts[2.0] = "Type";
atts[3.0] = "Owner";

headings = new Hashtable();
headings[1.0] = "Name of Item";
headings[2.0] = "Type of Item";
headings[3.0] = "Owner of Item";

// Create the NetDataSource instance
NetDataSource ds = new NetDataSource(tableName, atts, headings, items);

// Bind NetDataSource with the Grid Control
this.netGridControl.BindToDataSource(ds);
```

---

### 🧱 Component Structure

| Component                 | Description                                                                                                                                                                           |
| ------------------------- | ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| **`GridCmd`**             | The command class responsible for initializing and displaying the grid UI (`NetGridAddinControl`).                                                                                    |
| **`NetGridAddinControl`** | A custom UserControl derived from AVEVA’s grid component (`NetGridControl`), wrapped within a `Panel`.                                                                                |
| **`NetGridControl`**      | A built-in AVEVA UI component from `GridControl.dll`, used to display tabular data bound to a `NetDataSource`.                                                                        |
| **`NetDataSource`**       | Acts as a bridge between the grid UI and the backend data — defines table name, columns, headers, and row content.                                                                    |
| **`CE_Mem` Button**       | A custom button added above the grid, which, when clicked, fetches all members under the current element (`!!CE`) and displays them with attributes like `Name`, `Type`, and `Owner`. |

---

### 🧠 Key Concepts

| Concept                      | Explanation                                                                                                                |
| ---------------------------- | -------------------------------------------------------------------------------------------------------------------------- |
| **Dynamic Data Binding**     | Uses `NetDataSource` to define custom tables, columns, and attribute expressions at runtime.                               |
| **Embedding AVEVA Controls** | Demonstrates how AVEVA’s built-in UI components (e.g., `NetGridControl`) can be reused and extended within custom add-ins. |
| **Panel Integration**        | The grid is hosted inside a `System.Windows.Forms.Panel`, allowing flexible placement and resizing.                        |
| **Button-Driven Updates**    | The “CE_Mem” button dynamically populates the grid based on the current database context.                                  |
| **Custom Extensions**        | Developers can further extend this control with additional events, formatting, filters, or editing capabilities.           |

---

### ▶️ How to Test

1. Build and register the add-in in E3D as done in previous examples.
2. Launch the E3D application.
3. Use the command or toolbar button associated with `GridCmd`.
4. A new grid interface will appear showing member data.
5. Click **“CE_Mem”** to populate the table with current element members.

You should see a grid similar to:

| Name of Item | Type of Item | Owner of Item |
| ------------ | ------------ | ------------- |
| PIPE1        | PIPE         | EQUIP1        |
| VALVE1       | VALVE        | PIPE1         |
| BRANCH1      | BRANCH       | PIPE1         |

---

### 💡 Notes & Extensions

* This example focuses on **WinForms-based integration**.
* It is also possible to embed `NetGridControl` inside a **WPF (XAML)** environment using interop techniques such as `WindowsFormsHost`.
* However, that implementation is **beyond the current example’s scope**.

---

### 🚀 Summary

`E3DAddIn_8` bridges the gap between **existing AVEVA UI components** and **custom add-in interfaces**.
By leveraging `NetGridControl` and `NetDataSource`, developers can:

* Visualize and manage E3D database data directly inside their custom panels,
* Extend existing UI components with additional behaviors,
* Rapidly prototype new interactive tools using AVEVA’s framework libraries.

This approach forms the foundation for **rich, data-driven, and interactive UI extensions** within AVEVA E3D.

---