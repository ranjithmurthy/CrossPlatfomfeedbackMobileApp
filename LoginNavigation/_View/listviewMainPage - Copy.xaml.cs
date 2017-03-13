//using System;
//using System.Collections.ObjectModel;
//using GroupingSampleListView;
//using Xamarin.Forms;

//namespace LoginNavigation
//{
//    public partial class MainPage : ContentPage
//    {
//        private ObservableCollection<GroupedVeggieModel> grouped { get; set; }
//        public MainPage()
//        {
//            InitializeComponent();

//            grouped = new ObservableCollection<GroupedVeggieModel>();
//            var veggieGroup = new GroupedVeggieModel() { LongName = "vegetables", ShortName = "v" };
//            var fruitGroup = new GroupedVeggieModel() { LongName = "fruit", ShortName = "f" };
//            veggieGroup.Add(new VeggieModel() { Name = "celery", IsReallyAVeggie = true, Comment = "try ants on a log" });
//            veggieGroup.Add(new VeggieModel() { Name = "tomato", IsReallyAVeggie = false, Comment = "pairs well with basil" });
//            veggieGroup.Add(new VeggieModel() { Name = "zucchini", IsReallyAVeggie = true, Comment = "zucchini bread > bannana bread" });
//            veggieGroup.Add(new VeggieModel() { Name = "peas", IsReallyAVeggie = true, Comment = "like peas in a pod" });
//            fruitGroup.Add(new VeggieModel() { Name = "banana", IsReallyAVeggie = false, Comment = "available in chip form factor" });
//            fruitGroup.Add(new VeggieModel() { Name = "strawberry", IsReallyAVeggie = false, Comment = "spring plant" });
//            fruitGroup.Add(new VeggieModel() { Name = "cherry", IsReallyAVeggie = false, Comment = "topper for icecream" });
//            grouped.Add(veggieGroup); grouped.Add(fruitGroup);
//            lstView.ItemsSource = grouped;
//        }

//        async void OnLogoutButtonClicked(object sender, EventArgs e)
//        {
//            App.IsUserLoggedIn = false;
//            Navigation.InsertPageBefore(new LoginPage(), this);
//            await Navigation.PopAsync();
//        }
//    }
//}
