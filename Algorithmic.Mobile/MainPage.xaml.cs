namespace ShareInvest;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
    }
    async void OnOpenWebButtonClicked(object sender, EventArgs e)
    {
        await Browser.OpenAsync("https://www.devexpress.com/maui/");
    }
}