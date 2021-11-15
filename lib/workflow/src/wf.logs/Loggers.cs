//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    [ApiHost]
    public readonly struct Loggers
    {
        [Op]
        public static string format(IWfLogConfig src)
           => string.Format(RP.Settings4,
                nameof(src.LogRoot), src.LogRoot.Format(),
                nameof(src.StatusLog), src.StatusLog.Format(),
                nameof(src.ErrorLog), src.ErrorLog.Format()
                );

        [MethodImpl(Inline), Op]
        public static IWorkerLog worker(WfLogConfig config)
            => new WorkerLog(config);

        [MethodImpl(Inline), Op]
        public static IWorkerLog worker(PartId control, FS.FolderPath logdir)
            => worker(configure(control, logdir));

        [MethodImpl(Inline), Op]
        public static IWfEventLog events(WfLogConfig config)
            => new WfEventLog(config);

        [MethodImpl(Inline), Op]
        public static IEventSink term(string src)
            => new TermLog(src);

        [MethodImpl(Inline), Op]
        public static WfLogConfig configure(PartId part, FS.FolderPath dbRoot)
            => new WfLogConfig(part, dbRoot);

        [MethodImpl(Inline), Op]
        public static WfLogConfig configure(PartId part, FS.FolderPath dbRoot, string area)
            => new WfLogConfig(part, dbRoot);
    }
}