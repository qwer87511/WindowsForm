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
    public class RestaurantFormMealManagerPresentationModelTests
    {
        RestaurantFormMealManagerPresentationModel _model;
        PrivateObject _target;

        // 測試初始化
        [TestInitialize()]
        public void Initialize()
        {
            _model = new RestaurantFormMealManagerPresentationModel(new Model());
            _target = new PrivateObject(_model);
        }

        // Test Constructor and Properties
        [TestMethod()]
        public void RestaurantFormMealManagerPresentationModelTest()
        {
            Assert.AreEqual(RestaurantFormPresentationModelBase.EditMode.Edit, _target.GetFieldOrProperty("Mode"));
            Assert.AreEqual(-1, _model.SelectedMealIndex);
            Assert.IsFalse((bool)_target.GetFieldOrProperty("_isSelectedMeal"));
            Assert.AreEqual("Edit Meal", _model.Title);
            Assert.AreEqual("Save", _model.SaveButtonText);
            Assert.AreEqual(string.Empty, _model.MealName);
            Assert.AreEqual(string.Empty, _model.MealPrice);
            Assert.AreEqual(-1, _model.MealCategoryIndex);
            Assert.AreEqual(string.Empty, _model.MealImagePath);
            Assert.AreEqual(string.Empty, _model.MealDescription);
            Assert.IsFalse(_model.IsEditEnable);
            Assert.IsFalse(_model.IsSaveButtonEnable);
            Assert.IsFalse(_model.IsDeleteButtonEnable);
        }

        // 測試選擇餐點
        [TestMethod()]
        public void SelectedMealIndexTest()
        {
            for (int i = 0; i < _model.Meals.Count; i++)
            {
                Meal meal = _model.Meals[i];
                _model.SelectedMealIndex = i;
                Assert.AreEqual(i, _model.SelectedMealIndex);
                Assert.IsTrue((bool)_target.GetFieldOrProperty("_isSelectedMeal"));
                Assert.AreEqual(RestaurantFormPresentationModelBase.EditMode.Edit, _target.GetFieldOrProperty("Mode"));
                Assert.IsTrue(IsMealEqualsToView(meal, _model.MealName, _model.MealPrice, _model.Categories[_model.MealCategoryIndex], _model.MealImagePath, _model.MealDescription));
                Assert.IsTrue(_model.IsEditEnable);
                Assert.IsFalse(_model.IsSaveButtonEnable);
                Assert.IsTrue(_model.IsDeleteButtonEnable);
            }
        }

        // 檢查餐點是否和view相等
        private bool IsMealEqualsToView(Meal meal, string name, string price, Category category, string path, string description)
        {
            return meal.Name == name && meal.Price.ToString() == price && meal.Category == category && meal.ImageRelativePath == path && meal.Description == description;
        }

        // 測試加入餐點模式
        [TestMethod()]
        public void EnterAddModeTest()
        {
            _model.EnterAddMode();
            // 測試模式
            Assert.AreEqual(RestaurantFormPresentationModelBase.EditMode.Add, _target.GetFieldOrProperty("Mode"));
            // 測試標題
            Assert.AreEqual("Add Meal", _model.Title);
            Assert.AreEqual("Add", _model.SaveButtonText);
            // 測試輸入
            _model.MealName = "abc";
            Assert.AreEqual("abc", _model.MealName);
            _model.MealPrice = "123";
            Assert.AreEqual("123", _model.MealPrice);
            _model.MealCategoryIndex = 0;
            Assert.AreEqual(0, _model.MealCategoryIndex);
            _model.MealImagePath = "def";
            Assert.AreEqual("def", _model.MealImagePath);
            _model.MealDescription = "ghi";
            _model.MealDescription = "gahi";
            Assert.AreEqual("gahi", _model.MealDescription);
            _model.MealName = "xxx";
            Assert.AreEqual("xxx", _model.MealName);
        }

        // 測試刪除所選餐點
        [TestMethod()]
        public void DeleteSelectedMealTest()
        {
            int number = _model.Meals.Count;
            Meal meal = _model.Meals[number - 1];
            _model.SelectedMealIndex = number - 1;
            _model.DeleteSelectedMeal();
            Assert.AreEqual(number - 1, _model.Meals.Count);
            Assert.IsFalse(_model.Meals.Contains(meal));
            Assert.IsFalse((bool)_target.GetFieldOrProperty("_isSelectedMeal"));
            Assert.AreEqual(-1, _model.SelectedMealIndex);

            number = _model.Meals.Count;
            meal = _model.Meals[20];
            _model.SelectedMealIndex = 20;
            _model.DeleteSelectedMeal();
            Assert.AreEqual(--number, _model.Meals.Count);
            Assert.IsFalse(_model.Meals.Contains(meal));
            Assert.IsFalse((bool)_target.GetFieldOrProperty("_isSelectedMeal"));
            Assert.AreEqual(-1, _model.SelectedMealIndex);

            // 刪除全部
            while ((number = _model.Meals.Count) > 0)
            {
                meal = _model.Meals[0];
                _model.SelectedMealIndex = 0;
                _model.DeleteSelectedMeal();
                Assert.AreEqual(number - 1, _model.Meals.Count);
                Assert.IsFalse(_model.Meals.Contains(meal));
                Assert.IsFalse((bool)_target.GetFieldOrProperty("_isSelectedMeal"));
                Assert.AreEqual(-1, _model.SelectedMealIndex);
            }
        }

        // 測試儲存按鈕Enable
        [TestMethod()]
        public void SaveButtonEnableTest()
        {
            _model.SelectedMealIndex = 0;
            
            // 名字為空無法儲存
            _model.MealName = "";
            Assert.IsFalse(_model.IsSaveButtonEnable);
            _model.MealName = "name1";
            Assert.IsTrue(_model.IsSaveButtonEnable);

            // 價格為0或正數以外無法儲存
            _model.MealPrice = "-2";
            Assert.IsFalse(_model.IsSaveButtonEnable);
            _model.MealPrice = ".";
            Assert.IsFalse(_model.IsSaveButtonEnable);
            _model.MealPrice = "022";
            Assert.IsTrue(_model.IsSaveButtonEnable);

            // 沒有選擇種類無法儲存
            _model.MealCategoryIndex = -1;
            Assert.IsFalse(_model.IsSaveButtonEnable);
            _model.MealCategoryIndex = 0;
            Assert.IsTrue(_model.IsSaveButtonEnable);

            // 沒有影像無法儲存
            _model.MealImagePath = "";
            Assert.IsFalse(_model.IsSaveButtonEnable);
            _model.MealImagePath = "path1";
            Assert.IsTrue(_model.IsSaveButtonEnable);

            // 無敘述可以儲存
            _model.MealDescription = "";
            Assert.IsTrue(_model.IsSaveButtonEnable);
        }

        // 測試按下儲存按鈕
        [TestMethod()]
        public void ClickSaveButtonTest()
        {
            // 編輯模式下儲存
            for (int i = 0; i < _model.Meals.Count; i++)
            {
                Meal meal = _model.Meals[i];
                _model.SelectedMealIndex = i;
                _model.MealName = "name" + i;
                _model.MealPrice = i.ToString();
                _model.MealCategoryIndex = i % 3;
                _model.MealImagePath = "\\Resources\\meal" + i % 15 + ".png";
                _model.MealDescription = "description" + i;
                _model.ClickSaveButton();
                Assert.IsTrue(IsMealEqualsToView(meal, _model.MealName, _model.MealPrice, _model.Categories[_model.MealCategoryIndex], _model.MealImagePath, _model.MealDescription));
            }

            // 新增餐點
            for (int i = 0; i < 10; i++)
            {
                _model.EnterAddMode();
                _model.MealName = "newname" + i;
                _model.MealPrice = i.ToString();
                _model.MealCategoryIndex = i % 3;
                _model.MealImagePath = "\\Resources\\drink" + i % 6 + ".png";
                _model.MealDescription = "newdescription" + i;
                _model.ClickSaveButton();
                Assert.IsTrue(IsMealEqualsToView(_model.Meals.Last(), _model.MealName, _model.MealPrice, _model.Categories[_model.MealCategoryIndex], _model.MealImagePath, _model.MealDescription));
            }
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

            // 編輯餐點
            _model.SelectedMealIndex = 10;
            _model.MealName = "new";
            Assert.IsTrue(receivedEvents.Contains(nameof(_model.SelectedMealIndex)));
            Assert.IsTrue(receivedEvents.Contains(nameof(_model.MealName)));
            Assert.IsTrue(receivedEvents.Contains(nameof(_model.MealPrice)));
            Assert.IsTrue(receivedEvents.Contains(nameof(_model.MealCategoryIndex)));
            Assert.IsTrue(receivedEvents.Contains(nameof(_model.MealImagePath)));
            Assert.IsTrue(receivedEvents.Contains(nameof(_model.MealDescription)));
            Assert.IsTrue(receivedEvents.Contains(nameof(_model.IsEditEnable)));
            Assert.IsTrue(receivedEvents.Contains(nameof(_model.IsDeleteButtonEnable)));
            Assert.IsTrue(receivedEvents.Contains(nameof(_model.IsSaveButtonEnable)));

            // 進入加入模式
            receivedEvents.Clear();
            _model.EnterAddMode();
            Assert.IsTrue(receivedEvents.Contains(nameof(_model.Title)));
            Assert.IsTrue(receivedEvents.Contains(nameof(_model.SaveButtonText)));
        }
    }
}