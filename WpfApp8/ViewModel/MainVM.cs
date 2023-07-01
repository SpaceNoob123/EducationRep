using GalaSoft.MvvmLight.Command;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using WpfApp1.Model;
using WpfApp8;

namespace WpfApp1.ViewModel
{
    internal class MainVM : INotifyPropertyChanged
    {
        private MyDbContext dbContext;

        public ObservableCollection<User> Users { get; set; }
        private User selectedUser;

        public User MySelectedUser
        {
            get { return selectedUser; }
            set { selectedUser = value; OnPropertyChanged(); }
        }

        private RelayCommand addCommand;
        private RelayCommand deleteCommand;
        private RelayCommand updateCommand;

        public RelayCommand AddCommand
        {
            get
            {
                if (addCommand == null)
                    addCommand = new RelayCommand(AddTestUser);

                return addCommand;
            }
        }

        public RelayCommand DeleteCommand
        {
            get
            {
                if (deleteCommand == null)
                    deleteCommand = new RelayCommand(DeleteTestUser);

                return deleteCommand;
            }
        }

        public RelayCommand UpdateCommand
        {
            get
            {
                if (updateCommand == null)
                    updateCommand = new RelayCommand(UpdateTestUser);

                return updateCommand;
            }
        }

        public MainVM()
        {
            dbContext = new MyDbContext();
            Users = new ObservableCollection<User>(dbContext.Users);
            MySelectedUser = Users.Count > 0 ? Users[0] : null;
        }

        public void AddTestUser()
        {
            User newUser = new User() { Id = Users.Count + 1, Email = "test@mail.mu", Name = "Test" };
            dbContext.Users.Add(newUser);
            dbContext.SaveChanges();
            Users.Add(newUser);
        }

        public void DeleteTestUser()
        {
            dbContext.Users.Remove(selectedUser);
            dbContext.SaveChanges();
            Users.Remove(selectedUser);
        }



        public void UpdateTestUser()
        {
            dbContext.SaveChanges();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void Dispose()
        {
            dbContext.Dispose();
        }
    }
}
