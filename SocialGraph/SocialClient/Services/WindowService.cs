using SocialClient.ViewModels;
using SocialClient.Views;

namespace SocialClient.Services
{
    //todo make not static
    public class WindowService
    {
        public static void ShowUser(int id)
        {
            new UserWindow(new UserViewModel(id)).Show();
        }
    }
}