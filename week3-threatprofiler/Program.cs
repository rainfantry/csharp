using System;

class Program
{
    static void DisplayActors(string[] actors, int[] capability, string[] intent, string[] risk)
    {
        Console.WriteLine($"\n  {"ACTOR",-15} {"CAP",3} {"INTENT",-12} {"RISK",-8}");
        Console.WriteLine("  ─────────────────────────────────────────");
        for (int i = 0; i < actors.Length; i++)
        {
            Console.WriteLine($"  {actors[i],-15} {capability[i],3} {intent[i],-12} {risk[i],-8}");
        }
    }

    static void Main(string[] args)
    {
        string[] actors = { "APT28", "Lazarus", "ScriptKiddie", "Insider", "Hacktivists" };
        int[] capability = { 9, 8, 2, 5, 4 };
        string[] intent = { "espionage", "financial", "chaos", "sabotage", "ideology" };
        string[] risk = { "critical", "critical", "low", "high", "medium" };

        DisplayActors(actors, capability, intent, risk);
    }
}
