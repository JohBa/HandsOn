using System;
using System.Threading.Tasks;
using ContactManager.Models;
using ContactManager.Services;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.PlatformConfiguration.WindowsSpecific;
using Xamarin.Forms.Xaml;

namespace ContactManager.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ContactDetails : ContentPage
    {
        private readonly IContactRepository _contactRepository;
        private bool _isEditable;
        private Contact _contact;

        public ContactDetails(Contact contact) : this(contact, false)
        {
        }

        public ContactDetails(Contact contact, bool isEditable)
        {
            _contactRepository = new StaticContactRepository();
            InitializeComponent();
            _contact = contact;
            _isEditable = isEditable;

            InitContact();
        }

        private void InitContact()
        {
            FirstNameEntry.Text = _contact.FirstName;
            FirstNameEntry.IsEnabled = _isEditable;

            LastNameEntry.Text = _contact.LastName;
            LastNameEntry.IsEnabled = _isEditable;

            MailEntry.Text = _contact.Mail;
            MailEntry.IsEnabled = _isEditable;

            PhoneNumberEntry.Text = _contact.PhoneNumber;
            PhoneNumberEntry.IsEnabled = _isEditable;
        }

        private void EditClicked(object sender, EventArgs e)
        {
            _isEditable = !_isEditable;
            InitContact();
        }

        private void ReadContact()
        {
            _contact.FirstName = FirstNameEntry.Text;
            _contact.LastName = LastNameEntry.Text;
            _contact.Mail = MailEntry.Text;
            _contact.PhoneNumber = PhoneNumberEntry.Text;
        }

        private async void SaveClicked(object sender, EventArgs e)
        {
            if (!_isEditable)
            {
                await DisplayAlert("Cannot Save", "You can just save in editmode", "Accept", "Cancel");
            }
            ReadContact();
            await _contactRepository.SaveContact(_contact);
            _isEditable = false;
            InitContact();
        }

        private async void DeleteClicked(object sender, EventArgs e)
        {
            await _contactRepository.DeleteContact(_contact.Id);
            await Navigation.PopAsync();
        }
    }
}