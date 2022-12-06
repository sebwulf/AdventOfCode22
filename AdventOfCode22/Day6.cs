using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode22
{
    internal class Day6
    {
        public static void FindStartMark(string s)
        {
            var markerEnd = -1;
            for (int i = 3; i < s.Length; i++) 
            {
                var s0 = s[i - 3];
                var s1 = s[i - 2];
                var s2 = s[i - 1];
                var s3 = s[i];

                if (s0 != s1 && s0 != s2 && s0 != s3 &&
                    s1 != s2 && s1 != s3 &&
                    s2 != s3)
                {
                    markerEnd = i + 1;
                    break;
                }
            }

            Console.WriteLine($"Part1: MarkerEnd : {markerEnd}");
        }

        public static void FindMessageMark(string s)
        {
            int i = 0;
            for (i = 14; i < s.Length; i++)
            {
                //var window1 = s.AsSpan().Slice(start, end);
                var window = s.AsSpan().Slice(i - 14, 14).ToString();
                var hasRepeats = window.GroupBy(c => c).Where(g => g.Count() > 1).Any();

                if (!hasRepeats)
                {
                    break;
                }
            }

            Console.WriteLine($"Part1: MessageMarker : {i}");
        }

        public static void Part1()
        {
            var input = File.ReadAllLines("../../../Input/Day6.txt");

            FindStartMark(input.First());
        }

        public static void Part2()
        {
            var input = File.ReadAllLines("../../../Input/Day6.txt");

            FindMessageMark(input.First()); 
        }
    }
}
