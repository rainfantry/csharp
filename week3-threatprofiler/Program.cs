using System;

class Program
{
    // ═══════════════════════════════════════════════════════
    // DISPLAY — void, prints all actors formatted
    // ═══════════════════════════════════════════════════════
    static void DisplayActors(string[] actors, int[] capability, string[] intent, string[] risk)
    {
        Console.WriteLine($"\n  {"ACTOR",-15} {"CAP",3} {"INTENT",-12} {"RISK",-10}");
        Console.WriteLine("  ───────────────────────────────────────────");
        for (int i = 0; i < actors.Length; i++)
        {
            string marker = risk[i] == "critical" ? "[!]" : "   ";
            Console.WriteLine($"  {marker} {actors[i],-15} {capability[i],3} {intent[i],-12} {risk[i],-10}");
        }
    }

    // ═══════════════════════════════════════════════════════
    // MENU — void, prints options
    // ═══════════════════════════════════════════════════════
    static void ShowMenu()
    {
        Console.WriteLine("\n  ╔═══════════════════════════════════╗");
        Console.WriteLine("  ║   THREAT ACTOR PROFILER   v1.0   ║");
        Console.WriteLine("  ║   DST-Group-TR-3335 Framework    ║");
        Console.WriteLine("  ╚═══════════════════════════════════╝");
        Console.WriteLine("  [1] View All Actors");
        Console.WriteLine("  [2] Search Actor");
        Console.WriteLine("  [3] Filter by Risk Level");
        Console.WriteLine("  [4] High Capability Alert (7+)");
        Console.WriteLine("  [5] Count by Risk Level");
        Console.WriteLine("  [6] Threat Summary Report");
        Console.WriteLine("  [7] Compare Two Actors");
        Console.WriteLine("  [0] Exit");
        Console.Write("  INTEL> ");
    }

    // ═══════════════════════════════════════════════════════
    // SEARCH — returns int, index or -1
    // ═══════════════════════════════════════════════════════
    static int FindActor(string[] actors, string search)
    {
        for (int i = 0; i < actors.Length; i++)
        {
            if (actors[i].ToLower() == search.ToLower())
                return i;
        }
        return -1;
    }

    // ═══════════════════════════════════════════════════════
    // FILTER — void, displays actors matching a risk level
    // ═══════════════════════════════════════════════════════
    static void FilterByRisk(string[] actors, int[] capability, string[] intent, string[] risk, string filter)
    {
        Console.WriteLine($"\n  [*] Actors with risk level: {filter.ToUpper()}");
        Console.WriteLine("  ───────────────────────────────────────────");
        bool found = false;
        for (int i = 0; i < actors.Length; i++)
        {
            if (risk[i].ToLower() == filter.ToLower())
            {
                Console.WriteLine($"  {actors[i],-15} CAP:{capability[i]}  INTENT:{intent[i]}");
                found = true;
            }
        }
        if (!found)
            Console.WriteLine("  No actors found with that risk level.");
    }

    // ═══════════════════════════════════════════════════════
    // HIGH CAP ALERT — void, shows actors with capability >= threshold
    // ═══════════════════════════════════════════════════════
    static void HighCapAlert(string[] actors, int[] capability, string[] risk, int threshold)
    {
        Console.WriteLine($"\n  [!] HIGH CAPABILITY ACTORS (>= {threshold})");
        Console.WriteLine("  ───────────────────────────────────────────");
        for (int i = 0; i < actors.Length; i++)
        {
            if (capability[i] >= threshold)
                Console.WriteLine($"  [!] {actors[i],-15} CAP:{capability[i]}  RISK:{risk[i]}");
        }
    }

    // ═══════════════════════════════════════════════════════
    // COUNT — returns int, accumulator with condition
    // ═══════════════════════════════════════════════════════
    static int CountByRisk(string[] risk, string level)
    {
        int count = 0;
        foreach (string r in risk)
        {
            if (r.ToLower() == level.ToLower())
                count++;
        }
        return count;
    }

    // ═══════════════════════════════════════════════════════
    // IS CRITICAL — returns bool
    // ═══════════════════════════════════════════════════════
    static bool IsCritical(string riskLevel)
    {
        return riskLevel == "critical";
    }

    // ═══════════════════════════════════════════════════════
    // AVERAGE CAP — returns double, accumulator / count
    // ═══════════════════════════════════════════════════════
    static double AverageCapability(int[] capability)
    {
        int total = 0;
        foreach (int c in capability)
            total += c;
        return (double)total / capability.Length;
    }

    // ═══════════════════════════════════════════════════════
    // HIGHEST THREAT — returns int, index of highest capability
    // ═══════════════════════════════════════════════════════
    static int FindHighestThreat(int[] capability)
    {
        int maxIndex = 0;
        for (int i = 1; i < capability.Length; i++)
        {
            if (capability[i] > capability[maxIndex])
                maxIndex = i;
        }
        return maxIndex;
    }

    // ═══════════════════════════════════════════════════════
    // MAIN — entry point, while loop + switch
    // ═══════════════════════════════════════════════════════
    static void Main(string[] args)
    {
        string[] actors =    { "APT28", "Lazarus", "ScriptKiddie", "Insider", "Hacktivists", "DarkSide", "Equation Group", "Lapsus$" };
        int[] capability =   { 9, 8, 2, 5, 4, 7, 10, 6 };
        string[] intent =    { "espionage", "financial", "chaos", "sabotage", "ideology", "ransom", "espionage", "clout" };
        string[] risk =      { "critical", "critical", "low", "high", "medium", "high", "critical", "medium" };

        Console.WriteLine("\n  ╔═══════════════════════════════════╗");
        Console.WriteLine("  ║     THREAT ACTOR PROFILER         ║");
        Console.WriteLine("  ║     DST-Group-TR-3335             ║");
        Console.WriteLine("  ║     Vidimus Omnia                 ║");
        Console.WriteLine("  ╚═══════════════════════════════════╝");
        Console.WriteLine($"  [*] {actors.Length} actors loaded.");
        Console.WriteLine($"  [*] {CountByRisk(risk, "critical")} critical | {CountByRisk(risk, "high")} high | {CountByRisk(risk, "medium")} medium | {CountByRisk(risk, "low")} low");

        bool running = true;
        while (running)
        {
            ShowMenu();
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    DisplayActors(actors, capability, intent, risk);
                    break;

                case "2":
                    Console.Write("  Actor name: ");
                    string search = Console.ReadLine();
                    int idx = FindActor(actors, search);
                    if (idx != -1)
                    {
                        Console.WriteLine($"\n  ┌─── ACTOR PROFILE ───────────────────┐");
                        Console.WriteLine($"  │ Name:       {actors[idx],-25}│");
                        Console.WriteLine($"  │ Capability: {capability[idx],-25}│");
                        Console.WriteLine($"  │ Intent:     {intent[idx],-25}│");
                        Console.WriteLine($"  │ Risk:       {risk[idx],-25}│");
                        Console.WriteLine($"  └──────────────────────────────────────┘");
                        if (IsCritical(risk[idx]))
                            Console.WriteLine("  [!] WARNING: CRITICAL THREAT ACTOR");
                    }
                    else
                        Console.WriteLine("  [-] Actor not found in database.");
                    break;

                case "3":
                    Console.Write("  Risk level (critical/high/medium/low): ");
                    string filter = Console.ReadLine();
                    FilterByRisk(actors, capability, intent, risk, filter);
                    break;

                case "4":
                    HighCapAlert(actors, capability, risk, 7);
                    break;

                case "5":
                    Console.WriteLine("\n  ┌─── RISK BREAKDOWN ──────────────────┐");
                    Console.WriteLine($"  │ Critical: {CountByRisk(risk, "critical"),-27}│");
                    Console.WriteLine($"  │ High:     {CountByRisk(risk, "high"),-27}│");
                    Console.WriteLine($"  │ Medium:   {CountByRisk(risk, "medium"),-27}│");
                    Console.WriteLine($"  │ Low:      {CountByRisk(risk, "low"),-27}│");
                    Console.WriteLine($"  │ Total:    {actors.Length,-27}│");
                    Console.WriteLine($"  └──────────────────────────────────────┘");
                    break;

                case "6":
                    int top = FindHighestThreat(capability);
                    double avg = AverageCapability(capability);
                    Console.WriteLine("\n  ╔═══ THREAT SUMMARY REPORT ═══════════╗");
                    Console.WriteLine($"  ║ Total actors:     {actors.Length,-19}║");
                    Console.WriteLine($"  ║ Avg capability:   {avg:F1,-19}║");
                    Console.WriteLine($"  ║ Highest threat:   {actors[top],-19}║");
                    Console.WriteLine($"  ║   Capability:     {capability[top],-19}║");
                    Console.WriteLine($"  ║   Intent:         {intent[top],-19}║");
                    Console.WriteLine($"  ║   Risk:           {risk[top],-19}║");
                    Console.WriteLine($"  ║ Critical actors:  {CountByRisk(risk, "critical"),-19}║");
                    Console.WriteLine($"  ║ High risk actors: {CountByRisk(risk, "high"),-19}║");
                    Console.WriteLine($"  ╚══════════════════════════════════════╝");
                    break;

                case "7":
                    Console.Write("  First actor: ");
                    string name1 = Console.ReadLine();
                    Console.Write("  Second actor: ");
                    string name2 = Console.ReadLine();
                    int a = FindActor(actors, name1);
                    int b = FindActor(actors, name2);
                    if (a != -1 && b != -1)
                    {
                        Console.WriteLine($"\n  {"FIELD",-15} {actors[a],-17} {actors[b],-17}");
                        Console.WriteLine("  ──────────────────────────────────────────────");
                        Console.WriteLine($"  {"Capability",-15} {capability[a],-17} {capability[b],-17}");
                        Console.WriteLine($"  {"Intent",-15} {intent[a],-17} {intent[b],-17}");
                        Console.WriteLine($"  {"Risk",-15} {risk[a],-17} {risk[b],-17}");
                        if (capability[a] > capability[b])
                            Console.WriteLine($"\n  [!] {actors[a]} is the greater threat.");
                        else if (capability[b] > capability[a])
                            Console.WriteLine($"\n  [!] {actors[b]} is the greater threat.");
                        else
                            Console.WriteLine($"\n  [=] Equal capability.");
                    }
                    else
                        Console.WriteLine("  [-] One or both actors not found.");
                    break;

                case "0":
                    running = false;
                    Console.WriteLine("  [*] Intel session ended. Vidimus Omnia.");
                    break;

                default:
                    Console.WriteLine("  [-] Invalid option.");
                    break;
            }
        }
    }
}
