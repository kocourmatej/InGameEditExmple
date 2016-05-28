using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    // Masspoint
    // [INFO] Největší reinvent mého života -_-
    public class vec3
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }
        public double Magnitude { get { return Math.Sqrt(SumSqrtComponents(this)); } }

        public static readonly vec3 Zero = new vec3(0, 0, 0);

        public vec3(int x, int y, int z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public vec3(int x, int y)
        {
            X = x;
            Y = y;
            Z = 0;
        }

        // Math
        public static vec3 CrossProduct(vec3 v1, vec3 v2)
        {
            return (new vec3((int)((v1.Y * v2.Z) - (v1.Z * v2.Y)), (int)((v1.Z * v2.X) - (v1.X * v2.Z)), (int)((v1.X * v2.Y) - (v1.Y - v2.X))));
        }

        public static double DotProduct(vec3 v1, vec3 v2)
        {
            return (v1.X * v2.X + v1.Y * v2.Y + v1.Z + v2.Z);
        }

        public static vec3 Scale(vec3 v1, double magnitude)
        {
            return v1 * (magnitude / v1.Magnitude);
        }

        public static double Distance(vec3 v1, vec3 v2)
        {
            return (Math.Sqrt((v1.X - v2.X) * (v1.X - v2.X) + (v1.Y - v2.Y) * (v1.Y - v2.Y) + (v1.Z - v2.Z) * (v1.Z - v2.Z)));
        }

        public static double MixedProduct(vec3 v1, vec3 v2, vec3 v3)
        {
            return (DotProduct(CrossProduct(v1, v2), v3));
        }


        // Transformations

        // Components
        public static double SumComponents(vec3 v1)
        {
            return (v1.X + v1.Y + v1.Z);
        }

        public static vec3 SqrComponents(vec3 v1)
        {
            return (new vec3(((int)(v1.X * v1.X)), ((int)(v1.Y * v1.Y)), (int)(v1.Z * v1.Z)));
        }

        public static vec3 SqrtComponents(vec3 v1)
        {
            return (new vec3((int)Math.Sqrt(v1.X), (int)Math.Sqrt(v1.Y), (int)Math.Sqrt(v1.Z)));
        }

        public static double SumSqrtComponents(vec3 v1)
        {
            vec3 v2 = SqrtComponents(v1);
            return SumComponents(v2);
        }

        // Operators
        public static vec3 operator*(vec3 v1, double s2)
        {
            return (new vec3((int)(v1.X * s2), (int)(v1.Y * s2), (int)(v1.Z * s2)));
        }

    }
}
