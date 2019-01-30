using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace PosSystem
{
    public class RestaurantFormPresentationModelBase
    {
        protected Model _model;
        public enum EditMode
        {
            Edit,
            Add
        };

        public RestaurantFormPresentationModelBase(Model model)
        {
            _model = model;
        }

        public BindingList<Meal> Meals
        {
            get
            {
                return _model.Meals;
            }
        }

        public BindingList<Category> Categories
        {
            get
            {
                return _model.Categories;
            }
        }
    }
}
