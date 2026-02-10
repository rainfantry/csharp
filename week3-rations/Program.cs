using System;
class Program
{
    static void DisplayAll(string[] names, int[] calories)
    {
        for (int i = 0; i < names.Length; i++)
        {
            Console.WriteLine($" [{i}] {names[i]} - {calories[i]} cal");
        }
    }

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

    static int FindRation(string[] names, string search)
    {
        for (int i = 0; i < names.Length; i++)
        {
            if (names[i].ToLower() == search.ToLower())
                return i;
        }
        return -1;
    }

    static int GetTotalCalories(int[] calories)
    {
        int total = 0;
        foreach (int c in calories)
        {
            total += c;
        }
        return total;
    }

    static bool IsHighCalorie(int calories, int threshold)
    {
        return calories >= threshold;
    }

    static void Main(string[] args)
    {
        string[] rations = { "Combat Biscuit", "Beef Jerky", "Energy Bar", "MRE Pasta", "Protein Shake" };
        int[] calories = { 250, 189, 350, 620, 280 };

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
                    Console.Write("Search: ");
                    string s = Console.ReadLine();
                    int idx = FindRation(rations, s);
                    if (idx != -1)
                        Console.WriteLine($"Found: {rations[idx]} - {calories[idx]} cal");
                    else
                        Console.WriteLine("Ration not found.");
                    break;
                case "3":
                    Console.WriteLine($"Total Calories: {GetTotalCalories(calories)} Cal");
                    break;
                case "4":
                    Console.Write("Ration Name: ");
                    string name = Console.ReadLine();
                    int pos = FindRation(rations, name);
                    if (pos != -1)
                    {
                        if (IsHighCalorie(calories[pos], 400))
                            Console.WriteLine($"{rations[pos]} is high calorie. ({calories[pos]} cal)");
                        else
                            Console.WriteLine($"{rations[pos]} is not high calorie. ({calories[pos]} cal)");
                    }
                    else
                        Console.WriteLine("Ration not found.");
                    break;
                case "0":
                    running = false;
                    Console.WriteLine("Exiting...");
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }
}
