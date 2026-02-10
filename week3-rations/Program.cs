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
    static void Main(string[] args)
    {
        string[] rations = { "Combat Biscuit", "Beef Jerky", "Energy Bar", "MRE Pasta", "Protein Shake" };
            int[] calories = { 250, 189, 350, 620, 280 };

        DisplayAll(rations, calories);
        {
            Console.Write("Search for a ration: ");
            string s = (Console.ReadLine());
            int idx = FindRation(rations, s);
            if (idx != -1)
                Console.WriteLine($"Found: {rations[idx]} - {calories[idx]} cal");
            else
                Console.WriteLine("Not Found.");
        }
    }
}
