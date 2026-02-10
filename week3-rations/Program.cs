using System;

class Program
{
    // Pattern 4: void method — just displays, returns nothing
    static void DisplayAll(string[] names, int[] calories)
    {
        // Pattern 2: Loop through stuff
        for (int i = 0; i < names.Length; i++)
        {
            Console.WriteLine($"  [{i}] {names[i]} - {calories[i]} cal");
        }
    }

    static void Main(string[] args)
    {
        // Pattern 1: Store stuff — parallel arrays
        string[] rations = { "Combat Biscuit", "Beef Jerky", "Energy Bar", "MRE Pasta", "Protein Shake" };
        int[] calories = { 250, 180, 350, 620, 280 };

        DisplayAll(rations, calories);
    }
}
