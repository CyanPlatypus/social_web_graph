using SocialClient.ViewModels;
using SocialClient.Views;

namespace SocialClient.Services
{
    public class WindowService
    {
        private readonly IUserViewModelFactory _userViewModelFactory;
        private readonly IUserWindowFactory _userWindowFactory;

        public WindowService(IUserViewModelFactory userViewModelFactory,
            IUserWindowFactory userWindowFactory)
        {
            _userViewModelFactory = userViewModelFactory;
            _userWindowFactory = userWindowFactory;
        }

        public void ShowUser(int id)
        {
            _userWindowFactory.CreateUserWindow(_userViewModelFactory.CreateUserViewModel(id)).Show();
        }
    }

    public interface IUserViewModelFactory
    {
        UserViewModel CreateUserViewModel(int id);
    }

    public interface IUserWindowFactory
    {
        UserWindow CreateUserWindow(UserViewModel viewModel);
    }
}