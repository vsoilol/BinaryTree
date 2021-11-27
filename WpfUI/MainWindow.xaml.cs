using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Ellipse elip = new Ellipse();
        private Point anchorPoint;

        public MainWindow()
        {
            InitializeComponent();
            /*    canvas.MouseMove += canvas_MouseMove;
                canvas.MouseUp += canvas_MouseUp;
                canvas.MouseDown += canvas_MouseDown;*/

            DrawRectWithText();
        }

        private void canvas_MouseDown(object sender, MouseButtonEventArgs e)
        {
            //capture the mouse on the canvas
            //(this also helps us keep track of whether or not we're drawing)
            canvas.CaptureMouse();

            anchorPoint = e.MouseDevice.GetPosition(canvas);
            elip = new Ellipse
            {
                Stroke = Brushes.Black,
                StrokeThickness = 2
            };
            
            canvas.Children.Add(elip);
        }

        internal void DrawRectWithText()
        {
            var rect = new Rectangle();
            rect.Stroke = new SolidColorBrush(Colors.Black);
            rect.Fill = new SolidColorBrush(Colors.Beige);

            rect.Width = 100;
            rect.Height = 100;

            elip = new Ellipse
            {
                Stroke = Brushes.Black,
                StrokeThickness = 2,
                Width = 100,
                Height = 100,
            };

            // Use Canvas's static methods to position the rectangle
            Canvas.SetLeft(rect, 100);
            //Canvas.SetTop(rect, 100);

            var text = new TextBlock()
            {
                Text = "21",
            };

            // Use Canvas's static methods to position the text
            Canvas.SetLeft(text, 90);
            Canvas.SetTop(text, 90);

            // Draw the rectange and the text to my Canvas control.
            // DrawCanvas is the name of my Canvas control in the XAML code
            canvas.Children.Add(rect);
            canvas.Children.Add(text);
        }

        private void canvas_MouseMove(object sender, MouseEventArgs e)
        {
            //if we are not drawing, we don't need to do anything when the mouse moves
            if (!canvas.IsMouseCaptured)
                return;

            Point location = e.MouseDevice.GetPosition(canvas);

            double minX = Math.Min(location.X, anchorPoint.X);
            double minY = Math.Min(location.Y, anchorPoint.Y);
            double maxX = Math.Max(location.X, anchorPoint.X);
            double maxY = Math.Max(location.Y, anchorPoint.Y);

            Canvas.SetTop(elip, minY);
            Canvas.SetLeft(elip, minX);

            double height = maxY - minY;
            double width = maxX - minX;

            elip.Height = Math.Abs(height);
            elip.Width = Math.Abs(width);
        }

        private void canvas_MouseUp(object sender, MouseButtonEventArgs e)
        {
            // we are now no longer drawing
            canvas.ReleaseMouseCapture();
        }
    }
}