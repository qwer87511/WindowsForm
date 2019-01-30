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
    public class OrderItemTests
    {
        // Test Constructor and Properties
        [TestMethod()]
        public void OrderItemTest()
        {
            Category drink = new Category("drink");
            Meal meal = new Meal("juice", drink, 30, "good", "\\Resources\\drink0.png");
            OrderItem item = new OrderItem(meal);
            Assert.AreEqual(item.Meal, meal);
            Assert.AreEqual(meal.Name, item.Name);
            Assert.AreEqual(meal.Category.Name, item.CategoryName);
            Assert.AreEqual(meal.Price, item.UnitPrice);
            Assert.AreEqual(1, item.Quantity);
            Assert.AreEqual(30 * 1, item.Subtotal);
            Assert.AreEqual((30 * 1) + " NTD", item.SubtotalDollar);
        }

        // 測試order ite和meal的同步
        [TestMethod()]
        public void OrderItemSynchronizeTest()
        {
            Category category = new Category("drink");
            Meal meal = new Meal("juice", category, 30, "good", "\\Resources\\drink0.png");
            OrderItem item = new OrderItem(meal);
            // 測試meal名稱同步
            meal.Name = "Water";
            Assert.AreEqual("Water", item.Name);
            // 測試category同步
            category.Name = "liquid";
            Assert.AreEqual("liquid", item.CategoryName);
            // 測試meal價格同步
            meal.Price = 50;
            Assert.AreEqual(50 * 1, item.Subtotal);
            // 測試數量和價格同步
            item.Quantity++;
            Assert.AreEqual(50 * 2, item.Subtotal);
        }

        // 測試PropertyChanged事件
        [TestMethod()]
        public void PropertyChangedTest()
        {
            List<string> receivedEvents = new List<string>();
            Category drink = new Category("drink");
            Meal meal = new Meal("juice", drink, 30, "good", "\\Resources\\drink0.png");
            OrderItem item = new OrderItem(meal);
            // 訂閱事件
            item.PropertyChanged += delegate (object sender, PropertyChangedEventArgs e)
            {
                receivedEvents.Add(e.PropertyName);
            };
            item.Quantity++;
            // 測試訂閱
            Assert.AreEqual(receivedEvents[0], nameof(OrderItem.Quantity));
        }
    }
}