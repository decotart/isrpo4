using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace isrpo4
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            GlobalData.ElementColor = Brushes.Black;
        }

        private void btnPickElement_Click(object sender, RoutedEventArgs e)
        {
            GlobalData.isSuccessful = false;

            ElementPicker temp = new();
            temp.ShowDialog();

            if (GlobalData.isSuccessful)
            {
                DrawElement();
            }
        }

        private void btnPickSize_Click(object sender, RoutedEventArgs e)
        {
            GlobalData.isSuccessful = false;

            SizePicker temp = new();
            temp.ShowDialog();

            if (GlobalData.isSuccessful)
            {
                DrawElement();
            }
        }

        private void btnPickColor_Click(object sender, RoutedEventArgs e)
        {
            GlobalData.isSuccessful = false;

            ColorPicker temp = new();
            temp.ShowDialog();

            if (GlobalData.isSuccessful)
            {
                DrawElement();
            }
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void DrawElement()
        {
            mainCanvas.Children.Clear();

            switch (GlobalData.ElementId)
            {
                case 0:
                    DrawFractalTree();
                    break;

                case 1:
                    DrawKochCurve();
                    break;

                case 2:
                    DrawSierpinskiCarpet();
                    break;

                case 3:
                    DrawSierpinskiTriangle();
                    break;

                case 4:
                    DrawCantorSet();
                    break;
            }
        }

        private void DrawFractalTree()
        {
            Point startPoint = new Point(mainCanvas.ActualWidth / 2, mainCanvas.ActualHeight);
            Point endPoint = new Point(startPoint.X, startPoint.Y - 100);

            DrawBranch(startPoint, endPoint, GlobalData.ElementSize);
        }

        private void DrawBranch(Point start, Point end, int steps)
        {
            if (steps == 0) return;

            Line line = new Line
            {
                X1 = start.X,
                Y1 = start.Y,
                X2 = end.X,
                Y2 = end.Y,
                Stroke = GlobalData.ElementColor,
                StrokeThickness = 2
            };

            mainCanvas.Children.Add(line);

            Vector direction = end - start;

            double angle = 30.0 * Math.PI / 180.0;
            Point leftEnd = new Point(
                end.X + direction.X * Math.Cos(-angle) - direction.Y * Math.Sin(-angle),
                end.Y + direction.X * Math.Sin(-angle) + direction.Y * Math.Cos(-angle));

            DrawBranch(end, leftEnd, steps - 1);

            Point rightEnd = new Point(
                end.X + direction.X * Math.Cos(angle) - direction.Y * Math.Sin(angle),
                end.Y + direction.X * Math.Sin(angle) + direction.Y * Math.Cos(angle));

            DrawBranch(end, rightEnd, steps - 1);

            GlobalData.GradientId++;
        }

        private void DrawKochCurve()
        {
            Point endPoint = new Point(50, mainCanvas.ActualHeight / 2);
            Point startPoint = new Point(mainCanvas.ActualWidth - 50, mainCanvas.ActualHeight / 2);

            DrawKochSegment(startPoint, endPoint, GlobalData.ElementSize);
        }

        private void DrawKochSegment(Point p0, Point p1, int steps)
        {
            if (steps == 0)
            {
                Line line = new Line
                {
                    X1 = p0.X,
                    Y1 = p0.Y,
                    X2 = p1.X,
                    Y2 = p1.Y,
                    Stroke = GlobalData.ElementColor,
                    StrokeThickness = 2
                };

                mainCanvas.Children.Add(line);
            }
            else
            {
                Point p2 = new Point((2 * p0.X + 1 * p1.X) / 3, (2 * p0.Y + 1 * p1.Y) / 3);
                Point p3 = new Point((1 * p0.X + 2 * p1.X) / 3, (1 * p0.Y + 2 * p1.Y) / 3);

                Point peak = new Point(
                    (p2.X + p3.X) / 2 - Math.Sqrt(3) * (p3.Y - p2.Y) / 2,
                    (p2.Y + p3.Y) / 2 + Math.Sqrt(3) * (p3.X - p2.X) / 2
                );

                DrawKochSegment(p0, p2, steps - 1);
                DrawKochSegment(p2, peak, steps - 1);
                DrawKochSegment(peak, p3, steps - 1);
                DrawKochSegment(p3, p1, steps - 1);

                GlobalData.GradientId++;
            }
        }

        private void DrawSierpinskiCarpet()
        {
            double size = 400;
            Point topLeft = new Point((mainCanvas.ActualWidth - size) / 2, (mainCanvas.ActualHeight - size) / 2);

            DrawCarpet(topLeft, size, GlobalData.ElementSize);
        }

        private void DrawCarpet(Point topLeft, double size, int steps)
        {
            if (steps == 0)
            {
                Rectangle rectangle = new Rectangle
                {
                    Width = size,
                    Height = size,
                    Fill = GlobalData.ElementColor
                };

                Canvas.SetLeft(rectangle, topLeft.X);
                Canvas.SetTop(rectangle, topLeft.Y);
                mainCanvas.Children.Add(rectangle);

                GlobalData.GradientId++;
            }
            else
            {
                double newSize = size / 3;

                DrawCarpet(topLeft, newSize, steps - 1);
                DrawCarpet(new Point(topLeft.X + newSize, topLeft.Y), newSize, steps - 1);
                DrawCarpet(new Point(topLeft.X + 2 * newSize, topLeft.Y), newSize, steps - 1);

                DrawCarpet(new Point(topLeft.X, topLeft.Y + newSize), newSize, steps - 1);
                DrawCarpet(new Point(topLeft.X + 2 * newSize, topLeft.Y + newSize), newSize, steps - 1);

                DrawCarpet(new Point(topLeft.X, topLeft.Y + 2 * newSize), newSize, steps - 1); 
                DrawCarpet(new Point(topLeft.X + newSize, topLeft.Y + 2 * newSize), newSize, steps - 1);
                DrawCarpet(new Point(topLeft.X + 2 * newSize, topLeft.Y + 2 * newSize), newSize, steps - 1);

                GlobalData.GradientId++;
            }
        }

        private void DrawSierpinskiTriangle()
        {
            Point topPoint = new Point(mainCanvas.ActualWidth / 2, 50);
            Point leftPoint = new Point(50, mainCanvas.ActualHeight - 50);
            Point rightPoint = new Point(mainCanvas.ActualWidth - 50, mainCanvas.ActualHeight - 50);

            DrawTriangle(GlobalData.ElementSize, topPoint, leftPoint, rightPoint);
        }

        private void DrawTriangle(int steps, Point top, Point left, Point right)
        {
            if (steps == 0)
            {
                Polygon triangle = new Polygon
                {
                    Points = new PointCollection { top, left, right },
                    Fill = GlobalData.ElementColor
                };
                mainCanvas.Children.Add(triangle);

                GlobalData.GradientId++;
            }
            else
            {
                Point midLeft = Midpoint(top, left);
                Point midRight = Midpoint(top, right);
                Point midBottom = Midpoint(left, right);

                DrawTriangle(steps - 1, top, midLeft, midRight);
                DrawTriangle(steps - 1, left, midLeft, midBottom);
                DrawTriangle(steps - 1, right, midRight, midBottom);

                GlobalData.GradientId++;
            }
        }

        private Point Midpoint(Point p1, Point p2)
        {
            return new Point((p1.X + p2.X) / 2, (p1.Y + p2.Y) / 2);
        }

        private void DrawCantorSet()
        {
            double startX = mainCanvas.ActualWidth / 4;
            double startY = mainCanvas.ActualHeight / 4;
            double length = mainCanvas.ActualWidth / 2;

            DrawCantorSegment(startX, startY, length, GlobalData.ElementSize);
        }

        private void DrawCantorSegment(double startX, double startY, double length, int steps)
        {
            if (steps == 0) return;

            Line line = new Line
            {
                X1 = startX,
                Y1 = startY,
                X2 = startX + length,
                Y2 = startY,
                Stroke = GlobalData.ElementColor,
                StrokeThickness = 2
            };

            mainCanvas.Children.Add(line);

            double newLength = length / 3;

            DrawCantorSegment(startX, startY + 20, newLength, steps - 1);
            DrawCantorSegment(startX + 2 * newLength, startY + 20, newLength, steps - 1);

            GlobalData.GradientId++;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e) => DrawElement();
    }
}