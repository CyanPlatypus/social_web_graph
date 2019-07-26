using SocialClient.Views;
using SocialClient.Windows;

namespace SocialClient.Services
{
    //todo make not static
    public class WindowService
    {
        public static void ShowUser(int id)
        {
            new UserWindow(new UserView(id)).Show();
        }
    }
}