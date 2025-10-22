# 🔹 E3DAddIn_5

This example demonstrates how to **customize and integrate user-defined events** within **AVEVA E3D**, showcasing the event-driven extensibility of the platform.

The core class in this example is the **`DbEvent`** class, which enables developers to add event handlers based on specific requirements. This example primarily focuses on **database-related events**, illustrating how to listen for and respond to data changes in real time.

The event integration syntax can be found in [`MyAddIn.cs`](./MyAddIn.cs), within the `Start` method.

### Example Highlights

In this example, two key events are implemented:

1. **Current Element Changed** — Displays the name of the element whenever the `!!CE` (Current Element) changes.

   * Implemented using the `CurrentElement` class.
2. **New Element Added** — Displays a message box listing all newly created elements.

   * Implemented using the `DbEvent` class.

### Adding Database Events

Most event registration methods in `DbEvent` begin with the prefix **“Add”**, making them easy to identify and use.
Below is a list of available event functions and their descriptions:

| Event Function / Delegate       | Description                                                                                                                                                                                                         |
| ------------------------------- | ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| `AddDBFileChangingEventHandler` | Adds a pre-event delegate to capture changes made to the database file. Triggered during operations like *Savework*, *Flush*, *Refresh*, or *Drop*.                                                                 |
| `AddDBFileChangedEventHandler`  | Adds a post-event delegate for database file changes after *Savework*, *Flush*, *Refresh*, or *Drop* operations.                                                                                                    |
| `AddDBFileChangesAllowed`       | Adds a delegate to check whether a specific database operation is permitted.                                                                                                                                        |
| `AddFailedEventHandler`         | Captures failures that occur during *Savework* operations.                                                                                                                                                          |
| `AddClearCacheEventHandler`     | Adds a delegate to clear cached data after operations such as *Getwork*, *Undo*, *Redo*, or *Quit*. ⚠️ Note: This may be called thousands of times during a single operation, so handlers must be highly optimized. |
| `AddLocalChangingEventHandler`  | Adds a pre-event delegate for changes in the user's local view during *Getwork*, *Undo*, *Redo*, or *Quit*.                                                                                                         |
| `AddLocalChangedEventHandler`   | Adds a post-event delegate for local changes after *Getwork*, *Undo*, *Redo*, or *Quit*.                                                                                                                            |
| `AddCommitPendingEventHandler`  | Ensures any pending database changes are committed before *Savework*, *Setmark*, *Undo*, *Redo*, *Quit*, or *Getwork*.                                                                                              |
| `AddReleasedEventHandler`       | Adds a delegate to capture *release (unclaim)* actions.                                                                                                                                                             |
| `AddClaimedEventHandler`        | Adds a delegate to capture *claim* actions.                                                                                                                                                                         |
| `AddMdbClosingEventHandler`     | Adds a subscriber for pre-MDB close events.                                                                                                                                                                         |
| `AddMdbOpenedEventHandler`      | Adds a subscriber for post-MDB open events.                                                                                                                                                                         |
| `AddUdaRebuildHandler`          | Checks for invalid *UDA/UDET* objects after internal rebuild operations.                                                                                                                                            |
| `AddPostHandleUserChanges`      | Adds a delegate for post-user changes after all updates are processed.                                                                                                                                              |
| `AddHandleUserChanges`          | Captures all database changes made by the user. For performance, this event triggers only after user interaction ends (e.g., after running a PML macro or pressing **Apply**).                                      |

---

### 🧩 Summary

This example forms the **core foundation of AVEVA’s Event-Driven System**.
By leveraging these events, developers can create **custom behaviors**, **automate workflows**, and **implement company-specific business logic**, making AVEVA E3D far more adaptable to unique project requirements.