using System;
using System.Collections.Generic;
using System.Text;

namespace DrawingModel
{
    public class DrawCommand : ICommand
    {
        private Model _model;
        private Shape _shape;

        public DrawCommand(Model model, Shape shape)
        {
            _model = model;
            _shape = shape;
        }

        // Draw
        public void Execute()
        {
            _model.AddShape(_shape);
        }

        // Undo Draw
        public void UndoExecute()
        {
            _model.DeleteShape(_shape);
        }
    }
}
