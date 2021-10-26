using System.Collections.Generic;


namespace Invisible_Edges
{
    public class Figures
    {
        public static readonly List<Point> axisPoints = new List<Point>
        {
            new Point(0, 0, 0), //0
            new Point(500, 0, 0), //1
            new Point(0, 300, 0), //2
            new Point(0, 0, -1000), //3
        };

        public static readonly List<int[]> axisEdges = new List<int[]>
        {
            new int[] { 0, 1 },
            new int[] { 0, 2 },
            new int[] { 0, 3 }
        };

        public static readonly List<double[]> axisAreas = new List<double[]>
        {
            new double[] { 1, 0, 0, 0 },
            new double[] { 0, 1, 0, 0 },
            new double[] { 0, 0, 1, 0 }
        };

        public static readonly List<Point> cubePoints = new List<Point>
        {
            new Point(0, 0, 0), //0
            new Point(1, 0, 0), //1
            new Point(0, 1, 0), //2
            new Point(0, 0, 1), //3
            new Point(1, 1, 0), //4
            new Point(1, 0, 1), //5
            new Point(0, 1, 1), //6
            new Point(1, 1, 1)  //7
        };

        public static readonly List<int[]> cubeEdges = new List<int[]>
        {
            new int[] { 0, 1 },
            new int[] { 0, 2 },
            new int[] { 0, 3 },
            new int[] { 1, 5 },
            new int[] { 1, 4 },
            new int[] { 2, 4 },
            new int[] { 2, 6 },
            new int[] { 3, 5 },
            new int[] { 3, 6 },
            new int[] { 7, 4 },
            new int[] { 7, 5 },
            new int[] { 7, 6 }
        };

        public static readonly double[,] cubeGrani = new double[,]
        {
            { 0, 1, 4, 2 },
            { 0, 2, 6, 3 },
            { 2, 6, 7, 4 },
            { 4, 7, 5, 1 },
            { 1, 0, 3, 5 },
            { 3, 5, 7, 6 }

        };

        public static readonly List<Point> tetraedrPoints = new List<Point>
        {
            new Point(0, 0, 0),         // 0
            new Point(1, 0, 0),         // 1
            new Point(0.5f, 1, 0),      // 2
            new Point(0.5f, 0.5f, 1)    // 3
        };

        public static readonly List<int[]> tetraedrEdges = new List<int[]>
        {
            new int[] { 0, 1 },
            new int[] { 0, 2 },
            new int[] { 0, 3 },
            new int[] { 1, 2 },
            new int[] { 1, 3 },
            new int[] { 2, 3 }
        };

        public static readonly List<Point> tetraPoints = new List<Point>
        {
            new Point(0, 0, 0),     // 0
            new Point(1, 0, 0),     // 1
            new Point(0.5f, 1, 0),  // 2
            new Point(0, 0, 1),     // 3
            new Point(1, 0, 1),     // 4
            new Point(0.5f, 1, 1)   // 5
        };

        public static readonly List<int[]> tetraEdges = new List<int[]>
        {
            new int[] { 0, 1 },
            new int[] { 0, 2 },
            new int[] { 0, 3 },
            new int[] { 1, 2 },
            new int[] { 1, 4 },
            new int[] { 2, 5 },
            new int[] { 3, 4 },
            new int[] { 3, 5 },
            new int[] { 4, 5 },
        };
    }
}
