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
    async void OnAddButtonClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new ProductPage((Retete)
       this.BindingContext)
        {
            BindingContext = new Product()
        });
    }
    async void OnChooseButtonClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new ProductPage((Retete)
       this.BindingContext)
        {
            BindingContext = new Product()
        });

    }
}