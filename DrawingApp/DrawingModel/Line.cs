using System;

namespace DrawingModel
{
    public class Line : Shape
    {
        public Line()
        {
        }

        public Line(double x1, double y1, double x2, double y2) : base(x1, y1, x2, y2)
        {
        }

        // 畫線
        public override void Draw(IGraphics graphics)
        {
            if (IsSelected)
                graphics.DrawWrappedLine(X1, Y1, X2, Y2);
            else
                graphics.DrawLine(X1, Y1, X2, Y2);
        }

        // 判斷是否穿越點
        public override bool IsAcross(double pointX, double pointY)
        {
            const double MIN_DISTANCE = 8;
            double x2MinusX1 = X2 - X1;
            double y2MinusY1 = Y2 - Y1;
            double upper = Math.Abs(x2MinusX1 * (Y1 - pointY) - (X1 - pointX) * y2MinusY1);
            double lower = Math.Sqrt(x2MinusX1 * x2MinusX1 + y2MinusY1 * y2MinusY1);
            return (upper / lower) < MIN_DISTANCE; //MIN_DISTANCE decides how is sensitive.
        }
    }
}
