//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Reflection;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
    using Microsoft.Extensions.Logging;

    class App
    {
        public static FS.FolderPath Storage
            => (FS.path(Assembly.GetEntryAssembly().Location).FolderPath + FS.folder(".storage")).Create();

        public static PartId ControlId
            => Assembly.GetCallingAssembly().Id();

        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        static Controller worker(IServiceProvider provider)
            => new Controller(provider.GetService<ILogger<Controller>>());

        public static IHostBuilder CreateHostBuilder(string[] args)
            => Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddHostedService(worker);
                });
    }
}