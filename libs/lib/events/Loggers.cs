//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [ApiHost]
    public readonly struct Loggers
    {
        public static FS.FolderPath logs(Assembly src)
            => FS.dir($"d:/views/db/logs/{src.Id().Format()}");

        public static IWfEmissionLog emission(Assembly src, Timestamp? ts = null)
            => new WfEmissionLog(src, logs(src) + FS.folder("emissions"), ts);

        public static IWfEmissionLog emission(Assembly src, FS.FolderPath dst, Timestamp ts, string name)
            => new WfEmissionLog(src, dst, ts, name);

        internal static FS.FilePath config(Assembly src, FS.FolderPath root, string name, FileKind kind, Timestamp? ts = null)
        {
            var id = text.empty(name) ? src.Id().Format() : $"{src.Id().Format()}.{name}";
            return root + FS.file($"{id}.{ts ?? core.timestamp()}", kind.Ext());
        }

        [Op]
        public static string format(IWfLogConfig src)
           => string.Format(RpOps.Settings4,
                nameof(src.LogRoot), src.LogRoot.Format(),
                nameof(src.StatusPath), src.StatusPath.Format(),
                nameof(src.ErrorPath), src.ErrorPath.Format()
                );

        [MethodImpl(Inline), Op]
        public static IWfEventLog events(WfLogConfig config)
            => new WfEventLog(config);

        [MethodImpl(Inline), Op]
        public static IEventSink term(string src)
            => new TermLog(src);

        [MethodImpl(Inline), Op]
        public static WfLogConfig configure(string name = EmptyString)
            => new WfLogConfig(core.controller().Id(), FS.dir("d:/views/db/logs"), name);
    }
}