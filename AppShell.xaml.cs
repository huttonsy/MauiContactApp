using MauiContactApp.Views;
namespace MauiContactApp
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(ContactsPage), typeof(ContactsPage));
            Routing.RegisterRoute(nameof(ContactDetailsPage), typeof(ContactDetailsPage));
        }
    }
}
