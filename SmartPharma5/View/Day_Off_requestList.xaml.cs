using Acr.UserDialogs;
using SmartPharma5.ModelView;

namespace SmartPharma5.View;

public partial class Day_Off_requestList : ContentPage
{
    public Day_Off_requestList(int id)
    {
        InitializeComponent();
        BindingContext = new Cong�MV(id);
    }

    //protected  override  bool OnBackButtonPressed()
    //{
    //    //UserDialogs.Instance.ShowLoading("Loading Pleae wait ...");
    //   // Task.Delay(500).GetAwaiter();
    //    //App.Current.MainPage.Navigation.PushAsync(new NavigationPage(new HomeView())).GetAwaiter();
    //   // UserDialogs.Instance.HideLoading();

    //    return true;
    //}

}