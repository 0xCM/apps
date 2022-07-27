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
            AppController AddController(IServiceProvider provider)
                => new AppController(wf, provider.GetService<ILogger<AppController>>());

            return services.AddHostedService(AddController);
        }

        public static IHostBuilder CreateHostBuilder(IWfRuntime wf, string[] args)
            => Host.CreateDefaultBuilder(args)
                .ConfigureServices((c,s) => configure(wf,c,s));
    }
}