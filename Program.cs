using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp
{
    class Program
    {
        static void printStuffFromArray(int[] array)
        {
            int highest = 0;
            Dictionary <int, int> tally = new Dictionary <int, int>();

            foreach (int i in array)
            {  
                // tally of highest number
                if (i > highest)
                {
                    highest = i;
                }
                
                // tally of instances
                if (tally.ContainsKey(i) == false)
                {
                    tally.Add(i, 1);
                }
                else
                {
                    int current;
                    tally.TryGetValue(i, out current); 
                    tally[i] = current + 1;
                }

                // consecutive repeats
                // not attempted
            }
            
            Console.WriteLine("Highest Number : " + highest);
            Console.Write("Instances : [");

            var myStringBuilder = new StringBuilder();
            bool test = true;
            foreach(var item in tally)
            {
                if (test)
                {
                    test = false;
                }
                else
                {
                    myStringBuilder.Append(",");
                }
                myStringBuilder.AppendFormat("{0}x{1}", item.Value, item.Key);
            }
            Console.Write(myStringBuilder.ToString());
            Console.Write("]\n");
        }

        static void Main(string[] args)
        {
            int[] testArray = new int[] {1, 10, 7, 6, 1, 7, 7, 8, 8, 8, 5, 1};
            printStuffFromArray(testArray);

        }
    }
}