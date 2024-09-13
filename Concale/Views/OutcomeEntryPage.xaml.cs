using System.ComponentModel;

namespace Concale.Views;

public partial class OutcomeEntryPage : ContentPage
{
	public OutcomeEntryPage()
	{
		InitializeComponent();
	}

    async void btnSaveOutcome_Clicked(object sender, EventArgs e)
    {
        Models.OutcomeItem ocitem = (Models.OutcomeItem)BindingContext;
        ocitem.OutcomeMoney = string.IsNullOrWhiteSpace(ocitem.OutcomeMoney) ? "0" : ocitem.OutcomeMoney;
        if (String.IsNullOrWhiteSpace(ocitem.OutcomeFile))
        {
            var filename = Path.Combine(App.FolderPath, $"{DateTime.Now.ToString("yyyyMMddHHmmss")}.ocitem.txt");
            File.WriteAllText(filename, $"{ocitem.OutcomeMoney}#,#{ocitem.OutcomeName}#,#{ocitem.OutcomeDetail}");
        }
        else
        {
            File.WriteAllText(ocitem.OutcomeFile, $"{ocitem.OutcomeMoney}#,#{ocitem.OutcomeName}#,#{ocitem.OutcomeDetail}");
        }
        await Navigation.PopAsync();
    }
    
    async void btnDeleteOutcome_Clicked(object sender, EventArgs e)
    {
        Models.OutcomeItem ocitem = (Models.OutcomeItem)BindingContext;
        if (File.Exists(ocitem.OutcomeFile))
        {
            File.Delete(ocitem.OutcomeFile);
        }
        await Navigation.PopAsync();
    }
}
