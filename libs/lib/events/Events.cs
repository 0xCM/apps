//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [ApiHost]
    public readonly struct Events
    {
        [Op]
        public static StackFrame frame(int index)
            => new StackFrame(index);

        const NumericKind Closure = UInt64k;

        const string HandlerNotFound = "Handler for {0} not found";

        [MethodImpl(Inline), Op]
        public static EventSignal signal(IEventSink sink, WfHost host)
            => new EventSignal(sink, host);

        [MethodImpl(Inline), Op]
        public static EventSignal signal(IEventSink sink, Type host)
            => new EventSignal(sink, host);

        [Op, Closures(Closure)]
        public static BabbleEvent<T> babble<T>(Type host, T msg)
            => new BabbleEvent<T>(host, msg);

        [Op, Closures(Closure)]
        public static StatusEvent<T> status<T>(Type host, T msg, FlairKind flair = FlairKind.Status)
            => new StatusEvent<T>(host, msg, flair);

        [Op, Closures(Closure)]
        public static WarnEvent<T> warn<T>(Type host, T msg)
            => new WarnEvent<T>(host, msg);

        [Op, Closures(Closure)]
        public static ErrorEvent<string> error(Type host, Exception e, [CallerName] string caller = null, [CallerFile] string file = null, [CallerLine] int? line = null)
            => new ErrorEvent<string>(host, e, e.Message, originate(caller, caller,file, line ?? 0));

        [Op, Closures(Closure)]
        public static ErrorEvent<string> error(MethodInfo src, string msg)
            => new ErrorEvent<string>(src.DeclaringType, msg, originate(src.DeclaringType, src.DisplayName(), EmptyString, 0));

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
        public static EmittingFileEvent emittingFile(FS.FilePath dst)
            => new EmittingFileEvent(frame(4).GetType(), dst);

        [Op]
        public static EmittedFileEvent emittedFile(FS.FilePath path, Count count = default)
            => new EmittedFileEvent(frame(4).GetType(), path, count);

        [Op]
        public static EmittedFileEvent emittedFile(Type host, FS.FilePath path, Count count = default)
            => new EmittedFileEvent(host, path, count);

        [Op]
        public static EmittedFileEvent<T> emittedFile<T>(Type host, FS.FilePath path, T msg)
            => new EmittedFileEvent<T>(host, path, msg);

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
        public static RanEvent<T> ran<T>(RunningEvent<T> prior, T msg = default)
            => new RanEvent<T>(prior, msg);

        [Op, Closures(Closure)]
        public static CreatingEvent creating(Type host)
            => new CreatingEvent(host);

        [Op, Closures(Closure)]
        public static CreatedEvent created(Type host)
            => new CreatedEvent(host);

        [Op, Closures(Closure)]
        public static CreatedEvent created(CreatingEvent prior)
            => new CreatedEvent(prior);

        [Op, Closures(Closure)]
        public static DataEvent<T> data<T>(T data)
            => new DataEvent<T>(data);

        [Op, Closures(Closure)]
        public static DataEvent<T> data<T>(T data, FlairKind flair)
            => new DataEvent<T>(data, flair);

        [Op, Closures(Closure)]
        public static RowEvent<T> row<T>(T data, FlairKind flair)
            => new RowEvent<T>(data, flair);

        [Op, Closures(Closure)]
        public static RowEvent<T> row<T>(T data)
            => new RowEvent<T>(data, FlairKind.Data);

        [Op]
        public static DisposedEvent disposed(Type host)
            => new DisposedEvent(host);
    }
}