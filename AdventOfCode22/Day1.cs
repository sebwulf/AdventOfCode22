using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode22
{
    public class Day1
    {
        //public static void Part1()
        //{
        //    var input = File.ReadAllLines("../../../Input/Day1.txt");

        //    var backpacks = new List<List<int>>();
        //    var backpack = new List<int>();
        //    foreach (var line in input)
        //    {
        //        if (line != string.Empty)
        //        {
        //            backpack.Add(Convert.ToInt32(line));
        //        }
        //        else
        //        {
        //            backpacks.Add(backpack);
        //            backpack = new List<int>();
        //        }

        //    }

        //    var maxCal = backpacks.Select(b => b.Sum()).Max();
        //    Console.WriteLine($"Max. Calories: {maxCal}");
        //}

        //public static void Part2()
        //{
        //    var input = File.ReadAllLines("../../../Input/Day1.txt");

        //    var backpacks = new List<List<int>>();
        //    var backpack = new List<int>();
        //    foreach (var line in input)
        //    {
        //        if (line != string.Empty)
        //        {
        //            backpack.Add(Convert.ToInt32(line));
        //        }
        //        else
        //        {
        //            backpacks.Add(backpack);
        //            backpack = new List<int>();
        //        }

        //    }

        //    var sumCals = backpacks.Select(b => b.Sum()).OrderDescending().Take(3).Sum();
        //    Console.WriteLine($"Calories of top 3 backpacks: {sumCals}");
        //}
    }
}
