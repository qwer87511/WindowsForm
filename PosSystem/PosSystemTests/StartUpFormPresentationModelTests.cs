using Microsoft.VisualStudio.TestTools.UnitTesting;
using PosSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace PosSystem.Tests
{
    [TestClass()]
    public class StartUpFormPresentationModelTests
    {
        // Test Constructor and Properties
        [TestMethod()]
        public void StartUpFormPresentationModelTest()
        {
            StartUpFormPresentationModel model = new StartUpFormPresentationModel();
            model.IsStartCustomerProgramButtonEnabled = false;
            Assert.AreEqual(model.IsStartCustomerProgramButtonEnabled, false);
            model.IsStartRestaurantProgramButtonEnabled = false;
            Assert.AreEqual(model.IsStartRestaurantProgramButtonEnabled, false);
            model.IsStartCustomerProgramButtonEnabled = true;
            Assert.AreEqual(model.IsStartCustomerProgramButtonEnabled, true);
            model.IsStartRestaurantProgramButtonEnabled = true;
            Assert.AreEqual(model.IsStartRestaurantProgramButtonEnabled, true);
        }

        // 測試PropertyChanged事件
        [TestMethod()]
        public void PropertyChangedTest()
        {
            List<string> receivedEvents = new List<string>();
            StartUpFormPresentationModel model = new StartUpFormPresentationModel();
            // 訂閱事件
            model.PropertyChanged += delegate (object sender, PropertyChangedEventArgs e)
            {
                receivedEvents.Add(e.PropertyName);
            };
            model.IsStartCustomerProgramButtonEnabled = false;
            // 測試訂閱
            Assert.AreEqual(receivedEvents[0], nameof(StartUpFormPresentationModel.IsStartCustomerProgramButtonEnabled));
        }
    }
}