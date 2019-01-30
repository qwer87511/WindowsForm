using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PosSystem
{
    public partial class StartUpForm : Form
    {
        private StartUpFormPresentationModel _presentationModel;
        private CustomerFormPresentationModel _customerModel;
        private RestaurantFormMealManagerPresentationModel _restaurantMealModel;
        private RestaurantFormCategoryManagerPresentationModel _restaurantCategoryModel;

        public StartUpForm(StartUpFormPresentationModel presentationModel)
        {
            InitializeComponent();
            _presentationModel = presentationModel;
            Model model = new Model();
            _customerModel = new CustomerFormPresentationModel(model);
            _restaurantMealModel = new RestaurantFormMealManagerPresentationModel(model);
            _restaurantCategoryModel = new RestaurantFormCategoryManagerPresentationModel(model);
            _startCustomerProgramButton.DataBindings.Add(nameof(Button.Enabled), _presentationModel, nameof(StartUpFormPresentationModel.IsStartCustomerProgramButtonEnabled));
            _startRestaurantProgramButton.DataBindings.Add(nameof(Button.Enabled), _presentationModel, nameof(StartUpFormPresentationModel.IsStartRestaurantProgramButtonEnabled));
        }

        // 啟動客人用戶端
        private void StartCustomerProgram(object sender, EventArgs e)
        {
            PosCustomerSideForm customerSideForm = new PosCustomerSideForm(_customerModel);
            _presentationModel.IsStartCustomerProgramButtonEnabled = false;
            customerSideForm.FormClosed += CloseCustomerProgram;
            customerSideForm.Show();
        }

        // 啟動餐廳用戶端
        private void StartRestaurantProgram(object sender, EventArgs e)
        {
            PosRestaurantSideForm restaurantSideForm = new PosRestaurantSideForm(_restaurantMealModel, _restaurantCategoryModel);
            _presentationModel.IsStartRestaurantProgramButtonEnabled = false;
            restaurantSideForm.FormClosed += CloseRestaurantProgram;
            restaurantSideForm.Show();
        }

        // 關閉客人用戶端時通知model並將按鈕enable
        private void CloseCustomerProgram(object sender, FormClosedEventArgs e)
        {
            _presentationModel.IsStartCustomerProgramButtonEnabled = true;
        }

        // 關閉餐廳用戶端時通知model並將按鈕enable
        private void CloseRestaurantProgram(object sender, FormClosedEventArgs e)
        {
            _presentationModel.IsStartRestaurantProgramButtonEnabled = true;
        }

        // 離開程式
        private void ClickExitButton(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
