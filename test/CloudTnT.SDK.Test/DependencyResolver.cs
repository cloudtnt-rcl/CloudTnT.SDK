﻿using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CloudTnT.SDK.Test
{
    public static class DependencyResolver
    {
        public static ServiceProvider ServiceProvider()
        {
            ConfigurationBuilder builder = new ConfigurationBuilder();
            builder.AddUserSecrets<TestProject>();
            IConfiguration Configuration = builder.Build();

            IServiceCollection services = new ServiceCollection();

            services.AddCloudTnTNotificationConnectorServices();
            services.ConfigureCloudTnTApiOptions(options => Configuration.Bind("API", options));
            services.ConfigureCloudTnTSDKTestOptions(options => Configuration.Bind("User", options));
            services.AddCloudTnTDIDServices();

            return services.BuildServiceProvider();
        }
    }

    public class TestProject
    {
    }
}
