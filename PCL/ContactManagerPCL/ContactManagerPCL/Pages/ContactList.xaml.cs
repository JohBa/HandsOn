using System;
using System.Threading.Tasks;
using ContactManagerPCL.Models;
using ContactManagerPCL.Services;
using Xamarin.Forms;

namespace ContactManagerPCL.Pages
{
    public partial class ContactList : ContentPage
    {
        private readonly IContactRepository _contactRepository;

        public ContactList()
        {
            InitializeComponent();

            _contactRepository = new ContactRepository();
        }

        private async void OnContactsAppearing(object sender, EventArgs e)
        {
            ContactsListView.ItemsSource = await _contactRepository.GetContacts();
        }

        private async void ContactsListView_OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            await NavigateToDetailsPage((Contact) e.Item);
        }

        private async void AddClicked(object sender, EventArgs e)
        {
            await NavigateToDetailsPage(new Contact());
        }

        private async Task NavigateToDetailsPage(Contact contanct)
        {
            var detailsPage = new ContactDetails(contanct);
            await Navigation.PushAsync(detailsPage);
        }
    }
}
