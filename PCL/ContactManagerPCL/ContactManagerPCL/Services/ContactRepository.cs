using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ContactManagerPCL.Models;
using SQLite;
using Xamarin.Forms;

namespace ContactManagerPCL.Services
{
    public class ContactRepository : IContactRepository
    {
        private readonly SQLiteConnection _connection;

        public ContactRepository()
        {
            var fileLocator = DependencyService.Get<IFileLocator>();
            var path = fileLocator.GetFilePath("ContactDB.db3");
            _connection = new SQLiteConnection(path);
            _connection.CreateTable<Contact>();
        }

        public Task<IList<Contact>> GetContacts()
        {
            return Task.Run(() => _connection.Table<Contact>().ToList() as IList<Contact>);
        }

        public Task SaveContact(Contact contact)
        {
            return Task.Run(() =>
            {
                var result = _connection.Table<Contact>().Where(c => c.Id == contact.Id);

                if (result.ToList().Count == 0)
                {
                    _connection.Insert(contact);
                }
                else
                {
                    _connection.Update(contact);
                }
            });
        }

        public Task DeleteContact(Guid id)
        {
            return Task.Run(() => _connection.Delete<Contact>(id));
        }
    }
}
