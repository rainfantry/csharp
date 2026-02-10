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

        DisplayAll(rations, calories);

        Console.Write("Search for a ration: ");
        string s = Console.ReadLine();
        int idx = FindRation(rations, s);
        if (idx != -1)
            Console.WriteLine($"Found: {rations[idx]} - {calories[idx]} cal");
        else
            Console.WriteLine("Not Found.");

        Console.WriteLine($"Total Calories: {GetTotalCalories(calories)}");

        Console.Write("Check which ration: ");
        string name = Console.ReadLine();
        int pos = FindRation(rations, name);
        if (pos != -1)
        {
            if (IsHighCalorie(calories[pos], 400))
                Console.WriteLine($"{rations[pos]} is HIGH calorie ({calories[pos]} cal)");
            else
                Console.WriteLine($"{rations[pos]} is normal ({calories[pos]} cal)");
        }
        else
            Console.WriteLine("Not found.");
    }
}
