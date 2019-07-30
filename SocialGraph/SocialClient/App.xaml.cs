using System.Windows;
using Ninject;
using Ninject.Extensions.Factory;
using SocialClient.Services;
using SocialClient.ViewModels;
using SocialClient.Views;

namespace SocialClient
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private StandardKernel _container;

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            ConfigureContainer();
            Current.MainWindow = this._container.Get<MainWindow>();
            Current.MainWindow.Show();
        }

        private void ConfigureContainer()
        {
            this._container = new StandardKernel();

            _container.Bind<IUserViewModelFactory>().ToFactory();
            _container.Bind<IUserWindowFactory>().ToFactory();
            _container.Bind<UserService>().ToSelf().InSingletonScope();
            _container.Bind<WindowService>().ToSelf().InSingletonScope();
            _container.Bind<GraphViewModel>().ToSelf().InTransientScope();
            _container.Bind<GraphView>().ToSelf().InTransientScope();
        }
    }
}
