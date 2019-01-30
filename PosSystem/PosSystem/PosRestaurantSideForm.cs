using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace PosSystem
{
    public partial class PosRestaurantSideForm : Form
    {
        RestaurantFormMealManagerPresentationModel _mealManagerModel;
        RestaurantFormCategoryManagerPresentationModel _categoryManagerModel;

        public PosRestaurantSideForm(RestaurantFormMealManagerPresentationModel mealManagerModel, RestaurantFormCategoryManagerPresentationModel categoryManagerModel)
        {
            InitializeComponent();
            _mealManagerModel = mealManagerModel;
            _categoryManagerModel = categoryManagerModel;
            BindMealManagerViews();
            BindControlsEnable();
            BindCategoryManagerViews();
            _mealListBox.SelectedIndex = -1;
            _categoryListBox.SelectedIndex = -1;
        }

        // Bind Meal Manager 的 view
        private void BindMealManagerViews()
        {
            _mealListBox.DataSource = _mealManagerModel.Meals;
            _mealListBox.DisplayMember = nameof(Meal.Name);
            _categoryComboBox.DataSource = _mealManagerModel.Categories;
            _categoryComboBox.DisplayMember = nameof(Category.Name);
            _mealListBox.DataBindings.Add(nameof(ListBox.SelectedIndex), _mealManagerModel, nameof(_mealManagerModel.SelectedMealIndex));
            _editMealGroupBox.DataBindings.Add(nameof(GroupBox.Text), _mealManagerModel, nameof(_mealManagerModel.Title));
            _saveMealButton.DataBindings.Add(nameof(Button.Text), _mealManagerModel, nameof(_mealManagerModel.SaveButtonText));
            // 選擇的meal屬性
            _mealNameTextBox.DataBindings.Add(nameof(TextBox.Text), _mealManagerModel, nameof(_mealManagerModel.MealName));
            _mealPriceTextBox.DataBindings.Add(nameof(TextBox.Text), _mealManagerModel, nameof(_mealManagerModel.MealPrice));
            _categoryComboBox.DataBindings.Add(nameof(ComboBox.SelectedIndex), _mealManagerModel, nameof(_mealManagerModel.MealCategoryIndex));
            _mealImagePathTextBox.DataBindings.Add(nameof(TextBox.Text), _mealManagerModel, nameof(_mealManagerModel.MealImagePath));
            _mealDescriptionTextBox.DataBindings.Add(nameof(TextBox.Text), _mealManagerModel, nameof(_mealManagerModel.MealDescription));
        }
        
        // 選擇餐點時enable物件
        private void BindControlsEnable()
        {
            _mealNameTextBox.DataBindings.Add(nameof(TextBox.Enabled), _mealManagerModel, nameof(_mealManagerModel.IsEditEnable));
            _mealPriceTextBox.DataBindings.Add(nameof(TextBox.Enabled), _mealManagerModel, nameof(_mealManagerModel.IsEditEnable));
            _categoryComboBox.DataBindings.Add(nameof(ComboBox.Enabled), _mealManagerModel, nameof(_mealManagerModel.IsEditEnable));
            _mealImagePathTextBox.DataBindings.Add(nameof(TextBox.Enabled), _mealManagerModel, nameof(_mealManagerModel.IsEditEnable));
            _browseFileButton.DataBindings.Add(nameof(Button.Enabled), _mealManagerModel, nameof(_mealManagerModel.IsEditEnable));
            _mealDescriptionTextBox.DataBindings.Add(nameof(TextBox.Enabled), _mealManagerModel, nameof(_mealManagerModel.IsEditEnable));
            _deleteMealButton.DataBindings.Add(nameof(Button.Enabled), _mealManagerModel, nameof(_mealManagerModel.IsDeleteButtonEnable));
            _saveMealButton.DataBindings.Add(nameof(Button.Enabled), _mealManagerModel, nameof(_mealManagerModel.IsSaveButtonEnable));
        }

        // Bind Category Manager 的 view
        private void BindCategoryManagerViews()
        {
            _categoryListBox.DataSource = _categoryManagerModel.Categories;
            _categoryListBox.DisplayMember = nameof(Category.Name);
            _mealsOfSelectedCategoryListBox.DataSource = _categoryManagerModel.MealsNameOfSelectedCategory;
            _editCategoryGroupBox.DataBindings.Add(nameof(GroupBox.Text), _categoryManagerModel, nameof(_categoryManagerModel.Title));
            _saveCategoryButton.DataBindings.Add(nameof(Button.Text), _categoryManagerModel, nameof(_categoryManagerModel.SaveButtonText));
            _categoryNameTextBox.DataBindings.Add(nameof(TextBox.Text), _categoryManagerModel, nameof(_categoryManagerModel.CategoryName));
            _deleteCategoryButton.DataBindings.Add(nameof(Button.Enabled), _categoryManagerModel, nameof(_categoryManagerModel.IsDeleteButtonEnable));
            _categoryNameTextBox.DataBindings.Add(nameof(TextBox.Enabled), _categoryManagerModel, nameof(_categoryManagerModel.IsEditEnable));
            _saveCategoryButton.DataBindings.Add(nameof(Button.Enabled), _categoryManagerModel, nameof(_categoryManagerModel.IsSaveButtonEnable));
            _categoryListBox.DataBindings.Add(nameof(ListBox.SelectedIndex), _categoryManagerModel, nameof(_categoryManagerModel.SelectedCategoryIndex));
        }

        // 瀏覽餐點圖片
        private void ClickBrowseFileButton(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            string projectPath = Path.GetDirectoryName(Path.GetDirectoryName(Directory.GetCurrentDirectory()));
            fileDialog.InitialDirectory = projectPath;
            fileDialog.Multiselect = false;
            fileDialog.Filter = "Image|*.png;*.jpg;*.jpeg";
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                if (fileDialog.FileName.Contains(projectPath))
                    _mealManagerModel.MealImagePath = fileDialog.FileName.Substring(projectPath.Length);
                else
                    MessageBox.Show("請選擇專案內的圖片");
            }
        }

        // 選擇要編輯的餐點
        private void SelectMealListBoxIndex(object sender, EventArgs e)
        {
            _mealManagerModel.SelectedMealIndex = ((ListBox)sender).SelectedIndex;
        }

        // 儲存餐點
        private void ClickSaveMealButton(object sender, EventArgs e)
        {
            _mealManagerModel.ClickSaveButton();
        }

        // 加入新餐點
        private void ClickAddMealButton(object sender, EventArgs e)
        {
            _mealManagerModel.EnterAddMode();
        }

        // 刪除餐點
        private void ClickDeleteMealButton(object sender, EventArgs e)
        {
            _mealManagerModel.DeleteSelectedMeal();
        }

        // 更改餐點名稱
        private void ChangeMealNameTextBox(object sender, EventArgs e)
        {
            _mealManagerModel.MealName = ((TextBox)sender).Text;
        }

        // 修改餐點金額
        private void ChangeMealPriceText(object sender, EventArgs e)
        {
            _mealManagerModel.MealPrice = ((TextBox)sender).Text;
        }

        // 修改餐點敘述
        private void ChangeMealDescriptionTextBox(object sender, EventArgs e)
        {
            _mealManagerModel.MealDescription = ((TextBox)sender).Text;
        }

        // 選擇餐點種類
        private void SelectCategoryComboBoxIndex(object sender, EventArgs e)
        {
            _mealManagerModel.MealCategoryIndex = ((ComboBox)sender).SelectedIndex;
        }

        // 更改種類名稱
        private void ChangeCategoryNameText(object sender, EventArgs e)
        {
            _categoryManagerModel.CategoryName = ((TextBox)sender).Text;
        }

        // 按下加入種類按鈕
        private void ClickAddCategoryButton(object sender, EventArgs e)
        {
            _categoryManagerModel.EnterAddMode();
        }

        // 按下刪除種類按鈕
        private void ClickDeleteCategoryButton(object sender, EventArgs e)
        {
            _categoryManagerModel.DeleteSelectedCategory();
        }

        // 按下儲存
        private void ClickSaveCategoryButton(object sender, EventArgs e)
        {
            _categoryManagerModel.ClickSaveButton();
        }
        
        // 選擇要編輯的種類
        private void SelectCategoryListBoxIndex(object sender, EventArgs e)
        {
            _categoryManagerModel.SelectedCategoryIndex = ((ListBox)sender).SelectedIndex;
        }

        // 切換tab
        private void SelectTabControl(object sender, TabControlCancelEventArgs e)
        {
            _mealManagerModel.SelectedMealIndex = -1;
            _categoryManagerModel.SelectedCategoryIndex = -1;
        }
    }
}
