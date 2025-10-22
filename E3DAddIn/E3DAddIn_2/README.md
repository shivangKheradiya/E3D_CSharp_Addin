# 🔹 E3DAddIn_2

Following the previous example **E3DAddIn_1**, this project demonstrates how to extend AVEVA™ E3D functionality by integrating UI components, commands, and services using C#.

It focuses on how to:
* Access and utilize core **service managers** like `WindowManager` and `CommandManager`
* Create and register a **custom command** for E3D
* Build a **docked window** (form) using a custom `UserControl`
* Create a **button** to show or hide the docked window
* Handle **UI events** (e.g., show message box on button click)

---

## 🧰 **Project Setup Procedure**

### 1. Accessing Core AVEVA Services

Within the `Start()` method of your Add-in implementation, obtain instances of `WindowManager` and `CommandManager` using the `ServiceManager` provided by E3D:

Old Lagacy way for accessing the instance for existing service.
```csharp
CommandManager E3DCommandManager = (CommandManager)serviceManager.GetService(typeof(CommandManager));
WindowManager E3DWindowManager = (WindowManager)serviceManager.GetService(typeof(WindowManager));
```

New way for accessing the instance for existing service.
```csharp
WindowManager E3DWindowManager = (WindowManager)DependencyResolver.GetImplementationOf<IWindowManager>();
CommandManager E3DCommandManager = (CommandManager)DependencyResolver.GetImplementationOf<ICommandManager>();
```

New way for accessing the instance within `Start(IDependencyResolver resolver)` method for existing service.
```csharp
public void Start(IDependencyResolver resolver)
{
    WindowManager E3DWindowManager = (WindowManager)resolver.GetImplementationOf<IWindowManager>();
    CommandManager E3DCommandManager = (CommandManager)resolver.GetImplementationOf<ICommandManager>();
    DockingWindowCmd dwCmd = new DockingWindowCmd(E3DWindowManager);
    E3DCommandManager.Commands.Add(dwCmd);
}
```

These managers allow you to register custom commands and create UI windows programmatically.

---

### 2. Creating a Custom Command

Create a new class named **`DockingWindowCmd`** that inherits from
`Aveva.ApplicationFramework.Presentation.Command`.

This class:

* Defines a **unique key** for the command
* Overrides the **Execute()** method to perform the desired action (open or close the docked form)

After defining the class, **register** an instance of Command with the `CommandManager` in your add-in initialization (`MyAddIn.cs`):

```csharp
E3DCommandManager.Add(new DockingWindowCmd(E3DWindowManager));
```

**Related Files:**

* [`MyAddIn.cs`](./MyAddIn.cs): Registers the command with `CommandManager`
* [`DockingWindowCmd.cs`](./DockingWindowCmd.cs): Implements the command logic

---

### 3. Creating a Docked Window (`UserControl`)

Define a custom `UserControl` named **`MyDockedControl`**, containing any UI elements you wish (for example, a button that displays a message box):

```csharp
MessageBox.Show("Hi! It's working");
```

This control serves as the **main content** of your docked window.
📄 See [`MyDockedControl.cs`](./MyDockedControl.cs) for implementation details.

---

### 4. Command Logic — Connecting Command and Window

Your command (`DockingWindowCmd`) will:

* Use the existing `WindowManager` instance to **create or retrieve** a `DockedWindow`
* Manage its **visibility** by toggling open/close inside the `Execute()` method
* Maintain the **checked state** of the associated UI button based on the window’s visibility

Commands can be bound to UI buttons through the `.uic` file (e.g., [`MyE3DUic.uic`](./E3DInstallationDir/MyE3DUIC/MyE3DUic.uic)).

**Note:**
Always call `base.Execute();` within your overridden `Execute()` method — it ensures that E3D’s internal command lifecycle runs correctly.

---

### 5. Registering the Add-in

Update the `DesignAddins.xml` file located in your AVEVA installation directory to register this new Add-in:

```xml
<string>C:\cae_prog\AVEVA\v2.x\e3d\E3DAddIns\E3DAddIn_2</string>
```

Please note that the file full path is without .dll extension.

---

### 6. Registering the UI Customization

To make your button and UI elements visible in E3D, register your `.uic` file e.g. for our example `DesignCustomization.xml`:

```xml
<CustomizationFile Name="MyE3DAddIn" Path="C:\cae_prog\AVEVA\v2.x\e3d\MyE3DUIC\MyE3DUic.uic" />
```

You can also create or edit `.uic` files using the **Customize** button available within the AVEVA E3D application.

---

### 7. Running the Add-in

Once setup is complete:

* Launch **AVEVA™ E3D**
* A **new toolbar button** (linked to your command) will appear
* Clicking it will **toggle** the docked window containing your custom `UserControl`
* Inside the window, clicking the button should show:
  *“Hi! It’s working”*

---

## 🧩 **Summary**

| Component          | Description                                                    |
| ------------------ | ---------------------------------------------------------------|
| `CommandManager`   | Registers and executes custom commands                         |
| `WindowManager`    | Creates and manages docked or floating and other windows Type  |
| `DockingWindowCmd` | Defines toggleable command logic                               |
| `MyDockedControl`  | Custom `UserControl` loaded inside the docked window           |
| `.uic` File        | Maps commands to UI elements like buttons                      |

---

## 💡 **Tips & Best Practices**

* Always assign **unique keys** to commands (`Key` property).
* Use `base.Execute()` to maintain command lifecycle integrity.
* Store add-in binaries in a dedicated folder (e.g., `E3DAddIns`) for clarity.
* Keep UI resource paths consistent with AVEVA environment variables (`CAF_ADDINS_PATH`, `CAF_UIC_PATH`).

---