//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [ApiHost]
    public readonly struct Loggers
    {
        [MethodImpl(Inline), Op]
        public static ref EmissionLogEntry entry(in FileWritten src, out EmissionLogEntry dst)
        {
            dst.ExecToken = src.Token;
            dst.Target = src.Target;
            dst.FileType = src.Target.Ext;
            dst.Quantity = src.EmissionCount;
            dst.EventType = src.EmissionCount == 0 ? EmissionEventKind.Emitting : EmissionEventKind.Emitted;
            return ref dst;
        }

        [MethodImpl(Inline), Op, Closures(UnsignedInts)]
        public static ref EmissionLogEntry entry<T>(in WfTableFlow<T> src, out EmissionLogEntry dst)
            where T : struct
        {
            dst.ExecToken = src.Token;
            dst.Target = src.Target;
            dst.FileType = src.Target.Ext;
            dst.Quantity = src.EmissionCount;
            dst.EventType = src.EmissionCount == 0 ? EmissionEventKind.Emitting : EmissionEventKind.Emitted;
            return ref dst;
        }

        public static FS.FolderPath logs(Assembly src)
            => FS.dir($"d:/views/db/logs/{src.Id().Format()}");

        public static IWfEmissionLog emission(Assembly src)
            => new WfEmissionLog(src, logs(src) + FS.folder("emissions"));

        public static IWfEmissionLog emission(Assembly src, Timestamp ts)
            => new WfEmissionLog(src, logs(src) + FS.folder("emissions"), ts);

        public static IWfEmissionLog emission(Assembly src, FS.FolderPath dst, Timestamp ts, string name)
            => new WfEmissionLog(src, dst, ts, name);

        public static IWfEmissionLog emission(FS.FilePath dst)
            => new WfEmissionLog(dst);

        internal static FS.FilePath config(Assembly src, FS.FolderPath dst, string name, FileKind kind, Timestamp? ts = null)
        {
            var id = text.empty(name) ? src.Id().Format() : $"{src.Id().Format()}.{name}";
            return dst + FS.file($"{id}.{ts ?? core.timestamp()}", kind.Ext());
        }

        [MethodImpl(Inline), Op]
        public static IWorkerLog worker(FS.FolderPath home)
            => new WorkerLog(new LogSettings(home));

        [MethodImpl(Inline), Op]
        public static IWorkerLog worker(LogSettings config)
            => new WorkerLog(config);

        [MethodImpl(Inline), Op]
        public static IWfEventLog events(LogSettings config)
            => new WfEventLog(config);

        [MethodImpl(Inline), Op]
        public static IEventSink term(string src)
            => new TermLog(src);

        [MethodImpl(Inline), Op]
        public static LogSettings configure(string name = EmptyString)
            => new LogSettings(ExecutingPart.Component.Id(), FS.dir("d:/views/db/logs"), name);
    }
}