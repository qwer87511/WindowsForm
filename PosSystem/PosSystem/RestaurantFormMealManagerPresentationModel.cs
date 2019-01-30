using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace PosSystem
{
    public class RestaurantFormMealManagerPresentationModel : RestaurantFormPresentationModelBase, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private EditMode _mode;
        private bool _isSelectedMeal = false;
        private int _selectedMealIndex = -1;

        // Properties for Meal Manager
        private string _title = string.Empty;
        private string _saveButtonText = string.Empty;
        private string _mealName = string.Empty;
        private string _mealPrice = string.Empty;
        private int _mealCategoryIndex = -1;
        private string _mealImagePath = string.Empty;
        private string _mealDescription = string.Empty;
        private bool _isEditMealEnable = false;
        private bool _isSaveMealButtonEnable = false;
        private bool _isDeleteButtonEnable = false;

        public RestaurantFormMealManagerPresentationModel(Model model) : base(model)
        {
            Mode = EditMode.Edit;
        }

        // 通知屬性修改
        protected void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        // ------------------------updates---------------------------

        // 依照編輯模式更新標題
        private void UpdateTitle()
        {
            const string EDIT_TITLE = "Edit Meal";
            const string ADD_TITLE = "Add Meal";
            const string SAVE_TEXT = "Save";
            const string ADD_TEXT = "Add";
            if (Mode == EditMode.Edit)
            {
                Title = EDIT_TITLE;
                SaveButtonText = SAVE_TEXT;
            }
            else if (Mode == EditMode.Add)
            {
                Title = ADD_TITLE;
                SaveButtonText = ADD_TEXT;
            }
        }

        // 更新編輯的畫面
        // 若有選擇餐點，顯示該餐點的屬性
        // 否則，清空畫面
        private void UpdateEditView()
        {
            if (_isSelectedMeal)
                DisplaySelectedMealProperty();
            else
                EmptyMealProperties();
            UpdateButtonsEnable();
        }

        // 顯示餐點資料
        private void DisplaySelectedMealProperty()
        {
            Meal meal = _model.Meals[_selectedMealIndex];
            MealName = meal.Name;
            MealPrice = meal.Price.ToString();
            MealCategoryIndex = _model.Categories.IndexOf(meal.Category);
            MealImagePath = meal.ImageRelativePath;
            MealDescription = meal.Description;
        }

        // 清空餐點資料
        private void EmptyMealProperties()
        {
            MealName = string.Empty;
            MealPrice = string.Empty;
            MealCategoryIndex = -1;
            MealImagePath = string.Empty;
            MealDescription = string.Empty;
        }

        // 更新編輯元件狀態
        private void UpdateButtonsEnable()
        {
            IsEditEnable = _isSelectedMeal || Mode == EditMode.Add;
            IsSaveButtonEnable = false;
            IsDeleteButtonEnable = _isSelectedMeal;
        }

        // 更新儲存按紐狀態
        private void UpdateSaveButtonEnable()
        {
            IsSaveButtonEnable = IsEditEnable && MealName != string.Empty && uint.TryParse(MealPrice, out uint i) && MealCategoryIndex >= 0 && MealImagePath != string.Empty;
        }

        // -----------------------------functions----------------------------------

        // 進入新增餐點模式
        public void EnterAddMode()
        {
            Mode = EditMode.Add;
        }

        // 刪除所選餐點
        public void DeleteSelectedMeal()
        {
            _model.DeleteMeal(_selectedMealIndex);
            SelectedMealIndex = -1;
        }

        // 按下儲存按鈕後，依模式選擇行為
        public void ClickSaveButton()
        {
            if (Mode == EditMode.Edit)
                SaveEditedMealProperties();
            else if (Mode == EditMode.Add)
                AddNewMeal();
        }

        // 修改餐點資料
        private void SaveEditedMealProperties()
        {
            Meal editedMeal = new Meal(MealName, _model.Categories[MealCategoryIndex], int.Parse(MealPrice), MealDescription, MealImagePath);
            Meal meal = _model.Meals[SelectedMealIndex];
            // 如果沒有事先儲存，必須最後修改名字，因為名字和list box繫節，修改後會造成list reload，而properties也reload，造成資料損失
            meal.Name = editedMeal.Name;
            meal.Price = editedMeal.Price;
            meal.Category = editedMeal.Category;
            meal.ImageRelativePath = editedMeal.ImageRelativePath;
            meal.Description = editedMeal.Description;
        }

        // 儲存新的餐點資料
        private void AddNewMeal()
        {
            _model.AddMeal(new Meal(MealName, _model.Categories[MealCategoryIndex], int.Parse(MealPrice), MealDescription, MealImagePath));
            SelectedMealIndex = _model.MealsNumber - 1;
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
                    SelectedMealIndex = -1;
            }
            get
            {
                return _mode;
            }
        }

        // set時更新所選餐點屬性
        public int SelectedMealIndex
        {
            set
            {
                _selectedMealIndex = value;
                NotifyPropertyChanged(nameof(SelectedMealIndex));
                // 更新布林值
                _isSelectedMeal = _selectedMealIndex != -1;
                // 如果選了餐點，切換為編輯模式
                if (_isSelectedMeal)
                    Mode = EditMode.Edit;
                // 更新編輯畫面
                UpdateEditView();
            }
            get
            {
                return _selectedMealIndex;
            }
        }

        // -------------------------properties for views------------------------

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

        // set時更新儲存按鈕狀態
        public string MealName
        {
            set
            {
                _mealName = value;
                NotifyPropertyChanged(nameof(MealName));
                UpdateSaveButtonEnable();
            }
            get
            {
                return _mealName;
            }
        }

        // set時更新儲存按鈕狀態
        public string MealPrice
        {
            set
            {
                _mealPrice = value;
                NotifyPropertyChanged(nameof(MealPrice));
                UpdateSaveButtonEnable();
            }
            get
            {
                return _mealPrice;
            }
        }

        public int MealCategoryIndex
        {
            set
            {
                _mealCategoryIndex = value;
                NotifyPropertyChanged(nameof(MealCategoryIndex));
                UpdateSaveButtonEnable();
            }
            get
            {
                return _mealCategoryIndex;
            }
        }

        // set時更新儲存按鈕狀態
        public string MealImagePath
        {
            set
            {
                _mealImagePath = value;
                NotifyPropertyChanged(nameof(MealImagePath));
                UpdateSaveButtonEnable();
            }
            get
            {
                return _mealImagePath;
            }
        }

        // set時更新儲存按鈕狀態
        public string MealDescription
        {
            set
            {
                _mealDescription = value;
                NotifyPropertyChanged(nameof(MealDescription));
                UpdateSaveButtonEnable();
            }
            get
            {
                return _mealDescription;
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

        public bool IsEditEnable
        {
            set
            {
                _isEditMealEnable = value;
                NotifyPropertyChanged(nameof(IsEditEnable));
            }
            get
            {
                return _isEditMealEnable;
            }
        }

        public bool IsSaveButtonEnable
        {
            set
            {
                _isSaveMealButtonEnable = value;
                NotifyPropertyChanged(nameof(IsSaveButtonEnable));
            }
            get
            {
                return _isSaveMealButtonEnable;
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
