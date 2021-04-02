using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using Lab2.Models;
using Lab2.Views;
using Lab2.ViewModels;

namespace Lab2.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class ItemsPage : ContentPage
    {
        ItemsViewModel viewModel;

        public ItemsPage()
        {
            InitializeComponent();

            BindingContext = viewModel = new ItemsViewModel();
        }

        async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var item = args.SelectedItem as Item;
            if (item == null)
                return;

            await Navigation.PushAsync(new ItemDetailPage(new ItemDetailViewModel(item)));

            // Manually deselect item.
            ItemsListView.SelectedItem = null;
        }

        async void AddItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new NewItemPage()));
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.Items.Count == 0)
                viewModel.LoadItemsCommand.Execute(null);
        }

        private async void ImageButton_Clicked(object sender, EventArgs e)
        {
            textBox.Text = "Hello world!";

            ViewExtensions.FadeTo(sky, 0.2, 2000);

            await ViewExtensions.TranslateTo(button, 200, 0, 500);
            await ViewExtensions.RotateYTo(button, 0, 500);
            await ViewExtensions.TranslateTo(button, -200, 0, 500);
            await ViewExtensions.RotateYTo(button, 180, 500);

            ViewExtensions.FadeTo(sky, 1.0, 2000);

        }
    }
}