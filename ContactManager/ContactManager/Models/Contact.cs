using System;
using SQLite;

namespace ContactManager.Models
{
    public class Contact
    {
        [PrimaryKey]
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName => FirstName + " " +LastName;
        public string Mail { get; set; }
        public string PhoneNumber { get; set; }
    }
}
