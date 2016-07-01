using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication8
{
    class Compute
    {
        public Basis orthogonalBasis;
        public static Basis FindInputBasis()
        {
            Console.WriteLine("Enter a vector from your basis in the form of 1,2,3,...");
            Vector[] inputVectors = new Vector[100];
            int dimension = 0;
            int moreVectors = 0;
            do
            {
                string[] input = Console.ReadLine().Split(',');
                double[] inputVector = new double[input.Length];
                for (int j = 0; j < input.Length; ++j)
                {
                    inputVector[j] = Convert.ToDouble(input[j]);
                }
                ++dimension;
                inputVectors[dimension-1] = new Vector(inputVector);
                Console.WriteLine("Enter more? (1)Yes (2)No");
                moreVectors = int.Parse(Console.ReadLine());
            }while(moreVectors == 1);
            Vector[] vectorsOfBasis = new Vector[dimension];
            for(int i = 0; i < dimension; ++i)
            {
                vectorsOfBasis[i] = inputVectors[i];
            }
            Basis inputBasis = new Basis(vectorsOfBasis);
            return inputBasis;
        }
        public void Gram_Schmidt_Process(Basis inputBasis)
        {
            orthogonalBasis = new Basis(inputBasis.dim, inputBasis.vectors[0].n);
            orthogonalBasis.dim = inputBasis.dim;
            Vector[] u = Basis.VectorsOfBasis(inputBasis);
            Vector[] v = new Vector[u.Length];
            v[0] = inputBasis.vectors[0];
            double[] zeroVector = Vector.ZeroVector(u[0].n); 
            for (int i = 1; i < inputBasis.dim; ++i)
            {
                Vector deduct = new Vector(zeroVector);
                Vector[] deductVectors = new Vector[i];
                for (int j = 0; j < i; ++j)
                {
                    double innerProduct = Vector.FindInnerProduct(u[i], v[j]);
                    double normSquare = Vector.FindNormSquare(v[j]);
                    deductVectors[j] = Vector.ScalarMultiplication(v[j], (innerProduct / normSquare));
                }
                deduct = Vector.VectorArrayAddition(deductVectors);
                v[i] = Vector.VectorAddition(u[i], Vector.ScalarMultiplication(deduct, (-1)));
            }
            for(int i = 0; i < inputBasis.dim; ++i)
            {
                orthogonalBasis.vectors[i] = v[i];
            }
        }
        public void PrintResult()
        {
            Basis.PrintBasis(orthogonalBasis);
        }
    }
}
