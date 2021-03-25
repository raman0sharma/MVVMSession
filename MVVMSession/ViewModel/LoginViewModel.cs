using MVVMSession.Helper;
using MVVMSession.Model;
using System;
using System.Windows.Input;

namespace MVVMSession.ViewModel
{
    public class LoginViewModel : IDisposable 
    {
        public Users User { get; set; }
        public ICommand LoginCommand => new RelayCommand(param => ValidatePassword(), param => true);
        public ICommand CloseCommand => new RelayCommand(param => CloseAction(), param => true);
        public Action CloseAction { get; set; }

        public LoginViewModel()
        {
            User = new Users();
        }

        public void ValidatePassword()
        {
            User.ValidatePassword();
        }

        #region Implement IDisposable

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                DisposeHelp();
            }
        }

        private void DisposeHelp()
        {
            if (User != null) User = null;
        }

        #endregion
    }
}
