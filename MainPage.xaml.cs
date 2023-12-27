namespace AplicatieRetete;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
    }

    private async void btnNav_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new ListEntryPage());
    }
}
