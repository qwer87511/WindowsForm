using System;
using System.Collections.Generic;
using System.Text;

namespace DrawingModel
{
    public delegate void ShapesListChangedEventHandler();

    public interface IState
    {
        event ShapesListChangedEventHandler _shapesListChanged;

        // 按下滑鼠
        void PressPointer(double pointX, double pointY);

        // 移動滑鼠
        void MovePointer(double pointX, double pointY);

        // 放開滑鼠
        void ReleasePointer(double pointX, double pointY);
    }
}
