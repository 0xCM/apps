//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [ApiHost]
    public readonly struct EventFactory
    {
        const NumericKind Closure = UInt64k;

        const string HandlerNotFound = "Handler for {0} not found";

        [Op, Closures(Closure)]
        public static BabbleEvent<T> babble<T>(Type host, T msg)
            => new BabbleEvent<T>(host, msg);

        [Op, Closures(Closure)]
        public static StatusEvent<T> status<T>(Type host, T msg, FlairKind flair)
            => new StatusEvent<T>(host, msg, flair);

        [Op, Closures(Closure)]
        public static WarnEvent<T> warn<T>(Type host, T msg)
            => new WarnEvent<T>(host, msg);

        [Op, Closures(Closure)]
        public static ErrorEvent<string> error(Type host, Exception e, [CallerName] string caller = null, [CallerFile] string file = null, [CallerLine] int? line = null)
            => new ErrorEvent<string>(host, e, e.Message, originate(caller, caller,file, line ?? 0));

        [Op]
        public static EventOrigin originate(Type type,[CallerName] string caller = null, [CallerFile] string file = null, [CallerLine] int? line = null)
            => originate(type.Name, caller, file, line);

        [Op, Closures(UInt64k)]
        public static ErrorEvent<string> error(Type host, Exception e, EventOrigin source)
            => new ErrorEvent<string>(host, e, e.Message, source);

        [Op, Closures(Closure)]
        public static ErrorEvent<T> error<T>(string label, T data, [CallerName] string caller = null, [CallerFile] string file = null, [CallerLine] int? line = null)
            => new ErrorEvent<T>(label, data, originate(caller, caller,file, line ?? 0));

        [Op, Closures(UInt64k)]
        public static ErrorEvent<T> error<T>(Type host, T msg, EventOrigin source)
            => new ErrorEvent<T>(host, msg, source);

        [Op]
        public static EventOrigin originate(string name, [CallerName] string caller = null, [CallerFile] string file = null, [CallerLine] int? line = null)
            => new EventOrigin(name, new CallingMember(caller, file, line ?? 0));

        [Op]
        public static EventOrigin originate<T>([CallerName] string caller = null, [CallerFile] string file = null, [CallerLine] int? line = null)
            => originate(typeof(T), caller, file, line);

        [Op, Closures(Closure)]
        public static EmittingFileEvent emittingFile(Type host, FS.FilePath dst)
            => new EmittingFileEvent(host, dst);

        [Op]
        public static EmittedFileEvent emittedFile(Type host, FS.FilePath path, Count count = default)
            => new EmittedFileEvent(host, path, count);

        [Op]
        public static EmittingTableEvent emittingTable(Type host, Type src, FS.FilePath dst)
            => new EmittingTableEvent(host, src, dst);

        [Op, Closures(Closure)]
        public static EmittingTableEvent<T> emittingTable<T>(Type host, FS.FilePath dst)
            where  T : struct
                => new EmittingTableEvent<T>(host, dst);

        [Op, Closures(Closure)]
        public static EmittedTableEvent<T> emittedTable<T>(Type host, Count count, FS.FilePath dst)
            where  T : struct
                => new EmittedTableEvent<T>(host, count, dst);

        [Op]
        public static EmittedTableEvent emittedTable(Type host, TableId table, Count count, FS.FilePath dst)
            => new EmittedTableEvent(host, table, count, dst);

        [Op]
        public static EmittedTableEvent emittedTable(Type host, TableId table, FS.FilePath dst)
            => new EmittedTableEvent(host, table, dst);

        [Op]
        public static ProcessingFileEvent processingFile(Type step, FS.FilePath dst)
            => new ProcessingFileEvent(step, dst);

        [Op]
        public static ProcessedFileEvent processedFile(Type step, FS.FilePath dst)
            => new ProcessedFileEvent(step, dst);

        [Op, Closures(Closure)]
        public static RunningEvent<T> running<T>(Type host, T msg)
            => new RunningEvent<T>(host, msg);

        [Op]
        public static RunningEvent running(Type host)
            => new RunningEvent(host);

        [Op, Closures(Closure)]
        public static RanEvent<T> ran<T>(Type host, T msg)
            => new RanEvent<T>(host, msg);

        [Op, Closures(Closure)]
        public static RanEvent<T> ran<T>(RunningEvent<T> prior)
            => new RanEvent<T>(prior);

        [Op, Closures(Closure)]
        public static CreatingEvent<T> creating<T>(Type host, T msg)
            => new CreatingEvent<T>(host, msg);

        [Op, Closures(Closure)]
        public static CreatedEvent<T> created<T>(Type host, T msg)
            => new CreatedEvent<T>(host, msg);

        [Op, Closures(Closure)]
        public static CreatedEvent<T> created<T>(CreatingEvent<T> prior)
            => new CreatedEvent<T>(prior);

        [Op, Closures(Closure)]
        public static DataEvent<T> data<T>(T data, FlairKind? flair = null)
            => flair.HasValue ? new DataEvent<T>(data, flair.Value) : new DataEvent<T>(data);

        [Op]
        public static DisposedEvent disposed(Type host)
            => new DisposedEvent(host);
    }
}