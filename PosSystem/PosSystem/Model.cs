using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.IO;

namespace PosSystem
{
    public class Model
    {
        private Order _order;
        private BindingList<Category> _categories;
        private BindingList<Meal> _meals;

        public Model()
        {
            _order = new Order();
            _categories = new BindingList<Category>();
            _meals = new BindingList<Meal>();
            LoadCategories();
            LoadMeals();
        }

        // 取得特定種類餐點數量
        public int GetMealNumberOfCategory(int categoryIndex)
        {
            return _meals.Where(x => x.Category == _categories[categoryIndex]).Count();
        }

        // 取得特定種類的餐點
        public List<Meal> GetMealsOfCategory(int categoryIndex)
        {
            return _meals.Where(x => x.Category == _categories[categoryIndex]).ToList();
        }

        // 取得特定種類的餐點名
        public List<string> GetMealsNameOfCategory(int categoriesIndex)
        {
            return _meals.Where(x => x.Category == _categories[categoriesIndex]).Select(x => x.Name).ToList();
        }

        // 載入餐點類別
        private void LoadCategories()
        {
            const char LINE_FEED = '\n';
            const string CARRIAGE_RETURN = "\r";
            const string CATEGORIES_FILE = "\\categories.csv";
            StreamReader file = new StreamReader(ProjectPath + CATEGORIES_FILE);
            string[] data = file.ReadToEnd().Replace(CARRIAGE_RETURN, string.Empty).Split(LINE_FEED);
            foreach (string line in data)
            {
                _categories.Add(new Category(line));
            }
        }

        // 讀檔載入餐點
        private void LoadMeals()
        {
            const string MEALS_FILE = "\\meals.csv";
            const char END_LINE = '\n';
            const string CARRIAGE_RETURN = "\r";
            const char DELIMITER = ',';
            const int MEAL_PRICE_INDEX = 2;
            const int MEAL_DESCRIPTION_INDEX = 3;
            const int MEAL_IMAGE_PATH_INDEX = 4;
            StreamReader file = new StreamReader(ProjectPath + MEALS_FILE);
            string[] mealsData = file.ReadToEnd().Replace(CARRIAGE_RETURN, string.Empty).Split(END_LINE);
            foreach (string line in mealsData)
            {
                string[] data = line.Split(DELIMITER);
                _meals.Add(new Meal(data[0], _categories[int.Parse(data[1])], int.Parse(data[MEAL_PRICE_INDEX]), data[MEAL_DESCRIPTION_INDEX], data[MEAL_IMAGE_PATH_INDEX]));
            }
        }

        // 增加新的種類
        public void AddCategory(Category category)
        {
            _categories.Add(category);
        }

        // 刪除種類和屬於該種類的餐點
        public void DeleteCategoryAndBelongingItsMeal(int index)
        {
            foreach (Meal meal in _meals.Where(m => m.Category == _categories[index]).ToList())
                _meals.Remove(meal);
            _categories.RemoveAt(index);
        }

        // 增加新的餐點
        public void AddMeal(Meal meal)
        {
            _meals.Add(meal);
        }

        // 刪除餐點
        public void DeleteMeal(int index)
        {
            _meals.RemoveAt(index);
        }

        // 點餐
        public void OrderMeal(Meal meal)
        {
            _order.Add(meal);
        }

        // 刪除指定餐點
        public void DeleteOrderItem(int index)
        {
            _order.Remove(index);
        }

        // 設定餐點數量
        public void SetOrderItemQuantity(int index, int number)
        {
            _order.SetMealNumber(index, number);
        }

        // 回傳訂單是否包含某種類的餐點
        public bool IsOrderContainedCategory(int index)
        {
            return _order.IsContainingCategory(_categories[index]);
        }

        // 輸入餐點序號取得餐點資訊
        public BindingList<Meal> Meals
        {
            get
            {
                return _meals;
            }
        }

        public int CategoriesNumber
        {
            get
            {
                return _categories.Count;
            }
        }

        public BindingList<OrderItem> OrderItems
        {
            get
            {
                return _order.Items;
            }
        }

        // 取得該種類餐點的數量
        public int MealsNumber
        {
            get
            {
                return _meals.Count;
            }
        }

        // 取得已點餐點總金額
        public int TotalPrice
        {
            get
            {
                return _order.TotalPrice;
            }
        }

        public BindingList<Category> Categories
        {
            get
            {
                return _categories;
            }
        }

        public string ProjectPath
        {
            get
            {
                return Path.GetDirectoryName(Path.GetDirectoryName(Directory.GetCurrentDirectory()));
            }
        }

        public Order Order
        {
            get
            {
                return _order;
            }
        }
    }
}
