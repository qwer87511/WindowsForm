using PosSystem.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PosSystem
{
    public partial class PosCustomerSideForm : Form
    {
        private CustomerFormPresentationModel _model;
        private List<Button> _mealButtons;

        public PosCustomerSideForm(CustomerFormPresentationModel model)
        {
            InitializeComponent();
            _model = model;
            _mealButtons = new List<Button>
            {
                _mealButton0, _mealButton1, _mealButton2, _mealButton3, _mealButton4, _mealButton5, _mealButton6, _mealButton7, _mealButton8
            };
            _orderDataGridView.DataSource = _model.OrderItems;
            _mealDescribeTextBox.DataBindings.Add(nameof(RichTextBox.Text), _model, nameof(_model.DescriptionText));
            _pageLabel.DataBindings.Add(nameof(Label.Text), _model, nameof(_model.PageLabel));
            _totalLabel.DataBindings.Add(nameof(Label.Text), _model, nameof(_model.TotalPriceLabel));
            _addButton.DataBindings.Add(nameof(Button.Enabled), _model, nameof(_model.IsAddButtonEnabled));
            _previousPageButton.DataBindings.Add(nameof(Button.Enabled), _model, nameof(_model.IsPreviousButtonEnabled));
            _nextPageButton.DataBindings.Add(nameof(Button.Enabled), _model, nameof(_model.IsNextButtonEnabled));
            RefreshTabPages();
            RefreshMenu();
            // PM要顯示的餐點變更時 更新菜單
            _model._displayedMealChanged += RefreshMenu;
            _model.Categories.ListChanged += ChangeCategoriesList;
        }

        // 更改種類數量時，更新頁面數量
        private void ChangeCategoriesList(object sender, ListChangedEventArgs e)
        {
            if (e.ListChangedType == ListChangedType.ItemChanged)
                RefreshTabPagesName();
            else
                RefreshTabPages();
        }

        // 更新page名稱
        private void RefreshTabPagesName()
        {
            for (int i = 0; i < _tabControl.TabPages.Count; i++)
            {
                _tabControl.TabPages[i].Text = _model.Categories[i].Name;
            }
        }

        // 更新所有tabpage
        private void RefreshTabPages()
        {
            _tabControl.TabPages.Clear();
            _tabControl.TabPages.AddRange(_model.Categories.Select(c => new TabPage(c.Name)).ToArray());
            if (_tabControl.TabPages.Count > 0)
            {
                _tabControl.SelectedIndex = 0;
                SelectTabControl(_tabControl, null);
            }
        }

        // 更新菜單
        private void RefreshMenu()
        {
            const string TEXT = "Text";
            List<Meal> meals = _model.DisplayedMeals;
            int mealNumber = meals.Count;
            for (int i = 0; i < mealNumber; i++)
            {
                Meal meal = meals[i];
                _mealButtons[i].DataBindings.Clear();
                _mealButtons[i].Visible = true;
                _mealButtons[i].DataBindings.Add(TEXT, meal, "Data");
                _mealButtons[i].DataBindings.Add("BackgroundImage", meal, "Image", true, DataSourceUpdateMode.OnPropertyChanged, null);
            }
            for (int i = mealNumber; i < CustomerFormPresentationModel.PAGE_CAPACITY; i++)
            {
                _mealButtons[i].DataBindings.Clear();
                _mealButtons[i].Visible = false;
            }
        }

        // 儲存點選餐點序號
        private void ClickMealButton(object sender, EventArgs e)
        {
            _model.SelectedMealIndex = int.Parse((string)((Control)sender).Tag);
        }
        
        // 將點選的餐點加入清單
        private void ClickAddButton(object sender, EventArgs e)
        {
            _model.AddSelectedMeal();
        }

        // 將菜單更新為上一頁
        private void ClickPreviousPageButton(object sender, EventArgs e)
        {
            _model.Page--;
        }

        // 將菜單更新為下一頁
        private void ClickNextPageButton(object sender, EventArgs e)
        {
            _model.Page++;
        }
        
        // 按下DataGridView的內容
        private void ClickDataGridViewCell(object sender, DataGridViewCellEventArgs e)
        {
            // 按下刪除
            if (e.ColumnIndex == _deleteButton.Index && e.RowIndex >= 0)
                _model.DeleteOrderItem(e.RowIndex);
        }

        // 修改餐點數量
        private void ChangeDataGridViewCellValue(object sender, DataGridViewCellEventArgs e)
        {
            // 可以binding嗎
            DataGridView gridView = (DataGridView)sender;
            if (gridView.Rows.Count > 0 && e.ColumnIndex == _quantityDataGridViewTextBoxColumn.Index)
            {
                _model.SetOrderItemQuantity(e.RowIndex, (int)gridView.CurrentCell.Value);
            }
        }

        // 選取其他種類
        private void SelectTabControl(object sender, EventArgs e)
        {
            int tabIndex = ((TabControl)sender).SelectedIndex;
            if (tabIndex >= 0)
            {
                _model.SelectedCategoryIndex = tabIndex;
                _tabControl.TabPages[tabIndex].Controls.Add(_mealButtonsTableLayout);
            }
        }
    }
}
