using System.Windows;
using SocialClient.Views;

namespace SocialClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow(GraphView graphView)
        {
            InitializeComponent();
            mainGrid.Children.Add(graphView);
        }
    }
}
