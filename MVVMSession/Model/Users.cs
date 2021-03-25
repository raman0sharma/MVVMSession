using System.ComponentModel;
using System.Linq;

namespace MVVMSession.Model
{
    public class Users : INotifyPropertyChanged
    {
        private string _username;
        private string _password;
        private string _validationMessage;

        public string Username 
        {
            get { return _username; }
            set { _username = value; }
        }

        public string Password
        {
            get { return _password; }
            set
            {
                _password = value;

                OnPropertyChanged(nameof(Password));
            }
        }

        public string ValidationMessage
        {
            get { return _validationMessage; }
            set
            {
                _validationMessage = value;

                OnPropertyChanged(nameof(ValidationMessage));
            }
        }

        public void ValidatePassword()
        {
            if (Password.Trim().Length < 8)
            {
                ValidationMessage = "Password must be at least eight characters long";
            }
            else if (Password.Trim().Length > 20)
            {
                ValidationMessage = "Password cannot be more than twenty characters long";
            }
            else if (!Password.Any(char.IsUpper))
            {
                ValidationMessage = "Password must contain at least one upper-case character";
            }
            else if (!Password.Any(char.IsLower))
            {
                ValidationMessage = "Password must contain at least one lower-case character";
            }
            else if (!Password.Any(char.IsNumber))
            {
                ValidationMessage = "Password must contain at least one number";
            }
            else
            {
                ValidationMessage = "Password is secure";
            }
        }


        #region Property Change Notifier

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion

    }
}
