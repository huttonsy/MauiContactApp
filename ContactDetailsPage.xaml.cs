namespace MauiContactApp.Views
{
    public partial class ContactDetailsPage : ContentPage
    {
        public ContactDetailsPage(Contact contact)
        {
            InitializeComponent();
            BindingContext = contact;
        }

        private async void OnBackButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}
