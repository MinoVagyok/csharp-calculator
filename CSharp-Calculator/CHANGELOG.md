# 📦 Changelog

## [v1.0.0] - 2025-04-15

### ✨ Added
- Basic calculator functionality with operations: Sum, Subtract, Multiply, Divide
- Modular structure: separated logic into `ActionOperations.cs` and `FuncOperations.cs`
- Command-line menu loop with user interaction
- Input validation with `try-catch` to handle invalid numeric input
- Exit option and clean loop handling with `flag` + `ref` pattern

### 🛠️ Structure
- Uses dictionaries (`Dictionary<int, Action>`) to avoid switch-case clutter
- LINQ `.Sum()` used for future extensions (e.g. multi-input operations)