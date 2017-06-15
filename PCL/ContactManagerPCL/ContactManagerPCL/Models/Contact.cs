using System;
using SQLite;

namespace ContactManagerPCL.Models
{
    public class Contact
    {
        public Contact()
        {
            Id = Guid.NewGuid();
        }

        [PrimaryKey]
        public Guid Id { get; set; }

        public string FullName => FirstName + " " + LastName;

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string TelephoneNumber { get; set; }

        public string Email { get; set; }
    }
}
