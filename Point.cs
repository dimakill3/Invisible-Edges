namespace Invisible_Edges
{
    public class Point
    {
        public double x;
        public double y;
        public double z;

        private double k = 1f;

        public Point(double _x, double _y, double _z)
        {
            x = _x; y = _y; z = _z;
        }

        public Point(double[] coords)
        {
            x = coords[0]; y = coords[1]; z = coords[2]; k = coords[3];
        }

        public double[] coords
        {
            set { x = coords[0]; y = coords[1]; z = coords[2]; k = coords[3]; }

            get { return new double[] { x, y, z, k }; }
        }

        public static Point operator *(Point p, int k)
        {
            return new Point(p.x * k, p.y * k, p.z * k);
        }

        public static Point operator +(Point p, int k)
        {
            return new Point(p.x + k, p.y + k, p.z + k);
        }

        public static Point operator +(Point p1, Point p2)
        {
            return new Point(p1.x + p2.x, p1.y + p2.y, p1.z + p2.z);
        }

        public static Point operator -(Point p)
        {
            return new Point(-p.x, -p.y, -p.z);
        }
    }
}
