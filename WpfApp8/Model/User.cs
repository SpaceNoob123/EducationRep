using System.ComponentModel;
using System.Runtime.CompilerServices;
using WpfApp8;

namespace WpfApp1.Model
{
    public class User : ObservableEntity

    {
        private int id;
        public int Id
        {
            get { return id; }
            set { id = value; OnPropertyChanged(); }
        }

        private string name;
        public string Name
        {
            get { return name; }
            set { name = value; OnPropertyChanged(); }
        }

        private string email;
        public string Email
        {
            get { return email; }
            set { email = value; OnPropertyChanged(); }
        }
    }
}
