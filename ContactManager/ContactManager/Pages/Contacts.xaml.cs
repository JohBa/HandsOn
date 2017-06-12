﻿using System;
using System.Collections.Generic;
using ContactManager.Models;
using ContactManager.Services;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.PlatformConfiguration.WindowsSpecific;

namespace ContactManager.Pages
{
    public partial class Contacts : ContentPage
    {
        private readonly IContactRepository _contactRepository;
        public Contacts()
        {
            _contactRepository = new StaticContactRepository();
            InitializeComponent();
        }

        private void ContactList_OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
            {
                return;
            }

            Navigation.PushAsync(new ContactDetails(e.SelectedItem as Contact));
        }

        private async void Contacts_OnAppearing(object sender, EventArgs e)
        {
            ContactList.ItemsSource = await _contactRepository.GetContacts();
        }

        private void AddClicked(object sender, EventArgs e)
        {
            var newContact = new Contact { Id = Guid.NewGuid() };
            Navigation.PushAsync(new ContactDetails(newContact, true));
        }
    }
}
