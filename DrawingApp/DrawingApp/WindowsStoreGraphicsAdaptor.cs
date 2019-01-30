using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using DrawingModel;
using Windows.Foundation;

namespace DrawingApp
{
    public class WindowsStoreGraphicsAdaptor : IGraphics
    {
        Canvas _canvas;

        public WindowsStoreGraphicsAdaptor(Canvas canvas)
        {
            this._canvas = canvas;
        }

        // 清除
        public void ClearAll()
        {
            _canvas.Children.Clear();
        }

        // 畫線
        public void DrawLine(double x1, double y1, double x2, double y2)
        {
            DrawLine(Colors.Black, x1, y1, x2, y2);
        }

        // 畫被包裹的縣
        public void DrawWrappedLine(double x1, double y1, double x2, double y2)
        {
            DrawLine(Colors.Red, x1, y1, x2, y2);
        }

        // 畫鑽石
        public void DrawDiamond(double x1, double y1, double x2, double y2)
        {
            DrawDiamond(Colors.Black, x1, y1, x2, y2);
        }

        // 畫被包裹的鑽石
        public void DrawWrappedDiamond(double x1, double y1, double x2, double y2)
        {
            DrawDiamond(Colors.Red, x1, y1, x2, y2);
        }

        // 畫橢圓
        public void DrawEllipse(double x1, double y1, double x2, double y2)
        {
            DrawEllipse(Colors.Black, x1, y1, x2, y2);
        }

        // 畫被包裹的橢圓
        public void DrawWrappedEllipse(double x1, double y1, double x2, double y2)
        {
            DrawEllipse(Colors.Red, x1, y1, x2, y2);
        }

        // 畫線
        private void DrawLine(Color color, double x1, double y1, double x2, double y2)
        {
            Windows.UI.Xaml.Shapes.Line line = new Windows.UI.Xaml.Shapes.Line();
            line.X1 = x1;
            line.Y1 = y1;
            line.X2 = x2;
            line.Y2 = y2;
            line.Stroke = new SolidColorBrush(color);
            _canvas.Children.Add(line);
        }

        // 畫鑽石
        public void DrawDiamond(Color color, double x1, double y1, double x2, double y2)
        {
            const int TWO = 2;
            const int MARGIN = 25;
            Windows.UI.Xaml.Shapes.Polygon polygon = new Windows.UI.Xaml.Shapes.Polygon();
            PointCollection points = new PointCollection();
            points.Add(new Point((x1 + x2) / TWO, y1));
            points.Add(new Point(x2, (y1 + y2) / TWO));
            points.Add(new Point((x1 + x2) / TWO, y2));
            points.Add(new Point(x1, (y1 + y2) / TWO));
            polygon.Points = points;
            polygon.Margin = new Windows.UI.Xaml.Thickness(MARGIN);
            polygon.Fill = new SolidColorBrush(Colors.Yellow);
            polygon.Stroke = new SolidColorBrush(color);
            _canvas.Children.Add(polygon);
        }

        // 畫橢圓
        public void DrawEllipse(Color color, double x1, double y1, double x2, double y2)
        {
            Windows.UI.Xaml.Shapes.Ellipse ellipse = new Windows.UI.Xaml.Shapes.Ellipse();
            ellipse.Height = Math.Abs(y2 - y1);
            ellipse.Width = Math.Abs(x2 - x1);
            ellipse.Margin = new Windows.UI.Xaml.Thickness(Math.Min(x1, x2), Math.Min(y1, y2), 0, 0);
            ellipse.Fill = new SolidColorBrush(Colors.Yellow);
            ellipse.Stroke = new SolidColorBrush(color);
            _canvas.Children.Add(ellipse);
        }
    }
}
