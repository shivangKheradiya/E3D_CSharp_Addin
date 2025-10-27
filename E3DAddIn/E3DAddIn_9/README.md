# 🔹 E3DAddIn_9

This example focuses on **element collection and filtering mechanisms** within AVEVA E3D.

In AVEVA’s API, **collections** allow you to gather `DbElements` dynamically based on specific conditions such as element type, attribute states, or ownership hierarchy.

This example demonstrates several **filter types** and their combinations to perform efficient, object-oriented database queries in E3D.

---

### 🧩 Overview

The main logic for this example is implemented in [`FilterElementsCmd`](./FilterElementsCmd.cs), a class derived from `Command`.
It showcases the use of multiple filters from the `Aveva.Core.Database.Filters` namespace and demonstrates how to apply them to collect relevant elements.

---

### ⚙️ Filter Types Demonstrated

| Filter Type                | Description                                                                                              |
| -------------------------- | -------------------------------------------------------------------------------------------------------- |
| **`TypeFilter`**           | Collects elements based on their **element type**, such as `PIPE`, `BRANCH`, or `EQUI`.                  |
| **`AttributeUnsetFilter`** | Filters elements where a specific attribute is **unset** or undefined.                                   |
| **`AttributeRefFilter`**   | Filters elements where a **reference-type attribute** (e.g., `OWNER`, `HREF`, `CREF`) matches a specified value. |
| **`AndFilter`**            | Combines two or more filters with a logical **AND** condition — both filters must be satisfied.          |

In addition, other logical filters such as **`OrFilter`** are available, allowing complex combinations of filter logic (AND/OR chaining).

All filters inherit from the **`BaseFilter`** class, enabling flexible and reusable filter definitions through **object-oriented programming** principles.

---

### 🧱 Implementation Details

In this example, the **`DBElementCollection`** class from `Aveva.Core.Database.Filters` plays a key role.
It provides multiple overloaded constructors to collect elements using various filter combinations.
The resulting collection contains all `DbElements` that match the defined criteria.

Here’s a simplified view of how such a collection is built:

```csharp
// Example: Collect all PIPE elements under zone element ( /ZONE-PIPING-AREA01 )
BaseFilter typeFilter = new TypeFilter(DbType.GetDbType("PIPE"));
DbElementCollection collection = new DbElementCollection(DbElement.GetElement("/ZONE-PIPING-AREA01"), typeFilter);

foreach (DbElement element in collection)
{
    MessageBox.Show($"Collected Element: {element.GetAsString(DbAttributeInstance.NAME)}");
}
```

---

### 🧠 Example Methods Explained

Each method in this example demonstrates a different filtering scenario:

| Method                                | Description                                                                                                     |
| ------------------------------------- | --------------------------------------------------------------------------------------------------------------- |
| **`CollectTypeForCE()`**              | Collects all `PIPE`-type elements within the members of the current element (`!!CE`).                           |
| **`CollectTypeWithUnsetDescForCE()`** | Collects all elements under the current element where the attribute `DESC` is **unset**.                        |
| **`CollectTypeHasOwner()`**           | Collects all elements across the project (`/*/`) whose `Owner` attribute is `/ZONE-PIPING-AREA01`.              |
| **`CollectTypeAndUnsetDescForCE()`**  | Combines two conditions — collects all elements that are of type `PIPE` **and** have an unset `DESC` attribute. |

Each collection result is displayed via a **MessageBox** summarizing the found elements, and you can observe the filtering behavior by navigating to different hierarchical elements in E3D.

---

### 🧰 Technical Concepts Highlighted

| Concept                    | Explanation                                                                                                    |
| -------------------------- | -------------------------------------------------------------------------------------------------------------- |
| **Filter Composition**     | Multiple filters can be combined using logical operations (`AndFilter`, `OrFilter`) to create complex queries. |
| **Object-Oriented Design** | All filters inherit from `BaseFilter`, ensuring polymorphic handling across APIs.                              |
| **Dynamic Querying**       | The same command can be reused with different filters to retrieve different data sets dynamically.             |
| **E3D Integration**        | Demonstrates how AVEVA’s internal collection mechanisms can be controlled programmatically.                    |

---

### ▶️ How to Test

1. Build and register the `E3DAddIn_9` project in your E3D environment.
2. Launch AVEVA E3D to run the command associated with `FilterElementsCmd` using a button defined in UI.
3. Observe the message boxes showing the collected elements for each method.
4. Navigate to different hierarchy levels (e.g., SITE, ZONE, EQUIPMENT) and re-run the command to see the dynamic change in collected elements.
5. Optionally, attach a debugger to inspect runtime filter behavior.

---

### 🚀 Summary

`E3DAddIn_9` introduces the **powerful filtering framework** within the AVEVA E3D database layer.

By leveraging `TypeFilter`, `AttributeUnsetFilter`, `AttributeRefFilter`, `AndFilter` and Other Filters, developers can:

* Dynamically collect and manipulate element sets.
* Combine logical conditions for precise data extraction.
* Implement custom automation, validation, and reporting tools that respond to live E3D database changes.

This example serves as a **foundation for data-driven automation** within E3D, enabling smart engineering utilities built on top of the AVEVA API.

---