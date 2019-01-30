using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows.Input;
using System.Windows.Forms;
using System.Drawing;
using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.VisualStudio.TestTools.UITest.Extension;
using Keyboard = Microsoft.VisualStudio.TestTools.UITesting.Keyboard;


namespace CodedUITestProject
{
    /// <summary>
    /// CodedUITest1 的摘要說明
    /// </summary>
    [CodedUITest]
    public class StartUpFormCodedUITests
    {
        private const string FILE_PATH = @"../../../PosSystem/bin/Debug/PosSystem.exe";
        
        // Start up Form
        private const string STARTUP_FORM = "StartUpForm";
        private const string START_CUSTOMER_PROGRAM_BUTTON = "StartCustomerProgramButton";
        private const string START_RESTAURANT_PROGRAM_BUTTON = "StartRestaurantProgramButton";
        private const string EXIT_BUTTON = "ExitButton";

        // Customer Side Form
        private const string CUSTOMER_SIDE_FORM = "PosCustomerSideForm";
        
        // Restaurant Side Form
        private const string RESTAURANT_SIDE_FORM = "PosRestaurantSideForm";
        
        public StartUpFormCodedUITests()
        {
        }

        /// <summary>
        /// Launches the Calculator
        /// </summary>
        [TestInitialize()]
        public void Initialize()
        {
            Robot.Initialize(FILE_PATH, STARTUP_FORM);
        }

        /// <summary>
        /// Closes the launched program
        /// </summary>
        [TestCleanup()]
        public void Cleanup()
        {
            Robot.CleanUp();
        }

        // 測試 Start Up Form
        [TestMethod]
        public void StartUpFormTest()
        {
            Robot.ClickButton(START_CUSTOMER_PROGRAM_BUTTON);
            Robot.AssertButtonEnable(START_CUSTOMER_PROGRAM_BUTTON, false);
            Robot.AssertWindow(CUSTOMER_SIDE_FORM);
            Robot.CloseWindow(CUSTOMER_SIDE_FORM);
            Robot.AssertButtonEnable(START_CUSTOMER_PROGRAM_BUTTON, true);
            Robot.ClickButton(START_RESTAURANT_PROGRAM_BUTTON);
            Robot.AssertButtonEnable(START_RESTAURANT_PROGRAM_BUTTON, false);
            Robot.AssertWindow(RESTAURANT_SIDE_FORM);
            Robot.CloseWindow(RESTAURANT_SIDE_FORM);
            Robot.AssertButtonEnable(START_RESTAURANT_PROGRAM_BUTTON, true);
            Robot.ClickButton(EXIT_BUTTON);
        }

        /// <summary>
        ///取得或設定提供目前測試回合
        ///相關資訊與功能的測試內容。
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }
        private TestContext testContextInstance;

        public UIMap UIMap
        {
            get
            {
                if (this.map == null)
                {
                    this.map = new UIMap();
                }

                return this.map;
            }
        }

        private UIMap map;
    }
}
