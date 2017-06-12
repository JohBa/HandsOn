using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ContactManager
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            InitList();
        }

        private void InitList()
        {
            var contacts = new List<Contact>();
            contacts.Add(new Contact {Name = "foo", PhoneNumber = "fooweg"});
            contacts.Add(new Contact { Name = "foobar", PhoneNumber = "foostraße" });
            contacts.Add(new Contact { Name = "foobarz", PhoneNumber = "Foo Avenue 42" });
            ContactList.ItemsSource = contacts;
        }
    }
}
