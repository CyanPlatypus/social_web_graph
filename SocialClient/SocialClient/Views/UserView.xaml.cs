using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using SocialClient.ViewModels;
using System.Windows.Interactivity;
namespace SocialClient.Views
{
    /// <summary>
    /// Interaction logic for UserView.xaml
    /// </summary>
    public partial class UserView : UserControl
    {
        private UserViewModel _userViewModel;

        public UserView()
        {
            _userViewModel = new UserViewModel(1);
            this.DataContext = _userViewModel;

            InitializeComponent();
        }

        public UserView(int id)
        {
            _userViewModel = new UserViewModel(id);
            this.DataContext = _userViewModel;

            InitializeComponent();
        }
    }
}
