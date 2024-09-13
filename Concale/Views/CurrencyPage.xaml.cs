namespace Concale.Views;

public partial class CurrencyPage : ContentPage
{
	public CurrencyPage()
	{
		InitializeComponent();
	}

    async void Button_Clicked(object sender, EventArgs e)
    {
        Button button = sender as Button;
        string currencyCode = button.Text;

        await Navigation.PushAsync(new ConversionPage(currencyCode));
    }
}