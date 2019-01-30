using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace PosSystem
{
    // 餐廳的Category管理的P.M.
    public class RestaurantFormCategoryManagerPresentationModel : RestaurantFormPresentationModelBase, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private EditMode _mode;
        private bool _isSelectedCategory = false;
        private int _selectedCategoryIndex = -1;

        // Properties for Category Manager View
        private BindingList<string> _selectedCategoryMealsName;
        private string _title = string.Empty;
        private string _saveButtonText = string.Empty;
        private string _categoryName = string.Empty;
        private bool _isEditEnable = false;
        private bool _isSaveButtonEnable = false;
        private bool _isDeleteButtonEnable = false;

        public RestaurantFormCategoryManagerPresentationModel(Model model) : base(model)
        {
            _selectedCategoryMealsName = new BindingList<string>();
            Mode = EditMode.Edit;
            // 訂閱訂單更改事件
            _model.Order._orderChanged += UpdateDeleteButtonEnabled;
        }

        // 通知屬性修改
        private void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        // ------------------------updates---------------------------

        // 更新標題
        private void UpdateTitle()
        {
            const string EDIT_TITLE = "Edit Category";
            const string ADD_TITLE = "Add Category";
            const string SAVE = "Save";
            const string ADD = "Add";
            switch (Mode)
            {
                case EditMode.Edit:
                    Title = EDIT_TITLE;
                    SaveButtonText = SAVE;
                    break;
                case EditMode.Add:
                    Title = ADD_TITLE;
                    SaveButtonText = ADD;
                    break;
            }
        }

        // 更新編輯的畫面
        // 若有選擇種類，顯示該種類的屬性
        // 否則，清空畫面
        private void UpdateEditView()
        {
            if (_isSelectedCategory)
                DisplaySelectedCategoryProperties();
            else
                EmptyCategoryProperties();
            UpdateButtonsEnable();
        }

        // 顯示該種類的屬性
        private void DisplaySelectedCategoryProperties()
        {
            CategoryName = _model.Categories[_selectedCategoryIndex].Name;
            // 更新所選種類之餐點清單
            _selectedCategoryMealsName.Clear();
            foreach (string item in _model.GetMealsNameOfCategory(_selectedCategoryIndex))
            {
                _selectedCategoryMealsName.Add(item);
            }
        }

        // 清空畫面
        private void EmptyCategoryProperties()
        {
            CategoryName = string.Empty;
            _selectedCategoryMealsName.Clear();
        }

        // 初始化按鈕狀態
        private void UpdateButtonsEnable()
        {
            IsEditEnable = _isSelectedCategory || Mode == EditMode.Add;
            IsSaveButtonEnable = false;
            UpdateDeleteButtonEnabled();
        }

        // 更新刪除按鈕狀態，當訂單新增一種類餐點時，禁止刪除該種類
        private void UpdateDeleteButtonEnabled()
        {
            IsDeleteButtonEnable = _isSelectedCategory && !_model.IsOrderContainedCategory(_selectedCategoryIndex);
        }

        // -----------------------------functions----------------------------------

        // 進入新增模式
        public void EnterAddMode()
        {
            Mode = EditMode.Add;
        }

        // 刪除所選的種類
        public void DeleteSelectedCategory()
        {
            _model.DeleteCategoryAndBelongingItsMeal(_selectedCategoryIndex);
            SelectedCategoryIndex = -1;
        }

        // 依編輯模式選擇新增或儲存編輯後的屬性
        public void ClickSaveButton()
        {
            switch (Mode)
            {
                case EditMode.Edit:
                    SaveEditedCategoryProperties();
                    break;
                case EditMode.Add:
                    AddNewCategory();
                    break;
            }
        }

        // 儲存編輯後的屬性
        private void SaveEditedCategoryProperties()
        {
            _model.Categories[_selectedCategoryIndex].Name = CategoryName;
        }

        // 新增種類
        private void AddNewCategory()
        {
            _model.AddCategory(new Category(CategoryName));
            SelectedCategoryIndex = _model.Categories.Count - 1;
        }
        
        // -------------------------control properties----------------------------

        // 設定編輯方式並修改標題
        private EditMode Mode
        {
            set
            {
                _mode = value;
                // 更新標題
                UpdateTitle();
                // 如果是add模式，取消選擇餐點
                if (_mode == EditMode.Add)
                    SelectedCategoryIndex = -1;
            }
            get
            {
                return _mode;
            }
        }

        // set時更新所選種類之餐點清單
        // set時更新選擇狀態
        public int SelectedCategoryIndex
        {
            set
            {
                if (_selectedCategoryIndex != value)
                {
                    _selectedCategoryIndex = value;
                    // 更新布林值
                    _isSelectedCategory = _selectedCategoryIndex != -1;
                    // 通知變更
                    NotifyPropertyChanged(nameof(SelectedCategoryIndex));
                }
                // 如果選了種類，切換為編輯模式
                if (_isSelectedCategory)
                    Mode = EditMode.Edit;
                // 更新編輯畫面
                UpdateEditView();
            }
            get
            {
                return _selectedCategoryIndex;
            }
        }

        // --------------------properties for views-----------------------

        public BindingList<string> MealsNameOfSelectedCategory
        {
            get
            {
                return _selectedCategoryMealsName;
            }
        }

        public string Title
        {
            set
            {
                _title = value;
                NotifyPropertyChanged(nameof(Title));
            }
            get
            {
                return _title;
            }
        }

        public string SaveButtonText
        {
            set
            {
                _saveButtonText = value;
                NotifyPropertyChanged(nameof(SaveButtonText));
            }
            get
            {
                return _saveButtonText;
            }
        }

        // 用戶編輯種類名稱時更新儲存按鈕狀態
        public string CategoryName
        {
            set
            {
                _categoryName = value;
                NotifyPropertyChanged(nameof(CategoryName));
                // 更新儲存按鈕狀態
                IsSaveButtonEnable = _categoryName != string.Empty;
            }
            get
            {
                return _categoryName;
            }
        }

        public bool IsEditEnable
        {
            set
            {
                _isEditEnable = value;
                NotifyPropertyChanged(nameof(IsEditEnable));
            }
            get
            {
                return _isEditEnable;
            }
        }

        public bool IsSaveButtonEnable
        {
            set
            {
                _isSaveButtonEnable = value;
                NotifyPropertyChanged(nameof(IsSaveButtonEnable));
            }
            get
            {
                return _isSaveButtonEnable;
            }
        }

        public bool IsDeleteButtonEnable
        {
            set
            {
                _isDeleteButtonEnable = value;
                NotifyPropertyChanged(nameof(IsDeleteButtonEnable));
            }
            get
            {
                return _isDeleteButtonEnable;
            }
        }
    }
}
