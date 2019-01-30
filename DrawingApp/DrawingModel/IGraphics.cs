using System;
using System.Collections.Generic;
using System.Text;

namespace DrawingModel
{
    public interface IGraphics
    {
        // 清除
        void ClearAll();

        // 畫線
        void DrawLine(double x1, double y1, double x2, double y2);

        // 畫被包裹的線
        void DrawWrappedLine(double x1, double y1, double x2, double y2);

        // 畫鑽石
        void DrawDiamond(double x1, double y1, double x2, double y2);

        // 畫被包裹的鑽石
        void DrawWrappedDiamond(double x1, double y1, double x2, double y2);

        // 畫橢圓
        void DrawEllipse(double x1, double y1, double x2, double y2);

        // 畫被包裹的橢圓
        void DrawWrappedEllipse(double x1, double y1, double x2, double y2);
    }
}
