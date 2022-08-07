//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    class DirectoryMonitor : IMonitor
    {        
        public static IMonitor start(IDbSources src, IDbArchive dst)
            => new DirectoryMonitor(src, dst);

        readonly IWorkerLog Target;

        readonly IDbSources Sources;

        readonly IArchiveMonitor Service;

        readonly RunningEvent<string> Running;

        DirectoryMonitor(IDbSources src, IDbArchive dst)
        {
            var ts = Timestamp.now();
            var id = Archives.identifier(src.Root);
            var settings = new LogSettings(dst.Path($"{id}.{ts}",FileKind.Log), dst.Path($"{ts}.errors", FileKind.Log));
            Target = Loggers.worker(settings);
            Sources = src;
            Service = ArchiveMonitor.start(Sources, OnChange);
            Running = Events.running(GetType(), $"Initializing monitor over {Sources.Root}/*.*");
            term.emit(Running);
        }

        void Ran()
            => term.emit(Events.ran(Running, $"Finished monitoriing {Sources.Root}/*.*"));

        public void Dispose()
        {
            Service?.Dispose();
            Target?.Dispose();
            Ran();
        }

        void OnChange(FileChangeEvent change)
        {
            var message = change.Format();
            term.babble(message);
            Target.LogStatus(message);
        }

        public void Stop()
        {
            Dispose();
        }
    }
}