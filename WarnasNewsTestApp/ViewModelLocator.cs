using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarnasNewsTestApp.ViewModels;

namespace WarnasNewsTestApp
{
    class ViewModelLocator
    {
        private static ServiceProvider _provaider;


        public static void Init()
        {
            var services = new ServiceCollection();

            //My ViewModels
            services.AddTransient<MainViewModel>();

            services.AddTransient<ShowLastNewsPageViewModel>();

            services.AddTransient<AddNewsPageViewModel>();



            // My service
            //services.AddSingleton<NavigationService>();
            //services.AddSingleton<EventBus>();
            //services.AddSingleton<MessageBus>();
            //services.AddSingleton<ServerСommunication>();

            _provaider = services.BuildServiceProvider();

            foreach (var item in services)
            {
                _provaider.GetRequiredService(item.ServiceType);
            }
        }

        public MainViewModel MainViewModel => _provaider.GetRequiredService<MainViewModel>();

        public AddNewsPageViewModel AddNewsPageViewModel => _provaider.GetRequiredService<AddNewsPageViewModel>();

        public ShowLastNewsPageViewModel ShowLastNewsPageViewModel => _provaider.GetRequiredService<ShowLastNewsPageViewModel>();


    }
}
