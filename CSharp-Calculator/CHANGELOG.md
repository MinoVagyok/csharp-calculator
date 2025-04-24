## [v1.1.1] - 2025-04-24

### ✨ Changed
- 🧠 Reworked `ExpressionEvaluator` to use `Token`-based logic.
- ➕ Introduced `switch`-based operation handling (`+`, `-`, `*`, `/`).
- 🌐 Numbers are now parsed using `float.TryParse` with `InvariantCulture`.
- 🐞 Token debug print added for development clarity.
- ✅ Token sequence validation enhanced:
    - Even indexes must be numbers
    - Odd indexes must be operators
    - Last token must be a number

### 🐛 Fixed
- 🚫 Prevented malformed decimal numbers like `3.5.5`
- 🚫 Rejected multiple consecutive operators (e.g. `3+++2`)
- 🚫 Disallowed expressions ending in operators (e.g. `5+`)
- 🔐 Division by zero is now properly handled and blocked
