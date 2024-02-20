using System;

namespace Vector_Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            Vector test1 = new Vector(1, 3, 3);
            Vector test2 = new Vector(-1, 3, -3);

            Console.WriteLine("Vector 1: " + test1);
            Console.WriteLine("Vector 2: " + test2);

            // Addition
            Console.WriteLine("Addition: " + Vector.Add(test1, test2));

            // Subtraction
            Console.WriteLine("Subtraction: " + Vector.Subtract(test1, test2));

            // Negation
            Console.WriteLine("Negation of Vector 1: " + Vector.Negate(test1));

            // Scalar Multiplication
            float scalar = 2;
            Console.WriteLine($"Scalar Multiplication of Vector 1 with {scalar}: " + Vector.Scale(test1, scalar));

            // Magnitude
            Console.WriteLine("Magnitude of Vector 1: " + test1.GetMagnitude());

            // Normalization
            Console.WriteLine("Normalized Vector 1: " + Vector.Normalize(test1));

            // Dot Product
            Console.WriteLine("Dot Product: " + Vector.DotProduct(test1, test2));

            // Cross Product
            Console.WriteLine("Cross Product: " + Vector.CrossProduct(test1, test2));

            // Angle between vectors
            Console.WriteLine("Angle between vectors: " + Vector.AngleBetween(test1, test2));

            // Projection of Vector 1 onto Vector 2
            Console.WriteLine("Projection of Vector 1 onto Vector 2: " + Vector.ProjectOnto(test1, test2));
        }
    }

    public class Vector
    {
        public static readonly Vector Zero = new Vector(0, 0, 0);
        public static readonly Vector One = new Vector(1, 1, 1);

        public float x;
        public float y;
        public float z;

        public Vector(float x, float y, float z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        public override string ToString()
        {
            return $"<{x}, {y}, {z}>";
        }

        public static Vector Add(Vector v1, Vector v2)
        {
            return new Vector(v1.x + v2.x, v1.y + v2.y, v1.z + v2.z);
        }

        public static Vector Negate(Vector v)
        {
            return new Vector(-v.x, -v.y, -v.z);
        }

        public static Vector Subtract(Vector v1, Vector v2)
        {
            return new Vector(v1.x - v2.x, v1.y - v2.y, v1.z - v2.z);
        }

        public static Vector Scale(Vector v, float scalar)
        {
            return new Vector(v.x * scalar, v.y * scalar, v.z * scalar);
        }

        public float GetMagnitude()
        {
            return (float)Math.Sqrt((x * x) + (y * y) + (z * z));
        }

        public static Vector Normalize(Vector v)
        {
            float magnitude = v.GetMagnitude();
            return new Vector(v.x / magnitude, v.y / magnitude, v.z / magnitude);
        }

        public static float DotProduct(Vector v1, Vector v2)
        {
            return (v1.x * v2.x) + (v1.y * v2.y) + (v1.z * v2.z);
        }

        public static Vector CrossProduct(Vector v1, Vector v2)
        {
            return new Vector(
                (v1.y * v2.z) - (v1.z * v2.y),
                (v1.z * v2.x) - (v1.x * v2.z),
                (v1.x * v2.y) - (v1.y * v2.x)
            );
        }

        public static float AngleBetween(Vector v1, Vector v2)
        {
            float dotProduct = DotProduct(v1, v2);
            float magnitude1 = v1.GetMagnitude();
            float magnitude2 = v2.GetMagnitude();
            return (float)Math.Acos(dotProduct / (magnitude1 * magnitude2));
        }

        public static Vector ProjectOnto(Vector v1, Vector v2)
        {
            float dotProduct = DotProduct(v1, v2);
            float magnitude2 = v2.GetMagnitude();
            return Scale(v2, dotProduct / (magnitude2 * magnitude2));
        }
    }
}