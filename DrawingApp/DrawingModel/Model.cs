using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Text;

namespace DrawingModel
{
    public class Model
    {
        public event ShapesListChangedEventHandler _shapesListChanged;

        private ShapeFactory _factory;
        private List<Shape> _shapesList;

        private CommandManager _commandManager;

        private IState _state;
        private DrawingState _drawingState;
        private PointerState _pointerState;
        
        private bool _isPressed = false;

        private IDriveService _driveService;

        const string FILE_NAME = "ShapesList.txt";
        const string FILE_RELATIVE_PATH = "\\" + FILE_NAME;
        const string CONTENT_TYPE = "text/plain";
        string _filePath;

        public Model(IDriveService driveService)
        {
            _filePath = Directory.GetCurrentDirectory() + FILE_RELATIVE_PATH;

            _factory = new ShapeFactory();
            _shapesList = new List<Shape>();
            _commandManager = new CommandManager();
            _drawingState = new DrawingState(this, _commandManager, _shapesList, ref _isPressed);
            _pointerState = new PointerState(this, _commandManager, _shapesList, ref _isPressed);
            _driveService = driveService;

            _drawingState._shapesListChanged += NotifyShapesListChanged;
            _pointerState._shapesListChanged += NotifyShapesListChanged;
            _state = _pointerState;
        }

        // 按下滑鼠
        public void PressPointer(double pointX, double pointY)
        {
            _state.PressPointer(pointX, pointY);
        }

        // 移動滑鼠
        public void MovePointer(double pointX, double pointY)
        {
            _state.MovePointer(pointX, pointY);
        }
        
        // 放開滑鼠
        public void ReleasePointer(double pointX, double pointY)
        {
            _state.ReleasePointer(pointX, pointY);
            _state = _pointerState;
        }

        // 清除圖
        public void Clear()
        {
            _isPressed = false;
            _commandManager.Clear();
            _shapesList.Clear();
            NotifyShapesListChanged();
        }

        // 選擇線
        public void SelectLine()
        {
            _drawingState.Hint = _factory.CreateShape(nameof(DrawingModel), nameof(Line));
            _state = _drawingState;
        }
        
        // 選擇線
        public void SelectDiamond()
        {
            _drawingState.Hint = _factory.CreateShape(nameof(DrawingModel), nameof(Diamond));
            _state = _drawingState;
        }
        
        // 選擇線
        public void SelectEllipse()
        {
            _drawingState.Hint = _factory.CreateShape(nameof(DrawingModel), nameof(Ellipse));
            _state = _drawingState;
        }
        
        // 增加形狀
        public void AddShape(Shape shape)
        {
            _shapesList.Add(shape);
            NotifyShapesListChanged();
        }
        
        // 刪除形狀
        public void DeleteShape(Shape shape)
        {
            _shapesList.Remove(shape);
            NotifyShapesListChanged();
        }
        
        // 移動形狀
        public void MoveShape(Shape shape, double x1, double y1, double x2, double y2)
        {
            shape.X1 = x1;
            shape.Y1 = y1;
            shape.X2 = x2;
            shape.Y2 = y2;
            NotifyShapesListChanged();
        }

        // redo
        public void Redo()
        {
            _commandManager.Redo();
        }

        // undo
        public void Undo()
        {
            _commandManager.Undo();
        }

        // 儲存
        public void Save()
        {
            // 寫進檔案
            string data = ConvertShapesListToString();
            File.WriteAllText(_filePath, data);
            // 上傳檔案到雲端
            Google.Apis.Drive.v2.Data.File file = _driveService.ListRootFileAndFolder().Find(i => i.Title == FILE_NAME);
            // 如果檔案不存在，上傳新檔案
            if (file == null)
                _driveService.UploadFile(Directory.GetCurrentDirectory() + FILE_RELATIVE_PATH, CONTENT_TYPE);
            // 否則，將雲端上的檔案更新
            else
                _driveService.UpdateFile(FILE_NAME, file.Id, CONTENT_TYPE);
        }

        // 載入
        public bool Load()
        {
            // 從雲端下載檔案
            Google.Apis.Drive.v2.Data.File file = _driveService.ListRootFileAndFolder().Find(i => i.Title == FILE_NAME);
            // 找不到該檔案
            if (file == null)
                return false;
            _driveService.DownloadFile(file, Directory.GetCurrentDirectory());
            // 讀取檔案
            ConvertStringToShapesList(File.ReadAllText(_filePath));
            // 重設command manager
            _commandManager.Clear();
            // 通知變更
            NotifyShapesListChanged();
            // 成功載入
            return true;
        }

        // 把ShapesList資料轉為string
        private string ConvertShapesListToString()
        {
            const string DATA_FORMAT = "{0},{1},{2},{3},{4}\n";
            string data = string.Empty;
            foreach (Shape shape in _shapesList)
            {
                data += string.Format(DATA_FORMAT, shape.GetType(), shape.X1, shape.Y1, shape.X2, shape.Y2);
            }
            return data;
        }

        // 把string轉為ShapesList
        private void ConvertStringToShapesList(string data)
        {
            const char END_LINE = '\n';
            const char COMMA = ',';
            _shapesList.Clear();
            foreach (string line in data.Split(END_LINE))
            {
                if (line != string.Empty)
                {
                    string[] dataArray = line.Split(COMMA);
                    Shape shape = _factory.CreateShape(string.Empty, dataArray[0]);
                    shape.X1 = int.Parse(dataArray[1]);
                    shape.Y1 = int.Parse(dataArray[1 + 1]);
                    shape.X2 = int.Parse(dataArray[1 + 1 + 1]);
                    shape.Y2 = int.Parse(dataArray[1 + 1 + 1 + 1]);
                    _shapesList.Add(shape);
                }
            }
        }

        // 畫圖
        public void Draw(IGraphics graphics)
        {
            graphics.ClearAll();
            foreach (Shape shape in _shapesList)
                shape.Draw(graphics);

            if (_drawingState.Hint != null)
                _drawingState.Hint.Draw(graphics);
        }

        // 通知model變更
        private void NotifyShapesListChanged()
        {
            if (_shapesListChanged != null)
                _shapesListChanged();
        }

        public bool IsUndoEnabled
        {
            get
            {
                return _commandManager.IsUndoEnabled;
            }
        }

        public bool IsRedoEnabled
        {
            get
            {
                return _commandManager.IsRedoEnabled;
            }
        }
    }
}
