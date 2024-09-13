using System.Collections.ObjectModel;

namespace Concale.Views;

public partial class IncomePage : ContentPage
{
    ObservableCollection<Models.IncomeItem> IncomeLists { get; set; }
    public IncomePage()
    {
        InitializeComponent();
        IncomeLists = new ObservableCollection<Models.IncomeItem>();
        cvIncome.ItemsSource = IncomeLists;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        IncomeLists.Clear();
        var files = Directory.EnumerateFiles(App.FolderPath, "*.icitem.txt");
        files = files.OrderByDescending(x => x);
        string[] arrText = null;
        foreach (var filename in files)
        {
            arrText = File.ReadAllText(filename).Split("#,#");
            if (arrText.Count() == 1)
            {
                IncomeLists.Add(new Models.IncomeItem
                {
                    IncomeFile = filename,
                    IncomeName = File.ReadAllText(filename),
                    IncomeDetail = File.ReadAllText(filename),
                    IncomeMoney = "0",
                    Date = File.GetCreationTime(filename),
                });
            }
            else if (arrText.Length > 1)
            {
                IncomeLists.Add(new Models.IncomeItem
                {
                    IncomeFile = filename,
                    IncomeName = arrText[1],
                    IncomeDetail = arrText[2],
                    IncomeMoney = arrText[0],
                    Date = File.GetCreationTime(filename),
                });
            }
        }
    }

    async void ToolbarItem_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new IncomeEntryPage
        {
            BindingContext = new Models.IncomeItem()
        });
    }

    async void cvIncome_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection[0] != null)
        {
            Models.IncomeItem icitem = e.CurrentSelection[0] as Models.IncomeItem;
            await Navigation.PushAsync(new IncomeEntryPage
            {
                BindingContext = icitem
            });
        }
    }
}
