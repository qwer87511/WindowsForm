using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingModel
{
    public abstract class Shape 
    {
        public double X1
        {
            set;
            get;
        }
        public double Y1
        {
            set;
            get;
        }
        public double X2
        {
            set;
            get;
        }
        public double Y2
        {
            set;
            get;
        }
        public bool IsSelected
        {
            set;
            get;
        }

        public Shape()
        {
        }

        public Shape(double x1, double y1, double x2, double y2)
        {
            this.X1 = x1;
            this.Y1 = y1;
            this.X2 = x2;
            this.Y2 = y2;
        }

        // 畫線
        public abstract void Draw(IGraphics graphics);

        // 判斷是否穿越點
        public abstract bool IsAcross(double pointX, double pointY);
    }
}
