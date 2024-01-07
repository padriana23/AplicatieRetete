using AplicatieRetete.Models;

namespace AplicatieRetete;

public partial class ListPage : ContentPage
{
    public ListPage()
    {
        InitializeComponent();
    }
    async void OnSaveButtonClicked(object sender, EventArgs e)
    {
        var slist = (Retete)BindingContext;
        slist.Date = DateTime.UtcNow;
        await App.Database.SaveReteteAsync(slist);
        await Navigation.PopAsync();
    }

    async void OnDeleteButtonClicked(object sender, EventArgs e)
    {
        var slist = (Retete)BindingContext; // Assuming you're binding to a Retete instance
        if (slist != null)
        {
            bool result = await DisplayAlert("Confirmare", "Esti sigur ca vrei sa stergi aceasta reteta?", "Da", "Nu");
            if (result)
            {
                await App.Database.DeleteReteteAsync(slist);
                await Navigation.PopAsync();
            }
        }
    }
}