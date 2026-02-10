# C# Programming

**TAFE NSW Cert IV Programming | 22nd Survey Division**

## Structure

| Folder | Week | Concepts |
|--------|------|----------|
| `week3-rations` | 3 | Methods, Parameters, Return Types, switch, while Loops |

## Progress — Week 3 Rations Manager

- [x] Pattern 1: Store stuff — parallel arrays (rations + calories)
- [x] Pattern 2: Loop through stuff — `DisplayAll()` void method
- [x] Pattern 3: Decide on stuff — `FindRation()` search with return int / -1
- [x] Pattern 4: Wrap in methods — `GetTotalCalories()`, `IsHighCalorie()`
- [x] Pattern 5: Keep running — `while (running)` + `switch` menu

## Methods Reference

| Method | Return | Purpose |
|--------|--------|---------|
| `DisplayAll(string[], int[])` | void | Prints all rations with index and calories |
| `ShowMenu()` | void | Prints the menu options |
| `FindRation(string[], string)` | int | Search by name, returns index or -1 |
| `GetTotalCalories(int[])` | int | Accumulator — sums all calories |
| `IsHighCalorie(int, int)` | bool | Returns true if calories >= threshold |

## The 5 Patterns

| # | Pattern | Code Shape | When |
|---|---------|-----------|------|
| 1 | Store stuff | `string[] gear = { ... };` | Data exists |
| 2 | Loop through stuff | `for (int i = 0; ...)` | Process each item |
| 3 | Decide on stuff | `if / switch` | Choose what to do |
| 4 | Wrap in methods | `static int Find(...)` | Reuse code |
| 5 | Keep running | `while (running) + menu` | Interactive app |

## Lessons Learned

- Methods go **above Main**, as siblings inside the class — never nested
- Calling code goes **inside Main** — never loose in the class
- `return -1` = universal "not found" convention
- `total += c` = accumulator pattern (start at 0, add each, return sum)
- `switch` cases need `break;` or execution falls through
- `case "0": running = false;` kills the while loop
- `else` with one line doesn't need curly braces
- Watch your curly braces — cases must be siblings, not nested inside if/else blocks

---

Vidimus Omnia.
