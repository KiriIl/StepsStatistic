using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using StepsStatistic.AutoMapper;
using StepsStatistic.Models;
using StepsStatistic.Services;
using StepsStatistic.Services.Abstraction;
using StepsStatistic.ViewModels;
using StepsStatistic.Views;
using System.Windows;

namespace StepsStatistic
{
    public partial class App : Application
    {
        private ServiceProvider _serviceProvider;

        public App()
        {
            ServiceCollection services = new ServiceCollection();
            ConfigureServices(services);
            _serviceProvider = services.BuildServiceProvider();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            MainWindow = _serviceProvider.GetService<StatisticWindow>();
            MainWindow.Show();
        }

        private void ConfigureServices(ServiceCollection services)
        {
            services.AddSingleton(x => new JsonSerializerSettings()
            {
                Formatting = Formatting.Indented,
            });
            services.AddSingleton(new MapperConfiguration(serviceProvider => serviceProvider.AddProfile(new AutoMapperProfile())).CreateMapper());
            services.AddSingleton<IDialogService, DialogService>();
            services.AddSingleton<ISerializerService<UserModel>, UserSerializer>();
            services.AddSingleton<StatisticViewModel>();
            services.AddSingleton(serviceProvider => new StatisticWindow(serviceProvider.GetService<StatisticViewModel>()));
        }
    }
}