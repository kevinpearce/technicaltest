using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp
{
    class Program
    {
        static void printStuffFromArray(int[] array)
        {
            int highest = 0, record = 0, rolling = 0, lastNum = 0;
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
                if (i != lastNum)
                {
                    lastNum = i;
                    rolling = 1;
                }
                else
                {
                    rolling ++;
                }
                
                if (record < rolling)
                {
                    record = rolling;
                }
            }
            
            //exports results
            Console.WriteLine("Highest Number : " + highest);

            var myStringBuilder = new StringBuilder();
            myStringBuilder.Append("Instances : [");
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
            myStringBuilder.Append("]\n");
            Console.Write(myStringBuilder.ToString());
            // Console.Write("]\n");
            Console.WriteLine("Most Consecutive Instances: " + record);
        }

        static void Main(string[] args)
        {
            int[] testArray = new int[] {1, 10, 7, 6, 1, 7, 7};
            printStuffFromArray(testArray);
        }
    }
}