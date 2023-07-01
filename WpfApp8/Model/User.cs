using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace WpfApp1.Model
{
    public class User : INotifyPropertyChanged

    {
        private int id;
        private string name;
        private string email;

        public string Email
        {
            get { return email; }
            set { email = value; OnPropertyChanged("Email"); }
        }


        public string Name
        {
            get { return name; }
            set { name = value; OnPropertyChanged("Name"); }
        }


        public int Id
        {
            get { return id; }
            set { id = value; OnPropertyChanged("Id"); }
        }




        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

        public override string ToString()
        {
            return $"{Id}) {Name}\t{Email}";
        }
    }
}
