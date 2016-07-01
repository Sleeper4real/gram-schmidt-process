using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace ConsoleApplication8
{
    class Program
    {
        static void Main(string[] args)
        {
            Debug.Assert(Checker.DiscrepancyIsSmall());
            int restart = 1;
            do
            {
                Compute compute = new Compute();
                Basis inputBasis = Compute.FindInputBasis();
                compute.Gram_Schmidt_Process(inputBasis);
                compute.PrintResult();
                Console.WriteLine("Continue? (1)Yes (2)No");
                restart = int.Parse(Console.ReadLine());
            } while (restart == 1);
        }
    }
}