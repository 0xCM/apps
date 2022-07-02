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
            using var wf = ApiRuntime.create(args);
            CreateHostBuilder(wf, args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(IWfRuntime wf, string[] args)
            => Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostContext, services)
                    => services.AddHostedService(provider => new Controller(wf, provider.GetService<ILogger<Controller>>())));
    }
}