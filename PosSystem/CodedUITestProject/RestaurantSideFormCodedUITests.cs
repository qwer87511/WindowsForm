using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows.Input;
using System.Windows.Forms;
using System.Drawing;
using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.VisualStudio.TestTools.UITest.Extension;
using Keyboard = Microsoft.VisualStudio.TestTools.UITesting.Keyboard;
using System.Linq;

namespace CodedUITestProject
{
    /// <summary>
    /// CodedUITest2 的摘要說明
    /// </summary>
    [CodedUITest]
    public class RestaurantSideFormCodedUITests
    {
        private const string FILE_PATH = @"../../../PosSystem/bin/Debug/PosSystem.exe";

        // Start up Form
        private const string STARTUP_FORM = "StartUpForm";
        private const string START_CUSTOMER_PROGRAM_BUTTON = "StartCustomerProgramButton";
        private const string START_RESTAURANT_PROGRAM_BUTTON = "StartRestaurantProgramButton";
        private const string EXIT_BUTTON = "ExitButton";

        // Restaurant Side Form
        private const string RESTAURANT_SIDE_FORM = "PosRestaurantSideForm";

        // Meal Manager
        private const string MEAL_MANAGER = "Meal Manager";
        private const string MEAL_LISTBOX = "MealListBox";
        private const string MEAL_NAME_TEXTBOX = "MealNameTextBox";
        private const string MEAL_PRICE_TEXTBOX = "MealPriceTextBox";
        private const string CATEGORY_COMBOBOX = "CategoryComboBox";
        private const string MEAL_IMAGE_PATH_TEXTBOX = "MealImagePathTextBox";
        private const string MEAL_DESCRIPTION_TEXTBOX = "MealDescriptionTextBox";
        private const string BROWSE_FILE_BUTTON = "BrowseFileButton";
        private const string SAVE_MEAL_BUTTON = "SaveMealButton";
        private const string ADD_MEAL_BUTTON = "AddMealButton";
        private const string DELETE_MEAL_BUTTON = "DeleteMealButton";

        // Category Manager
        private const string CATEGORY_MANAGER = "Category Manager";
        private const string CATEGORY_LISTBOX = "CategoryListBox";
        private const string CATEGORY_NAME_TEXTBOX = "CategoryNameTextBox";
        private const string MEALS_OF_SELECTED_CATEGORY_LISTBOX = "MealsOfSelectedCategoryListBox";
        private const string SAVE_CATEGORY_BUTTON = "SaveCategoryButton";
        private const string ADD_CATEGORY_BUTTON = "AddCategoryButton";
        private const string DELETE_CATEGORY_BUTTON = "DeleteCategoryButton";

        // data
        private readonly List<string> CATEGORIES = new List<string>
        {
            "壽司","甜點","飲料"
        };
        private readonly List<List<string>> MEALS = new List<List<string>>
        {
            new List<string> { "烤鯖魚押壽司", "壽司", "40", "烤鯖魚押壽司，好吃", @"\Resources\meal0.png" },
            new List<string> { "稻荷天婦羅壽司", "壽司", "40", "稻荷天婦羅壽司，好吃", @"\Resources\meal1.png" },
            new List<string> { "鯖魚押壽司", "壽司", "40", "鯖魚押壽司，好吃", @"\Resources\meal2.png" },
            new List<string> { "大甲葉花枝", "壽司", "40", "大甲葉花枝，好吃", @"\Resources\meal3.png" },
            new List<string> { "炙烤起司長鰭鮪魚", "壽司", "40", "炙烤起司長鰭鮪魚，好吃", @"\Resources\meal4.png" },
            new List<string> { "特選長鰭鮪魚", "壽司", "80", "特選長鰭鮪魚，好棒", @"\Resources\meal5.png" },
            new List<string> { "長鰭鮪魚", "壽司", "40", "長鰭鮪魚，好棒", @"\Resources\meal6.png" },
            new List<string> { "炙烤鮪魚腹鱒魚卵", "壽司", "80", "炙烤鮪魚腹鱒魚卵，好棒", @"\Resources\meal7.png" },
            new List<string> { "柚子胡椒醃漬生鮮蝦", "壽司", "40", "柚子胡椒醃漬生鮮蝦，好棒", @"\Resources\meal8.png" },
            new List<string> { "炙烤照燒鮮蝦", "壽司", "40", "炙烤照燒鮮蝦，好棒", @"\Resources\meal9.png" },
            new List<string> { "竹姬壽司蔥花鮪魚", "壽司", "40", "竹姬壽司蔥花鮪魚，好讚", @"\Resources\meal10.png" },
            new List<string> { "熟成鮪魚", "壽司", "40", "熟成鮪魚，好讚", @"\Resources\meal11.png" },
            new List<string> { "炙烤照燒鮭魚", "壽司", "40", "炙烤照燒鮭魚，好讚", @"\Resources\meal12.png" },
            new List<string> { "黃金酥脆捲", "壽司", "80", "黃金酥脆捲，好讚", @"\Resources\meal13.png" },
            new List<string> { "酥脆炸蝦捲", "壽司", "80", "酥脆炸蝦捲，好讚", @"\Resources\meal14.png" },
            new List<string> { "焦糖法式金磚", "甜點", "90", "焦糖法式金磚，好甜", @"\Resources\dessert0.png" },
            new List<string> { "喀滋蜜核桃焦糖聖代", "甜點", "60", "喀滋蜜核桃焦糖聖代", @"\Resources\dessert1.png" },
            new List<string> { "抹茶牛奶冰淇淋", "甜點", "90", "抹茶牛奶冰淇淋，好甜", @"\Resources\dessert2.png" },
            new List<string> { "靜岡抹茶冰淇淋", "甜點", "90", "靜岡抹茶冰淇淋，好甜", @"\Resources\dessert3.png" },
            new List<string> { "京都風蕨餅", "甜點", "90", "京都風蕨餅，好甜", @"\Resources\dessert4.png" },
            new List<string> { "義式提拉米蘇", "甜點", "90", "義式提拉米蘇，好甜", @"\Resources\dessert5.png" },
            new List<string> { "100%純柳橙汁", "飲料", "60", "100%純柳橙汁，好喝", @"\Resources\drink0.png" },
            new List<string> { "啤酒", "飲料", "90", "啤酒，好喝", @"\Resources\drink1.png" },
            new List<string> { "100%純頻果汁", "飲料", "60", "100%純頻果汁，好喝", @"\Resources\drink2.png" },
            new List<string> { "1983年純柳橙汁", "飲料", "90", "1983年純柳橙汁，好喝", @"\Resources\drink3.png" },
            new List<string> { "1983年啤酒", "飲料", "120", "1983年啤酒，好喝", @"\Resources\drink4.png" },
            new List<string> { "1983年純頻果汁", "飲料", "90", "1983年純頻果汁，好喝", @"\Resources\drink5.png" }
        };
        private List<string> _categories;
        private List<List<string>> _meals;

        public RestaurantSideFormCodedUITests()
        {
        }

        /// <summary>
        /// Launches the Calculator
        /// </summary>
        [TestInitialize()]
        public void Initialize()
        {
            _categories = new List<string>(CATEGORIES);
            _meals = new List<List<string>>(MEALS);
            Robot.Initialize(FILE_PATH, STARTUP_FORM);
            Robot.ClickButton(START_CUSTOMER_PROGRAM_BUTTON);
            Robot.ClickButton(START_RESTAURANT_PROGRAM_BUTTON);
            Robot.SetForm(RESTAURANT_SIDE_FORM);
        }

        /// <summary>
        /// Closes the launched program
        /// </summary>
        [TestCleanup()]
        public void Cleanup()
        {
            Robot.CleanUp();
        }

        // 測試 Restaurant Side Form
        [TestMethod]
        public void RestaurantSideFormTest()
        {
        }

        // ------------------------Meal Manager---------------------

        // 測試選取
        [TestMethod]
        public void MealPropertiesTest()
        {
            // init
            AssertEditEnabled(false);
            Robot.AssertButtonEnable(SAVE_MEAL_BUTTON, false);
            Robot.AssertButtonEnable(ADD_MEAL_BUTTON, true);
            Robot.AssertButtonEnable(DELETE_MEAL_BUTTON, false);
            Robot.AssertListViewByValue(MEAL_LISTBOX, _meals.Select(m => m[0]).ToArray());

            // 點選餐點
            Robot.ClickListViewByValue(MEAL_LISTBOX, _meals[26][0]);
            AssertMealProperties(_meals[26].ToArray());
            Robot.AssertButtonEnable(SAVE_MEAL_BUTTON, false);

            Robot.ClickListViewByValue(MEAL_LISTBOX, _meals[5][0]);
            AssertMealProperties(_meals[5].ToArray());

            Robot.ClickListViewByValue(MEAL_LISTBOX, _meals[15][0]);
            AssertMealProperties(_meals[15].ToArray());

            Robot.ClickListViewByValue(MEAL_LISTBOX, _meals[0][0]);
            AssertMealProperties(_meals[0].ToArray());
            Robot.AssertButtonEnable(SAVE_MEAL_BUTTON, false);
        }

        // 測試 Meal Manager
        [TestMethod]
        public void ModifyMealPropertiesTest()
        {
            Robot.ClickListViewByValue(MEAL_LISTBOX, _meals[0][0]);
            var list = _meals.ToList();

            // 修改餐點
            string[] meal = new string[] { "name1", "甜點", "100", "description1", @"\Resources\dessert1.png" };
            SetMealEdit(meal);
            Robot.ClickButton(SAVE_MEAL_BUTTON);
            AssertMealProperties(meal);
            Robot.AssertButtonEnable(SAVE_MEAL_BUTTON, false);
            list[0] = meal.ToList();
            Robot.AssertListViewByValue(MEAL_LISTBOX, list.Select(m => m[0]).ToArray());

            Robot.ClickListViewByValue(MEAL_LISTBOX, _meals[22][0]);
            meal = new string[] { "name2", "壽司", "200", "description2", @"\Resources\dessert2.png" };
            SetMealEdit(meal);
            Robot.ClickButton(SAVE_MEAL_BUTTON);
            AssertMealProperties(meal);
            Robot.AssertButtonEnable(SAVE_MEAL_BUTTON, false);
            list[22] = meal.ToList();
            Robot.AssertListViewByValue(MEAL_LISTBOX, list.Select(m => m[0]).ToArray());
        }

        // 新增餐點
        [TestMethod]
        public void AddMealTest()
        {
            Robot.ClickButton(ADD_MEAL_BUTTON);
            string[] meal = new string[] { "name11", "甜點", "1100", "description1", @"\Resources\dessert1.png" };
            SetMealEdit(meal);
            Robot.ClickButton(SAVE_MEAL_BUTTON);
            AssertMealProperties(meal);
            _meals.Add(meal.ToList());
            Robot.AssertListViewByValue(MEAL_LISTBOX, _meals.Select(m => m[0]).ToArray());

            Robot.ClickButton(ADD_MEAL_BUTTON);
            meal = new string[] { "name22", "甜點", "2200", "description22", @"\Resources\drink2.png" };
            SetMealEdit(meal);
            Robot.ClickButton(SAVE_MEAL_BUTTON);
            AssertMealProperties(meal);
            _meals.Add(meal.ToList());
            Robot.AssertListViewByValue(MEAL_LISTBOX, _meals.Select(m => m[0]).ToArray());
        }

        // 刪除餐點
        [TestMethod]
        public void DeleteMealTest()
        {
            int index = 20;
            Robot.ClickListViewByValue(MEAL_LISTBOX, _meals[index][0]);
            Robot.ClickButton(DELETE_MEAL_BUTTON);
            _meals.RemoveAt(index);
            Robot.AssertListViewByValue(MEAL_LISTBOX, _meals.Select(m => m[0]).ToArray());

            index = 25;
            Robot.ClickListViewByValue(MEAL_LISTBOX, _meals[index][0]);
            Robot.ClickButton(DELETE_MEAL_BUTTON);
            _meals.RemoveAt(index);
            Robot.AssertListViewByValue(MEAL_LISTBOX, _meals.Select(m => m[0]).ToArray());

            index = 0;
            while (_meals.Count > 0)
            {
                Robot.ClickListViewByValue(MEAL_LISTBOX, _meals[index][0]);
                Robot.ClickButton(DELETE_MEAL_BUTTON);
                _meals.RemoveAt(0);
            }
            Robot.AssertListViewByValue(MEAL_LISTBOX, null);
        }

        // 把 data 寫進 Edit
        private void SetMealEdit(string[] data)
        {
            Robot.SetEdit(MEAL_NAME_TEXTBOX, data[0]);
            Robot.SetComboBox(CATEGORY_COMBOBOX, data[1]);
            Robot.SetEdit(MEAL_PRICE_TEXTBOX, data[2]);
            Robot.SetEdit(MEAL_DESCRIPTION_TEXTBOX, data[3]);
            Robot.ClickButton(BROWSE_FILE_BUTTON);
            Robot.SelectFileByOpenFileDialog("開啟", data[4].Trim('\\').Split('\\'));
        }

        // Assert 點選的 meal 是否正確顯示屬性
        private void AssertMealProperties(string[] data)
        {
            Robot.AssertEdit(MEAL_NAME_TEXTBOX, data[0]);
            Robot.AssertComboBox(CATEGORY_COMBOBOX, data[1]);
            Robot.AssertEdit(MEAL_PRICE_TEXTBOX, data[2]);
            Robot.AssertEdit(MEAL_DESCRIPTION_TEXTBOX, data[3]);
            Robot.AssertEdit(MEAL_IMAGE_PATH_TEXTBOX, data[4]);
        }

        // assert edit enable
        private void AssertEditEnabled(bool enabled)
        {
            Robot.AssertEditEnable(MEAL_NAME_TEXTBOX, enabled);
            Robot.AssertComboEnable(CATEGORY_COMBOBOX, enabled);
            Robot.AssertEditEnable(MEAL_PRICE_TEXTBOX, enabled);
            Robot.AssertEditEnable(MEAL_DESCRIPTION_TEXTBOX, enabled);
            Robot.AssertEditEnable(MEAL_IMAGE_PATH_TEXTBOX, enabled);
            Robot.AssertButtonEnable(BROWSE_FILE_BUTTON, enabled);
        }

        // ------------------------Meal Manager---------------------

        // 測試 Category Manager
        [TestMethod]
        public void RestaurantCategoryManagerTest()
        {
            Robot.ClickTabControl(CATEGORY_MANAGER);

            Robot.AssertButtonEnable(SAVE_CATEGORY_BUTTON, false);
            Robot.AssertButtonEnable(ADD_CATEGORY_BUTTON, true);
            Robot.AssertButtonEnable(DELETE_CATEGORY_BUTTON, false);
            Robot.AssertListViewByValue(CATEGORY_LISTBOX, _categories.ToArray());

            int index = 0;
            Robot.ClickListViewByValue(CATEGORY_LISTBOX, _categories[index]);
            Robot.AssertEdit(CATEGORY_NAME_TEXTBOX, _categories[index]);
            Robot.AssertListViewByValue(MEALS_OF_SELECTED_CATEGORY_LISTBOX, _meals.Where(i => i[1] == _categories[index]).Select(i => i[0]).ToArray());

            index = 2;
            Robot.ClickListViewByValue(CATEGORY_LISTBOX, _categories[index]);
            Robot.AssertEdit(CATEGORY_NAME_TEXTBOX, _categories[index]);
            Robot.AssertListViewByValue(MEALS_OF_SELECTED_CATEGORY_LISTBOX, _meals.Where(i => i[1] == _categories[index]).Select(i => i[0]).ToArray());
        }

        // 修改 Category
        [TestMethod]
        public void ModifyCategoryTest()
        {
            Robot.ClickTabControl(CATEGORY_MANAGER);

            int index = 2;
            string category = "category2";
            Robot.ClickListViewByValue(CATEGORY_LISTBOX, _categories[index]);
            Robot.SetEdit(CATEGORY_NAME_TEXTBOX, category);
            Robot.ClickButton(SAVE_CATEGORY_BUTTON);
            Robot.AssertEdit(CATEGORY_NAME_TEXTBOX, category);
            _categories[index] = category;
            Robot.AssertListViewByValue(CATEGORY_LISTBOX, _categories.ToArray());

            index = 0;
            category = "category0";
            Robot.ClickListViewByValue(CATEGORY_LISTBOX, _categories[index]);
            Robot.SetEdit(CATEGORY_NAME_TEXTBOX, category);
            Robot.ClickButton(SAVE_CATEGORY_BUTTON);
            Robot.AssertEdit(CATEGORY_NAME_TEXTBOX, category);
            _categories[index] = category;
            Robot.AssertListViewByValue(CATEGORY_LISTBOX, _categories.ToArray());
        }

        // 新增 Category
        [TestMethod]
        public void AddCategoryTest()
        {
            Robot.ClickTabControl(CATEGORY_MANAGER);

            string newCategory = "new category";
            Robot.ClickButton(ADD_CATEGORY_BUTTON);
            Robot.SetEdit(CATEGORY_NAME_TEXTBOX, newCategory);
            Robot.ClickButton(SAVE_CATEGORY_BUTTON);
            _categories.Add(newCategory);
            Robot.AssertListViewByValue(CATEGORY_LISTBOX, _categories.ToArray());

            newCategory = "new new category";
            Robot.ClickButton(ADD_CATEGORY_BUTTON);
            Robot.SetEdit(CATEGORY_NAME_TEXTBOX, newCategory);
            Robot.ClickButton(SAVE_CATEGORY_BUTTON);
            _categories.Add(newCategory);
            Robot.AssertListViewByValue(CATEGORY_LISTBOX, _categories.ToArray());
        }

        // 刪除 Category
        [TestMethod]
        public void DeleteCategoryTest()
        {
            Robot.ClickTabControl(CATEGORY_MANAGER);

            int index = 2;
            Robot.ClickListViewByValue(CATEGORY_LISTBOX, _categories[index]);
            Robot.ClickButton(DELETE_CATEGORY_BUTTON);
            _categories.RemoveAt(index);
            Robot.AssertListViewByValue(CATEGORY_LISTBOX, _categories.ToArray());

            index = 0;
            Robot.ClickListViewByValue(CATEGORY_LISTBOX, _categories[index]);
            Robot.ClickButton(DELETE_CATEGORY_BUTTON);
            _categories.RemoveAt(index);
            Robot.AssertListViewByValue(CATEGORY_LISTBOX, _categories.ToArray());

            Robot.ClickListViewByValue(CATEGORY_LISTBOX, _categories[index]);
            Robot.ClickButton(DELETE_CATEGORY_BUTTON);
            _categories.RemoveAt(index);
            Robot.AssertListViewByValue(CATEGORY_LISTBOX, _categories.ToArray());
        }

        /// <summary>
        ///取得或設定提供目前測試回合
        ///相關資訊與功能的測試內容。
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }
        private TestContext testContextInstance;

        public UIMap UIMap
        {
            get
            {
                if (this.map == null)
                {
                    this.map = new UIMap();
                }

                return this.map;
            }
        }

        private UIMap map;
    }
}
