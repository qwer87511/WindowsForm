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
    public class RestaurantFormCategoryManagerPresentationModelTests
    {
        RestaurantFormCategoryManagerPresentationModel _model;
        PrivateObject _target;

        // 測試初始化
        [TestInitialize()]
        public void Initialize()
        {
            _model = new RestaurantFormCategoryManagerPresentationModel(new Model());
            _target = new PrivateObject(_model);
        }

        // Test Constructor and Properties
        [TestMethod()]
        public void RestaurantFormCategoryManagerPresentationModelTest()
        {
            Assert.AreEqual(RestaurantFormPresentationModelBase.EditMode.Edit, _target.GetFieldOrProperty("Mode"));
            Assert.AreEqual(-1, _model.SelectedCategoryIndex);
            Assert.IsFalse((bool)_target.GetFieldOrProperty("_isSelectedCategory"));
            Assert.AreEqual("Edit Category", _model.Title);
            Assert.AreEqual("Save", _model.SaveButtonText);
            Assert.AreEqual(string.Empty, _model.CategoryName);
            Assert.IsFalse(_model.MealsNameOfSelectedCategory.Any());
            Assert.IsFalse(_model.IsEditEnable);
            Assert.IsFalse(_model.IsSaveButtonEnable);
            Assert.IsFalse(_model.IsDeleteButtonEnable);
        }

        // 測試選擇種類
        [TestMethod()]
        public void SelectedMealIndexTest()
        {
            for (int i = 0; i < _model.Categories.Count; i++)
            {
                Category category = _model.Categories[i];
                _model.SelectedCategoryIndex = i;
                Assert.AreEqual(i, _model.SelectedCategoryIndex);
                Assert.IsTrue((bool)_target.GetFieldOrProperty("_isSelectedCategory"));
                Assert.AreEqual(RestaurantFormPresentationModelBase.EditMode.Edit, _target.GetFieldOrProperty("Mode"));
                Assert.AreEqual(category.Name, _model.CategoryName);
                Assert.IsTrue(_model.MealsNameOfSelectedCategory.All(_model.Meals.Where(x => x.Category == category).Select(x => x.Name).Contains));
                Assert.IsTrue(_model.IsEditEnable);
                Assert.IsFalse(_model.IsSaveButtonEnable);
                Assert.IsTrue(_model.IsDeleteButtonEnable);
            }
        }

        // 測試加入模式
        [TestMethod()]
        public void EnterAddModeTest()
        {
            _model.EnterAddMode();
            // 測試模式
            Assert.AreEqual(RestaurantFormPresentationModelBase.EditMode.Add, _target.GetFieldOrProperty("Mode"));
            Assert.AreEqual(-1, _model.SelectedCategoryIndex);
            // 測試標題
            Assert.AreEqual("Add Category", _model.Title);
            Assert.AreEqual("Add", _model.SaveButtonText);
            // 測試輸入
            _model.CategoryName = "abc";
            Assert.AreEqual("abc", _model.CategoryName);
            _model.CategoryName = "xxx";
            Assert.AreEqual("xxx", _model.CategoryName);
        }

        // 測試刪除所選種類
        [TestMethod()]
        public void DeleteSelectedCategoryTest()
        {
            int number = _model.Categories.Count;
            Category category = _model.Categories[number - 1];
            _model.SelectedCategoryIndex = number - 1;
            _model.DeleteSelectedCategory();
            Assert.AreEqual(number - 1, _model.Categories.Count);
            Assert.IsFalse(_model.Categories.Contains(category));
            Assert.IsFalse((bool)_target.GetFieldOrProperty("_isSelectedCategory"));
            Assert.AreEqual(-1, _model.SelectedCategoryIndex);

            // 刪除全部
            while ((number = _model.Categories.Count) > 0)
            {
                category = _model.Categories[0];
                _model.SelectedCategoryIndex = 0;
                _model.DeleteSelectedCategory();
                Assert.AreEqual(number - 1, _model.Categories.Count);
                Assert.IsFalse(_model.Categories.Contains(category));
                Assert.IsFalse((bool)_target.GetFieldOrProperty("_isSelectedCategory"));
                Assert.AreEqual(-1, _model.SelectedCategoryIndex);
            }
        }

        // 測試按下儲存按鈕
        [TestMethod()]
        public void ClickSaveButtonTest()
        {
            // 編輯模式下儲存
            for (int i = 0; i < _model.Categories.Count; i++)
            {
                Category category = _model.Categories[i];
                _model.SelectedCategoryIndex = i;
                _model.CategoryName = "name" + i;
                _model.ClickSaveButton();
                Assert.AreEqual("name" + i, category.Name);
            }

            // 新增種類
            for (int i = 0; i < 10; i++)
            {
                _model.EnterAddMode();
                _model.CategoryName = "newname" + i;
                _model.ClickSaveButton();
                Assert.AreEqual("newname" + i, _model.Categories.Last().Name);
            }
        }

        // 測試PropertyChanged事件
        [TestMethod()]
        public void PropertyChangedTest()
        {
            List<string> receivedEvents = new List<string>();
            bool isReceivedListEvent = false;

            // 訂閱事件
            _model.PropertyChanged += delegate (object sender, PropertyChangedEventArgs e)
            {
                receivedEvents.Add(e.PropertyName);
            };
            _model.MealsNameOfSelectedCategory.ListChanged += delegate (object sender, ListChangedEventArgs e)
            {
                isReceivedListEvent = true;
            };

            // 編輯餐點
            _model.SelectedCategoryIndex = 1;
            Assert.IsTrue(receivedEvents.Contains(nameof(_model.SelectedCategoryIndex)));
            Assert.IsTrue(receivedEvents.Contains(nameof(_model.CategoryName)));
            Assert.IsTrue(receivedEvents.Contains(nameof(_model.IsEditEnable)));
            Assert.IsTrue(receivedEvents.Contains(nameof(_model.IsDeleteButtonEnable)));
            Assert.IsTrue(receivedEvents.Contains(nameof(_model.IsSaveButtonEnable)));
            Assert.IsTrue(isReceivedListEvent);

            // 進入加入模式
            receivedEvents.Clear();
            _model.EnterAddMode();
            Assert.IsTrue(receivedEvents.Contains(nameof(_model.Title)));
            Assert.IsTrue(receivedEvents.Contains(nameof(_model.SaveButtonText)));
        }
    }
}