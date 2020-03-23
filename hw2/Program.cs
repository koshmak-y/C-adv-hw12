using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Linq;

namespace hw2
{
    class Program
    {
        static int[] massive = new int[1000001];
        static void Main(string[] args)
        {
            Random random = new Random();
            Action action = new Action(StartPINQ);
            for (int i = 0; i < massive.Length; i++)
            {
                massive[i] = random.Next(0, 1000);
                Console.WriteLine(massive[i]);
                if (i == 500000) action.BeginInvoke(null, null);
            }
            Console.ReadKey();
        }

        static void StartPINQ()
        {
            ParallelQuery pq = from value in massive.AsParallel()
                               where value % 2 == 0
                               select value;

            foreach (var item in pq)
            {
                Console.WriteLine($"\t{item}");
                Thread.Sleep(100);
            }
        }
    }
}
