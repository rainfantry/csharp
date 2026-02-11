using System;
class Program
{
    // Pattern 4: void method — displays all scan results
    static void DisplayScanResults(int[] ports, string[] services, string[] states)
    {
        Console.WriteLine("\n  PORT      SERVICE         STATE");
        Console.WriteLine("  ────      ───────         ─────");
        for (int i = 0; i < ports.Length; i++)
        {
            Console.WriteLine($"  {ports[i],-9} {services[i],-15} {states[i]}");
        }
    }

    // Pattern 4: void method — menu display
    static void ShowMenu()
    {
        Console.WriteLine("\n=== PORT SCAN ANALYZER ===");
        Console.WriteLine("[1] View All Results");
        Console.WriteLine("[2] Search Port");
        Console.WriteLine("[3] Count Open Ports");
        Console.WriteLine("[4] Check High Risk");
        Console.WriteLine("[5] Filter by State");
        Console.WriteLine("[0] Exit");
        Console.Write("nmap> ");
    }

    // Pattern 4: returns int — search by port number
    static int FindPort(int[] ports, int target)
    {
        for (int i = 0; i < ports.Length; i++)
        {
            if (ports[i] == target)
                return i;
        }
        return -1;
    }

    // Pattern 4: returns int — accumulator, counts open ports
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

    // Pattern 4: returns bool — checks if a service is high risk
    static bool IsHighRisk(string service)
    {
        // Telnet, FTP, and SMB are high risk — unencrypted or commonly exploited
        return service == "telnet" || service == "ftp" || service == "smb";
    }

    // Pattern 4: void method — filters and displays by state
    static void FilterByState(int[] ports, string[] services, string[] states, string filter)
    {
        Console.WriteLine($"\n  Ports with state: {filter}");
        Console.WriteLine("  ────────────────────────");
        bool found = false;
        for (int i = 0; i < ports.Length; i++)
        {
            if (states[i] == filter.ToLower())
            {
                Console.WriteLine($"  {ports[i],-9} {services[i],-15} {states[i]}");
                found = true;
            }
        }
        if (!found)
            Console.WriteLine("  No ports found with that state.");
    }

    static void Main(string[] args)
    {
        // Pattern 1: Store stuff — parallel arrays (simulated nmap scan results)
        int[] ports =       { 21,      22,     23,       80,     139,    443,    445,   3306,    8080 };
        string[] services = { "ftp",   "ssh",  "telnet", "http", "smb",  "https","smb", "mysql", "http-proxy" };
        string[] states =   { "open",  "open", "open",   "open", "open", "open", "open","closed","filtered" };

        Console.WriteLine("[*] Scan complete. 9 ports scanned.");
        Console.WriteLine($"[*] {CountOpen(states)} open | {ports.Length - CountOpen(states)} closed/filtered");

        // Pattern 5: Keep running
        bool running = true;
        while (running)
        {
            ShowMenu();
            string choice = Console.ReadLine();

            // Pattern 3: Decide (switch)
            switch (choice)
            {
                case "1":
                    DisplayScanResults(ports, services, states);
                    break;
                case "2":
                    Console.Write("Enter port number: ");
                    string input = Console.ReadLine();
                    int portNum;
                    if (int.TryParse(input, out portNum))
                    {
                        int idx = FindPort(ports, portNum);
                        if (idx != -1)
                            Console.WriteLine($"  {ports[idx]}/{services[idx]} — {states[idx]}");
                        else
                            Console.WriteLine($"  Port {portNum} not in scan results.");
                    }
                    else
                        Console.WriteLine("  Invalid port number.");
                    break;
                case "3":
                    int open = CountOpen(states);
                    Console.WriteLine($"  Open: {open} | Closed/Filtered: {ports.Length - open}");
                    break;
                case "4":
                    Console.WriteLine("\n  HIGH RISK SERVICES");
                    Console.WriteLine("  ──────────────────");
                    for (int i = 0; i < services.Length; i++)
                    {
                        if (IsHighRisk(services[i]) && states[i] == "open")
                            Console.WriteLine($"  [!] {ports[i]}/{services[i]} — OPEN — unencrypted/exploitable");
                    }
                    break;
                case "5":
                    Console.Write("Filter (open/closed/filtered): ");
                    string filter = Console.ReadLine();
                    FilterByState(ports, services, states, filter);
                    break;
                case "0":
                    running = false;
                    Console.WriteLine("[*] Scan session ended.");
                    break;
                default:
                    Console.WriteLine("  Invalid option.");
                    break;
            }
        }
    }
}
