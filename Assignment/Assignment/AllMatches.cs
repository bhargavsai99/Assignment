using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment1
{
    class AllMatches
    {
        static void Main()
        {
            int overs, matches;
            float totalscore = 0;
            float sum = 0;
            double StrikeRate;
            Console.WriteLine("Enter Number of Overs");
            overs = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Number of Matches");
            matches = int.Parse(Console.ReadLine());
            int op = overs * 6;
            overs = matches*overs * 6;
            int[] score = new int[overs];
            float[] match = new float[matches];
            Random rand = new Random();
            int[] values = new int[6] { 0, 1, 2, 3, 4, 6 };
            
            for (int i = 0; i < match.Length; i++)
            {
                for (int j = 0; j < score.Length; j++)
                {
                    int value = values[rand.Next(0, values.Length)];
                    int runs = value;
                    score[j] = runs;
                    for(int k=0;k<op;k++)
                    {
                        sum = sum + score[j];

                    }
                    //sum = sum + score[j];
                    match[i] = sum;
                    sum = 0;

                }
                
        
                
                Console.WriteLine("Scores:{0}", match[i]);
                totalscore = totalscore + match[i];

            }
             
            Console.WriteLine("Total Scores in ALL Inings:{0}", totalscore);
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
            
            Console.WriteLine("Total Runs by Team: {0}", totalscore);

            StrikeRate = (totalscore / overs) ;

            Console.WriteLine("Strike Rate of the Team: {0}", StrikeRate);
        }
    }
}

