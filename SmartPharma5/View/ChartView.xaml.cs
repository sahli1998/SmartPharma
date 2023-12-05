using Acr.UserDialogs;
using DevExpress.Maui.DataGrid;
using SmartPharma5.ViewModel;
//using DevExpress.Maui.DataGrid.iOS.Internal;
using Microsoft.Maui;
using DevExpress.Utils.Filtering.Internal;
using SmartPharma5.Model;
using DevExpress.Maui.Core;

using SQLite;
using SmartPharma5.ModelView;

namespace SmartPharma5.View;

public partial class ChartView : ContentPage
{
    public ChartView(List<ModelGridParametre> List_Paramettre_final, string xml_file)
    {
        InitializeComponent();
        BindingContext = new GridMV(List_Paramettre_final, xml_file);
        var ovm = BindingContext as GridMV;

        DataGridView data = new DataGridView
        {
            ItemsSource = ovm.GridList,
            AllowSort = true,
            AllowGroupCollapse = true,
            AllowVirtualHorizontalScrolling = true,
            FilterIconColor = Colors.BlueViolet,
            ShowAutoFilterRow = true,



        };

        List<GridElement> ListGrid = new List<GridElement>();
        ListGrid = ovm.ContentList;



        foreach (GridElement e in ListGrid)
        {
            if (e.type.ToLower() == "string")
            {
                data.Columns.Add(new TextColumn
                {
                    FieldName = e.name,
                    Caption = e.name.ToUpper(),
                    HorizontalContentAlignment = TextAlignment.Center,
                    MinWidth = 200
                });

            }
            else if (e.type.ToLower() == "boolean")
            {
                data.Columns.Add(new CheckBoxColumn
                {
                    FieldName = e.name,
                    Caption = e.name.ToUpper(),
                    HorizontalContentAlignment = TextAlignment.Center,
                    MinWidth = 200
                });

            }
            else if (e.type.ToLower() == "uint32" || e.type.ToLower() == "decimal" || e.type.ToLower() == "uint16")
            {
                data.Columns.Add(new NumberColumn
                {
                    FieldName = e.name,
                    MaxDecimalDigitCount = 5,


                    Caption = e.name.ToUpper(),
                    HorizontalContentAlignment = TextAlignment.Center,
                    MinWidth = 250
                });

            }
            else if (e.type.ToLower() == "datetime")
            {
                data.Columns.Add(new DateColumn
                {
                    FieldName = e.name,
                    Caption = e.name.ToUpper(),
                    HorizontalContentAlignment = TextAlignment.Center,
                    MinWidth = 200
                });

            }
            else
            {
                data.Columns.Add(new TextColumn
                {
                    FieldName = e.name,

                    Caption = e.name.ToUpper(),
                    HorizontalContentAlignment = TextAlignment.Center,
                    MinWidth = 200
                });

            }


        }



        List<GridColumnAttributeSymmary> ListSummary = ovm.SUMMURIES;
        foreach (GridColumnAttributeSymmary summ in ListSummary)
        {


            GridColumnSummary Opp = new GridColumnSummary
            {
                FieldName = summ.DataMember,

            };
            if (summ.summaryType.ToLower() == "avg")
            {
                Opp.Type = DataSummaryType.Average;
                Opp.DisplayFormat = "AVG: {0:F3} ";
                data.TotalSummaries.Add(Opp);

            }
            else if (summ.summaryType.ToLower() == "sum")
            {
                Opp.Type = DataSummaryType.Sum;
                Opp.DisplayFormat = "SUM: {0:F3} ";
                data.TotalSummaries.Add(Opp);

            }
            else if (summ.summaryType.ToLower() == "count")
            {
                Opp.Type = DataSummaryType.Count;
                Opp.DisplayFormat = "COUNT : {0:F0} ";
                data.TotalSummaries.Add(Opp);
            }
            else if (summ.summaryType.ToLower() == "max")
            {
                Opp.Type = DataSummaryType.Max;
                Opp.DisplayFormat = "MAX : {0:F3} ";
                data.TotalSummaries.Add(Opp);
            }
            else if (summ.summaryType.ToLower() == "min")
            {
                Opp.Type = DataSummaryType.Min;
                Opp.DisplayFormat = "MIN : {0:F3} ";
                data.TotalSummaries.Add(Opp);
            }



        }






        scroll.Add(new Button { Text = "Parametrage", Margin = 10 });

        scroll.Add(data);





    }
    public ChartView()
    {
        InitializeComponent();
        BindingContext = new GridMV();
        var ovm = BindingContext as GridMV;

        DataGridView data = new DataGridView
        {
            ItemsSource = ovm.GridList,
            AllowSort = true,
            AllowGroupCollapse = true,
            AllowVirtualHorizontalScrolling = true,
            FilterIconColor = Colors.BlueViolet,
            ShowAutoFilterRow = true,



        };

        List<GridElement> ListGrid = new List<GridElement>();
        ListGrid = ovm.ContentList;



        foreach (GridElement e in ListGrid)
        {
            if (e.type.ToLower() == "string")
            {
                data.Columns.Add(new TextColumn
                {
                    FieldName = e.name,
                    Caption = e.name.ToUpper(),
                    HorizontalContentAlignment = TextAlignment.Center,
                    MinWidth = 200
                });

            }
            else if (e.type.ToLower() == "boolean")
            {
                data.Columns.Add(new CheckBoxColumn
                {
                    FieldName = e.name,
                    Caption = e.name.ToUpper(),
                    HorizontalContentAlignment = TextAlignment.Center,
                    MinWidth = 200
                });

            }
            else if (e.type.ToLower() == "uint32" || e.type.ToLower() == "decimal" || e.type.ToLower() == "uint16")
            {
                data.Columns.Add(new NumberColumn
                {
                    FieldName = e.name,
                    MaxDecimalDigitCount = 5,


                    Caption = e.name.ToUpper(),
                    HorizontalContentAlignment = TextAlignment.Center,
                    MinWidth = 250
                });

            }
            else if (e.type.ToLower() == "datetime")
            {
                data.Columns.Add(new DateColumn
                {
                    FieldName = e.name,
                    Caption = e.name.ToUpper(),
                    HorizontalContentAlignment = TextAlignment.Center,
                    MinWidth = 200
                });

            }
            else
            {
                data.Columns.Add(new TextColumn
                {
                    FieldName = e.name,

                    Caption = e.name.ToUpper(),
                    HorizontalContentAlignment = TextAlignment.Center,
                    MinWidth = 200
                });

            }


        }



        List<GridColumnAttributeSymmary> ListSummary = ovm.SUMMURIES;
        foreach (GridColumnAttributeSymmary summ in ListSummary)
        {


            GridColumnSummary Opp = new GridColumnSummary
            {
                FieldName = summ.DataMember,

            };
            if (summ.summaryType.ToLower() == "avg")
            {
                Opp.Type = DataSummaryType.Average;
                Opp.DisplayFormat = "AVG: {0:F3} ";
                data.TotalSummaries.Add(Opp);

            }
            else if (summ.summaryType.ToLower() == "sum")
            {
                Opp.Type = DataSummaryType.Sum;
                Opp.DisplayFormat = "SUM: {0:F3} ";
                data.TotalSummaries.Add(Opp);

            }
            else if (summ.summaryType.ToLower() == "count")
            {
                Opp.Type = DataSummaryType.Count;
                Opp.DisplayFormat = "COUNT : {0:F0} ";
                data.TotalSummaries.Add(Opp);
            }
            else if (summ.summaryType.ToLower() == "max")
            {
                Opp.Type = DataSummaryType.Max;
                Opp.DisplayFormat = "MAX : {0:F3} ";
                data.TotalSummaries.Add(Opp);
            }
            else if (summ.summaryType.ToLower() == "min")
            {
                Opp.Type = DataSummaryType.Min;
                Opp.DisplayFormat = "MIN : {0:F3} ";
                data.TotalSummaries.Add(Opp);
            }



        }






        scroll.Add(new Button { Text = "Parametrage", Margin = 10 });

        scroll.Add(data);





    }
    protected override bool OnBackButtonPressed()
    {
        GoHome().GetAwaiter();


        return true;
    }

    public async Task GoHome()
    {
        UserDialogs.Instance.ShowLoading("Loading Pleae wait ...");
        await Task.Delay(500);
        await App.Current.MainPage.Navigation.PushAsync(new NavigationPage(new HomeView()));
        UserDialogs.Instance.HideLoading();


    }

    private void ImageButton_Clicked(object sender, EventArgs e)
    {
        Popup2.IsOpen = true;

    }

    private async void Button_Clicked(object sender, EventArgs e)
    {
        UserDialogs.Instance.ShowLoading("Loading Pleae wait ...");
        await Task.Delay(500);
        var ovm = BindingContext as GridMV;
        await App.Current.MainPage.Navigation.PushAsync(new NavigationPage(new ChartView(ovm.List_Paramettre_final, ovm.XML_FILE)));
        Popup2.IsOpen = false;
        UserDialogs.Instance.HideLoading();

    }
}