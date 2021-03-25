using NUnit.Framework;
using MVVMSession.ViewModel;

namespace Test.MVVMSession
{
    [TestFixture(Description = "Test ViewModel")]
    public class LoginViewModelTest
    {
        [OneTimeSetUp]
        public void StartUp()
        {

        }

        [Test]
        public void Test_PasswordIsTooShort()
        {
            using(var _mvvmViewModel = new LoginViewModel())
            {
                _mvvmViewModel.User.Password = "asd"; 
                _mvvmViewModel.ValidatePassword();

                Assert.AreEqual("Password must be at least eight characters long",
                            _mvvmViewModel.User.ValidationMessage);
            }
        }

        [Test]
        public void Test_PasswordIsTooLong()
        {
            using (var _mvvmViewModel = new LoginViewModel())
            {
                _mvvmViewModel.User.Password = "asdasdasdasdasdasdasd";
                _mvvmViewModel.ValidatePassword();

                Assert.AreEqual("Password cannot be more than twenty characters long",
                                _mvvmViewModel.User.ValidationMessage);
            }
        }

        [Test]
        public void Test_PasswordMustHaveAnUpperCaseCharacter()
        {
            using (var _mvvmViewModel = new LoginViewModel())
            {
                _mvvmViewModel.User.Password = "asdasdasd";
                _mvvmViewModel.ValidatePassword();

                Assert.AreEqual("Password must contain at least one upper-case character",
                                _mvvmViewModel.User.ValidationMessage);
            }
        }

        [Test]
        public void Test_PasswordMustHaveALowerCaseCharacter()
        {
            using (var _mvvmViewModel = new LoginViewModel())
            {
                _mvvmViewModel.User.Password = "ASDASDASD";
                _mvvmViewModel.ValidatePassword();

                Assert.AreEqual("Password must contain at least one lower-case character",
                                _mvvmViewModel.User.ValidationMessage);
            }
        }

        [Test]
        public void Test_PasswordMustHaveANumber()
        {
            using (var _mvvmViewModel = new LoginViewModel())
            {
                _mvvmViewModel.User.Password = "asdasdasdA";
                _mvvmViewModel.ValidatePassword();

                Assert.AreEqual("Password must contain at least one number",
                                _mvvmViewModel.User.ValidationMessage);
            }
        }

        [Test]
        public void Test_PasswordIsSecure()
        {
            using (var _mvvmViewModel = new LoginViewModel())
            {
                _mvvmViewModel.User.Password = "asdasdasdA1";
                _mvvmViewModel.ValidatePassword();

                Assert.AreEqual("Password is secure",
                                _mvvmViewModel.User.ValidationMessage);
            }
        }
    }
}
