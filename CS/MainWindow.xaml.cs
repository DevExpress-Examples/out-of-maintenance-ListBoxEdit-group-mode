using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Markup;
using System.ComponentModel;
using DevExpress.Mvvm;
using DevExpress.Mvvm.DataAnnotations;

namespace DXGridSample {
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
        }
    }
    [POCOViewModel]
    public class MainViewModel {
        public virtual ObservableCollection<Item> Items { get; set; }
        public virtual ICollectionView GroupedItems { get; set; }
        public MainViewModel() {
            Items = new ObservableCollection<Item>();
            for (int i = 0; i < 100; i++)
                Items.Add(new Item { Id = i, Name = "Name" + i, GroupName = "Group" + i % 10 });
            var listCollectionView = new ListCollectionView(Items);
            listCollectionView.GroupDescriptions.Add(new PropertyGroupDescription("GroupName"));
            GroupedItems = listCollectionView;
        }
    }
    public class Item {
        public int Id { get; set; }
        public string Name { get; set; }
        public string GroupName { get; set; }

        public string grouping { get; set; }
        public int SortIndex { get; set; }
    }
    public class TestConverter : MarkupExtension, IValueConverter {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
            return value;
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
            throw new NotImplementedException();
        }
        public override object ProvideValue(IServiceProvider serviceProvider) {
            return this;
        }
    }
}