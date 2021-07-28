using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment1
{
    class ScoreBoard
    {
        static void Main()
        {
            int overs;
            float sum = 0;
            double StrikeRate;
            Console.WriteLine("Enter Number of Overs");
            overs = int.Parse(Console.ReadLine());
            overs = overs * 6;
            int[] score = new int[overs];

            Random rand = new Random();

            int[] values = new int[6] { 0, 1, 2, 3, 4, 6 };

            for (int j = 0; j < score.Length; j++)
            {
                int value = values[rand.Next(0, values.Length)];
                int runs = value;
                score[j] = runs;
                sum = sum + score[j];

            }

            Dictionary<int, int> ItemCount = new Dictionary<int, int>();
            foreach (int item in score)
            {
                if (ItemCount.ContainsKey(item))
                {
                    ItemCount[item]++;
                }
                else
                {
                    ItemCount.Add(item, 1);
                }
            }
            Console.WriteLine("R | C");//R for runs and C for their Count
            foreach (KeyValuePair<int, int> res in ItemCount)
            {
                Console.WriteLine(res.Key + " | " + res.Value);
            }

            Console.WriteLine("Total Runs by Team: {0}", sum);

            StrikeRate = (sum / overs) * 100;

            Console.WriteLine("Strike Rate of the Team: {0}", StrikeRate);


        }
    }
}
