using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication8
{
    class Basis
    {
        public int dim;
        public Vector[] vectors;
        public Basis(Vector[] vectors)
        {
            this.dim = vectors.Length;
            this.vectors = new Vector[dim];
            for (int i = 0; i < vectors.Length; ++i)
            {
                this.vectors[i] = vectors[i];
            }
        }
        public Basis(Basis basis)
        {
            this.dim = basis.vectors.Length;
            this.vectors = new Vector[dim];
            this.vectors = basis.vectors;
        }
        public Basis(int dim, int n)
        {
            vectors = new Vector[dim];
            for(int i = 0; i < dim; ++i)
            {
                vectors[i] = new Vector(n, i);
            }
        }
        public static Vector[] VectorsOfBasis(Basis basis)
        {
            return basis.vectors;
        }
        public static void PrintBasis(Basis basis)
        {
            for(int i = 0; i < basis.vectors.Length; ++i)
            {
                Vector.PrintVector(basis.vectors[i]);
            }
        }
    }
}
