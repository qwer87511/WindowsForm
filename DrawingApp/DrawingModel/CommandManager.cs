using System;
using System.Collections.Generic;
using System.Text;

namespace DrawingModel
{
    public class CommandManager
    {
        private Stack<ICommand> _undoCommand;
        private Stack<ICommand> _redoCommand;

        public CommandManager()
        {
            _redoCommand = new Stack<ICommand>();
            _undoCommand = new Stack<ICommand>();
        }

        // Execute a command
        public void Execute(ICommand command)
        {
            command.Execute();
            _undoCommand.Push(command);
            _redoCommand.Clear();
        }

        // Unexecute a command
        public void Undo()
        {
            ICommand command = _undoCommand.Pop();
            command.UndoExecute();
            _redoCommand.Push(command);
        }

        // Execute a unexecuted command
        public void Redo()
        {
            ICommand command = _redoCommand.Pop();
            command.Execute();
            _undoCommand.Push(command);
        }

        // 清除
        public void Clear()
        {
            _undoCommand.Clear();
            _redoCommand.Clear();
        }

        public bool IsUndoEnabled
        {
            get
            {
                return _undoCommand.Count > 0;
            }
        }

        public bool IsRedoEnabled
        {
            get
            {
                return _redoCommand.Count > 0;
            }
        }
    }
}
