using Microsoft.Maui.Controls;
using System.Collections.ObjectModel;
using System.Linq;

namespace Concale.Views;

public partial class SummaryPage : ContentPage
{
    public SummaryPage()
    {
        InitializeComponent();
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        UpdateSummary();
    }

    private void UpdateSummary()
    {
        double totalIncome = GetTotalIncome();
        double totalOutcome = GetTotalOutcome();
        double balance = totalIncome - totalOutcome;

        lblBalance.Text = balance.ToString("N2");
        lblIncome.Text = totalIncome.ToString("N2");
        lblOutcome.Text = totalOutcome.ToString("N2");
    }

    private double GetTotalIncome()
    {
        var incomeFiles = Directory.EnumerateFiles(App.FolderPath, "*.icitem.txt");
        double totalIncome = 0;
        foreach (var file in incomeFiles)
        {
            string[] data = File.ReadAllText(file).Split("#,#");
            if (data.Length > 0 && double.TryParse(data[0], out double amount))
            {
                totalIncome += amount;
            }
        }
        return totalIncome;
    }

    private double GetTotalOutcome()
    {
        var outcomeFiles = Directory.EnumerateFiles(App.FolderPath, "*.ocitem.txt");
        double totalOutcome = 0;
        foreach (var file in outcomeFiles)
        {
            string[] data = File.ReadAllText(file).Split("#,#");
            if (data.Length > 0 && double.TryParse(data[0], out double amount))
            {
                totalOutcome += amount;
            }
        }
        return totalOutcome;
    }
}
