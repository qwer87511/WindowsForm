using System;
using System.Collections.Generic;
using System.Text;

namespace DrawingModel
{
    public class Diamond : Shape
    {
        public Diamond()
        {
        }

        public Diamond(double x1, double y1, double x2, double y2) : base(x1, y1, x2, y2)
        {
        }

        // 畫鑽石
        public override void Draw(IGraphics graphics)
        {
            if (IsSelected)
                graphics.DrawWrappedDiamond(X1, Y1, X2, Y2);
            else
                graphics.DrawDiamond(X1, Y1, X2, Y2);
        }

        // 判斷是否穿越點
        public override bool IsAcross(double pointX, double pointY)
        {
            const int TWO = 2;
            double weight = Math.Abs(X1 - X2);
            double height = Math.Abs(Y1 - Y2);
            pointX = pointX - (X1 + X2) / TWO;
            pointY = pointY - (Y1 + Y2) / TWO;
            return Math.Abs(pointX * height) + Math.Abs(pointY * weight) <= height * weight / TWO;
        }
    }
}
