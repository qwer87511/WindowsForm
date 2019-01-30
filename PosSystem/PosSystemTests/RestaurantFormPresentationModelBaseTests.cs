using Microsoft.VisualStudio.TestTools.UnitTesting;
using PosSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PosSystem.Tests
{
    [TestClass()]
    public class RestaurantFormPresentationModelBaseTests
    {
        // Test Constructor and Properties
        [TestMethod()]
        public void RestaurantFormPresentationModelBaseTest()
        {
            Model model = new Model();
            RestaurantFormPresentationModelBase pModel = new RestaurantFormPresentationModelBase(model);
            Assert.AreSame(model.Meals, pModel.Meals);
            Assert.AreSame(model.Categories, pModel.Categories);
        }
    }
}