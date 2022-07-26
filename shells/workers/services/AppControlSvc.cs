//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Extensions.Hosting;
    using Microsoft.Extensions.Logging;

    public struct WatchSettings
    {
        public const string Name = "watch";

        public string Sources;

        public string Targets;
    }
    class ServiceControl : BackgroundService
    {
        readonly ILogger<ServiceControl> DisplayLog;

        readonly IWorkerLog WorkLog;

        readonly IArchiveMonitor Monitor;

        readonly FS.FolderPath LogStorage;

        readonly IDbSources Targets;

        readonly IWfRuntime Wf;

        public ServiceControl(IWfRuntime wf, ILogger<ServiceControl> logger)
        {
            Wf = wf;
            var db = AppDb.Service;
            var settings = Settings.lookup(db.Settings(WatchSettings.Name, FileKind.Toml),Chars.Eq);
            Targets = AppDb.Service.DbRoot().Sources();
            Starting(Targets);
            LogStorage = ExecutingPart.Component.Path().FolderPath + FS.folder("logs");
            WorkLog = Loggers.worker(LogStorage);
            DisplayLog = logger;
            Monitor = ArchiveMonitor.start(Targets, OnChange);
        }

        void Starting(IDbSources target)
            => term.print(Events.running(GetType(),$"Monitor covering {target.Root}/*.* initializing"));

        void Disposing(IDbSources target)
            => term.print(Events.ran(GetType(), $"Montior covering {Monitor.Target.Root} terminating"));

        void OnChange(FileChange change)
        {
            var message = change.Format();
            DisplayLog.LogInformation(message);
            WorkLog.LogStatus(message);
        }

        public override void Dispose()
        {
            Disposing(Targets);
            base.Dispose();
            Monitor?.Dispose();
            WorkLog?.Dispose();
            Wf.Dispose();
        }

        protected override async Task ExecuteAsync(CancellationToken cancel)
        {
            while (!cancel.IsCancellationRequested)
                await Task.Delay(1000, cancel);
        }
    }
}
