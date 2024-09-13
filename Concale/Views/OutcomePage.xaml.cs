using System.Collections.ObjectModel;

namespace Concale.Views;

public partial class OutcomePage : ContentPage
{
    ObservableCollection<Models.OutcomeItem> OutcomeLists { get; set; }
    public OutcomePage()
    {
        InitializeComponent();
        OutcomeLists = new ObservableCollection<Models.OutcomeItem>();
        cvOutcome.ItemsSource = OutcomeLists;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        OutcomeLists.Clear();
        var files = Directory.EnumerateFiles(App.FolderPath, "*.ocitem.txt");
        files = files.OrderByDescending(x => x);
        string[] arrText = null;
        foreach (var filename in files)
        {
            arrText = File.ReadAllText(filename).Split("#,#");
            if (arrText.Count() == 1)
            {
                OutcomeLists.Add(new Models.OutcomeItem
                {
                    OutcomeFile = filename,
                    OutcomeName = File.ReadAllText(filename),
                    OutcomeDetail = File.ReadAllText(filename),
                    OutcomeMoney = "0",
                    Date = File.GetCreationTime(filename),
                });
            }
            else if (arrText.Count() > 1)
            {
                OutcomeLists.Add(new Models.OutcomeItem
                {
                    OutcomeFile = filename,
                    OutcomeName = arrText[1],
                    OutcomeDetail = arrText[2],
                    OutcomeMoney = arrText[0],
                    Date = File.GetCreationTime(filename),
                });
            }
        }
    }

    async void ToolbarItem_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new OutcomeEntryPage
        {
            BindingContext = new Models.OutcomeItem()
        });
    }

    async void listViewNote_ItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        if (e.SelectedItem != null)
        {
            Models.OutcomeItem ocitem = e.SelectedItem as Models.OutcomeItem;
            await Navigation.PushAsync(new OutcomeEntryPage
            {
                BindingContext = ocitem
            });
        }
    }

    async void cvOutcome_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection[0] != null)
        {
            Models.OutcomeItem ocitem = e.CurrentSelection[0] as Models.OutcomeItem;
            await Navigation.PushAsync(new OutcomeEntryPage
            {
                BindingContext = ocitem
            });
        }
    }
}
