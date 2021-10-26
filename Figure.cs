using System.Collections.Generic;


namespace Invisible_Edges
{
    class Figure
    {
        private (List<Point>, List<int[]>) figure;
        private List<Point> stdPoints;
        private Point shift = new Point(0, 0, 0);
        private Point stdShift;
        public List<double[]> areas = new List<double[]>();
        public double[,] grani;


        public Figure(List<Point> points, List<int[]> edges, List<double[]> areas, Point sh, int siz = 1)
        {
            AddShift(sh);
            stdShift = new Point(sh.coords);

            for (int i = 0; i < points.Count; i++)
            {
                points[i] *= siz;
                points[i] += shift;
            }

            figure = (points, edges);

            if (areas.Count == 0)
                makeAreas();
            else
                this.areas = new List<double[]>(areas);

            stdPoints = new List<Point>(points);
        }

        public List<Point> points
        {
            set { figure.Item1 = points; }

            get { return figure.Item1; }
        }

        public List<int[]> edges
        {
            set { figure.Item2 = edges; }

            get { return figure.Item2; }
        }

        public void AddShift(Point sh)
        {
            shift += sh;
        }

        public void Changes(double[,] matrix)
        {
            AddShift(new Point(matrix[3, 0], matrix[3, 1], matrix[3, 2]));

            for (int i = 0; i < figure.Item1.Count; i++)
            {
                figure.Item1[i] = Matrix.Multiplicate(figure.Item1[i], Matrix.GetCenterMatrix(-shift));
                figure.Item1[i] = Matrix.Multiplicate(figure.Item1[i], matrix);
                figure.Item1[i] = Matrix.Multiplicate(figure.Item1[i], Matrix.GetCenterMatrix(shift));
            }

            if (areas.Count != 3)
                makeAreas();
        }

        public List<Point> Project()
        {
            List<Point> projectFigurePoints = new List<Point>();

            foreach (var point in figure.Item1)
            {
                projectFigurePoints.Add(Matrix.Multiplicate(point, Matrix.projection));
            }

            return projectFigurePoints;
        }

        public void ToBegining()
        {
            figure.Item1 = new List<Point>(stdPoints);
            shift = new Point(stdShift.coords);
            makeAreas();
        }

        private void makeAreas()
        {
            areas.Clear();
            areas.Add(GetArea(figure.Item1[0], figure.Item1[1], figure.Item1[2]));
            areas.Add(GetArea(figure.Item1[0], figure.Item1[1], figure.Item1[3]));
            areas.Add(GetArea(figure.Item1[0], figure.Item1[2], figure.Item1[3]));
            areas.Add(GetArea(figure.Item1[2], figure.Item1[4], figure.Item1[6]));
            areas.Add(GetArea(figure.Item1[1], figure.Item1[4], figure.Item1[5]));
            areas.Add(GetArea(figure.Item1[3], figure.Item1[5], figure.Item1[6]));

            Point centerPoint = FindFigureCenter();

            for (int i = 0; i < areas.Count; i++)
            {
                if (Matrix.ScalarMul(centerPoint.coords, areas[i]) > 0)
                {
                    for (int j = 0; j < areas[i].Length; j++)
                        areas[i][j] *= -1;
                }
            }
        }

        private double[] GetArea(Point p1, Point p2, Point p3)
        {
            double A = p1.y * (p2.z - p3.z) + p2.y * (p3.z - p1.z) + p3.y * (p1.z - p2.z);
            double B = p1.z * (p2.x - p3.x) + p2.z * (p3.x - p1.x) + p3.z * (p1.x - p2.x);
            double C = p1.x * (p2.y - p3.y) + p2.x * (p3.y - p1.y) + p2.x * (p1.y - p2.y);
            double D = -(p1.x * (p2.y * p3.z - p3.y * p2.z) + p2.x * (p3.y * p1.z - p1.y * p3.z) + p3.x * (p1.y * p2.z - p2.y * p1.z));

            return new double[] { A, B, C, D };
        }

        private Point FindFigureCenter()
        {
            double centerX = (figure.Item1[1].x - figure.Item1[0].x) / 2;
            double centerY = (figure.Item1[2].y - figure.Item1[0].y) / 2;
            double centerZ = (figure.Item1[3].z - figure.Item1[0].z) / 2;

            return new Point(centerX, centerY, centerZ);
        }

        public List<double[]> GetFrontalAreas()
        {
            List<double[]> frontalAreas = new List<double[]>();
            double[] visitorNormal = new double[] { 1, 1, 1, 0};

            for (int i = 0; i < areas.Count; i++)
                if (Matrix.ScalarMul(areas[i], visitorNormal) > 0)
                    frontalAreas.Add(areas[i]);

            return frontalAreas;
        }
    }
}
