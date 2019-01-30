using Microsoft.VisualStudio.TestTools.UnitTesting;
using PosSystem;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PosSystem.Tests
{
    [TestClass()]
    public class CustomerFormPresentationModelTests
    {
        CustomerFormPresentationModel _model;
        PrivateObject _target;

        // 測試初始化
        [TestInitialize()]
        public void Initialize()
        {
            _model = new CustomerFormPresentationModel(new Model());
            _target = new PrivateObject(_model);
        }

        // Test Constructor and Properties
        [TestMethod()]
        public void CustomerFormPresentationModelTest()
        {
            Assert.AreEqual(_model.SelectedCategoryIndex, 0);
            Assert.AreEqual(_model.Page, 0);
            Assert.AreEqual(_model.SelectedMealIndex, -1);
            Assert.AreEqual(_target.GetFieldOrProperty("IsSelectedMeal"), false);
            Assert.AreEqual(_model.Categories.Count, 3);
            Assert.AreEqual(_model.DisplayedMeals.Count, CustomerFormPresentationModel.PAGE_CAPACITY);
            Assert.AreEqual(_model.OrderItems.Count, 0);
            Assert.AreEqual(_model.DescriptionText, string.Empty);
            Assert.AreEqual(_target.GetFieldOrProperty("MaxPage"), 2);
            Assert.AreEqual(_model.PageLabel, "Page : 1 / 2");
            Assert.AreEqual(_model.TotalPrice, 0);
            Assert.AreEqual(_model.TotalPriceLabel, "Total : 0 元");
            Assert.IsFalse(_model.IsAddButtonEnabled);
            Assert.IsFalse(_model.IsPreviousButtonEnabled);
            Assert.IsTrue(_model.IsNextButtonEnabled);
        }

        // 測試選擇種類
        [TestMethod()]
        public void SelectedCategoryIndexTest()
        {
            _model.SelectedCategoryIndex = 1;
            Assert.AreEqual(_target.GetFieldOrProperty("MaxPage"), 1);
            Assert.AreEqual(_model.Page, 0);
            Assert.AreEqual(_model.PageLabel, "Page : 1 / 1");
            Assert.AreEqual(_model.DisplayedMeals.Count, 6);
            Assert.IsTrue(_model.DisplayedMeals.All(m => m.Category == _model.Categories[1]));
            Assert.AreEqual(_model.SelectedMealIndex, -1);
            Assert.IsFalse((bool)_target.GetFieldOrProperty("IsSelectedMeal"));
            Assert.IsFalse(_model.IsAddButtonEnabled);
            Assert.IsFalse(_model.IsPreviousButtonEnabled);
            Assert.IsFalse(_model.IsNextButtonEnabled);

            _model.SelectedCategoryIndex = 0;
            Assert.AreEqual(_target.GetFieldOrProperty("MaxPage"), 2);
            Assert.AreEqual(_model.Page, 0);
            Assert.AreEqual(_model.PageLabel, "Page : 1 / 2");
            Assert.AreEqual(_model.DisplayedMeals.Count, 9);
            Assert.IsTrue(_model.DisplayedMeals.All(m => m.Category == _model.Categories[0]));
            Assert.AreEqual(_model.SelectedMealIndex, -1);
            Assert.IsFalse((bool)_target.GetFieldOrProperty("IsSelectedMeal"));
            Assert.IsFalse(_model.IsAddButtonEnabled);
            Assert.IsFalse(_model.IsPreviousButtonEnabled);
            Assert.IsTrue(_model.IsNextButtonEnabled);
        }

        // 測試切換頁數
        [TestMethod()]
        public void PageTest()
        {
            _model.Page++;
            _model.Page++;
            _model.Page++;
            Assert.AreEqual(_model.Page, 1);
            Assert.AreEqual(_model.PageLabel, "Page : 2 / 2");
            Assert.AreEqual(_model.DisplayedMeals.Count, 6);
            Assert.IsTrue(_model.DisplayedMeals.All(m => m.Category == _model.Categories[0]));
            Assert.AreEqual(_model.SelectedMealIndex, -1);
            Assert.IsFalse((bool)_target.GetFieldOrProperty("IsSelectedMeal"));
            Assert.IsFalse(_model.IsAddButtonEnabled);
            Assert.IsTrue(_model.IsPreviousButtonEnabled);
            Assert.IsFalse(_model.IsNextButtonEnabled);

            _model.Page = -5;
            Assert.AreEqual(_model.Page, 0);
            Assert.AreEqual(_model.PageLabel, "Page : 1 / 2");
            Assert.AreEqual(_model.DisplayedMeals.Count, 9);
            Assert.IsTrue(_model.DisplayedMeals.All(m => m.Category == _model.Categories[0]));
            Assert.AreEqual(_model.SelectedMealIndex, -1);
            Assert.IsFalse((bool)_target.GetFieldOrProperty("IsSelectedMeal"));
            Assert.IsFalse(_model.IsAddButtonEnabled);
            Assert.IsFalse(_model.IsPreviousButtonEnabled);
            Assert.IsTrue(_model.IsNextButtonEnabled);
        }

        // 測試選擇餐點
        [TestMethod()]
        public void SelectedMealIndexTest()
        {
            _model.SelectedMealIndex = 2;
            Assert.AreEqual(_model.SelectedMealIndex, 2);
            Assert.IsTrue((bool)_target.GetFieldOrProperty("IsSelectedMeal"));
            Assert.IsTrue(_model.IsAddButtonEnabled);
            Assert.AreEqual(_model.DescriptionText, "鯖魚押壽司，好吃");

            _model.SelectedMealIndex = 0;
            Assert.AreEqual(_model.SelectedMealIndex, 0);
            Assert.IsTrue((bool)_target.GetFieldOrProperty("IsSelectedMeal"));
            Assert.IsTrue(_model.IsAddButtonEnabled);
            Assert.AreEqual(_model.DescriptionText, "烤鯖魚押壽司，好吃");

            // 取消選擇
            _model.SelectedMealIndex = -1;
            Assert.AreEqual(_model.SelectedMealIndex, -1);
            Assert.IsFalse((bool)_target.GetFieldOrProperty("IsSelectedMeal"));
            Assert.IsFalse(_model.IsAddButtonEnabled);
            Assert.AreEqual(_model.DescriptionText, string.Empty);

            _model.SelectedMealIndex = 8;
            Assert.AreEqual(_model.SelectedMealIndex, 8);
            Assert.IsTrue((bool)_target.GetFieldOrProperty("IsSelectedMeal"));
            Assert.IsTrue(_model.IsAddButtonEnabled);
            Assert.AreEqual(_model.DescriptionText, "柚子胡椒醃漬生鮮蝦，好棒");
        }

        // 測試加入已選餐點
        [TestMethod()]
        public void AddSelectedMealTest()
        {
            _model.SelectedMealIndex = 0;
            _model.AddSelectedMeal();
            Assert.AreEqual(_model.SelectedMealIndex, -1);
            Assert.IsFalse((bool)_target.GetFieldOrProperty("IsSelectedMeal"));
            Assert.IsFalse(_model.IsAddButtonEnabled);
            Assert.AreEqual(_model.DescriptionText, string.Empty);
            Assert.AreEqual(_model.OrderItems.Count, 1);
            Assert.AreEqual(_model.OrderItems[0].Name, "烤鯖魚押壽司");
            Assert.AreEqual(_model.OrderItems[0].Quantity, 1);
            Assert.AreEqual(_model.TotalPrice, 40);
            Assert.AreEqual(_model.TotalPriceLabel, "Total : 40 元");

            _model.SelectedMealIndex = 8;
            _model.AddSelectedMeal();
            _model.SelectedMealIndex = 2;
            _model.AddSelectedMeal();
            _model.SelectedMealIndex = 0;
            _model.AddSelectedMeal();
            Assert.AreEqual(_model.OrderItems.Count, 4);
            Assert.AreEqual(_model.OrderItems[1].Name, "柚子胡椒醃漬生鮮蝦");
            Assert.AreEqual(_model.OrderItems[2].Name, "鯖魚押壽司");
            Assert.AreEqual(_model.OrderItems[3].Name, "烤鯖魚押壽司");
            Assert.AreEqual(_model.TotalPrice, 160);
            Assert.AreEqual(_model.TotalPriceLabel, "Total : 160 元");
        }

        // 測試從點單移除指定項目
        [TestMethod()]
        public void DeleteOrderItemTest()
        {
            _model.SelectedMealIndex = 0;//40
            _model.AddSelectedMeal();
            _model.SelectedMealIndex = 8;//40
            _model.AddSelectedMeal();
            _model.SelectedMealIndex = 0;//40--delete
            _model.AddSelectedMeal();
            _model.SelectedMealIndex = 5;//80
            _model.AddSelectedMeal();

            _model.DeleteOrderItem(2);
            Assert.AreEqual(_model.OrderItems.Count, 3);
            Assert.AreEqual(_model.OrderItems[0].Name, "烤鯖魚押壽司");
            Assert.AreEqual(_model.OrderItems[1].Name, "柚子胡椒醃漬生鮮蝦");
            Assert.AreEqual(_model.OrderItems[2].Name, "特選長鰭鮪魚");
            Assert.AreEqual(_model.TotalPrice, 160);
            Assert.AreEqual(_model.TotalPriceLabel, "Total : 160 元");

            _model.SelectedMealIndex = 1;//40
            _model.AddSelectedMeal();
            _model.SelectedMealIndex = 2;//40
            _model.AddSelectedMeal();

            _model.DeleteOrderItem(0);
            _model.DeleteOrderItem(1);
            Assert.AreEqual(_model.OrderItems.Count, 3);
            Assert.AreEqual(_model.OrderItems[0].Name, "柚子胡椒醃漬生鮮蝦");
            Assert.AreEqual(_model.OrderItems[1].Name, "稻荷天婦羅壽司");
            Assert.AreEqual(_model.OrderItems[2].Name, "鯖魚押壽司");
            Assert.AreEqual(_model.TotalPrice, 120);
            Assert.AreEqual(_model.TotalPriceLabel, "Total : 120 元");
        }

        // 測試設定餐點數量
        [TestMethod()]
        public void SetOrderItemQuantityTest()
        {
            _model.SelectedMealIndex = 0;//40
            _model.AddSelectedMeal();
            _model.SelectedMealIndex = 8;//40
            _model.AddSelectedMeal();
            _model.SelectedMealIndex = 0;//40
            _model.AddSelectedMeal();
            _model.SelectedMealIndex = 5;//80
            _model.AddSelectedMeal();
            Assert.AreEqual(_model.OrderItems[0].Quantity, 1);
            _model.SetOrderItemQuantity(0, 55);
            _model.SetOrderItemQuantity(3, 66);
            Assert.AreEqual(_model.OrderItems[0].Quantity, 55);
            Assert.AreEqual(_model.OrderItems[3].Quantity, 66);
            Assert.AreEqual(_model.TotalPrice, 55 * 40 + 40 + 40 + 66 * 80);
            Assert.AreEqual(_model.TotalPriceLabel, "Total : " + (55 * 40 + 40 + 40 + 66 * 80) + " 元");
        }

        // 測試PropertyChanged事件
        [TestMethod()]
        public void PropertyChangedTest()
        {
            List<string> receivedEvents = new List<string>();

            // 訂閱事件
            _model.PropertyChanged += delegate (object sender, PropertyChangedEventArgs e)
            {
                receivedEvents.Add(e.PropertyName);
            };

            // 變更屬性
            _model.SelectedCategoryIndex = 1;
            
            // 測試訂閱
            Assert.IsTrue(receivedEvents.Contains(nameof(_model.SelectedCategoryIndex)));
            Assert.IsTrue(receivedEvents.Contains(nameof(_model.PageLabel)));
            Assert.IsTrue(receivedEvents.Contains(nameof(_model.IsAddButtonEnabled)));
            Assert.IsTrue(receivedEvents.Contains(nameof(_model.IsPreviousButtonEnabled)));
            Assert.IsTrue(receivedEvents.Contains(nameof(_model.IsNextButtonEnabled)));
        }

        // 測試 meal list 更新時更新畫面並發出 _displayedMealChanged 事件
        [TestMethod()]
        public void DisplayedMealChangedTest()
        {
            Model model = ((Model)_target.GetField("_model"));
            bool isReceivedEvent = false;

            // 訂閱事件
            _model._displayedMealChanged += delegate ()
            {
                isReceivedEvent = true;
            };

            // 修改名
            isReceivedEvent = false;
            model.Meals[1].Name = "qwer";
            Assert.IsTrue(isReceivedEvent);
            Assert.AreEqual("qwer", _model.DisplayedMeals[1].Name);

            // 修改種類
            isReceivedEvent = false;
            model.Meals[1].Category = model.Categories[2];
            Assert.IsTrue(isReceivedEvent);
            Assert.IsFalse(_model.DisplayedMeals.Contains(model.Meals[1])); // 是否把該meal從畫面移除

            // 刪除餐點的同步
            isReceivedEvent = false;
            Meal deletingMeal = model.Meals[0];
            model.Meals.RemoveAt(0);
            Assert.IsTrue(isReceivedEvent);
            Assert.AreNotEqual(deletingMeal, _model.DisplayedMeals[0]);
        }
    }
}