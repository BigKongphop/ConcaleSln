using System;
using Microsoft.Maui.Controls;

namespace Concale.Views;

public partial class HomeInstallmentsPage : ContentPage
{
	public HomeInstallmentsPage()
	{
		InitializeComponent();
	}

    async void btnHomeCalculate_Clicked(object sender, EventArgs e)
    {
        try
            {
                decimal loanAmount = Convert.ToDecimal(LoanAmountEntry.Text);
                decimal annualInterestRate = Convert.ToDecimal(InterestRateEntry.Text) / 100;
                int loanTermMonths = Convert.ToInt32(LoanTermEntry.Text);

                decimal monthlyInterestRate = annualInterestRate / 12;
                decimal monthlyPayment = loanAmount * monthlyInterestRate / (1 - (decimal)Math.Pow(1 + (double)monthlyInterestRate, -loanTermMonths));

                MonthlyPaymentLabel.Text = monthlyPayment.ToString("N2");
            }
            catch (Exception ex)
            {
                DisplayAlert("Error", "กรุณากรอกข้อมูลให้ครบถ้วน", "OK");
            }
    }
}
