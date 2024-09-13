using System.Globalization;

namespace Concale.Views;

public partial class IncomeEntryPage : ContentPage
{
    public IncomeEntryPage()
    {
        InitializeComponent();
    }

    async void btnSaveIncome_Clicked(object sender, EventArgs e)
    {
        Models.IncomeItem icitem = (Models.IncomeItem)BindingContext;
        icitem.IncomeMoney = string.IsNullOrWhiteSpace(icitem.IncomeMoney) ? "0.00" : icitem.IncomeMoney;

        if (double.TryParse(icitem.IncomeMoney, out double incomeMoney))
        {
            icitem.IncomeMoney = incomeMoney.ToString("N2", CultureInfo.InvariantCulture);
        }

        if (String.IsNullOrWhiteSpace(icitem.IncomeFile))
        {
            var filename = Path.Combine(App.FolderPath, $"{DateTime.Now:yyyyMMddHHmmss}.icitem.txt");
            File.WriteAllText(filename, $"{incomeMoney}#,#{icitem.IncomeName}#,#{icitem.IncomeDetail}");
        }
        else
        {
            File.WriteAllText(icitem.IncomeFile, $"{incomeMoney}#,#{icitem.IncomeName}#,#{icitem.IncomeDetail}");
        }
        await Navigation.PopAsync();
    }

    async void btnDeleteIncome_Clicked(object sender, EventArgs e)
    {
        Models.IncomeItem icitem = (Models.IncomeItem)BindingContext;
        if (File.Exists(icitem.IncomeFile))
        {
            File.Delete(icitem.IncomeFile);
        }
        await Navigation.PopAsync();
    }
}
