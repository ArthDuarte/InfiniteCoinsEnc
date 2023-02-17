using System;
using System.Collections.Generic;

public class Program
{
    public static HashSet<List<int>> MakeChange(int n)
    {
        // Initialize a set to store the ways of representing n cents
        HashSet<List<int>> set = new HashSet<List<int>>();

        // Define the denominations in an array
        int[] denominations = { 25, 10, 5, 1 };

        // Define a recursive function to calculate the ways of representing n cents
        void CalcWays(int remaining, int[] denoms, List<int> way)
        {
            // If there are no more denominations to use, add the current way to the set if it represents the desired amount
            if (denoms.Length == 0)
            {
                if (remaining == 0)
                {
                    set.Add(way);
                }
                return;
            }

            // Get the current denomination
            int denom = denoms[0];

            // Calculate the maximum number of times the current denomination can be used to represent the remaining amount
            int maxCount = remaining / denom;

            // Try using the current denomination from 0 to the maximum number of times
            for (int i = 0; i <= maxCount; i++)
            {
                // Calculate the new remaining amount
                int newRemaining = remaining - (i * denom);
                // Calculate the new way by adding the current denomination to the current way
                List<int> newWay = new List<int>(way);
                newWay.Add(i);
                // Recursively call the function with the new remaining amount and remaining denominations
                CalcWays(newRemaining, denoms[1..], newWay);
            }
        }

        // Initialize the current way as an empty list and start the recursive function
        CalcWays(n, denominations, new List<int>());

        // Return the set of ways
        return set;
    }

    public static void Main()
    {
        HashSet<List<int>> ways = MakeChange(10);
        foreach (List<int> way in ways)
        {
            Console.WriteLine(string.Join(" ", way));
        }
    }
}
