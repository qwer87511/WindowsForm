using System;
using System.Collections.Generic;
using System.Text;

namespace DrawingModel
{
    public interface ICommand
    {
        // Execute undoable command
        void Execute();

        // Unexecute
        void UndoExecute();
    }
}
