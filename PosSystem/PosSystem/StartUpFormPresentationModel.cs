using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ComponentModel;

namespace PosSystem
{
    public class StartUpFormPresentationModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private bool _isCustomerProgramStarted = true;
        private bool _isRestaurantProgramStarted = true;

        public StartUpFormPresentationModel()
        {
        }

        // 通知屬性修改
        protected void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public bool IsStartCustomerProgramButtonEnabled
        {
            set
            {
                _isCustomerProgramStarted = value;
                NotifyPropertyChanged(nameof(IsStartCustomerProgramButtonEnabled));
            }
            get
            {
                return _isCustomerProgramStarted;
            }
        }

        public bool IsStartRestaurantProgramButtonEnabled
        {
            set
            {
                _isRestaurantProgramStarted = value;
                NotifyPropertyChanged(nameof(IsStartRestaurantProgramButtonEnabled));
            }
            get
            {
                return _isRestaurantProgramStarted;
            }
        }
    }
}
