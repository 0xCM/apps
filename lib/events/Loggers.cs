//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [ApiHost]
    public readonly struct Loggers
    {
        public static IWfEmissionLog emission(string name, EnvData env)
            => new WfEmissionLog(env.Logs + FS.folder("emissions") + FS.file(name + ".emissions", FS.Log));

        public static IWfEmissionLog emission(string name, FS.FolderPath dir)
            => new WfEmissionLog(dir  + FS.file(name + ".emissions", FS.Log));

        [Op]
        public static string format(IWfLogConfig src)
           => string.Format(RP.Settings4,
                nameof(src.LogRoot), src.LogRoot.Format(),
                nameof(src.StatusPath), src.StatusPath.Format(),
                nameof(src.ErrorPath), src.ErrorPath.Format()
                );

        [MethodImpl(Inline), Op]
        public static IWorkerLog worker(WfLogConfig config)
            => new WorkerLog(config);

        [MethodImpl(Inline), Op]
        public static IWorkerLog worker(PartId control, FS.FolderPath root, string name = EmptyString)
            => worker(configure(control, root, name));

        [MethodImpl(Inline), Op]
        public static IWfEventLog events(WfLogConfig config)
            => new WfEventLog(config);

        [MethodImpl(Inline), Op]
        public static IEventSink term(string src)
            => new TermLog(src);

        [MethodImpl(Inline), Op]
        public static WfLogConfig configure(string name = EmptyString)
        {
            var a = core.controller();
            var id = a.Id();
            return new WfLogConfig(id, FS.path(a.Location).FolderPath, name);
        }

        [MethodImpl(Inline), Op]
        public static WfLogConfig configure(PartId part, FS.FolderPath root, string name = EmptyString)
            => new WfLogConfig(part, root, name);
    }
}