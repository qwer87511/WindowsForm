using DrawingModel;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingForm
{
    public class WindowsFormsGraphicsAdapter : IGraphics
    {
        Graphics _graphics;

        public WindowsFormsGraphicsAdapter(Graphics graphics)
        {
            _graphics = graphics;
        }

        // 清空圖
        public void ClearAll()
        {
            // OnPaint時會自動清除畫面，因此不需實作
        }

        // 畫線
        public void DrawLine(double x1, double y1, double x2, double y2)
        {
            DrawLine(Color.Black, x1, y1, x2, y2);
        }

        // 畫被包裹的線
        public void DrawWrappedLine(double x1, double y1, double x2, double y2)
        {
            DrawLine(Color.Red, x1, y1, x2, y2);
        }

        // 畫鑽石
        public void DrawDiamond(double x1, double y1, double x2, double y2)
        {
            DrawDiamond(Color.Black, x1, y1, x2, y2);
        }

        // 畫被包裹的鑽石
        public void DrawWrappedDiamond(double x1, double y1, double x2, double y2)
        {
            DrawDiamond(Color.Red, x1, y1, x2, y2);
        }

        // 畫橢圓
        public void DrawEllipse(double x1, double y1, double x2, double y2)
        {
            DrawEllipse(Color.Black, x1, y1, x2, y2);
        }

        // 畫被包裹的橢圓
        public void DrawWrappedEllipse(double x1, double y1, double x2, double y2)
        {
            DrawEllipse(Color.Red, x1, y1, x2, y2);
        }

        // 畫線
        private void DrawLine(Color edgeColor, double x1, double y1, double x2, double y2)
        {
            _graphics.DrawLine(new Pen(edgeColor), (float)x1, (float)y1, (float)x2, (float)y2);
        }

        // 畫鑽石
        private void DrawDiamond(Color edgeColor, double x1, double y1, double x2, double y2)
        {
            const int TWO = 2;
            Point[] points = { new Point((int)(x1 + x2) / TWO, (int)y1), new Point((int)x2, (int)(y1 + y2) / TWO), new Point((int)(x1 + x2) / TWO, (int)y2), new Point((int)x1, (int)(y1 + y2) / TWO) };
            _graphics.FillPolygon(Brushes.Yellow, points);
            _graphics.DrawPolygon(new Pen(edgeColor), points);
        }

        // 畫橢圓
        private void DrawEllipse(Color edgeColor, double x1, double y1, double x2, double y2)
        {
            float ellipseX = (float)x1;
            float ellipseY = (float)y1;
            float width = (float)(x2 - x1);
            float height = (float)(y2 - y1);
            _graphics.FillEllipse(Brushes.Yellow, ellipseX, ellipseY, width, height);
            _graphics.DrawEllipse(new Pen(edgeColor), ellipseX, ellipseY, width, height);
        }
    }
}
