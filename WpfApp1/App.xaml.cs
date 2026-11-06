using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Configuration;
using System.Data;
using System.Windows;
using WpfApp1.ViewModels;
using WpfApp1.Views;
namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private IHost? _host;
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            _host = new HostBuilder().ConfigureServices((context, services) =>
            {
                services.AddSingleton<MainWindow>();

                services.AddSingleton<MainViewModel>();
                services.AddSingleton<ViewModels.ViewModel1>();
                services.AddSingleton<ViewModels.ViewModel2>();
                services.AddSingleton<ViewModels.ViewModel3>();

            }).Build();

            _host.StartAsync().GetAwaiter().GetResult();

            var mainWindow = _host.Services.GetRequiredService<MainWindow>();
            mainWindow.Show();
        }

        protected override void OnExit(ExitEventArgs e)
        {
            if (_host != null)
            {
                _host?.Dispose();
            }
            base.OnExit(e);
        }
    }

}
