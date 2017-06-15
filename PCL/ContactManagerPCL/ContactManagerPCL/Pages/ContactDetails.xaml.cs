using System;
using ContactManagerPCL.Models;
using ContactManagerPCL.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ContactManagerPCL.Pages
{
    public partial class ContactDetails : ContentPage
    {
        private readonly Contact _contact;
        private readonly IContactRepository _contactRepository;

        public ContactDetails(Contact contact)
        {
            InitializeComponent();

            _contact = contact;
            _contactRepository = new ContactRepository();

            InitDetailsPage(_contact);
        }

        private void InitDetailsPage(Contact contact)
        {
            FirstNameeEntry.Text = contact.FirstName;
            LastNameEntry.Text = contact.LastName;
            TelephoneNumberEntry.Text = contact.TelephoneNumber;
            EmailEntry.Text = contact.Email;
        }

        private async void OnSaveClick(object sender, EventArgs e)
        {
            ReadContact();
            await _contactRepository.SaveContact(_contact);
            await Navigation.PopAsync();
        }

        private void ReadContact()
        {
            _contact.FirstName = FirstNameeEntry.Text;
            _contact.LastName = LastNameEntry.Text;
            _contact.Email = EmailEntry.Text;
            _contact.TelephoneNumber = TelephoneNumberEntry.Text;
        }

        private async void OnDeleteClick(object sender, EventArgs e)
        {
            await _contactRepository.DeleteContact(_contact.Id);
            await Navigation.PopAsync();
        }
    }
}