# SeeSharp — Project Overview

- **Target:** .NET 10 (SDK required)  
- **Language:** C# 14.0  
- **Run any project from repo root:**  
  `dotnet run --project ./ProjectN/ProjectN.csproj`

## Project descriptions

### Project2 — FizzBuzz / output abstraction
- **Purpose:** Demonstrates small design patterns for testable output and delegates.  
- **Key files / types:** `Program.cs`, `FizzBuzz`, `IFizzBuzz`, `ConsoleFizzOutput`, `FizzBuzzOutput` delegate.  
- **Behavior:** Contains an object-oriented `FizzBuzz` that accepts an `IFizzBuzz` output implementer and a static `Run(int, int)` that accepts a delegate (an `Action<string>` such as `Console.WriteLine` can be passed).  
- **Usage:** Runs the FizzBuzz sequence and writes results to the provided output; useful as a teaching example for dependency inversion and delegates.

### Project3 — Multiplication table
- **Purpose:** Console program that prompts for rows and columns and prints a formatted multiplication table.  
- **Key file:** `Program.cs`  
- **Behavior:** Validates integer input for rows/columns, prints a header row and a formatted table with aligned columns using composite formatting.  
- **Usage:** Run and follow prompts; demonstrates simple user input handling and console layout.

### Project4 — Reverse string
- **Purpose:** Tiny utility that reads a line from the console and prints the reversed string.  
- **Key file:** `Program.cs`  
- **Behavior:** Reads `Console.ReadLine()`, reverses by iterating characters in reverse, and prints the result.  
- **Notes:** Demonstrates basic string handling; for larger inputs consider `Span<char>` or `Array.Reverse` for better performance.

### Project5 — Simple contact manager (in-memory)
- **Purpose:** Interactive CLI demonstrating dictionary usage for add/view/update/delete/list operations.  
- **Key file:** `Program.cs` (namespace `Project5`)  
- **Behavior:** Presents a menu (Add, View, Update, Delete, List, Exit). Uses a `Dictionary<string, string>` (`DataBase`) to store contacts.  
- **Edge cases:** `DataBase.Add(key, value)` will throw if `key` already exists; current code does not guard against duplicates when adding. `TryGetValue` and `ContainsKey` are used for safe reads/removals.  
- **Usage:** Run and follow the menu. Good example for control flow, input validation, and basic in-memory CRUD.

### Project6 — Shopping cart demo
- **Purpose:** Demonstrates simple domain modeling with `Cart` and `CartItem`, plus collection handling.  
- **Key file:** `Program.cs` (contains `CartItem`, `Cart`, and demo `Program`)  
- **Behavior:** `Cart` maintains a `Dictionary<string, double>` of items (case-insensitive keys) and an internal `CartItem[]` array for iteration. Supports `AddItem(string, double)`, `RemoveItem(string)`, `GetTotal()`, and `ToString()`.  
- **Notes:**
  - `AddItem` appends to the internal array by allocating a new array per add (simple but not optimal for large lists).  
  - `RemoveItem` rebuilds the array excluding removed items.  
  - `Items` is exposed as `IReadOnlyDictionary<string, double>` and `ItemsArray` as `CartItem[]`.  
- **Usage:** Run to see add/list/total/remove demonstration. Consider switching to `List<CartItem>` or exposing a read-only `IEnumerable<CartItem>` for better performance and maintainability.
