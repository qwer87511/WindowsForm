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
    public class OrderTests
    {
        // Test Constructor and Properties
        [TestMethod()]
        public void OrderTest()
        {
            Order order = new Order();
            Assert.AreEqual(order.TotalPrice, 0);
        }

        // 測試加入餐點
        [TestMethod()]
        public void AddTest()
        {
            Category category = new Category("drink");
            Meal meal1 = new Meal("烤鯖魚押壽司", category, 40, "好吃", "");
            Meal meal2 = new Meal("炙烤鮪魚腹鱒魚卵", category, 80, "好吃", "");
            Meal meal3 = new Meal("酥脆炸蝦捲", category, 80, "好吃", "");
            Meal meal4 = new Meal("義式提拉米蘇", category, 80, "好吃", "");
            Order order = new Order();
            order.Add(meal1);
            Assert.AreEqual(order.TotalPrice, 40);
            Assert.AreEqual(order.Items.Count, 1);
            Assert.AreEqual(order.Items[0].Meal.Name, "烤鯖魚押壽司");
            order.Add(meal1);
            order.Add(meal2);
            order.Add(meal3);
            order.Add(meal4);
            Assert.AreEqual(order.TotalPrice, 320);
            Assert.AreEqual(order.Items.Count, 5);
            Assert.AreEqual(order.Items[3].Meal.Name, "酥脆炸蝦捲");
            Assert.AreEqual(order.Items[4].Meal.Name, "義式提拉米蘇");
        }

        // 測試修改餐點數量
        [TestMethod()]
        public void SetMealNumberTest()
        {
            Category category = new Category("drink");
            Meal meal1 = new Meal("烤鯖魚押壽司", category, 80, "好吃", "");
            Meal meal2 = new Meal("炙烤鮪魚腹鱒魚卵", category, 40, "好吃", "");
            Meal meal3 = new Meal("酥脆炸蝦捲", category, 80, "好吃", "");
            Order order = new Order();
            order.Add(meal1);//80
            order.Add(meal1);//80
            order.Add(meal2);//40
            order.Add(meal3);//80
            order.SetMealNumber(0, 100);
            Assert.AreEqual(order.Items[0].Quantity, 100);
            Assert.AreEqual(order.TotalPrice, 8200);
            order.SetMealNumber(2, 66);
            Assert.AreEqual(order.Items[2].Quantity, 66);
            Assert.AreEqual(order.TotalPrice, 10800);
        }

        // 測試刪去特定餐點
        [TestMethod()]
        public void RemoveTest()
        {
            Category category = new Category("drink");
            Meal meal1 = new Meal("烤鯖魚押壽司", category, 40, "好吃", "");
            Meal meal2 = new Meal("炙烤鮪魚腹鱒魚卵", category, 80, "好吃", "");
            Meal meal3 = new Meal("酥脆炸蝦捲", category, 80, "好吃", "");
            Meal meal4 = new Meal("eee", category, 80, "好吃", "");
            Meal meal5 = new Meal("rrr", category, 80, "好吃", "");
            Meal meal6 = new Meal("ttt", category, 80, "好吃", "");
            Order order = new Order();
            order.Add(meal1);
            order.Add(meal2);
            order.Add(meal3);
            // 刪去第一項餐點
            order.Remove(1);
            Assert.AreEqual(order.Items.Count, 2);
            Assert.AreEqual(order.Items[0].Meal, meal1);
            Assert.AreEqual(order.Items[0].Meal.Name, "烤鯖魚押壽司");
            Assert.AreEqual(order.Items[1].Meal, meal3);
            Assert.AreEqual(order.Items[1].Meal.Name, "酥脆炸蝦捲");
            order.Add(meal4);
            order.Add(meal5);
            order.Add(meal6);
            // 刪去餐點
            order.Remove(2);
            order.Remove(0);
            Assert.AreEqual(order.Items[0].Meal, meal3);
            Assert.AreEqual(order.Items[0].Meal.Name, "酥脆炸蝦捲");
            Assert.AreEqual(order.Items[1].Meal, meal5);
            Assert.AreEqual(order.Items[1].Meal.Name, "rrr");
            Assert.AreEqual(order.Items[2].Meal, meal6);
            Assert.AreEqual(order.Items[2].Meal.Name, "ttt");
        }

        // 測試PropertyChanged事件
        [TestMethod()]
        public void PropertyChangedTest()
        {
            Meal meal = new Meal("eee", new Category(""), 80, "好吃", "");
            int receivedEventsCount = 0;
            Order order = new Order();
            // 訂閱事件
            order._orderChanged += delegate ()
            {
                receivedEventsCount++;
            };
            order.Add(meal);
            Assert.AreEqual(receivedEventsCount, 1);
            meal.Price = 123;
            Assert.IsTrue(receivedEventsCount > 1);
        }

        // 測試回傳是否包含某種類的餐點
        [TestMethod()]
        public void IsContainingCategoryTest()
        {
            Category category1 = new Category("drin23k");
            Category category2 = new Category("dre3k");
            Category category3 = new Category("dqwr");
            Meal meal1 = new Meal("烤鯖魚押壽司", category1, 40, "好吃", "");
            Meal meal2 = new Meal("炙烤鮪魚腹鱒魚卵", category1, 80, "好吃", "");
            Meal meal3 = new Meal("酥脆炸蝦捲", category1, 80, "好吃", "");
            Meal meal4 = new Meal("eee", category2, 80, "好吃", "");
            Meal meal5 = new Meal("rrr", category2, 80, "好吃", "");
            Meal meal6 = new Meal("ttt", category2, 80, "好吃", "");
            Order order = new Order();
            order.Add(meal1);
            order.Add(meal2);
            order.Add(meal3);
            order.Add(meal4);
            order.Add(meal5);
            order.Add(meal6);
            Assert.IsTrue(order.IsContainingCategory(category1));
            Assert.IsTrue(order.IsContainingCategory(category2));
            Assert.IsFalse(order.IsContainingCategory(category3));
        }

        //private Category[] PreparedCategoriesList
        //{
        //    get
        //    {
        //        return new Category[3] {
        //            new Category("Salty"),
        //            new Category("drink"),
        //            new Category("dessert")
        //        };
        //    }
        //}

        //private Meal[] PreparedMealsList
        //{
        //    get
        //    {
        //        Category[] categoriesList = PreparedCategoriesList;
        //        return new Meal[27] {
        //            new Meal("烤鯖魚押壽司", categoriesList[0], 40, "好吃", ""),
        //            new Meal("稻荷天婦羅壽司", categoriesList[0], 40, "好吃", ""),
        //            new Meal("鯖魚押壽司", categoriesList[0], 40, "好吃", ""),
        //            new Meal("大甲葉花枝", categoriesList[0], 40, "好吃", ""),
        //            new Meal("炙烤起司長鰭鮪魚", categoriesList[0], 40, "好吃", ""),
        //            new Meal("特選長鰭鮪魚", categoriesList[0], 80, "好吃", ""),
        //            new Meal("長鰭鮪魚", categoriesList[0], 40, "好吃", ""),
        //            new Meal("炙烤鮪魚腹鱒魚卵", categoriesList[0], 80, "好吃", ""),
        //            new Meal("柚子胡椒醃漬生鮮蝦", categoriesList[0], 80, "好吃", ""),
        //            new Meal("炙烤照燒鮮蝦", categoriesList[0], 40, "好吃", ""),
        //            new Meal("竹姬壽司蔥花鮪魚", categoriesList[0], 40, "好吃", ""),
        //            new Meal("熟成鮪魚", categoriesList[0], 40, "好吃", ""),
        //            new Meal("炙烤照燒鮭魚", categoriesList[0], 40, "好吃", ""),
        //            new Meal("黃金酥脆捲", categoriesList[0], 80, "好吃", ""),
        //            new Meal("酥脆炸蝦捲", categoriesList[0], 80, "好吃", ""),
        //            new Meal("焦糖法式金磚", categoriesList[1], 40, "好吃", ""),
        //            new Meal("喀滋蜜核桃焦糖聖代", categoriesList[1], 40, "好吃", ""),
        //            new Meal("抹茶牛奶冰淇淋", categoriesList[1], 40, "好吃", ""),
        //            new Meal("靜岡抹茶冰淇淋", categoriesList[1], 80, "好吃", ""),
        //            new Meal("京都風蕨餅", categoriesList[1], 80, "好吃", ""),
        //            new Meal("義式提拉米蘇", categoriesList[1], 80, "好吃", ""),
        //            new Meal("100%純柳橙汁", categoriesList[2], 40, "好吃", ""),
        //            new Meal("啤酒", categoriesList[2], 40, "好吃", ""),
        //            new Meal("100%純頻果汁", categoriesList[2], 40, "好吃", ""),
        //            new Meal("1983年純柳橙汁", categoriesList[2], 80, "好吃", ""),
        //            new Meal("1983年啤酒", categoriesList[2], 80, "好吃", ""),
        //            new Meal("1983年純頻果汁", categoriesList[2], 80, "好吃", ""),
        //        };
        //    }   
        //}
    }
}