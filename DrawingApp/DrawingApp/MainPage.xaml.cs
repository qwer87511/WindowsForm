using DrawingModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// 空白頁項目範本已記錄在 https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x404

namespace DrawingApp
{
    /// <summary>
    /// 可以在本身使用或巡覽至框架內的空白頁面。
    /// </summary>
    public sealed partial class MainPage : Page
    {
        AppPresentationModel _model;

        public MainPage()
        {
            this.InitializeComponent();

            _model = new AppPresentationModel(_canvas);

            _grid.Background = new SolidColorBrush(Colors.Black);
            _canvas.Background = new SolidColorBrush(Colors.LightYellow);
            
            _canvas.PointerPressed += HandleCanvasPressed;
            _canvas.PointerReleased += HandleCanvasReleased;
            PointerReleased += HandleCanvasReleased;
            _canvas.PointerMoved += HandleCanvasMoved;
            _diamondButton.Click += HandleDiamondButtonClick;
            _lineButton.Click += HandleLineButtonClick;
            _clearButton.Click += HandleClearButtonClick;

            _undoButton.DataContext = _model;
            _redoButton.DataContext = _model;
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.  The Parameter
        /// property is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }

        // 按下Undo按鈕
        private void HandleUndoButtonClick(object sender, RoutedEventArgs e)
        {
            _model.ClickUndoButton();
        }

        // 按下Redo按鈕
        private void HandleRedoButtonClick(object sender, RoutedEventArgs e)
        {
            _model.ClickRedoButton();
        }

        // 按下儲存按鈕
        private void HandleSaveButtonClick(object sender, RoutedEventArgs e)
        {
            //_model.SaveShapes();
            const string MESSAGE = "尚未實作";
            var thing = new MessageDialog(MESSAGE).ShowAsync();
        }

        // 按下載入按鈕
        private void HandleLoadButtonClick(object sender, RoutedEventArgs e)
        {
            //_model.LoadShapes();
            const string MESSAGE = "尚未實作";
            var thing = new MessageDialog(MESSAGE).ShowAsync();
        }

        // 按下線按鈕
        private void HandleLineButtonClick(object sender, RoutedEventArgs e)
        {
            _model.ClickLineButton();
        }

        // 按下鑽石按鈕
        private void HandleDiamondButtonClick(object sender, RoutedEventArgs e)
        {
            _model.ClickDiamondButton();
        }
        
        // 按下橢圓按鈕
        private void HandleEllipseButtonClick(object sender, RoutedEventArgs e)
        {
            _model.ClickEllipseButton();
        }

        // 按下清除按鈕
        private void HandleClearButtonClick(object sender, RoutedEventArgs e)
        {
            _model.Clear();
        }

        // 在畫布按下滑鼠
        public void HandleCanvasPressed(object sender, PointerRoutedEventArgs e)
        {
            _model.PressPointerOnCanvas(e.GetCurrentPoint(_canvas).Position.X, e.GetCurrentPoint(_canvas).Position.Y);
        }

        // 在畫布放開滑鼠
        public void HandleCanvasReleased(object sender, PointerRoutedEventArgs e)
        {
            _model.ReleasePointerOnCanvas(e.GetCurrentPoint(_canvas).Position.X, e.GetCurrentPoint(_canvas).Position.Y);
        }

        // 在畫布移動滑鼠
        public void HandleCanvasMoved(object sender, PointerRoutedEventArgs e)
        {
            _model.MovePointerOnCanvas(e.GetCurrentPoint(_canvas).Position.X, e.GetCurrentPoint(_canvas).Position.Y);
        }
    }
}
