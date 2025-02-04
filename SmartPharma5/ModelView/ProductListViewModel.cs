﻿
/* Modification non fusionnée à partir du projet 'SmartPharma5 (net7.0-ios)'
Avant :
using SmartPharma5.Model;
using SmartPharma5.View;
using MvvmHelpers;
Après :
using MvvmHelpers;
using MvvmHelpers.Commands;
using SmartPharma5.Model;
*/
using MvvmHelpers;
using MvvmHelpers.Commands;

/* Modification non fusionnée à partir du projet 'SmartPharma5 (net7.0-ios)'
Avant :
using SmartPharma5.View;
using SmartPharma5.Model;
Après :
using SmartPharma5.Model;
using SmartPharma5.View;
*/
using SmartPharma5.Model;
using SmartPharma5.View;
using Command = MvvmHelpers.Commands.Command;
//using Xamarin.Essentials;

namespace SmartPharma5.ViewModel
{
    public class ProductListViewModel : BaseViewModel
    {
        //public ShoppingCardView ShoppingCardView { get; set; }
        public int Quantity { get; set; }
        private bool productpopup = false;
        public bool ProductPopup { get => productpopup; set => SetProperty(ref productpopup, value); }

        public Command AddProductCommand { get; set; }
        public AsyncCommand CancelProductCommand { get; set; }
        public AsyncCommand ExitCommand { get; set; }
        public AsyncCommand LogoutCommand { get; set; }
        public AsyncCommand ChangeClientCommand { get; set; }
        public MvvmHelpers.Commands.Command<Product> TapCommand { get; }

        private Product product;
        public Product Product { get => product; set => SetProperty(ref product, value); }
        public ObservableRangeCollection<OpportunityLine> Lines;
        public ObservableRangeCollection<Product> ProductList { get; set; }
        public Opportunity Opportunity { get; set; }
        public ProductListViewModel()
        {
        }
        public ProductListViewModel(Opportunity opportunity, ObservableRangeCollection<Product> products)
        {

            try
            {
                TapCommand = new MvvmHelpers.Commands.Command<Product>(TapCommandAsync);
                ExitCommand = new AsyncCommand(Exit);
                LogoutCommand = new AsyncCommand(Logout);
                ChangeClientCommand = new AsyncCommand(ChangeClient);
                AddProductCommand = new Command(AddProduct);
                CancelProductCommand = new AsyncCommand(CancelProduct);
                Opportunity = opportunity;
                ProductList = products;
            }
            catch(Exception ex)
            {

            }
         


        }

        private Task CancelProduct()
        {
            ProductPopup = false;
            return Task.CompletedTask;
        }

        private async void AddProduct()
        {
            try

            /* Modification non fusionnée à partir du projet 'SmartPharma5 (net7.0-ios)'
            Avant :
                        {

                            Opportunity.opportunity_lines.Add(new OpportunityLine(0, Product.name, Product.price_sale, Product.Id, Convert.ToDecimal(Quantity), Product.sale_tax1, Product.sale_tax2, Product.sale_tax3, Product.sale_tax4, Product.sale_tax5, Product.Discount));
            Après :
                        {

                            Opportunity.opportunity_lines.Add(new OpportunityLine(0, Product.name, Product.price_sale, Product.Id, Convert.ToDecimal(Quantity), Product.sale_tax1, Product.sale_tax2, Product.sale_tax3, Product.sale_tax4, Product.sale_tax5, Product.Discount));
            */
            {

               Opportunity.Opportunity_lines.Add(new OpportunityLine(0, Product.name, Product.price_sale, Product.Id, Convert.ToDecimal(Quantity), Product.sale_tax1, Product.sale_tax2, Product.sale_tax3, Product.sale_tax4, Product.sale_tax5, Product.Discount));
                await App.Current.MainPage.Navigation.PopAsync();
                //await Shell.Current.Navigation.PopAsync();
                //await Shell.Current.GoToAsync("../ProductListView");
                Opportunity.totalAmount = Opportunity.getTotalAmount();
            }
            catch (Exception ex)
            {

            }


        }

        private void TapCommandAsync(object obj)
        {
            Product = obj as Product;
            ProductPopup = true;
            //await App.Current.MainPage.Navigation.PushAsync(new ProductView(u));

        }


        private async Task ChangeClient()
        {
            var c = await App.Current.MainPage.DisplayAlert("Warning", "Are you sure you want to start new opportunity ?", "Yes", "No");
            if (c)
            {

                await App.Current.MainPage.Navigation.PushAsync(new CustomerListView());

            }
        }

        private async Task Logout()
        {
            var r = await App.Current.MainPage.DisplayAlert("Warning", "Are you sure you want to log out!", "Yes", "No");
            if (r)
            {
                await App.Current.MainPage.Navigation.PushAsync(new LoginView());
            }
        }

        private async Task Exit()
        {
            var r = await App.Current.MainPage.DisplayAlert("Warning", "Are you sure you want to exit!", "Yes", "No");
            if (r)
            {
                await App.Current.MainPage.Navigation.PushAsync(new HomeView());
            }
        }
    }
}
