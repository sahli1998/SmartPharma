﻿using SmartPharma5.Model;
using SmartPharma5.Services;
using SmartPharma5.View;
using System.ComponentModel;

namespace SmartPharma5
{
    public partial class App : Application
    {
        public static BindingList<Tax> taxList;
        public static BindingList<Tax.Type> taxTypeList;
        public uint IdEmploye { get; set; }
        public int IdUser { get; set; }
        public App()
        {
           Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("Mjk2MzIxMEAzMjMzMmUzMDJlMzBnRkF1USsva0FUWndDOXpUUWtEZWsyQW9RcEg1Y0NDQmN6VURaemkwb0tZPQ==");
            InitializeComponent();
            Routing.RegisterRoute(nameof(HomeView), typeof(HomeView));
            Routing.RegisterRoute(nameof(SammaryView), typeof(SammaryView));
            Routing.RegisterRoute(nameof(SalesModule), typeof(SalesModule));
            Routing.RegisterRoute(nameof(ProfilingModule), typeof(ProfilingModule));
            Routing.RegisterRoute(nameof(PaymentModule), typeof(PaymentModule));
            Routing.RegisterRoute(nameof(HrModule), typeof(HrModule));
            Routing.RegisterRoute(nameof(LoginView), typeof(LoginView));
            Routing.RegisterRoute(nameof(OpportunityView), typeof(OpportunityView));
           

            Routing.RegisterRoute(nameof(CustomerView2), typeof(CustomerView2));
            user_contrat.getInfo().GetAwaiter();
            user_contrat.getModules().GetAwaiter();
            //user_contrat.getResponsabilities();
           // MainPage = new NavigationPage(new NavigationPage(new ShowMenuItemPages()));



            try
            {
                IdEmploye = (uint)Preferences.Get("idagent", Convert.ToUInt32(null));
                IdUser = Preferences.Get("iduser", 0);
                try
                {
                    if (User.UserIsActif(Convert.ToUInt32(IdEmploye)) == null)
                    {


                        MainPage = new NavigationPage(new NavigationPage(new TestInternet()));
                    }
                    else
                    {

                        int CrmGroupe = 0;

                        if (IdEmploye == 0)
                        {
                            MainPage = new NavigationPage(new NavigationPage(new LoginView()));


                        }


                        else
                        {
                            CrmGroupe = Task.Run(async () => await UserCheckModule()).Result;

                            switch (CrmGroupe)
                            {
                                case 27:

                                    MainPage = new NavigationPage(new NavigationPage(new HomeView()));
                                    break;
                                case 28:
                                    // Shell.Current.GoToAsync("/HomeView").GetAwaiter();
                                    MainPage = new NavigationPage(new NavigationPage(new HomeView()));
                                    break;
                                case 32:

                                    MainPage = new NavigationPage(new NavigationPage(new HomeView()));
                                    break;
                                case 37:

                                    MainPage =  new NavigationPage(new NavigationPage(new HomeView()));
                                    break;
                                default:

                                    MainPage = new NavigationPage(new NavigationPage(new HomeView()));
                                    break;
                            }
                        }

                        taxList = Tax.getList();
                        taxTypeList = Tax.Type.getList();
                    }

                }
                catch (Exception ex)
                {

                    MainPage =new LoginView();
                }

            }
            catch (Exception ex)
            { }

        }

        protected override void OnStart()
        {
            // Initialiser le Shell (si ce n'est pas déjà fait)
           /* Shell shell = (Shell)MainPage;
            if (shell == null)
            {
                MainPage = new AppShell();
                shell = (Shell)MainPage;
            }

            // Naviguer vers la page souhaitée
            shell.GoToAsync("//appshell/LoginView");*/
        }
        public static async Task<int> UserCheckModule()
        {
            int CrmGroupe = 0;
            int iduser = Preferences.Get("iduser", 0);
            var UMG = await User_Module_Groupe_Services.GetGroupeCRM(iduser);

            if (UMG != null)
            {
                CrmGroupe = UMG.IdGroup;
            }




            return CrmGroupe;


        }
    }
}