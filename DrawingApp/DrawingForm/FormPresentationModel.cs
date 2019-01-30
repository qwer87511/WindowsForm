using DrawingModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingForm
{
    public class FormPresentationModel : INotifyPropertyChanged
    {
        public event ShapesListChangedEventHandler _changeModel;
        public event PropertyChangedEventHandler PropertyChanged;

        Model _model;
        bool _isRedoButtonEnabled = false;
        bool _isUndoButtonEnabled = false;

        public FormPresentationModel(Model model)
        {
            _model = model;
            _model._shapesListChanged += HandleModelChanged;
        }

        // 通知屬性變更
        private void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        // 通知Model的圖形變更
        private void HandleModelChanged()
        {
            if (_changeModel != null)
            {
                _changeModel();
            }
        }

        // 在畫布按下滑鼠
        public void PressPointerOnCanvas(double pointX, double pointY)
        {
            _model.PressPointer(pointX, pointY);
        }

        // 在畫圖拖移滑鼠
        public void MovePointerOnCanvas(double pointX, double pointY)
        {
            _model.MovePointer(pointX, pointY);
        }

        // 在畫布放開滑鼠
        public void ReleasePointerOnCanvas(double pointX, double pointY)
        {
            _model.ReleasePointer(pointX, pointY);
            UpdateUndoAndRedoButton();
        }

        // 清空圖
        public void Clear()
        {
            _model.Clear();
            UpdateUndoAndRedoButton();
        }

        // 按下線按鈕
        public void ClickLineButton()
        {
            _model.SelectLine();
        }

        // 按下鑽石按鈕
        public void ClickDiamondButton()
        {
            _model.SelectDiamond();
        }
        
        // 按下橢圓按鈕
        public void ClickEllipseButton()
        {
            _model.SelectEllipse();
        }

        // 按下Redo
        public void ClickRedoButton()
        {
            _model.Redo();
            UpdateUndoAndRedoButton();
        }
        
        // 按下Undo
        public void ClickUndoButton()
        {
            _model.Undo();
            UpdateUndoAndRedoButton();
        }

        // 儲存圖形
        public void SaveShapes()
        {
            _model.Save();
        }
        
        // 載入圖形
        public bool LoadShapes()
        {
            bool isSucceed;
            if (isSucceed = _model.Load())
                UpdateUndoAndRedoButton();
            return isSucceed;
        }

        // 畫圖
        public void Draw(Graphics graphics)
        {
            // graphics物件是Paint事件帶進來的，只能在當次Paint使用
            // 而Adaptor又直接使用graphics，這樣DoubleBuffer才能正確運作
            // 因此，Adaptor不能重複使用，每次都要重新new
            _model.Draw(new WindowsFormsGraphicsAdapter(graphics));
        }

        // 更新 redo 和 undo 按鈕狀態
        private void UpdateUndoAndRedoButton()
        {
            IsUndoButtonEnabled = _model.IsUndoEnabled;
            IsRedoButtonEnabled = _model.IsRedoEnabled;
        }

        public bool IsRedoButtonEnabled
        {
            private set
            {
                _isRedoButtonEnabled = value;
                NotifyPropertyChanged(nameof(IsRedoButtonEnabled));
            }
            get
            {
                return _isRedoButtonEnabled;
            }
        }

        public bool IsUndoButtonEnabled
        {
            private set
            {
                _isUndoButtonEnabled = value;
                NotifyPropertyChanged(nameof(IsUndoButtonEnabled));
            }
            get
            {
                return _isUndoButtonEnabled;
            }
        }
    }
}
