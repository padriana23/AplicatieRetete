using AplicatieRetete.Models;

namespace AplicatieRetete;

public partial class ListEntryPage : ContentPage
{
    public ListEntryPage()
    {
        InitializeComponent();
    }
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        listView.ItemsSource = await App.Database.GetRetetesAsync();
    }
    async void OnReteteAddedClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new ListPage
        {
            BindingContext = new Retete()
        });
    }
    async void OnListViewItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        if (e.SelectedItem != null)
        {
            await Navigation.PushAsync(new ListPage
            {
                BindingContext = e.SelectedItem as Retete
            });
        }
    }
}