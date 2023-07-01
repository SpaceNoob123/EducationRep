using GalaSoft.MvvmLight.Command;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using WpfApp1.Model;

namespace WpfApp1.ViewModel
{
    internal class MainVM : INotifyPropertyChanged
    {
        public ObservableCollection<User> Users { get; set; }
        private User selectedUser;

        public User MySelectedUser 
        {
            get { return selectedUser; }
            set { selectedUser = value; OnPropertyChanged("MySelectedUser"); }
        }


        private RelayCommand addCommand;

        public RelayCommand AddCommand
        {
            get {
                if (addCommand == null)
                    addCommand = new RelayCommand(AddTestUser);

                return addCommand; 
            }
        }

        private RelayCommand delCommand;

        public RelayCommand DelCommand
        {
            get
            {
                if (delCommand == null)
                    delCommand = new RelayCommand(DeleteTestUser);

                return delCommand;
            }
        }
        public MainVM()
        {
            Users = new ObservableCollection<User>()
            {
                new User() {Id = 1, Email = "vasil@yandex.ru", Name = "Artem"},
                new User() {Id = 2, Email = "bigbebrik@gmail.com", Name = "Kolya" }
            };
            MySelectedUser = Users[0];
        }

        public void AddTestUser() => Users.Add(new User() { Id = Users.LastOrDefault().Id + 1, Email = "test@mail.mu", Name = "Test" });
        public void DeleteTestUser() => Users.Remove(selectedUser);

        //public void ParamTest(object obj) => Users.Add(new User() { Id = Users.LastOrDefault().Id + 1, Email = "test@mail.mu", Name = "Test" });

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null) 
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
