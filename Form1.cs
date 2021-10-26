using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;


namespace Invisible_Edges
{
    public partial class MainForm : Form
    {
        // Размер фигуры
        private Random size = new Random();

        private List<Figure> figures = new List<Figure>();

        private Figure axis;

        private int curF;

        public MainForm()
        {
            InitializeComponent();

            axis = new Figure(Figures.axisPoints, Figures.axisEdges, Figures.axisAreas, new Point(0, 0, 0));

            axis.Changes(Matrix.projection);

            figures.Add(new Figure(new List<Point>(Figures.cubePoints), Figures.cubeEdges, new List<double[]> { }, new Point(0, 0, 0), size.Next(40, 60)));
            //figures.Add(new Figure(new List<Point>(Figures.tetraedrPoints), Figures.tetraedrEdges, new Point(60, 0, 0), size.Next(40, 60)));
            //figures.Add(new Figure(new List<Point>(Figures.tetraPoints), Figures.tetraEdges, new Point(0, 60, 0), size.Next(40, 60)));
            //figures.Add(new Figure(new List<Point>(Figures.cubePoints), Figures.cubeEdges, new Point(0, 0, 60), size.Next(40, 60)));
            //figures.Add(new Figure(new List<Point>(Figures.tetraPoints), Figures.tetraEdges, new Point(120, 120, 0), size.Next(40, 60)));

            curF = 0;
        }

        private void Paint(PaintEventArgs e, List<int[]> edges, List<Point> points, Pen pen)
        {
            foreach (var edge in edges)
            {
                Point p1 = points[edge[0]], p2 = points[edge[1]];

                e.Graphics.DrawLine(pen,
                    Math.Abs(DrawPanel.Size.Width / 2 + (float)p1.coords[0]),
                    Math.Abs(DrawPanel.Size.Height / 2 - (float)p1.coords[1]),
                    Math.Abs(DrawPanel.Size.Width / 2 + (float)p2.coords[0]),
                    Math.Abs(DrawPanel.Size.Height / 2 - (float)p2.coords[1]));
            }
        }

        private void DrawPanel_Paint(object sender, PaintEventArgs e)
        {
            // Очищаем панель
            e.Graphics.Clear(Color.White);

            List<int[]> visibleEdges = new List<int[]>();

            List<double[]> frontalAreas = new List<double[]>();
            frontalAreas.AddRange(figures[curF].GetFrontalAreas());

            // Задаём три карандаша - для осей, для выбранной фигуры и для остальных фигур
            Pen figurePen = new Pen(Color.Black, 2);
            Pen curFigurePen = new Pen(Color.Red, 2);
            Pen axisPen = new Pen(Color.Green, 2);

            foreach (int[] edge in axis.edges)
            {
                visibleEdges.Add(edge);
            }

            foreach (int[] edge in figures[curF].edges)
            {
                visibleEdges.Add(edge);
            }

            int i = 0;
            while(i != visibleEdges.Count)
            {

            }

            /*// Отрисовываем оси
            Paint(e, axis.edges, axis.points, axisPen);

            // Проецируем фигуры на 2D
            for (int i = 0; i < figures.Count; i++)
            {
                // Проекция фигуры
                List<Point> projectFigurePoints = figures[i].Project();

                // Отрисовываем фигуру
                if (i == curF)
                    Paint(e, figures[i].edges, projectFigurePoints, curFigurePen);
                else
                    Paint(e, figures[i].edges, projectFigurePoints, figurePen);
            }*/
        }

        private void Animation()
        {
            double[,] jump = new double[4, 4];
            Array.Copy(Matrix.moveUp, jump, 16);

            double force = 4;
            int count = 3;

            while (force >= -4)
            {
                jump[3, 1] = force;
                for (int k = 0; k < count; k++)
                {
                    figures[curF].Changes(jump);
                    DrawPanel.Refresh();
                }

                force--;
            }
        }

        private void DoSmth(double[,] matrix)
        {
            figures[curF].Changes(matrix);
            DrawPanel.Refresh();
        }

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.W:
                    switch (e.Modifiers)
                    {
                        case Keys.Shift:
                            DoSmth(Matrix.moveFrom);
                            break;

                        case Keys.Control:
                            DoSmth(Matrix.rotationXPlus);
                            break;
                        case Keys.Alt:
                            DoSmth(Matrix.compressionYPlus);
                            break;
                        default:
                            DoSmth(Matrix.moveUp);
                            break;
                    }
                    break;
                case Keys.S:
                    switch (e.Modifiers)
                    {
                        case Keys.Shift:
                            DoSmth(Matrix.moveTo);
                            break;

                        case Keys.Control:
                            DoSmth(Matrix.rotationXMinus);
                            break;
                        case Keys.Alt:
                            DoSmth(Matrix.compressionYMinus);
                            break;
                        default:
                            DoSmth(Matrix.moveDown);
                            break;
                    }
                    break;
                case Keys.A:
                    switch (e.Modifiers)
                    {
                        case Keys.Control:
                            DoSmth(Matrix.rotationYPlus);
                            break;
                        case Keys.Alt:
                            DoSmth(Matrix.compressionXMinus);
                            break;
                        default:
                            DoSmth(Matrix.moveLeft);
                            break;
                    }
                    break;
                case Keys.D:
                    switch (e.Modifiers)
                    {
                        case Keys.Control:
                            DoSmth(Matrix.rotationYMinus);
                            break;
                        case Keys.Alt:
                            DoSmth(Matrix.compressionXPlus);
                            break;
                        default:
                            DoSmth(Matrix.moveRight);
                            break;
                    }
                    break;
                case Keys.R:
                    figures[curF].ToBegining();
                    DrawPanel.Refresh();
                    break;
                case Keys.Q:
                    switch (e.Modifiers)
                    {
                        case Keys.Control:
                            DoSmth(Matrix.rotationZPlus);
                            break;
                        case Keys.Alt:
                            DoSmth(Matrix.compressionZPlus);
                            break;
                        default:
                            break;
                    }
                    break;
                case Keys.E:
                    switch (e.Modifiers)
                    {
                        case Keys.Control:
                            DoSmth(Matrix.rotationZMinus);
                            break;
                        case Keys.Alt:
                            DoSmth(Matrix.compressionZMinus);
                            break;
                        default:
                            break;
                    }
                    break;
                case Keys.J:
                    DoSmth(Matrix.MatrixMirrorXY);
                    break;
                case Keys.K:
                    DoSmth(Matrix.MatrixMirrorYZ);
                    break;
                case Keys.L:
                    DoSmth(Matrix.MatrixMirrorXZ);
                    break;
                case Keys.Space:
                    Animation();
                    break;
                case Keys.C:
                    if (curF + 1 < figures.Count)
                        curF++;
                    else
                        curF = 0;
                    DrawPanel.Refresh();
                    break;
                default:
                    break;
            }
        }
    }
}
