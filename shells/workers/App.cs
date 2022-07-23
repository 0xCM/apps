//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
    using Microsoft.Extensions.Logging;

    class App
    {
        public static void Main(string[] args)
            => CreateHostBuilder(ApiRuntime.create(), args).Build().Run();

        static IServiceCollection configure(IWfRuntime wf, HostBuilderContext context, IServiceCollection services)
        {
            ServiceControl AddController(IServiceProvider provider)
                => new ServiceControl(wf, provider.GetService<ILogger<ServiceControl>>());

            return services.AddHostedService(AddController);
        }

        public static IHostBuilder CreateHostBuilder(IWfRuntime wf, string[] args)
            => Host.CreateDefaultBuilder(args)
                .ConfigureServices((c,s) => configure(wf,c,s));

                //.ConfigureServices( (hostContext, services) => services.AddHostedService(provider => new Controller(wf, provider.GetService<ILogger<Controller>>())));
    }
}