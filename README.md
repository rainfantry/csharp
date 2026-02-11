# C# Programming

**TAFE NSW Cert IV Programming | 22nd Survey Division**

## Structure

| Folder | Week | Concepts |
|--------|------|----------|
| `week3-rations` | 3 | Methods, Parameters, Return Types, switch, while Loops |
| `week3-switch` | 3 | switch statement with int cases |
| `week3-portscan` | 3 | Port Scan Analyzer — pentest-themed, all 5 patterns |

---

## Week 3 — Field Rations Manager

A menu-driven console app that manages a squad's field rations. Uses all 5 programming patterns from the study guide.

### Progress

- [x] Pattern 1: Store stuff — parallel arrays (rations + calories)
- [x] Pattern 2: Loop through stuff — `DisplayAll()` void method
- [x] Pattern 3: Decide on stuff — `FindRation()` search with return int / -1
- [x] Pattern 4: Wrap in methods — `GetTotalCalories()`, `IsHighCalorie()`
- [x] Pattern 5: Keep running — `while (running)` + `switch` menu

---

## Tutorial — Building It Step by Step

### Step 1: The Skeleton (Pattern 1 — Store Stuff)

Every C# console app starts the same way.

```csharp
using System;
class Program
{
    static void Main(string[] args)
    {
        string[] rations = { "Combat Biscuit", "Beef Jerky", "Energy Bar", "MRE Pasta", "Protein Shake" };
        int[] calories = { 250, 189, 350, 620, 280 };
    }
}
```

| Line | What It Does |
|------|-------------|
| `using System;` | Imports core tools like `Console`. Without this, nothing prints. |
| `class Program` | The container. Everything lives inside this class. |
| `static void Main(string[] args)` | The entry point. When you hit Run, execution starts here. |
| `string[] rations = { ... };` | An array of strings — the ration names. |
| `int[] calories = { ... };` | An array of integers — the calorie counts. |

**Parallel arrays**: `rations[0]` ("Combat Biscuit") maps to `calories[0]` (250). Same index = same item. This is how you store related data in two arrays without using objects.

---

### Step 2: Display Method (Pattern 2 — Loop + Pattern 4 — Methods)

A `void` method that prints all rations. It does a job but returns nothing.

```csharp
static void DisplayAll(string[] names, int[] calories)
{
    for (int i = 0; i < names.Length; i++)
    {
        Console.WriteLine($" [{i}] {names[i]} - {calories[i]} cal");
    }
}
```

| Line | What It Does |
|------|-------------|
| `static void` | Belongs to the class. Returns nothing. |
| `string[] names, int[] calories` | Parameters — the method receives both arrays when called. |
| `for (int i = 0; i < names.Length; i++)` | Loop from 0 to array length. `i` is the index. |
| `names.Length` | How many items in the array (5). The loop stops before reaching 5 because `<` not `<=`. |
| `$" [{i}] {names[i]} - {calories[i]} cal"` | String interpolation. The `$` lets you embed variables inside `{}`. |

**Calling it from Main:**
```csharp
DisplayAll(rations, calories);
```
`rations` gets received as `names`. `calories` gets received as `calories`. The parameter names don't have to match — the position matters.

---

### Step 3: Search Method (Pattern 3 — Decide + Pattern 4 — Methods)

A method that returns an `int` — the position where the item was found, or -1 if not found.

```csharp
static int FindRation(string[] names, string search)
{
    for (int i = 0; i < names.Length; i++)
    {
        if (names[i].ToLower() == search.ToLower())
            return i;
    }
    return -1;
}
```

| Line | What It Does |
|------|-------------|
| `static int` | Returns an integer — the index of the found item. |
| `string search` | The search term passed in by the user. |
| `.ToLower()` | Converts to lowercase so "BEEF JERKY" matches "Beef Jerky". Case-insensitive search. |
| `return i;` | Found it — immediately exit the method and send back the position. |
| `return -1;` | Loop finished without finding anything. -1 is the universal "not found" signal because array indexes start at 0, so -1 can never be a real position. |

**Calling it from Main:**
```csharp
int idx = FindRation(rations, s);
if (idx != -1)
    Console.WriteLine($"Found: {rations[idx]} - {calories[idx]} cal");
else
    Console.WriteLine("Ration not found.");
```
Always check if the result is -1 before using it as an index. Using -1 as an array index would crash the program.

---

### Step 4a: Accumulator Method (Pattern 4 — Methods)

A method that totals up all values in an array. Start at 0, add each value, return the sum.

```csharp
static int GetTotalCalories(int[] calories)
{
    int total = 0;
    foreach (int c in calories)
    {
        total += c;
    }
    return total;
}
```

| Line | What It Does |
|------|-------------|
| `int total = 0;` | The accumulator. Starts at zero. |
| `foreach (int c in calories)` | Simpler than `for` when you don't need the index. `c` takes the value of each element in order. |
| `total += c;` | Shorthand for `total = total + c`. Adds current value to the running total. |
| `return total;` | After the loop, send back the sum. |

**`for` vs `foreach`**: Use `for` when you need the index (to access parallel arrays). Use `foreach` when you just need each value.

**Calling it from Main:**
```csharp
Console.WriteLine($"Total Calories: {GetTotalCalories(calories)} Cal");
```
You can call a method directly inside string interpolation. It runs, returns the value, and that value gets printed.

---

### Step 4b: Bool Method (Pattern 4 — Methods)

A method that returns `true` or `false`. The simplest type of method.

```csharp
static bool IsHighCalorie(int calories, int threshold)
{
    return calories >= threshold;
}
```

| Line | What It Does |
|------|-------------|
| `static bool` | Returns true or false, nothing else. |
| `int calories, int threshold` | Two parameters — the value to check and the limit to check against. |
| `return calories >= threshold;` | The expression `calories >= threshold` already IS a bool. If 620 >= 400, it evaluates to `true`. No if statement needed. |

**Calling it from Main:**
```csharp
if (IsHighCalorie(calories[pos], 400))
    Console.WriteLine($"{rations[pos]} is high calorie.");
```
The method returns true/false, which goes directly into the `if` condition.

---

### Step 5: Menu + While Loop + Switch (Pattern 5 — Keep Running)

The `ShowMenu` method just prints options. Another `void` method.

```csharp
static void ShowMenu()
{
    Console.WriteLine("\n=== FIELD RATIONS MANAGER ===");
    Console.WriteLine("[1] Display All Rations");
    Console.WriteLine("[2] Search for a Ration");
    Console.WriteLine("[3] Total Calories");
    Console.WriteLine("[4] Check if High Calorie");
    Console.WriteLine("[0] Exit");
    Console.Write("Select: ");
}
```

`\n` at the start adds a blank line above the menu for readability. `Console.Write` (not `WriteLine`) keeps the cursor on the same line as "Select: ".

**The while loop + switch in Main:**

```csharp
bool running = true;
while (running)
{
    ShowMenu();
    string choice = Console.ReadLine();

    switch (choice)
    {
        case "1":
            DisplayAll(rations, calories);
            break;
        case "2":
            // ... search logic
            break;
        case "3":
            // ... total logic
            break;
        case "4":
            // ... high calorie logic
            break;
        case "0":
            running = false;
            Console.WriteLine("Exiting...");
            break;
        default:
            Console.WriteLine("Invalid choice.");
            break;
    }
}
```

| Line | What It Does |
|------|-------------|
| `bool running = true;` | The kill switch. Starts ON. |
| `while (running)` | Keep looping as long as `running` is true. |
| `ShowMenu();` | Prints the menu every loop iteration. |
| `Console.ReadLine();` | Waits for user input. |
| `switch (choice)` | Checks `choice` against each case. Cleaner than chaining if/else. |
| `case "1":` | If choice equals "1", run this block. |
| `break;` | Exits the switch. Without it, execution falls through to the next case. |
| `case "0": running = false;` | Flips the kill switch. The while loop checks the condition again and stops. |
| `default:` | Catches anything that didn't match a case. Like `else` in if/else. |

---

## Program Structure — Where Everything Goes

```
class Program
{
    DisplayAll()        ← method (sibling)
    ShowMenu()          ← method (sibling)
    FindRation()        ← method (sibling)
    GetTotalCalories()  ← method (sibling)
    IsHighCalorie()     ← method (sibling)

    Main()              ← method (sibling) — calls the others
    {
        arrays          ← data lives here
        while loop      ← calling code lives here
        {
            switch      ← calls methods from here
        }
    }
}
```

**Rules:**
- All methods are **siblings** inside the class — never nested inside each other
- **Method definitions** (the code that says what a method does) go above Main
- **Method calls** (the code that runs a method) go inside Main
- Never put calling code loose in the class between methods

---

## Methods Reference

| Method | Return | Parameters | Purpose |
|--------|--------|------------|---------|
| `DisplayAll` | void | `string[] names, int[] calories` | Prints all rations with index |
| `ShowMenu` | void | none | Prints the menu options |
| `FindRation` | int | `string[] names, string search` | Search by name, returns index or -1 |
| `GetTotalCalories` | int | `int[] calories` | Accumulator — sums all calories |
| `IsHighCalorie` | bool | `int calories, int threshold` | Returns true if calories >= threshold |

---

## Common Mistakes

| Mistake | Why It Breaks | Fix |
|---------|--------------|-----|
| Putting calling code between methods | Code can't execute outside a method body | Move it inside Main |
| Nesting a method inside Main | C# doesn't allow methods inside methods | Move it outside Main, inside the class |
| Missing `break;` in switch case | Execution falls through to the next case | Always end each case with `break;` |
| Putting `case` inside an `if/else` block | Cases must be direct children of `switch` | Close the if/else first, then add the case |
| Using -1 as an array index | Arrays start at 0, -1 crashes the program | Always check `if (idx != -1)` first |
| Missing `$` before string with `{}` | Without `$`, curly braces print literally | `$"text {variable}"` not `"text {variable}"` |
| Missing semicolon `;` | Every statement needs one | Check line endings |
| `IsHighCalorie` returning true but printing "normal" | Logic is backwards | Match the message to the condition |

---

## Week 3 — Switch with Integers (`week3-switch`)

A basic switch statement using `int` instead of `string`. Maps a day number to a day name.

```csharp
int day = 4;
switch (day)
{
    case 1:
        Console.WriteLine("Monday");
        break;
    case 2:
        Console.WriteLine("Tuesday");
        break;
    case 3:
        Console.WriteLine("Wednesday");
        break;
    case 4:
        Console.WriteLine("HURRDURR");
        break;
    case 5:
        Console.WriteLine("Friday");
        break;
    case 6:
        Console.WriteLine("Saturday");
        break;
    case 7:
        Console.WriteLine("Sunday");
        break;
    default:
        Console.WriteLine("Invalid day");
        break;
}
```

| Line | What It Does |
|------|-------------|
| `int day = 4;` | The variable being checked. An integer this time, not a string. |
| `switch (day)` | Evaluates `day` against each case. |
| `case 1:` | Note: no quotes. These are `int` values, not strings. `case 1:` not `case "1":`. |
| `break;` | Exits the switch after the matched case runs. |
| `default:` | Catches any value that doesn't match (e.g. 0, 8, -3, 999). |

### String vs Int Cases

| Data Type | Case Syntax | Example |
|-----------|------------|---------|
| `string` | `case "1":` | Menu choices from `Console.ReadLine()` (always returns string) |
| `int` | `case 1:` | Numeric variables, counters, enums |

`Console.ReadLine()` always returns a `string`, so menu apps use `case "1":` with quotes. If you have an `int` variable, use `case 1:` without quotes.

### Output

```
HURRDURR
```

Because `day` is 4, only `case 4:` executes. Every other case is skipped. If `day` were 9, `default:` would catch it and print "Invalid day".

---

## Week 3 — Port Scan Analyzer (`week3-portscan`)

Same 5 patterns as the Rations Manager, reskinned for pentest. Simulates analyzing nmap scan results.

### What It Does

```
[*] Scan complete. 9 ports scanned.
[*] 7 open | 2 closed/filtered

=== PORT SCAN ANALYZER ===
[1] View All Results
[2] Search Port
[3] Count Open Ports
[4] Check High Risk
[5] Filter by State
[0] Exit
nmap>
```

### The Data — Three Parallel Arrays

```csharp
int[] ports =       { 21,      22,     23,       80,     139,    443,    445,   3306,    8080 };
string[] services = { "ftp",   "ssh",  "telnet", "http", "smb",  "https","smb", "mysql", "http-proxy" };
string[] states =   { "open",  "open", "open",   "open", "open", "open", "open","closed","filtered" };
```

Three arrays instead of two. Same index = same port. `ports[0]` (21) maps to `services[0]` ("ftp") maps to `states[0]` ("open"). This is how nmap stores results internally — port, service, state.

### Methods — Pattern Mapping

| Method | Return | Rations Equivalent | Pentest Purpose |
|--------|--------|--------------------|-----------------|
| `DisplayScanResults()` | void | `DisplayAll()` | Print all ports with service and state |
| `ShowMenu()` | void | `ShowMenu()` | Print the menu |
| `FindPort()` | int | `FindRation()` | Search by port number, return index or -1 |
| `CountOpen()` | int | `GetTotalCalories()` | Accumulator — count open ports instead of summing calories |
| `IsHighRisk()` | bool | `IsHighCalorie()` | Check if service is exploitable (telnet, ftp, smb) |
| `FilterByState()` | void | (new) | Filter results by open/closed/filtered |

### Line-by-Line — New Concepts

**`DisplayScanResults` — Formatted output with alignment**

```csharp
Console.WriteLine($"  {ports[i],-9} {services[i],-15} {states[i]}");
```

| Part | What It Does |
|------|-------------|
| `{ports[i],-9}` | Left-align in a 9-character wide column. The `-` means left-align. |
| `{services[i],-15}` | Left-align in a 15-character wide column. Makes output line up neatly. |

Without alignment: `21 ftp open` / `3306 mysql closed` (messy).
With alignment: columns line up like real nmap output.

**`FindPort` — Searching ints instead of strings**

```csharp
static int FindPort(int[] ports, int target)
{
    for (int i = 0; i < ports.Length; i++)
    {
        if (ports[i] == target)
            return i;
    }
    return -1;
}
```

Same pattern as `FindRation` but comparing `int == int` instead of `string == string`. No `.ToLower()` needed — numbers don't have case.

**`CountOpen` — Accumulator with a condition**

```csharp
static int CountOpen(string[] states)
{
    int count = 0;
    foreach (string s in states)
    {
        if (s == "open")
            count++;
    }
    return count;
}
```

| Line | What It Does |
|------|-------------|
| `int count = 0;` | Accumulator starts at zero. |
| `if (s == "open")` | Only count ports that are open — adds a filter to the accumulator pattern. |
| `count++;` | Shorthand for `count = count + 1`. Same as `count += 1`. |

In rations, you summed all values. Here you count values that match a condition. Same pattern, just with an `if` gate.

**`IsHighRisk` — Bool with OR conditions**

```csharp
static bool IsHighRisk(string service)
{
    return service == "telnet" || service == "ftp" || service == "smb";
}
```

| Part | What It Does |
|------|-------------|
| `\|\|` | Logical OR. Returns true if ANY condition is true. |
| `service == "telnet"` | Telnet transmits credentials in plaintext. |
| `service == "ftp"` | FTP transmits credentials in plaintext. |
| `service == "smb"` | SMB is commonly exploited (EternalBlue, relay attacks). |

Why these are high risk:
- **Telnet (23)**: Everything sent in cleartext. Use SSH instead.
- **FTP (21)**: Credentials in cleartext. Use SFTP instead.
- **SMB (139/445)**: EternalBlue (MS17-010), relay attacks, null sessions.

**`int.TryParse` — Safe string-to-int conversion**

```csharp
if (int.TryParse(input, out portNum))
```

| Part | What It Does |
|------|-------------|
| `int.TryParse(input, out portNum)` | Tries to convert string to int. Returns true if it worked, false if not. |
| `out portNum` | If conversion succeeds, the result gets stored in `portNum`. |

`Console.ReadLine()` returns a string. You can't compare `"22" == 22`. `TryParse` safely converts without crashing if the user types "abc".

**`FilterByState` — Void method with four parameters**

```csharp
static void FilterByState(int[] ports, string[] services, string[] states, string filter)
```

More parameters doesn't change the pattern. The method receives all three arrays plus the filter string. Loops through, prints only matching rows. The `bool found` flag tracks whether anything matched so you can print "No ports found" if nothing did.

### Pentest Concepts in the Code

| C# Concept | Pentest Application |
|-------------|-------------------|
| Parallel arrays | How scan tools store results (port, service, state) |
| Accumulator with condition | Counting open ports, vulnerable services, live hosts |
| Bool method with OR | Risk classification — checking against known-bad lists |
| Search returning -1 | Port lookup — "is this port in the scan?" |
| Filter method | Filtering scan results by state (like `nmap --open`) |
| `int.TryParse` | Input validation — don't trust user input (ever) |
| String formatting `{,-9}` | Clean output formatting like real security tools |

### What Nmap Actually Does

This app simulates what happens AFTER a scan. Real nmap:

```bash
nmap -sV -sC 192.168.1.64
```

Output:
```
PORT     STATE    SERVICE     VERSION
21/tcp   open     ftp         vsftpd 3.0.5
22/tcp   open     ssh         OpenSSH 9.7
23/tcp   open     telnet      Linux telnetd
80/tcp   open     http        Apache httpd 2.4
```

Your C# app stores and analyzes that same data structure. Same pattern, different tool.

---

## The 5 Patterns

| # | Pattern | Code Shape | When |
|---|---------|-----------|------|
| 1 | Store stuff | `string[] gear = { ... };` | Data exists |
| 2 | Loop through stuff | `for (int i = 0; ...)` | Process each item |
| 3 | Decide on stuff | `if / switch` | Choose what to do |
| 4 | Wrap in methods | `static int Find(...)` | Reuse code |
| 5 | Keep running | `while (running) + menu` | Interactive app |

---

Vidimus Omnia.
