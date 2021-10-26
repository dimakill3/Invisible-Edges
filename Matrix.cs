using System;


namespace Invisible_Edges
{
    public class Matrix
    {
        public static readonly double[,] projection = new double[4, 4]
        {
            {1, 0, 0, 0},
            {0, 1, 0, 0},
            {0.5 * Math.Sqrt(2)/2, 0.5 * Math.Sqrt(2)/2, 0, 0},
            {0, 0, 0, 1},
        };

        public static readonly double[,] moveUp = new double[4, 4]
        {
            {1, 0, 0, 0},
            {0, 1, 0, 0},
            {0, 0, 1, 0},
            {0, 1, 0, 1},
        };

        public static readonly double[,] moveDown = new double[4, 4]
        {
            {1, 0, 0, 0},
            {0, 1, 0, 0},
            {0, 0, 1, 0},
            {0, -1, 0, 1},
        };

        public static readonly double[,] moveRight = new double[4, 4]
        {
            {1, 0, 0, 0},
            {0, 1, 0, 0},
            {0, 0, 1, 0},
            {1, 0, 0, 1},
        };

        public static readonly double[,] moveLeft = new double[4, 4]
        {
            {1, 0, 0, 0},
            {0, 1, 0, 0},
            {0, 0, 1, 0},
            {-1, 0, 0, 1},
        };

        public static readonly double[,] moveFrom = new double[4, 4]
        {
            {1, 0, 0, 0},
            {0, 1, 0, 0},
            {0, 0, 1, 0},
            {0, 0, 1, 1},
        };

        public static readonly double[,] moveTo = new double[4, 4]
        {
            {1, 0, 0, 0},
            {0, 1, 0, 0},
            {0, 0, 1, 0},
            {0, 0, -1, 1},
        };

        public static readonly double[,] rotationXPlus = new double[4, 4]
       {
            {1, 0, 0, 0},
            {0, Math.Cos(Math.PI * 1 / 180.0), Math.Sin(Math.PI * 1 / 180.0), 0},
            {0, -Math.Sin(Math.PI * 1 / 180.0), Math.Cos(Math.PI * 1 / 180.0), 0},
            {0, 0, 0, 1},
       };

        public static readonly double[,] rotationXMinus = new double[4, 4]
        {
            {1, 0, 0, 0},
            {0, Math.Cos(Math.PI * 1 / 180.0), -Math.Sin(Math.PI * 1 / 180.0), 0},
            {0, Math.Sin(Math.PI * 1 / 180.0), Math.Cos(Math.PI * 1 / 180.0), 0},
            {0, 0, 0, 1},
        };

        public static readonly double[,] rotationYPlus = new double[4, 4]
        {
            {Math.Cos(Math.PI * 1 / 180.0), 0, Math.Sin(Math.PI * 1 / 180.0), 0},
            {0, 1, 0, 0},
            {-Math.Sin(Math.PI * 1 / 180.0), 0, Math.Cos(Math.PI * 1 / 180.0), 0},
            {0, 0, 0, 1},
        };

        public static readonly double[,] rotationYMinus = new double[4, 4]
        {
            {Math.Cos(Math.PI * 1 / 180.0), 0, -Math.Sin(Math.PI * 1 / 180.0), 0},
            {0, 1, 0, 0},
            {Math.Sin(Math.PI * 1 / 180.0), 0, Math.Cos(Math.PI * 1 / 180.0), 0},
            {0, 0, 0, 1},
        };

        public static readonly double[,] rotationZPlus = new double[4, 4]
        {
            {Math.Cos(Math.PI * 1 / 180.0), Math.Sin(Math.PI * 1 / 180.0), 0, 0},
            {-Math.Sin(Math.PI * 1 / 180.0), Math.Cos(Math.PI * 1 / 180.0), 0, 0},
            {0, 0, 1, 0},
            {0, 0, 0, 1},
        };

        public static readonly double[,] rotationZMinus = new double[4, 4]
        {
            {Math.Cos(Math.PI * 1 / 180.0), Math.Sin(-Math.PI * 1 / 180.0), 0, 0},
            {Math.Sin(Math.PI * 1 / 180.0), Math.Cos(Math.PI * 1 / 180.0), 0, 0},
            {0, 0, 1, 0},
            {0, 0, 0, 1},
        };

        public static readonly double[,] compressionXPlus = new double[4, 4]
        {
            {1.1, 0, 0, 0},
            {0, 1, 0, 0},
            {0, 0, 1, 0},
            {0, 0, 0, 1},
        };

        public static readonly double[,] compressionXMinus = new double[4, 4]
        {
            {0.9, 0, 0, 0},
            {0, 1, 0, 0},
            {0, 0, 1, 0},
            {0, 0, 0, 1},
        };

        public static readonly double[,] compressionYPlus = new double[4, 4]
        {
            {1, 0, 0, 0},
            {0, 1.1, 0, 0},
            {0, 0, 1, 0},
            {0, 0, 0, 1},
        };

        public static readonly double[,] compressionYMinus = new double[4, 4]
        {
            {1, 0, 0, 0},
            {0, 0.9, 0, 0},
            {0, 0, 1, 0},
            {0, 0, 0, 1},
        };

        public static readonly double[,] compressionZPlus = new double[4, 4]
        {
            {1, 0, 0, 0},
            {0, 1, 0, 0},
            {0, 0, 1.1, 0},
            {0, 0, 0, 1},
        };

        public static readonly double[,] compressionZMinus = new double[4, 4]
        {
            {1, 0, 0, 0},
            {0, 1, 0, 0},
            {0, 0, 0.9, 0},
            {0, 0, 0, 1},
        };

        public static readonly double[,] MatrixMirrorYZ = new double[4, 4]
        {
            {-1, 0, 0, 0},
            {0, 1, 0, 0},
            {0, 0, 1, 0},
            {0, 0, 0, 1},
        };

        public static readonly double[,] MatrixMirrorXY = new double[4, 4]
        {
            {1, 0, 0, 0},
            {0, 1, 0, 0},
            {0, 0, -1, 0},
            {0, 0, 0, 1},
        };

        public static readonly double[,] MatrixMirrorXZ = new double[4, 4]
        {
            {1, 0, 0, 0},
            {0, -1, 0, 0},
            {0, 0, 1, 0},
            {0, 0, 0, 1},
        };

        public static double[,] GetCenterMatrix(Point shift)
        {
            double[,] centerMatrix = new double[4, 4]
            {
                {1, 0, 0, 0},
                {0, 1, 0, 0},
                {0, 0, 1, 0},
                {shift.coords[0], shift.coords[1], shift.coords[2], 1}
            };

            return centerMatrix;
        }

        public static Point Multiplicate(Point point, double[,] matrix)
        {
            double[] coords = new double[4];
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    coords[i] += point.coords[j] * matrix[j, i];
                }
            }
            return new Point(coords);
        }

        public static double ScalarMul(double[] v1, double[] v2)
        {
            double mul = 0;

            if (v1.Length != v2.Length)
                throw new IndexOutOfRangeException("Векторы разной длины!");

            for (int i = 0; i < v1.Length; i++)
            {
                mul += v1[i] * v2[i];
            }

            return mul;
        }
    }
}
