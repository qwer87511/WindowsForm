using System;
using System.Collections.Generic;
using System.Text;

namespace DrawingModel
{
    public class DrawingState : IState
    {
        public event ShapesListChangedEventHandler _shapesListChanged;

        private Model _model;
        private CommandManager _commandManager;

        private List<Shape> _shapesList;
        private Shape _hint;

        private double _firstPointX;
        private double _firstPointY;
        private bool _isPressed;

        public DrawingState(Model model, CommandManager commandManager, List<Shape> shapesList, ref bool isPressed)
        {
            _model = model;
            _commandManager = commandManager;
            _shapesList = shapesList;
            _isPressed = isPressed;
        }

        // 通知ShapesList變更
        private void NotifyShapesListChanged()
        {
            if (_shapesListChanged != null)
            {
                _shapesListChanged();
            }
        }

        // 按下滑鼠
        public void PressPointer(double pointX, double pointY)
        {
            if (pointX > 0 && pointY > 0)
            {
                _hint.X1 = _hint.X2 = _firstPointX = pointX;
                _hint.Y1 = _hint.Y2 = _firstPointY = pointY;
                _isPressed = true;
            }
        }

        // 移動滑鼠
        public void MovePointer(double pointX, double pointY)
        {
            if (_isPressed)
            {
                _hint.X2 = pointX;
                _hint.Y2 = pointY;
                NotifyShapesListChanged();
            }
        }

        // 放開滑鼠
        public void ReleasePointer(double pointX, double pointY)
        {
            if (_isPressed)
            {
                _commandManager.Execute(new DrawCommand(_model, _hint));
                _isPressed = false;
                _hint = null;
            }
        }

        public Shape Hint
        {
            set
            {
                _hint = value;
            }
            get
            {
                return _hint;
            }
        }
    }
}
