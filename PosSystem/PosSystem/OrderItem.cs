using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace PosSystem
{
    public class OrderItem : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private Meal _meal;
        private int _quantity;
        private int _subtotal;

        public OrderItem(Meal meal)
        {
            _meal = meal;
            Quantity = 1;
            meal.PropertyChanged += ChangeMealProperty;
        }

        // 通知屬性被更改
        void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        // meal更新時重新計算金額並發出通知
        private void ChangeMealProperty(object sender, PropertyChangedEventArgs e)
        {
            // 計算金額
            ComputeSubtotal();
            NotifyPropertyChanged(nameof(Name));
            NotifyPropertyChanged(nameof(CategoryName));
            NotifyPropertyChanged(nameof(UnitPrice));
        }

        // 計算該項餐點金額
        private void ComputeSubtotal()
        {
            Subtotal = UnitPrice * Quantity;
        }

        public Meal Meal
        {
            get
            {
                return _meal;
            }
        }

        public string Name
        {
            get
            {
                return _meal.Name;
            }
        }

        public string CategoryName
        {
            get
            {
                return _meal.Category.Name;
            }
        }

        // 修改時更新總金額
        public int UnitPrice
        {
            get
            {
                return _meal.Price;
            }
        }

        // 修改時更新總金額
        public int Quantity
        {
            set
            {
                _quantity = value;
                NotifyPropertyChanged(nameof(Quantity));
                // 更新總金額
                ComputeSubtotal();
            }
            get
            {
                return _quantity;
            }
        }

        public int Subtotal
        {
            set
            {
                _subtotal = value;
                NotifyPropertyChanged(nameof(Subtotal));
                NotifyPropertyChanged(nameof(SubtotalDollar));
            }
            get
            {
                return _subtotal;
            }
        }

        public string SubtotalDollar
        {
            get
            {
                const string CURRENCY = " NTD";
                return _subtotal + CURRENCY;
            }
        }
    }
}
