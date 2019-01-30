using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.ComponentModel;
using System.IO;

namespace PosSystem
{
    public class Meal : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private string _name;
        private Category _category;
        private int _price;
        private string _description;
        private string _relativeImagePath = string.Empty;
        private Image _image = null;

        public Meal(string name, Category category, int price, string description, string relativeImagePath)
        {
            Name = name;
            Category = category;
            Price = price;
            Description = description;
            ImageRelativePath = relativeImagePath;
            category.PropertyChanged += ChangeCategoryProperty;
        }

        // category 變更時發出通知 
        private void ChangeCategoryProperty(object sender, PropertyChangedEventArgs e)
        {
            NotifyPropertyChanged(nameof(Category));
        }

        // 通知屬性被更改
        void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public string Name
        {
            set
            {
                _name = value;
                NotifyPropertyChanged(nameof(Name));
                NotifyPropertyChanged(nameof(Data));
            }
            get
            {
                return _name;
            }
        }

        public Category Category
        {
            set
            {
                _category = value;
                NotifyPropertyChanged(nameof(Category));
            }
            get
            {
                return _category;
            }
        }

        public int Price
        {
            set
            {
                _price = value;
                NotifyPropertyChanged(nameof(Price));
                NotifyPropertyChanged(nameof(Data));
            }
            get
            {
                return _price;
            }
        }

        public string Description
        {
            set
            {
                _description = value;
                NotifyPropertyChanged(nameof(Description));
            }
            get
            {
                return _description;
            }
        }

        // 修改圖片路徑時更新圖片
        public string ImageRelativePath
        {
            set
            {
                _relativeImagePath = value;
                NotifyPropertyChanged(nameof(ImageRelativePath));
                if (_relativeImagePath != string.Empty)
                    Image = Image.FromFile(Path.GetDirectoryName(Path.GetDirectoryName(Directory.GetCurrentDirectory())) + _relativeImagePath);
                else
                    Image = null;
            }
            get
            {
                return _relativeImagePath;
            }
        }

        public Image Image
        {
            set
            {
                _image = value;
                NotifyPropertyChanged(nameof(Image));
            }
            get
            {
                return _image;
            }
        }

        public string Data
        {
            get
            {
                const string FORMAT = "{0}\n${1}";
                return string.Format(FORMAT, Name, Price);
            }
        }
    }
}
