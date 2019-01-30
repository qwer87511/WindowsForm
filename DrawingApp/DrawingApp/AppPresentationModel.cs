using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DrawingModel;
using Windows.UI.Xaml.Controls;

namespace DrawingApp
{
    public class AppPresentationModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private Model _model;
        private IGraphics _graphics;

        private bool _isUndoButtonEnabled;
        private bool _isRedoButtonEnabled;

        public AppPresentationModel(Canvas canvas)
        {
            _model = new Model(new DriveServiceAdapter());
            _graphics = new WindowsStoreGraphicsAdaptor(canvas);
            _model._shapesListChanged += HandleModelChanged;
        }

        // 通知屬性變更
        private void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
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

        // 清空圖形
        public void Clear()
        {
            _model.Clear();
            UpdateUndoAndRedoButton();
        }

        // 在畫布按下滑鼠
        public void PressPointerOnCanvas(double pointX, double pointY)
        {
            _model.PressPointer(pointX, pointY);
        }

        // 在畫布移動滑鼠
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

        // 當model改變時重畫
        private void HandleModelChanged()
        {
            // 重複使用igraphics物件
            _model.Draw(_graphics);
        }

        // 更新redo/undo 按鈕狀態
        private void UpdateUndoAndRedoButton()
        {
            IsRedoButtonEnabled = _model.IsRedoEnabled;
            IsUndoButtonEnabled = _model.IsUndoEnabled;
        }

        public bool IsRedoButtonEnabled
        {
            set
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
            set
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
