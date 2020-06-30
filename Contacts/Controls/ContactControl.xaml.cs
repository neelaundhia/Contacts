using Contacts.Classes;
using System.Windows.Controls;

namespace Contacts.Controls
{
    /// <summary>
    /// Interaction logic for ContactControl.xaml
    /// </summary>
    public partial class ContactControl : UserControl
    {
        private Contact contact;

        public Contact Contact 
        { 
            get
            {
                return contact;
            }
            
            set
            {
                contact = value;
                nameTextBox.Text = contact.Name;
                emailTextBox.Text = contact.Email;
                phoneTextBox.Text = contact.Phone;
            }
        }

        public ContactControl()
        {
            InitializeComponent();
        }
    }
}
