using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ContactManager.Models;
using SQLite;
using Xamarin.Forms;

namespace ContactManager.Services
{
    public class ContactDatabase : IContactRepository
    {
        private readonly SQLiteConnection _connection;
        public ContactDatabase()
        {
            var dbFile = DependencyService.Get<IFileHelper>().GetLocalFilePath("ContactDB.db3");
            _connection = new SQLiteConnection(dbFile);
            _connection.CreateTable<Contact>();
        }

        public Task<IList<Contact>> GetContacts()
        {
            return Task.FromResult(_connection.Table<Contact>().ToList() as IList<Contact>);
        }

        public Task DeleteContact(Guid id)
        {
            return Task.FromResult(_connection.Execute("delete from Contact where Id = '" + id + "'"));
        }

        public Task SaveContact(Contact c)
        {
            var result = _connection.Table<Contact>().Where(i => i.Id == c.Id);
            if (result.ToList().Count == 0)
            {
                _connection.Insert(c);
            }
            else
            {
                _connection.Update(c);
            }
            return Task.CompletedTask;
        }
    }
}
