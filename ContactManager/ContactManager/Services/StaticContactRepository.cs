using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContactManager.Models;

namespace ContactManager.Services
{
    public class StaticContactRepository : IContactRepository
    {
        private static IList<Contact> _contacts;

        public StaticContactRepository()
        {
            if (_contacts == null)
            {
                _contacts = new List<Contact>();
                MockData();
            }
        }

        public Task<IList<Contact>> GetContacts()
        {
            return Task.FromResult(_contacts.OrderBy(x => x.FirstName).ToList() as IList<Contact>);
        }

        private void MockData()
        {
            _contacts.Add(new Contact { Id = Guid.NewGuid(), FirstName = "foo", PhoneNumber = "123456"});
            _contacts.Add(new Contact { Id = Guid.NewGuid(), FirstName = "foobar", PhoneNumber = "12345665960976" });
            _contacts.Add(new Contact { Id = Guid.NewGuid(), FirstName = "bar", PhoneNumber = "1337" });
            _contacts.Add(new Contact { Id = Guid.NewGuid(), FirstName = "baz", PhoneNumber = "42" });
        }

        public Task SaveContact(Contact c)
        {
            var itemToRemove = _contacts.SingleOrDefault(r => r.Id == c.Id);
            if (itemToRemove != null)
            {
                _contacts.Remove(itemToRemove);
            }
            _contacts.Add(c);
            return Task.CompletedTask;
        }

        public Task DeleteContact(Guid id)
        {
            var itemToRemove = _contacts.SingleOrDefault(r => r.Id == id);
            if (itemToRemove != null)
            {
                _contacts.Remove(itemToRemove);
            }
            return Task.CompletedTask;
        }
    }
}
