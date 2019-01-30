using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace PosSystem
{
    public class CustomerFormPresentationModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public delegate void DisplayedMealChangedEventHandler();
        public event DisplayedMealChangedEventHandler _displayedMealChanged;
        private Model _model;
        private int _totalPrice = 0;
        
        // page info
        public const int PAGE_CAPACITY = 9;
        private int _page = 0;
        private int _maxPage;

        // states
        private int _selectedCategoryIndex = 0;
        private int _selectedMealIndex; // of _displayedMeals
        private bool _isSelectedMeal = false;
        
        // databindings properties
        private List<Meal> _displayedMeals;
        private string _descriptionText = string.Empty;
        private bool _isAddButtonEnabled = false;
        private bool _isPreviousButtonEnabled = false;
        private bool _isNextButtonEnabled = false;

        public CustomerFormPresentationModel(Model model)
        {
            _model = model;
            Update();
            // 訂閱餐點修改事件
            _model.Meals.ListChanged += UpdateOnMealsListChanged;
            // 訂閱總金額修改事件
            _model.Order._orderChanged += UpdateTotalPrice;
        }
        
        // ----------------------Delegate------------------------

        // model的餐點被修改時的事件
        // 更新所有畫面
        private void UpdateOnMealsListChanged(object sender, ListChangedEventArgs e)
        {
            Update();
        }

        // ------------------------NotifyEvents------------------------

        // 通知屬性變更
        private void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        // 通知要顯示的餐點變更
        private void NotifyDisplayedMealChanged()
        {
            if (_displayedMealChanged != null)
            {
                _displayedMealChanged();
            }
        }

        // -------------------------Update-----------------------

        // 更新所有資料
        private void Update()
        {
            UpdateDisplayedMeal();
            UpdateMaxPage();
            UpdatePageButtonsState();
            SelectedMealIndex = -1;
        }

        // 更新要顯示的餐點
        // 通知顯示餐點變更
        private void UpdateDisplayedMeal()
        {
            _displayedMeals = _model.GetMealsOfCategory(_selectedCategoryIndex).Skip(_page * PAGE_CAPACITY).Take(PAGE_CAPACITY).ToList();
            // 通知顯示餐點變更
            NotifyDisplayedMealChanged();
        }

        // 更新最大頁數量
        private void UpdateMaxPage()
        {
            MaxPage = (_model.GetMealNumberOfCategory(_selectedCategoryIndex) - 1) / PAGE_CAPACITY + 1;
        }

        // 更新按鈕狀態
        private void UpdatePageButtonsState()
        {
            IsPreviousButtonEnabled = Page != 0;
            IsNextButtonEnabled = Page != MaxPage - 1;
        }

        // 依狀態更新餐點屬性
        private void UpdateSelectedMealPropertiesView()
        {
            DescriptionText = IsSelectedMeal ? _displayedMeals[SelectedMealIndex].Description : string.Empty;
        }

        // 更新總金額
        private void UpdateTotalPrice()
        {
            TotalPrice = _model.TotalPrice;
        }

        // ----------------------functions----------------------

        // 加入已選餐點
        public void AddSelectedMeal()
        {
            _model.OrderMeal(_displayedMeals[_selectedMealIndex]);
            SelectedMealIndex = -1;
        }

        // 從點單移除指定項目
        public void DeleteOrderItem(int index)
        {
            _model.DeleteOrderItem(index);
        }

        // 設定餐點數量
        public void SetOrderItemQuantity(int index, int number)
        {
            _model.SetOrderItemQuantity(index, number);
        }

        // --------------------control properties-------------------

        // 切換 TabPage
        // 換tab時回到第一頁
        public int SelectedCategoryIndex
        {
            set
            {
                _selectedCategoryIndex = value;
                // 更新最大頁數量
                UpdateMaxPage();
                // 換tab時回到第一頁
                Page = 0;
                NotifyPropertyChanged(nameof(SelectedCategoryIndex));
            }
            get
            {
                return _selectedCategoryIndex;
            }
        }

        // 顯示的頁數
        // 換頁更新畫面
        public int Page
        {
            set
            {
                _page = value;
                // 自動校正
                if (_page >= MaxPage)
                    _page = MaxPage - 1;
                else if (_page < 0)
                    _page = 0;
                // 更新畫面
                UpdateDisplayedMeal();
                // 取消選擇餐點
                SelectedMealIndex = -1;
                // 更新頁按鈕狀態
                UpdatePageButtonsState();
                // 通知頁面變更
                NotifyPropertyChanged(nameof(PageLabel));
            }
            get
            {
                return _page;
            }
        }
        
        // 選擇的餐點按鈕
        // 選擇時更新餐點敘述
        public int SelectedMealIndex
        {
            set
            {
                _selectedMealIndex = value;
                // 更新狀態
                IsSelectedMeal = _selectedMealIndex != -1;
                // 更新顯示的餐點屬性
                UpdateSelectedMealPropertiesView();
            }
            get
            {
                return _selectedMealIndex;
            }
        }

        // 是否選擇餐點
        // 更新時修改Add按鈕狀態
        private bool IsSelectedMeal
        {
            set
            {
                _isSelectedMeal = value;
                // 修改Add按鈕狀態
                IsAddButtonEnabled = _isSelectedMeal;
            }
            get
            {
                return _isSelectedMeal;
            }
        }

        // --------------------properties for views-----------------------

        // 取得餐點種類
        public BindingList<Category> Categories
        {
            get
            {
                return _model.Categories;
            }
        }

        public List<Meal> DisplayedMeals
        {
            get
            {
                return _displayedMeals;
            }
        }

        public BindingList<OrderItem> OrderItems
        {
            get
            {
                return _model.OrderItems;
            }
        }

        public string DescriptionText
        {
            set
            {
                _descriptionText = value;
                NotifyPropertyChanged(nameof(DescriptionText));
            }
            get
            {
                return _descriptionText;
            }
        }

        private int MaxPage
        {
            set
            {
                _maxPage = value;
                NotifyPropertyChanged(nameof(PageLabel));
            }
            get
            {
                return _maxPage;
            }
        }

        // 顯示當前頁數
        public string PageLabel
        {
            get
            {
                const string PAGE_LABEL_FORMAT = "Page : {0} / {1}";
                return string.Format(PAGE_LABEL_FORMAT, Page + 1, MaxPage);
            }
        }

        public int TotalPrice
        {
            set
            {
                _totalPrice = value;
                NotifyPropertyChanged(nameof(TotalPriceLabel));
            }
            get
            {
                return _totalPrice;
            }
        }

        // 顯示總金額
        public string TotalPriceLabel
        {
            get
            {
                const string TOTAL_PRICE_FORMAT = "Total : {0} 元";
                return string.Format(TOTAL_PRICE_FORMAT, _model.TotalPrice);
            }
        }

        public bool IsAddButtonEnabled
        {
            private set
            {
                _isAddButtonEnabled = value;
                NotifyPropertyChanged(nameof(IsAddButtonEnabled));
            }
            get
            {
                return _isAddButtonEnabled;
            }
        }

        public bool IsPreviousButtonEnabled
        {
            private set
            {
                _isPreviousButtonEnabled = value;
                NotifyPropertyChanged(nameof(IsPreviousButtonEnabled));
            }
            get
            {
                return _isPreviousButtonEnabled;
            }
        }

        public bool IsNextButtonEnabled
        {
            private set
            {
                _isNextButtonEnabled = value;
                NotifyPropertyChanged(nameof(IsNextButtonEnabled));
            }
            get
            {
                return _isNextButtonEnabled;
            }
        }
    }
}