//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Reflection;
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Extensions.Hosting;
    using Microsoft.Extensions.Logging;

    class Controller : BackgroundService
    {
        readonly ILogger<Controller> DisplayLog;

        readonly IWorkerLog WorkLog;

        readonly IEnvPaths Paths;

        readonly IArchiveMonitor Monitor;

        readonly FS.FolderPath Storage;

        public Controller(ILogger<Controller> logger)
        {
            Storage = App.Storage;
            WorkLog = Loggers.worker(App.ControlId, Storage);
            DisplayLog = logger;
            Paths = EnvPaths.create();
            Monitor = ArchiveMonitor.start(Paths.DbRoot(), OnChange);
        }

        void OnChange(FileChange change)
        {
            var message = change.Format();
            DisplayLog.LogInformation(message);
            WorkLog.LogStatus(message);
        }

        public override void Dispose()
        {
            base.Dispose();
            Monitor?.Dispose();
            WorkLog?.Dispose();
        }

        protected override async Task ExecuteAsync(CancellationToken cancel)
        {
            while (!cancel.IsCancellationRequested)
            {
                await Task.Delay(1000, cancel);
            }
        }
    }
}
