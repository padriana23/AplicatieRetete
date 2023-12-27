using AplicatieRetete.Models;

namespace AplicatieRetete;

public partial class ProductPage : ContentPage
{
    Retete sl;
    public ProductPage(Retete slist)
    {
        InitializeComponent();
        sl = slist;
    }


    protected override async void OnAppearing()
    {
        base.OnAppearing();
        listView.ItemsSource = await App.Database.GetProductsAsync();
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