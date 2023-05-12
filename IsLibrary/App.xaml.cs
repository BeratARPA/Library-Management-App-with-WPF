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

            services.AddScoped<ShellViewModel>();
            services.AddScoped<ShellView>(provider => new ShellView
            {
                DataContext = provider.GetRequiredService<ShellViewModel>()
            });

            services.AddScoped<HomeViewModel>();
            services.AddScoped<BookListViewModel>();
            services.AddScoped<AddBookViewModel>();
            services.AddScoped<INavigationService, Services.NavigationService>();

            services.AddScoped<Func<Type, ViewModelBase>>(serviceProvider => viewModelType => (ViewModelBase)serviceProvider.GetRequiredService(viewModelType));

            _serviceProvider = services.BuildServiceProvider();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            var shellView = _serviceProvider.GetRequiredService<ShellView>();
            shellView.Show();
            base.OnStartup(e);
        }
    }
}
