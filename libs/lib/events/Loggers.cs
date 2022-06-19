//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [ApiHost]
    public readonly struct Loggers
    {
        public static IWfEmissionLog emission(Assembly src, Timestamp? ts = null, string name = null)
            => new WfEmissionLog(src, Environs.dir(EnvNames.Logs).VarValue + FS.folder(src.Id().Format()), ts, name);

        public static IWfEmissionLog emission(Assembly src, FS.FolderPath dst, Timestamp ts, string name)
            => new WfEmissionLog(src, Environs.dir(EnvNames.Logs).VarValue + FS.folder(src.Id().Format()), ts, name);

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
            => new WfLogConfig(core.controller().Id(), Environs.dir(EnvNames.Logs), name);

        [MethodImpl(Inline), Op]
        public static WfLogConfig configure(PartId part, FS.FolderPath root, string name = EmptyString)
            => new WfLogConfig(part, root, name);
    }
}