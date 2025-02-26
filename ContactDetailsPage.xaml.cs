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
        private async void OnContactSelected(object sender, SelectionChangedEventArgs e)
        {
            if (e.CurrentSelection.FirstOrDefault() is MauiContactApp.Contact selectedContact)
            {
                await Navigation.PushAsync(new ContactDetailsPage(selectedContact));
                ((CollectionView)sender).SelectedItem = null; 
            }
        }

    }
}
