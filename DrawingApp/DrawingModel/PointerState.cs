using System;
using System.Collections.Generic;
using System.Text;

namespace DrawingModel
{
    public class PointerState : IState
    {
        public event ShapesListChangedEventHandler _shapesListChanged;

        private Model _model;
        private CommandManager _commandManager;
        private MoveCommand _moveCommand;

        private List<Shape> _shapesList;

        private bool _isPressed;

        private Shape _selectedShape;
        private bool _isSelectedShape;
        private double _pressedX;
        private double _pressedY;

        public PointerState(Model model, CommandManager commandManager, List<Shape> shapesList, ref bool isPressed)
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
            _selectedShape = _shapesList.FindLast(i => i.IsAcross(pointX, pointY));
            if (_selectedShape != null)
            {
                _moveCommand = new MoveCommand(_model, _selectedShape);
                _pressedX = pointX;
                _pressedY = pointY;
                _isSelectedShape = true;
                _selectedShape.IsSelected = true;
                NotifyShapesListChanged();
            }
        }

        // 移動滑鼠
        public void MovePointer(double pointX, double pointY)
        {
            if (_isSelectedShape)
            {
                double deltaX = pointX - _pressedX;
                double deltaY = pointY - _pressedY;
                _pressedX = pointX;
                _pressedY = pointY;
                _selectedShape.X1 += deltaX;
                _selectedShape.Y1 += deltaY;
                _selectedShape.X2 += deltaX;
                _selectedShape.Y2 += deltaY;
                NotifyShapesListChanged();
            }
        }

        // 放開滑鼠
        public void ReleasePointer(double pointX, double pointY)
        {
            if (_isSelectedShape)
            {
                _moveCommand.SetDestination(_selectedShape.X1, _selectedShape.Y1, _selectedShape.X2, _selectedShape.Y2);
                _commandManager.Execute(_moveCommand);
                _selectedShape.IsSelected = false;
                _selectedShape = null;
                _isSelectedShape = false;
                NotifyShapesListChanged();
            }
        }
    }
}
