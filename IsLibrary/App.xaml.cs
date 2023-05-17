using IsLibrary.Helpers;
using IsLibrary.Services;
using IsLibrary.ViewModels;
using IsLibrary.Views;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Windows;

namespace IsLibrary
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly ServiceProvider _serviceProvider;

        public App()
        {
            IServiceCollection services = new ServiceCollection();

            services.AddSingleton<ShellViewModel>();
            services.AddSingleton<ShellView>(provider => new ShellView
            {
                DataContext = provider.GetRequiredService<ShellViewModel>()
            });

            services.AddSingleton<HomeViewModel>();
            services.AddSingleton<BookListViewModel>();
            services.AddSingleton<AddBookViewModel>();
            services.AddSingleton<INavigationService, Services.NavigationService>();

            services.AddSingleton<Func<Type, ViewModelBase>>(serviceProvider => viewModelType => (ViewModelBase)serviceProvider.GetRequiredService(viewModelType));

            _serviceProvider = services.BuildServiceProvider();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            AppDomain.CurrentDomain.UnhandledException += AppDomainUnhandledException;

            try
            {
                var shellView = _serviceProvider.GetRequiredService<ShellView>();
                shellView.Show();
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }

            base.OnStartup(e);
        }

        private static void AppDomainUnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            HandleException(e.ExceptionObject as Exception);
        }

        private static void HandleException(Exception ex)
        {
            if (ex == null) return;
            ExceptionReporter.Show(ex);
            Environment.Exit(1);
        }
    }
}
