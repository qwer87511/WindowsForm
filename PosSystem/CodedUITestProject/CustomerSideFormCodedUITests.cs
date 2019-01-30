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


namespace CodedUITestProject
{
    /// <summary>
    /// CodedUITest1 的摘要說明
    /// </summary>
    [CodedUITest]
    public class CustomerSideFormCodedUITests
    {
        private const string FILE_PATH = @"../../../PosSystem/bin/Debug/PosSystem.exe";

        // Start up Form
        private const string STARTUP_FORM = "StartUpForm";
        private const string START_CUSTOMER_PROGRAM_BUTTON = "StartCustomerProgramButton";
        private const string START_RESTAURANT_PROGRAM_BUTTON = "StartRestaurantProgramButton";
        private const string EXIT_BUTTON = "ExitButton";

        // Customer Side Form
        private const string CUSTOMER_SIDE_FORM = "PosCustomerSideForm";
        private readonly string[] CATEGORIES = new string[3]
        {
            "壽司", "甜點", "飲料"
        };
        private readonly string[] MEAL_BUTTONS = new string[9]
        {
            "MealButton0", "MealButton1", "MealButton2", "MealButton3", "MealButton4", "MealButton5", "MealButton6", "MealButton7", "MealButton8"
        };
        private const string ADD_BUTTON = "AddButton";
        private const string PREVIOUS_PAGE_BUTTON = "PreviousPageButton";
        private const string NEXT_PAGE_BUTTON = "NextPageButton";
        private const string MEAL_DESCRIBE_TEXTBOX = "MealDescribeTextBox";
        private const string ORDER_DATAGRIDVIEW = "OrderDataGridView";
        private const string PAGE_LABEL = "PageLabel";
        private const string TOTAL_LABEL = "TotalLabel";

        public CustomerSideFormCodedUITests()
        {
        }

        /// <summary>
        /// Launches the Calculator
        /// </summary>
        [TestInitialize()]
        public void Initialize()
        {
            Robot.Initialize(FILE_PATH, STARTUP_FORM);
            Robot.ClickButton(START_CUSTOMER_PROGRAM_BUTTON);
            Robot.SetForm(CUSTOMER_SIDE_FORM);
        }

        /// <summary>
        /// Closes the launched program
        /// </summary>
        [TestCleanup()]
        public void Cleanup()
        {
            Robot.CleanUp();
        }

        // 測試 Customer Side Form
        [TestMethod]
        public void CustomerSideFormTest()
        {
            Robot.AssertText(TOTAL_LABEL, "Total : 0 元");
            Robot.AssertText(PAGE_LABEL, "Page : 1 / 2");
            Robot.AssertButtonEnable(ADD_BUTTON, false);
            Robot.AssertButtonEnable(PREVIOUS_PAGE_BUTTON, false);
            Robot.AssertButtonEnable(NEXT_PAGE_BUTTON, true);
            Robot.AssertDataItemsInDataGridView(ORDER_DATAGRIDVIEW, 0);
            // 下一頁
            Robot.ClickButton(NEXT_PAGE_BUTTON);
            Robot.AssertText(PAGE_LABEL, "Page : 2 / 2");
            Robot.AssertButtonEnable(PREVIOUS_PAGE_BUTTON, true);
            Robot.AssertButtonEnable(NEXT_PAGE_BUTTON, false);
            // 上一頁
            Robot.ClickButton(PREVIOUS_PAGE_BUTTON);
            Robot.AssertText(PAGE_LABEL, "Page : 1 / 2");
            Robot.AssertButtonEnable(PREVIOUS_PAGE_BUTTON, false);
            Robot.AssertButtonEnable(NEXT_PAGE_BUTTON, true);
            // 換 tab
            Robot.ClickTabControl(CATEGORIES[1]);
            Robot.AssertText(PAGE_LABEL, "Page : 1 / 1");
            Robot.AssertButtonEnable(ADD_BUTTON, false);
            Robot.AssertButtonEnable(PREVIOUS_PAGE_BUTTON, false);
            Robot.AssertButtonEnable(NEXT_PAGE_BUTTON, false);
            // 換 tab
            Robot.ClickTabControl(CATEGORIES[2]);
            Robot.AssertText(PAGE_LABEL, "Page : 1 / 1");
            Robot.AssertButtonEnable(ADD_BUTTON, false);
            Robot.AssertButtonEnable(PREVIOUS_PAGE_BUTTON, false);
            Robot.AssertButtonEnable(NEXT_PAGE_BUTTON, false);
        }

        // 測試點餐
        [TestMethod]
        public void OrderMealTest()
        {
            // 點餐
            AssertOrderMeal(0, 1, "烤鯖魚押壽司", "壽司", "烤鯖魚押壽司，好吃", "40");
            Robot.AssertText(TOTAL_LABEL, "Total : 40 元");
            Robot.ClickTabControl(CATEGORIES[2]);
            AssertOrderMeal(1, 2, "啤酒", "飲料", "啤酒，好喝", "90");
            Robot.AssertText(TOTAL_LABEL, "Total : 130 元");
            AssertOrderMeal(5, 3, "1983年純頻果汁", "飲料", "1983年純頻果汁，好喝", "90");
            Robot.AssertText(TOTAL_LABEL, "Total : 220 元");
            Robot.ClickTabControl(CATEGORIES[1]);
            AssertOrderMeal(2, 4, "抹茶牛奶冰淇淋", "甜點", "抹茶牛奶冰淇淋，好甜", "90");
            Robot.AssertText(TOTAL_LABEL, "Total : 310 元");
            Robot.ClickTabControl(CATEGORIES[0]);
            AssertOrderMeal(8, 5, "柚子胡椒醃漬生鮮蝦", "壽司", "柚子胡椒醃漬生鮮蝦，好棒", "40");
            Robot.AssertText(TOTAL_LABEL, "Total : 350 元");
            Robot.ClickButton(NEXT_PAGE_BUTTON);
            AssertOrderMeal(5, 6, "酥脆炸蝦捲", "壽司", "酥脆炸蝦捲，好讚", "80");
            Robot.AssertText(TOTAL_LABEL, "Total : 430 元");
            Robot.ClickButton(PREVIOUS_PAGE_BUTTON);
            AssertOrderMeal(0, 7, "烤鯖魚押壽司", "壽司", "烤鯖魚押壽司，好吃", "40");
            Robot.AssertText(TOTAL_LABEL, "Total : 470 元");
        }

        // 完成點餐並Assert
        private void AssertOrderMeal(int buttonIndex, int index, string mealName, string categoryName, string describe, string unitPrice)
        {
            Robot.ClickButton(MEAL_BUTTONS[buttonIndex]);
            Robot.AssertEdit(MEAL_DESCRIBE_TEXTBOX, describe + "\r");
            Robot.AssertButtonEnable(ADD_BUTTON, true);
            Robot.ClickButton(ADD_BUTTON);
            Robot.AssertEdit(MEAL_DESCRIBE_TEXTBOX, "\r");
            Robot.AssertButtonEnable(ADD_BUTTON, false);
            Robot.AssertDataItemsInDataGridView(ORDER_DATAGRIDVIEW, index);
            Robot.AssertDataGridViewByIndex(ORDER_DATAGRIDVIEW, index, new string[] { "X", mealName, categoryName, unitPrice, "1", unitPrice + " NTD" });
        }

        // 測試修改訂單
        [TestMethod]
        public void ModifyOrderTest()
        {
            // 點餐
            Robot.ClickButton(MEAL_BUTTONS[0]); // 烤鯖魚押壽司 40
            Robot.ClickButton(ADD_BUTTON);
            Robot.ClickButton(MEAL_BUTTONS[8]); // 柚子胡椒醃漬生鮮蝦 40
            Robot.ClickButton(ADD_BUTTON);
            Robot.ClickButton(NEXT_PAGE_BUTTON);
            Robot.ClickButton(MEAL_BUTTONS[0]); // 炙烤照燒鮮蝦 40
            Robot.ClickButton(ADD_BUTTON);
            Robot.ClickTabControl(CATEGORIES[1]);
            Robot.ClickButton(MEAL_BUTTONS[0]); // 焦糖法式金磚 90
            Robot.ClickButton(ADD_BUTTON);
            Robot.ClickButton(MEAL_BUTTONS[2]); // 抹茶牛奶冰淇淋 90
            Robot.ClickButton(ADD_BUTTON);
            Robot.ClickTabControl(CATEGORIES[2]);
            Robot.ClickButton(MEAL_BUTTONS[4]); // 1983年啤酒 120
            Robot.ClickButton(ADD_BUTTON);
            Robot.ClickButton(MEAL_BUTTONS[5]); // 1983年純頻果汁 90
            Robot.ClickButton(ADD_BUTTON);
            Robot.AssertText(TOTAL_LABEL, "Total : 510 元");

            // 修改餐點
            Robot.SetDataGridViewQuantity(ORDER_DATAGRIDVIEW, "1", "5");
            Robot.AssertDataGridViewByIndex(ORDER_DATAGRIDVIEW, 1, new string[] { "X", "烤鯖魚押壽司", "壽司", "40", "5", "200 NTD" });
            Robot.AssertText(TOTAL_LABEL, "Total : 670 元");
            Robot.SetDataGridViewQuantity(ORDER_DATAGRIDVIEW, "7", "15");
            Robot.AssertDataGridViewByIndex(ORDER_DATAGRIDVIEW, 7, new string[] { "X", "1983年純頻果汁", "飲料", "90", "15", "1350 NTD" });
            Robot.AssertText(TOTAL_LABEL, "Total : 1930 元");
            Robot.SetDataGridViewQuantity(ORDER_DATAGRIDVIEW, "1", "20");
            Robot.AssertDataGridViewByIndex(ORDER_DATAGRIDVIEW, 1, new string[] { "X", "烤鯖魚押壽司", "壽司", "40", "20", "800 NTD" });
            Robot.AssertText(TOTAL_LABEL, "Total : 2530 元");
            Robot.SetDataGridViewQuantity(ORDER_DATAGRIDVIEW, "4", "100");
            Robot.AssertDataGridViewByIndex(ORDER_DATAGRIDVIEW, 4, new string[] { "X", "焦糖法式金磚", "甜點", "90", "100", "9000 NTD" });
            Robot.AssertText(TOTAL_LABEL, "Total : 11440 元");

            // 刪除餐點
            List<List<string>> data = new List<List<string>>
            {
                new List<string> { "X", "烤鯖魚押壽司", "壽司", "40", "20", "800 NTD" },
                new List<string> { "X", "柚子胡椒醃漬生鮮蝦", "壽司", "40", "1", "40 NTD" },
                new List<string> { "X", "炙烤照燒鮮蝦", "壽司", "40", "1", "40 NTD" },
                new List<string> { "X", "焦糖法式金磚", "甜點", "90", "100", "9000 NTD" },
                new List<string> { "X", "抹茶牛奶冰淇淋", "甜點", "90", "1", "90 NTD" },
                new List<string> { "X", "1983年啤酒", "飲料", "120", "1", "120 NTD" },
                new List<string> { "X", "1983年純頻果汁", "飲料", "90", "15", "1350 NTD" }
            };
            Robot.DeleteDataGridViewRowByIndex(ORDER_DATAGRIDVIEW, "3");
            data.RemoveAt(2);
            Robot.AssertDataItemsInDataGridView(ORDER_DATAGRIDVIEW, 6);
            for (int i = 0; i < data.Count; i++)
                Robot.AssertDataGridViewByIndex(ORDER_DATAGRIDVIEW, i + 1, data[i].ToArray());

            Robot.DeleteDataGridViewRowByIndex(ORDER_DATAGRIDVIEW, "6");
            data.RemoveAt(5);
            Robot.AssertDataItemsInDataGridView(ORDER_DATAGRIDVIEW, 5);
            for (int i = 0; i < data.Count; i++)
                Robot.AssertDataGridViewByIndex(ORDER_DATAGRIDVIEW, i + 1, data[i].ToArray());

            Robot.DeleteDataGridViewRowByIndex(ORDER_DATAGRIDVIEW, "5");
            data.RemoveAt(4);
            Robot.AssertDataItemsInDataGridView(ORDER_DATAGRIDVIEW, 4);
            for (int i = 0; i < data.Count; i++)
                Robot.AssertDataGridViewByIndex(ORDER_DATAGRIDVIEW, i + 1, data[i].ToArray());

            Robot.DeleteDataGridViewRowByIndex(ORDER_DATAGRIDVIEW, "1");
            data.RemoveAt(0);
            Robot.AssertDataItemsInDataGridView(ORDER_DATAGRIDVIEW, 3);
            for (int i = 0; i < data.Count; i++)
                Robot.AssertDataGridViewByIndex(ORDER_DATAGRIDVIEW, i + 1, data[i].ToArray());

            Robot.DeleteDataGridViewRowByIndex(ORDER_DATAGRIDVIEW, "1");
            Robot.AssertDataItemsInDataGridView(ORDER_DATAGRIDVIEW, 2);
            Robot.DeleteDataGridViewRowByIndex(ORDER_DATAGRIDVIEW, "1");
            Robot.AssertDataItemsInDataGridView(ORDER_DATAGRIDVIEW, 1);
            Robot.DeleteDataGridViewRowByIndex(ORDER_DATAGRIDVIEW, "1");
            Robot.AssertDataItemsInDataGridView(ORDER_DATAGRIDVIEW, 0);
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
