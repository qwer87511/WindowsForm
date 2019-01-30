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
    public class CategoryTests
    {
        // Test Constructor and Properties
        [TestMethod()]
        public void CategoryTest()
        {
            Category category = new Category("c1");
            // 測試所有屬性
            Assert.AreEqual("c1", category.Name);
            // 測試屬性setter
            category.Name = "c2";
            Assert.AreEqual("c2", category.Name);
        }

        // 測試PropertyChanged事件
        [TestMethod()]
        public void PropertyChangedTest()
        {
            List<string> receivedEvents = new List<string>();
            Category category = new Category("c1");
            // 訂閱事件
            category.PropertyChanged += delegate (object sender, PropertyChangedEventArgs e)
            {
                receivedEvents.Add(e.PropertyName);
            };
            category.Name = "c2";
            // 測試訂閱
            Assert.AreEqual(receivedEvents[0], nameof(Category.Name));
        }
    }
}