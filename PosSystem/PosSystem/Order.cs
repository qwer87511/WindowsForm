using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace PosSystem
{
    public class Order
    {
        public delegate void OrderChangedEventHandler();
        public event OrderChangedEventHandler _orderChanged;
        private BindingList<OrderItem> _items;
        private int _totalPrice;

        public Order()
        {
            TotalPrice = 0;
            _items = new BindingList<OrderItem>();
            _items.ListChanged += UpdateAndNotify;
        }

        // 通知total price修改
        private void NotifyOrderChanged()
        {
            if (_orderChanged != null)
            {
                _orderChanged();
            }
        }

        // order list 改變時更新總金額並通知
        private void UpdateAndNotify(object sender, ListChangedEventArgs e)
        {
            ComputeTotalPrice();
            NotifyOrderChanged();
        }

        // 將餐點加入清單
        public void Add(Meal meal)
        {
            _items.Add(new OrderItem(meal));
        }

        // 設定餐點數量
        public void SetMealNumber(int index, int number)
        {
            _items[index].Quantity = number;
        }

        // 刪除餐點
        public void Remove(int index)
        {
            _items.RemoveAt(index);
        }

        // 計算總金額
        private void ComputeTotalPrice()
        {
            TotalPrice = _items.Sum(i => i.Subtotal);
        }

        // 回傳是否包含某種類的餐點
        public bool IsContainingCategory(Category category)
        {
            return _items.FirstOrDefault(i => i.Meal.Category == category) != null;
        }

        public BindingList<OrderItem> Items
        {
            get
            {
                return _items;
            }
        }

        public int TotalPrice
        {
            set
            {
                _totalPrice = value;
            }
            get
            {
                return _totalPrice;
            }
        }
    }
}
