using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DrawingForm
{
    public partial class DrawingForm : Form
    {
        FormPresentationModel _model;
        Canvas _canvas;

        public DrawingForm(FormPresentationModel model)
        {
            InitializeCanvas(); // 如果後執行，繪圖會卡頓
            InitializeComponent();

            _model = model;
            _model._changeModel += HandleModelChanged;

            _canvas.MouseDown += HandleCanvasPressed;
            _canvas.MouseUp += HandleCanvasReleased;
            _canvas.MouseMove += HandleCanvasMoved;
            _canvas.Paint += HandleCanvasPaint;

            _diamondButton.Click += HandleDiamondButtonClick;
            _lineButton.Click += HandleLineButtonClick;
            _clearButton.Click += HandleClearButtonClick;

            // Databindings
            _undoButton.DataBindings.Add(nameof(Button.Enabled), _model, nameof(FormPresentationModel.IsUndoButtonEnabled));
            _redoButton.DataBindings.Add(nameof(Button.Enabled), _model, nameof(FormPresentationModel.IsRedoButtonEnabled));
        }

        // 初始化畫布
        private void InitializeCanvas()
        {
            SuspendLayout();
            _canvas = new Canvas();
            _canvas.Location = new System.Drawing.Point(12, 68);
            _canvas.Name = "_canvas";
            _canvas.Size = new System.Drawing.Size(1326, 649);
            _canvas.TabIndex = 3;
            Controls.Add(_canvas);
            ResumeLayout(false);
        }

        // 在畫布按下滑鼠
        public void HandleCanvasPressed(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            _model.PressPointerOnCanvas(e.X, e.Y);
        }

        // 在畫布放開滑鼠
        public void HandleCanvasReleased(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            _model.ReleasePointerOnCanvas(e.X, e.Y);
        }

        // 在畫布拖移滑鼠
        public void HandleCanvasMoved(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            _model.MovePointerOnCanvas(e.X, e.Y);
        }

        // 畫圖
        public void HandleCanvasPaint(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            _model.Draw(e.Graphics);
        }

        // 按下清除按鈕
        private void HandleClearButtonClick(object sender, EventArgs e)
        {
            _model.Clear();
        }

        // 按下線按鈕
        private void HandleLineButtonClick(object sender, EventArgs e)
        {
            _model.ClickLineButton();
        }

        // 按下鑽石按鈕
        private void HandleDiamondButtonClick(object sender, EventArgs e)
        {
            _model.ClickDiamondButton();
        }

        // 按下橢圓按鈕
        private void HandleEllipseButtonClick(object sender, EventArgs e)
        {
            _model.ClickEllipseButton();
        }

        // 重新畫圖
        private void HandleModelChanged()
        {
            Invalidate(true);
        }

        // 按下undo按鈕
        private void HandleUndoButtonClick(object sender, EventArgs e)
        {
            _model.ClickUndoButton();
        }

        // 按下redo按鈕
        private void HandleRedoButtonClick(object sender, EventArgs e)
        {
            _model.ClickRedoButton();
        }

        // 按下儲存按鈕
        private void HandleSaveButtonClick(object sender, EventArgs e)
        {
            _model.SaveShapes();
        }

        // 按下載入按鈕
        private void HandleLoadButtonClick(object sender, EventArgs e)
        {
            if (!_model.LoadShapes())
                MessageBox.Show("檔案不存在");
        }
    }
}
