using System.Collections.ObjectModel;
using System.Linq;

namespace MauiContactApp.Views
{
    public partial class ContactsPage : ContentPage
    {
        public ObservableCollection<GroupedContacts> ContactsGrouped { get; set; }

        public ContactsPage()
        {
            InitializeComponent();
            LoadContacts();
            BindingContext = this;
        }

        private void LoadContacts()
        {
            var contacts = new List<Contact>
            {
                new Contact { Name = "Alice", Email = "alice@example.com", PhoneNumber = "123-456-7890", Description = "Loves hiking", Photo = "pic2.png" },
                new Contact { Name = "Andrew", Email = "andrew@example.com", PhoneNumber = "234-567-8901", Description = "Loves reading", Photo = "pic1.png" },
                new Contact { Name = "Amanda", Email = "amanda@example.com", PhoneNumber = "345-678-9012", Description = "Enjoys coding", Photo = "pic4.png" },

                new Contact { Name = "Ben", Email = "ben@example.com", PhoneNumber = "456-789-0123", Description = "Gamer", Photo = "pic1.png" },
                new Contact { Name = "Barbara", Email = "barbara@example.com", PhoneNumber = "567-890-1234", Description = "Musician", Photo = "pic4.png" },
                new Contact { Name = "Brian", Email = "brian@example.com", PhoneNumber = "678-901-2345", Description = "Loves movies", Photo = "pic3.png" },

                new Contact { Name = "Charlie", Email = "charlie@example.com", PhoneNumber = "789-012-3456", Description = "Traveler", Photo = "pic1.png" },
                new Contact { Name = "Chris", Email = "chris@example.com", PhoneNumber = "890-123-4567", Description = "Blogger", Photo = "pic3.png" },
                new Contact { Name = "Catherine", Email = "catherine@example.com", PhoneNumber = "901-234-5678", Description = "Photographer", Photo = "pic2.png" },

                new Contact { Name = "David", Email = "david@example.com", PhoneNumber = "012-345-6789", Description = "Dancer", Photo = "pic3.png" },
                new Contact { Name = "Diana", Email = "diana@example.com", PhoneNumber = "123-456-7891", Description = "Chef", Photo = "pic2.png" },
                new Contact { Name = "Daniel", Email = "daniel@example.com", PhoneNumber = "234-567-8902", Description = "Artist", Photo = "pic1.png" },

                new Contact { Name = "Eve", Email = "eve@example.com", PhoneNumber = "345-678-9013", Description = "Writer", Photo = "pic2.png" },
                new Contact { Name = "Edward", Email = "edward@example.com", PhoneNumber = "456-789-0124", Description = "Athlete", Photo = "pic1.png" },
                new Contact { Name = "Ella", Email = "ella@example.com", PhoneNumber = "567-890-1235", Description = "Designer", Photo = "pic4.png" }
            };

            ContactsGrouped = new ObservableCollection<GroupedContacts>(
                contacts.GroupBy(c => c.Name[0].ToString().ToUpper()) 
                        .OrderBy(g => g.Key) 
                        .Select(g => new GroupedContacts(g.Key, new ObservableCollection<Contact>(g.OrderBy(c => c.Name))))
            );
        }

        public class GroupedContacts : ObservableCollection<Contact>
        {
            public string Key { get; }

            public GroupedContacts(string key, ObservableCollection<Contact> contacts) : base(contacts)
            {
                Key = key;
            }
        }

        private async void OnContactSelected(object sender, SelectionChangedEventArgs e)
        {
            if (e.CurrentSelection.FirstOrDefault() is Contact selectedContact)
            {
                await Navigation.PushAsync(new ContactDetailsPage(selectedContact));
                ((CollectionView)sender).SelectedItem = null; 
            }
        }
    }
}
