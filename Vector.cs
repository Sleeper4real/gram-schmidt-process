using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication8
{
    class Vector
    {
        public int n;
        public double[] entries;
        public Vector(double[] entries)
        {
            n = entries.Length;
            this.entries = new double [n];
            for(int i = 0; i < n; ++i)
            {
                this.entries[i] = entries[i];
            }
        }
        public Vector(Vector vector)
        {
            n = vector.entries.Length;
            this.entries = vector.entries;
        }
        public Vector(int n, int row)
        {
            this.n = n;
            entries = new double[n];
            for (int i = 0; i < n; ++i)
            {
                this.entries[i] = 0;
            }
            this.entries[row] = 1;
        }
        public static double FindNormSquare(Vector vector)
        {
            double normSquare = 0;
            for(int i = 0; i < vector.n; ++i)
            {
                normSquare += Math.Pow(vector.entries[i], 2);
            }
            return normSquare;
        }
        public static double FindInnerProduct(Vector vector1, Vector vector2)
        {
            double innerProduct = 0;
            for (int i = 0; i < vector1.n; ++i)
            {
                innerProduct += (vector1.entries[i] * vector2.entries[i]);
            }
            return innerProduct;
        }
        public static Vector ScalarMultiplication(Vector vector, double scalar)
        {
            Vector scalarMultiple = new Vector(Vector.ZeroVector(vector.n));
            for (int i = 0; i < vector.n; ++i)
            {
                scalarMultiple.entries[i] = scalar * vector.entries[i];
            }
            return scalarMultiple;
        }
        public static Vector VectorAddition(Vector vector1, Vector vector2)
        {
            Vector vectorSum = vector1;
            for (int i = 0; i < vector1.n; ++i)
            {
                vectorSum.entries[i] = (vector1.entries[i] + vector2.entries[i]);
            }
            return vectorSum;
        }
        public static Vector VectorArrayAddition(Vector[] vectorArray)
        {
            Vector vectorArraySum = new Vector(ZeroVector(vectorArray[0].n));
            vectorArraySum.n = vectorArray[0].n;
            for(int i = 0; i < vectorArray[0].n; ++i)
            {
                for(int j = 0; j < vectorArray.Length; ++j)
                {
                    vectorArraySum.entries[i] += vectorArray[j].entries[i];
                }
            }
            return vectorArraySum;
        }
        public static void PrintVector(Vector vector)
        {
            Console.Write("[");
            for (int i = 0; i < vector.n - 1; ++i)
            {
                Console.Write(Math.Round(vector.entries[i], 4) + ",");
            }
            Console.WriteLine(Math.Round(vector.entries[vector.n - 1], 4) + "]");
        }
        public static double[] ZeroVector(int n)
        {
            double[] zeroVector = new double[n];
            for (int i = 0; i < n; ++i)
            {
                zeroVector[i] = 0;
            }
            return zeroVector;
        }
    }
}
