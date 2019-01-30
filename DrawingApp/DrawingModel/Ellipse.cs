using System;
using System.Collections.Generic;
using System.Text;

namespace DrawingModel
{
    class Ellipse : Shape
    {
        public Ellipse()
        {
        }

        public Ellipse(double x1, double y1, double x2, double y2) : base(x1, y1, x2, y2)
        {
        }

        // 畫鑽石
        public override void Draw(IGraphics graphics)
        {
            if (IsSelected)
                graphics.DrawWrappedEllipse(X1, Y1, X2, Y2);
            else
                graphics.DrawEllipse(X1, Y1, X2, Y2);
        }

        // 判斷是否穿越點
        public override bool IsAcross(double pointX, double pointY)
        {
            const double MIN_DISTANCE = 1.05;
            const double TWO = 2;
            double centerX = (X1 + X2) / TWO;
            double centerY = (Y1 + Y2) / TWO;
            double xRadius = Math.Abs(centerX - X1);
            double yRadius = Math.Abs(centerY - Y1);
            double normalX = pointX - centerX;
            double normalY = pointY - centerY;
            double distance = ((normalX * normalX) / (xRadius * xRadius)) + ((normalY * normalY) / (yRadius * yRadius));
            return distance <= MIN_DISTANCE; //MIN_DISTANCE decides how is sensitive.
        }
    }
}
