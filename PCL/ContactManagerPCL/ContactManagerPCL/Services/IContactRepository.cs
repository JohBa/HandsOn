using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ContactManagerPCL.Models;

namespace ContactManagerPCL.Services
{
    public interface IContactRepository
    {
        Task<IList<Contact>> GetContacts();
        Task SaveContact(Contact contact);
        Task DeleteContact(Guid id);
    }
}
