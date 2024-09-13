using Microsoft.Maui.Controls;

namespace Concale.Views;

public partial class ConversionPage : ContentPage
{
    private string _currencyCode;

    public ConversionPage(string currencyCode)
    {
        InitializeComponent();
        _currencyCode = currencyCode;
    }

    private void OnConvertButtonClicked(object sender, EventArgs e)
    {
        double amount = double.Parse(AmountEntry.Text);
        double result = ConvertCurrency(amount, _currencyCode);

        ResultLabel.Text = $"{amount} THB = {result} {_currencyCode}";
    }

    private double ConvertCurrency(double amount, string currencyCode)
    {
        double conversionRate = currencyCode switch
        {
            "USD" => 0.03,
            "GBP" => 0.022,
            "EUR" => 0.027,
            "JPY" => 3.45,
            "HKD" => 0.24,
            "MYR" => 0.13,
            "SGD" => 0.04,
            "BND" => 0.04,
            "PHP" => 1.56,
            "IDR" => 467.82,
            "INR" => 2.25,
            "CHF" => 0.03,
            "AUD" => 0.042,
            "NZD" => 0.045,
            "CAD" => 0.035,
            "SEK" => 0.31,
            "DKK" => 0.20,
            "NOK" => 0.32,
            "CNY" => 0.21,
            "MXN" => 0.58,
            "ZAR" => 0.52,
            "KRW" => 32.62,
            "TWD" => 0.90,
            "KWD" => 0.0098,
            "SAR" => 0.11,
            "AED" => 0.11,
            "MMK" => 62.61,
            "BDT" => 2.55,
            "CZK" => 0.60,
            "KHR" => 123.48,
            "KES" => 4.08,
            "LAK" => 329.56,
            "RUB" => 2.22,
            "VND" => 711.04,
            "EGP" => 0.93,
            "PLN" => 0.13,
            "LKR" => 9.45,
            "IQD" => 43.59,
            "BHD" => 0.011,
            "OMR" => 0.012,
            "JOD" => 0.021,
            "QAR" => 0.11,
            "MVR" => 0.46,
            "NPR" => 3.54,
            "PGK" => 0.11,
            "ILS" => 0.11,
            "HUF" => 10.35,
            "PKR" => 8.92,
            _ => 0.0
        };

        return amount * conversionRate;
    }
}
