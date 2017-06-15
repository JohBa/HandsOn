using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContactManager.Models;

namespace ContactManager.Services
{
    public interface IContactRepository
    {
        Task<IList<Contact>> GetContacts();
        Task DeleteContact(Guid id);
        Task SaveContact(Contact c);
    }
}
