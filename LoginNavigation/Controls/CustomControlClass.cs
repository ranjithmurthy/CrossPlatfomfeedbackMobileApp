using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LoginNavigation._ViewModels;
using Xamarin.Forms;

namespace LoginNavigation.Controls
{
   

    public class CustomList : ListView
    {


        public ObservableCollection<SurveryData> ListDataSource
        {
            get { return (ObservableCollection<SurveryData>)GetValue(DataSourceProperty); }
            set
            {
                SetValue(DataSourceProperty, value);
                this.ItemsSource = value;
            }
        }

        // Using a DependencyProperty as the backing store for ImageURL.  This enables animation, styling, binding, etc...
        public static readonly BindableProperty DataSourceProperty =
            BindableProperty.Create<CustomList, ObservableCollection<SurveryData>>(x => x.ListDataSource,
            defaultValue: new ObservableCollection<SurveryData>(),
            defaultBindingMode: BindingMode.TwoWay,
            propertyChanging: (bindable, oldValue, newValue) =>
            {
                var ctrl = (CustomList)bindable;
                ctrl.ItemsSource = newValue;
            });

    }
}
