using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace hw3
{
    class Program
    {
        static int i = 500;
        static void Main(string[] args)
        {
            ParallelOptions options = new ParallelOptions();
            options.MaxDegreeOfParallelism = 2;
            Parallel.Invoke(options, Method1, Method2);
            
        }
        static void  Method1()
        {
            for (; i <= 1000; i++)
            {
                Thread.Sleep(500);
                Console.WriteLine($"{i}");
                if (i > 750) i = 500;
            }
        }
        static void Method2()
        {
            for (; i >= 0; i--)
            {
                Thread.Sleep(500);
                Console.WriteLine($"\t{i}");
                if (i < 250) i = 500;
            }
        }
    }
}
