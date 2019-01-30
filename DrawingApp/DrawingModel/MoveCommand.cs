using System;
using System.Collections.Generic;
using System.Text;

namespace DrawingModel
{
    public class MoveCommand : ICommand
    {
        private Model _model;
        private Shape _shape;
        private double _originX1;
        private double _originY1;
        private double _originX2;
        private double _originY2;
        private double _destinationX1;
        private double _destinationY1;
        private double _destinationX2;
        private double _destinationY2;

        public MoveCommand(Model model, Shape shape)
        {
            _model = model;
            _shape = shape;
            _originX1 = shape.X1;
            _originY1 = shape.Y1;
            _originX2 = shape.X2;
            _originY2 = shape.Y2;
        }

        // 設定目的
        public void SetDestination(double destinationX1, double destinationY1, double destinationX2, double destinationY2)
        {
            _destinationX1 = destinationX1;
            _destinationY1 = destinationY1;
            _destinationX2 = destinationX2;
            _destinationY2 = destinationY2;
        }

        // 移動到目的
        public void Execute()
        {
            _model.MoveShape(_shape, _destinationX1, _destinationY1, _destinationX2, _destinationY2);
        }

        // 回到原點
        public void UndoExecute()
        {
            _model.MoveShape(_shape, _originX1, _originY1, _originX2, _originY2);
        }
    }
}
