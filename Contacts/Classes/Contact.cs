using SQLite;

namespace Contacts.Classes
{
    public class Contact
    {
        //SQLite Attributes
        [PrimaryKey, AutoIncrement]

        public int ID { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public override string ToString()
        {
            return $"{Name} - {Email} - {Phone}";
        }

    }
}
