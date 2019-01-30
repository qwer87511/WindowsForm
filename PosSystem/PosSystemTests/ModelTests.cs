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
    public class ModelTests
    {
        // 測試model資料
        [TestMethod()]
        public void ModelTest()
        {
            Model model = new Model();
            Assert.AreEqual(model.Categories.Count, 3);
            Assert.AreEqual(model.Categories[0].Name, "壽司");
            Assert.AreEqual(model.Categories[1].Name, "甜點");
            Assert.AreEqual(model.Meals.Count, 27);
            Assert.AreEqual(model.Meals[0].Name, "烤鯖魚押壽司");
            Assert.AreEqual(model.Meals[26].Name, "1983年純頻果汁");
        }

        // 測試回傳特定種類的餐點
        [TestMethod()]
        public void GetMealsIdOfCategoryTest()
        {
            Model model = new Model();
            List<Meal> mealsList = model.GetMealsOfCategory(2);
            Assert.IsTrue(mealsList.All(x => x.Category.Name == "飲料"));
            Assert.AreEqual(mealsList.Count, 6);
            Assert.AreEqual(mealsList[1].Name, "啤酒");
            Assert.AreEqual(mealsList[2].Name, "100%純頻果汁");
            Assert.AreEqual(mealsList[5].Name, "1983年純頻果汁");

            mealsList = model.GetMealsOfCategory(0);
            Assert.IsTrue(mealsList.All(x => x.Category.Name == "壽司"));
            Assert.AreEqual(mealsList.Count, 15);
            Assert.AreEqual(mealsList[0].Name, "烤鯖魚押壽司");
            Assert.AreEqual(mealsList[2].Name, "鯖魚押壽司");
            Assert.AreEqual(mealsList[14].Name, "酥脆炸蝦捲");
        }

        // 測試回傳特定種類的餐點數量
        [TestMethod()]
        public void GetMealNumberOfCategoryTest()
        {
            Model model = new Model();
            Assert.AreEqual(model.GetMealNumberOfCategory(0), 15);
            Assert.AreEqual(model.GetMealNumberOfCategory(1), 6);
            Assert.AreEqual(model.GetMealNumberOfCategory(2), 6);
        }

        // 測試回傳特定種類的餐點名稱
        [TestMethod()]
        public void GetMealsNameOfCategoryTest()
        {
            Model model = new Model();
            // 測試甜點的第0 1 5項
            List<string> mealsNameList = model.GetMealsNameOfCategory(1);
            mealsNameList.All(mealsNameList.Contains);
            Assert.AreEqual(mealsNameList.Count, 6);
            Assert.AreEqual(mealsNameList[0], "焦糖法式金磚");
            Assert.AreEqual(mealsNameList[1], "喀滋蜜核桃焦糖聖代");
            Assert.AreEqual(mealsNameList[5], "義式提拉米蘇");
            // 測試甜點的第1 2 5項
            mealsNameList = model.GetMealsNameOfCategory(2);
            Assert.AreEqual(mealsNameList.Count, 6);
            Assert.AreEqual(mealsNameList[1], "啤酒");
            Assert.AreEqual(mealsNameList[2], "100%純頻果汁");
            Assert.AreEqual(mealsNameList[5], "1983年純頻果汁");
        }

        // 測試增加種類
        [TestMethod()]
        public void AddCategoryTest()
        {
            Model model = new Model();
            Category category = new Category("new");
            Category category2 = new Category("new2");
            int oldCategoriesNumber = model.CategoriesNumber;
            model.AddCategory(category);
            Assert.AreEqual(++oldCategoriesNumber, model.CategoriesNumber);
            Assert.AreEqual(model.Categories[oldCategoriesNumber - 1].Name, "new");
            model.AddCategory(category2);
            Assert.AreEqual(++oldCategoriesNumber, model.CategoriesNumber);
            Assert.AreEqual(model.Categories[oldCategoriesNumber - 1].Name, "new2");
        }

        // 測試刪除種類，亦刪除該種類的餐點
        [TestMethod()]
        public void DeleteCategoryCascadingDeleteMealTest()
        {
            Model model = new Model();
            int oldCategoriesNumber = model.CategoriesNumber;
            // 刪除第零個種類
            Category deletingCategory = model.Categories[0];
            model.DeleteCategoryAndBelongingItsMeal(0);
            Assert.AreEqual(--oldCategoriesNumber, model.CategoriesNumber);
            Assert.IsFalse(model.Categories.Contains(deletingCategory));
            Assert.IsNull(model.Meals.FirstOrDefault(m => m.Category == deletingCategory));
            // 刪除第一個種類
            deletingCategory = model.Categories[1];
            model.DeleteCategoryAndBelongingItsMeal(1);
            Assert.AreEqual(--oldCategoriesNumber, model.CategoriesNumber);
            Assert.IsFalse(model.Categories.Contains(deletingCategory));
            Assert.IsNull(model.Meals.FirstOrDefault(m => m.Category == deletingCategory));
            // 刪除全部種類
            while (model.CategoriesNumber > 0)
            {
                model.DeleteCategoryAndBelongingItsMeal(0);
            }
            Assert.AreEqual(model.CategoriesNumber, 0);
            Assert.AreEqual(model.MealsNumber, 0);
        }

        // 測試增加餐點
        [TestMethod()]
        public void AddMealTest()
        {
            Model model = new Model();
            Meal meal1 = new Meal("juice", model.Categories[0], 30, "good", "\\Resources\\drink0.png");
            Meal meal2 = new Meal("juice2", model.Categories[0], 30, "good", "\\Resources\\drink0.png");
            Meal meal3 = new Meal("juice3", model.Categories[1], 30, "good", "\\Resources\\drink0.png");
            Meal meal4 = new Meal("juice4", model.Categories[2], 30, "good", "\\Resources\\drink0.png");
            int oldMealNumber = model.MealsNumber;
            model.AddMeal(meal1);
            Assert.AreEqual(++oldMealNumber, model.MealsNumber);
            Assert.IsTrue(model.Meals.Contains(meal1));
            model.AddMeal(meal2);
            Assert.AreEqual(++oldMealNumber, model.MealsNumber);
            Assert.IsTrue(model.Meals.Contains(meal2));
            model.AddMeal(meal3);
            model.AddMeal(meal4);
            Assert.AreEqual(model.GetMealNumberOfCategory(0), 17);
            Assert.AreEqual(model.GetMealNumberOfCategory(1), 7);
            Assert.AreEqual(model.GetMealNumberOfCategory(2), 7);
        }

        // 測試刪除餐點
        [TestMethod()]
        public void DeleteMealTest()
        {
            Model model = new Model();
            int oldMealNumber = model.MealsNumber;
            // 刪除第五個餐點
            Meal deletingMeal = model.Meals[5];
            model.DeleteMeal(5);
            Assert.AreEqual(--oldMealNumber, model.MealsNumber);
            Assert.IsFalse(model.Meals.Contains(deletingMeal));
            // 刪除第零個餐點
            deletingMeal = model.Meals[0];
            model.DeleteMeal(0);
            Assert.AreEqual(--oldMealNumber, model.MealsNumber);
            Assert.IsFalse(model.Meals.Contains(deletingMeal));
            // 刪除全部餐點
            while (model.MealsNumber > 0)
            {
                model.DeleteMeal(0);
            }
            Assert.AreEqual(model.MealsNumber, 0);
        }

        // 測試回傳訂單是否包含某種類的餐點
        [TestMethod()]
        public void IsOrderContainedCategoryTest()
        {
            Model model = new Model();
            Category category1 = model.Categories[0];
            Category category2 = model.Categories[1];
            Category category3 = model.Categories[2];
            Meal meal1 = new Meal("juice1", category1, 30, "good", "\\Resources\\drink0.png");
            Meal meal2 = new Meal("juice2", category1, 33, "good", "\\Resources\\drink0.png");
            Meal meal3 = new Meal("juice3", category1, 44, "good", "\\Resources\\drink0.png");
            Meal meal4 = new Meal("juice4", category2, 30, "good", "\\Resources\\drink0.png");
            Meal meal5 = new Meal("juice5", category2, 33, "good", "\\Resources\\drink0.png");
            Meal meal6 = new Meal("juice6", category2, 44, "good", "\\Resources\\drink0.png");
            Assert.IsFalse(model.IsOrderContainedCategory(0));
            model.OrderMeal(meal1);
            model.OrderMeal(meal2);
            model.OrderMeal(meal3);
            model.OrderMeal(meal4);
            model.OrderMeal(meal5);
            model.OrderMeal(meal6);
            Assert.IsTrue(model.IsOrderContainedCategory(0));
            Assert.IsTrue(model.IsOrderContainedCategory(1));
            Assert.IsFalse(model.IsOrderContainedCategory(2));
            model.DeleteOrderItem(0);
            model.DeleteOrderItem(0);
            model.DeleteOrderItem(0);
            Assert.IsFalse(model.IsOrderContainedCategory(0));
        }

        // 測試點餐
        [TestMethod()]
        public void OrderMealTest()
        {
            Model model = new Model();
            Category category = new Category("new");
            Meal meal1 = new Meal("juice1", category, 30, "good", "\\Resources\\drink0.png");
            Meal meal2 = new Meal("juice2", category, 33, "good", "\\Resources\\drink0.png");
            Meal meal3 = new Meal("juice3", category, 44, "good", "\\Resources\\drink0.png");
            Assert.AreEqual(0, model.OrderItems.Count);
            model.OrderMeal(meal1);
            model.OrderMeal(meal2);
            model.OrderMeal(meal3);
            model.OrderMeal(meal1);
            model.OrderMeal(meal1);
            Assert.AreEqual(5, model.OrderItems.Count);
            Assert.AreEqual("juice1", model.OrderItems[0].Name);
            Assert.AreEqual("juice2", model.OrderItems[1].Name);
            Assert.AreEqual("juice3", model.OrderItems[2].Name);
            Assert.AreEqual("juice1", model.OrderItems[3].Name);
            Assert.AreEqual("juice1", model.OrderItems[4].Name);
        }

        // 測試修改餐點數量
        [TestMethod()]
        public void SetOrderItemQuantityTest()
        {
            Model model = new Model();
            Category category = new Category("new");
            Meal meal1 = new Meal("jee1", category, 30, "good", "\\Resources\\drink0.png");
            Meal meal2 = new Meal("jee2", category, 40, "good", "\\Resources\\drink0.png");
            Meal meal3 = new Meal("jee3", category, 50, "good", "\\Resources\\drink0.png");
            Meal meal4 = new Meal("jee3", category, 222, "good", "\\Resources\\drink0.png");
            Assert.AreEqual(0, model.TotalPrice);
            model.OrderMeal(meal1);
            model.OrderMeal(meal2);
            model.OrderMeal(meal3);
            model.OrderMeal(meal4);
            model.OrderMeal(meal1);
            // 起始數量為1
            Assert.AreEqual(1, model.OrderItems[0].Quantity);
            Assert.AreEqual(1, model.OrderItems[1].Quantity);
            Assert.AreEqual(40, model.OrderItems[1].Subtotal);
            // 修改數量
            model.SetOrderItemQuantity(3, 60);
            model.SetOrderItemQuantity(4, 55);
            Assert.AreEqual(60, model.OrderItems[3].Quantity);
            Assert.AreEqual(55, model.OrderItems[4].Quantity);
            Assert.AreEqual(222 * 60, model.OrderItems[3].Subtotal);
            Assert.AreEqual(30 * 55, model.OrderItems[4].Subtotal);
            Assert.AreEqual(15090, model.TotalPrice);
            Assert.AreEqual(15090, model.Order.TotalPrice);
        }

        // 測試刪除點餐
        [TestMethod()]
        public void RemoveOrderedMealTest()
        {
            Model model = new Model();
            Category category = new Category("new");
            Meal meal1 = new Meal("jee1", category, 40, "good", "\\Resources\\drink0.png");
            Meal meal2 = new Meal("jee2", category, 40, "good", "\\Resources\\drink0.png");
            Meal meal3 = new Meal("jee3", category, 90, "good", "\\Resources\\drink0.png");
            Meal meal4 = new Meal("jee3", category, 120, "good", "\\Resources\\drink0.png");
            Assert.AreEqual(0, model.TotalPrice);
            model.OrderMeal(meal1);//40
            model.OrderMeal(meal2);//40
            model.OrderMeal(meal1);//40
            model.OrderMeal(meal3);//90
            model.OrderMeal(meal4);//120
            Assert.AreEqual(5, model.OrderItems.Count);
            // 修改數量
            model.SetOrderItemQuantity(0, 41);
            model.SetOrderItemQuantity(4, 7);
            // 刪除
            model.DeleteOrderItem(0);
            Assert.AreEqual(4, model.OrderItems.Count);
            Assert.AreEqual(40 + 40 + 90 + 120 * 7, model.TotalPrice);
            model.DeleteOrderItem(0);
            Assert.AreEqual(3, model.OrderItems.Count);
            Assert.AreEqual(40 + 90 + 120 * 7, model.TotalPrice);
            // 刪除全部點餐
            while (model.OrderItems.Count > 0)
            {
                model.DeleteOrderItem(0);
            }
            Assert.AreEqual(model.OrderItems.Count, 0);
        }
    }
}