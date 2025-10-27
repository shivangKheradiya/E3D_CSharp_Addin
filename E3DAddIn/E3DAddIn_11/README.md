# 🔹 E3DAddIn_11

This example demonstrates the **use cases and functionalities of different database tables** available in the `Aveva.Core.Database.dll`.
These tables are extremely powerful and allow developers to **find, search, and filter elements** based on their **attributes, names, references, or numeric identifiers** within the active MDB (Model Database).

By leveraging these built-in table structures, developers can efficiently perform element lookups without manually traversing the entire hierarchy.

---

### 🧩 Overview

The `Aveva.Core.Database.dll` provides several specialized table types to locate database elements based on different attribute criteria.
Each table serves a unique purpose and can be used independently or in combination depending on the data search requirement.

| Table Type       | Purpose                                                                                    |
| ---------------- | ------------------------------------------------------------------------------------------ |
| **RefTable**     | Finds elements referencing a specific **reference element** on a reference-type attribute. |
| **NameTable**    | Finds elements using a specific **string value** defined on an attribute.                  |
| **IntTable**     | Finds elements using a specific **integer value** defined on an attribute.                 |
| **MdbNameTable** | Uses the **MDB’s name table** to collect elements by their attributes.                     |

These tables collectively provide the foundation for efficient **element retrieval** operations in AVEVA E3D databases.

---

### ⚙️ Commands Implemented

The project includes **three main command classes**, each demonstrating a different type of table usage and query mechanism.

---

#### 🔸 [`GetDesGeoCmd`](./GetDesGeoCmd.cs)

This command demonstrates **element lookup** using methods from the `CATA` database via the **RefTable** interface.

| Operation      | Description                                                                                        |
| -------------- | -------------------------------------------------------------------------------------------------- |
| `FindElement`  | Finds a single element named `/ABTA330EE` of type `scom` within the current MDB.                   |
| `FindElements` | Finds all `spco` elements having a **catref** value of `/ABTA330EE` within the current MDB.        |
| Result Output  | All collected design elements with matching references are printed in the **Command-Line Output**. |

> 🧠 Note: Multiple overloaded versions of the `FindElement` and `FindElements` methods exist, providing flexibility for different search criteria.

---

#### 🔸 [`GetUdaDataCmd`](./GetUdaDataCmd.cs)

This command showcases the use of the **NameTable** for performing searches based on **User-Defined Attributes (UDA)**.

| Operation         | Description                                                                                     |
| ----------------- | ----------------------------------------------------------------------------------------------- |
| `GetMdbNameTable` | Fetches all elements where the `:myuda` attribute equals `'s'` within the current MDB.          |
| Target Database   | Searches specifically within the **DESI (Design)** database type.                               |
| Result Output     | Prints the names of all matching elements and their `:myuda` values in the command-line window. |

This demonstrates how UDAs can be queried efficiently using name-based searches.

---

#### 🔸 [`GetTeeDataFromRefTableCmd`](./GetTeeDataFromRefTableCmd.cs)

This command demonstrates the **RefTable** use case by traversing through multiple databases.

| Operation           | Description                                                                               |
| ------------------- | ----------------------------------------------------------------------------------------- |
| Database Iteration  | Iterates through all databases defined in the current MDB.                                |
| Reference Filtering | Collects all elements having a **SPRE** (reference) attribute using `GetRefTable`.        |
| Result Filtering    | From the collected set, filters and prints only elements where the element type is `TEE`. |

This approach highlights how **RefTables** can be used to perform cross-database element lookups based on reference relationships.

---

### 🔍 Available Table Types Summary

| Table Class      | Description                                     | Example Use Case                                                                            |
| ---------------- | ----------------------------------------------- | ------------------------------------------------------------------------------------------- |
| **RefTable**     | Searches based on **reference-type attributes** | Find all components referring to a specific element (e.g., all `SPCO` with a given `SPRE`). |
| **NameTable**    | Searches using **string values** in attributes  | Retrieve all elements having a particular user-defined attribute text.                      |
| **IntTable**     | Searches using **integer values**               | Identify elements by numeric attributes (e.g., size, ID).                                   |
| **MdbNameTable** | Uses MDB-level name table for lookups           | Collect all elements within the MDB based on attribute names or patterns.                   |

---

### ▶️ How to Test

1. Build and register the `E3DAddIn_11` project in your AVEVA E3D environment.
2. Open the desired MDB and navigate to the Command-Line window.
3. Run the following commands sequentially to observe the results:

   * `GetDesGeoCmd` → Finds design elements based on reference and name.
   * `GetUdaDataCmd` → Retrieves elements based on user-defined attributes.
   * `GetTeeDataFromRefTableCmd` → Collects referenced `TEE` elements across all DBs.
4. Observe the printed results in the command-line output for each test.

---

### 🧠 Technical Concepts Highlighted

| Concept                      | Description                                                                      |
| ---------------------------- | -------------------------------------------------------------------------------- |
| **Database Tables**          | Demonstrates structured data search mechanisms within `Aveva.Core.Database.dll`. |
| **Reference Resolution**     | Shows how elements can be linked through reference-type attributes.              |
| **Attribute-Based Querying** | Provides examples of searching using string, integer, and reference attributes.  |
| **Cross-Database Search**    | Demonstrates how to iterate across multiple databases in the MDB context.        |

---

### 🚀 Summary

`E3DAddIn_11` provides a **practical overview of element lookup techniques** using the built-in AVEVA E3D database table classes.
Through these examples, developers can:

* Search for elements based on **attributes, names, references, or integer values**.
* Integrate **efficient querying logic** without manual iteration.
* Leverage **RefTable**, **NameTable**, **IntTable**, and **MdbNameTable** for flexible element discovery.
* Extend the examples to build **custom database search utilities** or **smart filtering tools** in E3D add-ins.

> 💡 *Exercises:* Try implementing similar search logic using `IntTable` and `NameTable` for additional practice and deeper understanding.
