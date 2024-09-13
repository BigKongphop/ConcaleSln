using System.Reflection;

namespace Concale.Views;

public partial class FlyoutMenuPage : ContentPage
{
    public FlyoutMenuPage()
    {
        InitializeComponent();
    }

    void collectionView_SelectionChanged(System.Object sender, Microsoft.Maui.Controls.SelectionChangedEventArgs e)
    {
        Models.FlyoutPageItem menuClick = e.CurrentSelection[0] as Models.FlyoutPageItem;
        
        var menu = App.Current.MainPage as MainPage;

        ContentPage Pagex = GetInstance<ContentPage>(menuClick.TargetType.ToString());

        menu.Detail = new NavigationPage(Pagex);
    }

    public T GetInstance<T>(string type)
    {
        return (T)Activator.CreateInstance(Type.GetType(type));
    }
}