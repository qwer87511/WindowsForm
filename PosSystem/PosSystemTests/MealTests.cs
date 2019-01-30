using Microsoft.VisualStudio.TestTools.UnitTesting;
using PosSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.IO;
using System.ComponentModel;

namespace PosSystem.Tests
{
    [TestClass()]
    public class MealTests
    {
        // Test Constructor and Properties
        [TestMethod()]
        public void MealTest()
        {
            List<string> receivedEvents = new List<string>();
            Category drink = new Category("drink");
            Meal meal = new Meal("juice", drink, 30, "good", "\\Resources\\drink0.png");
            Assert.AreEqual("juice", meal.Name);
            Assert.AreEqual(drink, meal.Category);
            Assert.AreEqual(30, meal.Price);
            Assert.AreEqual("good", meal.Description);
            Assert.AreEqual("\\Resources\\drink0.png", meal.ImageRelativePath);
            Assert.IsNotNull(meal.Image);
            Assert.AreEqual("juice\n$30", meal.Data);
            meal.PropertyChanged += delegate (object sender, PropertyChangedEventArgs e)
            {
                receivedEvents.Add(e.PropertyName);
            };
            // 測試圖片路徑為空
            meal.ImageRelativePath = string.Empty;
            Assert.AreEqual(string.Empty, meal.ImageRelativePath);
            Assert.IsNull(meal.Image);
            // 測試訂閱
            Assert.AreEqual(receivedEvents[0], nameof(Meal.ImageRelativePath));
        }

        // 測試PropertyChanged事件
        [TestMethod()]
        public void PropertyChangedTest()
        {
            List<string> receivedEvents = new List<string>();
            Category drink = new Category("drink");
            Meal meal = new Meal("juice", drink, 30, "good", "\\Resources\\drink0.png");
            // 訂閱事件
            meal.PropertyChanged += delegate (object sender, PropertyChangedEventArgs e)
            {
                receivedEvents.Add(e.PropertyName);
            };
            meal.Name = "c2";
            // 測試訂閱
            Assert.AreEqual(receivedEvents[0], nameof(Meal.Name));
        }
    }
}