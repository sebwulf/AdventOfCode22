using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode22
{
    internal class Day3
    {
        public class Rucksack
        {
            public string Comp1 { get; set; }
            public string Comp2 { get; set; }

            public Rucksack(string s)
            {
                Comp1 = s.Substring(0, s.Length / 2);
                Comp2 = s.Substring(s.Length / 2);
            }

            //public string GetCommon()
            //{
            //    var x = Comp1.GroupBy(c => c)
            //        .Join(
            //            Comp2.GroupBy(c => c),
            //            g => g.Key,
            //            g => g.Key,
            //            (lg, rg) => lg.Zip(rg, (l, r) => l).Count());

            //    return x.
            //}

            public char GetCommon()
            {
                foreach (char c in Comp1)
                {
                    foreach(char d in Comp2)
                    {
                        if (d == c) return c; 
                    }
                }

                return ' ';
            }
        }

        public static int GetPrio(char c)
        {
            if (c <= 'a' && c <= 'z')
            {
                return (int)(c - 'a' + 1);
            }
            else if (c <= 'A' && c <= 'Z')
            {
                return (int)(c - 'A' + 27);
            }

            return 0;
        }

        public static bool test()
        {
            return true;
        }

        public static void Part1()
        {
            var input = File.ReadAllLines("../../../Input/Day3.txt");

            var x = test();

            var rucksacks = input.Select(s => new Rucksack(s));
            var commons = rucksacks.Select(r => r.GetCommon());
            var sum = commons.Select(c => GetPrio(c)).Sum();

            var y = test();

            Console.WriteLine($"Sum Prios: {sum}");

        }
    }
}
