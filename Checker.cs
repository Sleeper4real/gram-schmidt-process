using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication8
{
    class Checker
    {
        public static bool DiscrepancyIsSmall()
        {
            Random rand = new Random();
            double changingEntry = rand.Next() % 10;
            double[] entries1 = new double[3] {-1, 3, 4};
            double[] entries2 = new double[3] {-7, 11, changingEntry};
            Vector vector1 = new Vector(entries1);
            Vector vector2 = new Vector(entries2);
            Vector[] inputVectors = {vector1, vector2};
            Basis inputBasis = new Basis(inputVectors);
            Compute compute = new Compute();
            compute.Gram_Schmidt_Process(inputBasis);
            Vector[] result = Basis.VectorsOfBasis(compute.orthogonalBasis);
            double innerProduct = Vector.FindInnerProduct(result[0], result[1]);
            bool discrepancyIsSmall = (innerProduct <= 0.01);
            return discrepancyIsSmall;
        }
    }
}
