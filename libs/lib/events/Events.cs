//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    [ApiHost]
    public readonly struct Events
    {
        const NumericKind Closure = UInt64k;

        const string HandlerNotFound = "Handler for {0} not found";

        [MethodImpl(Inline), Op]
        public static EventSignal signal(IEventSink sink, WfHost host)
            => new EventSignal(sink, host);

        [MethodImpl(Inline), Op]
        public static EventSignal signal(IEventSink sink, Type host)
            => new EventSignal(sink, host);

        [Op, Closures(Closure)]
        public static BufferedProjector<T> projector<T>(IPipeline pipeline)
            => projector(pipeline, new Queue<T>(), new SFxProjector<T>(identity));

        [Op, Closures(Closure)]
        public static BufferedProjector<T> projector<T>(IPipeline pipes, ISFxProjector<T> sfx)
            => projector(pipes, new Queue<T>(), sfx);

        public static BufferedProjector<S,T> projector<S,T>(IPipeline pipes, ISFxProjector<S,T> sfx)
            => projector<S,T>(pipes, new Queue<S>(), sfx);

        [MethodImpl(Inline)]
        internal static BufferedProjector<S,T> projector<S,T>(IPipeline pipes, Queue<S> buffer, ISFxProjector<S,T> fx)
            => new BufferedProjector<S,T>(pipes, buffer, fx);

        [MethodImpl(Inline), Op, Closures(Closure)]
        internal static BufferedProjector<T> projector<T>(IPipeline pipes, Queue<T> buffer, ISFxProjector<T> projector)
            => new BufferedProjector<T>(pipes, buffer, projector);

        public static SpanProjector<S,T> projector<S,T>(IPipeline pipes, ISpanMap<S,T> map)
            => SpanProjector<S,T>.create(pipes).With(map);

        static T identity<T>(T src)
            => src;

        [Op, Closures(Closure)]
        public static void transmit<T>(ReadOnlySpan<T> src, ReadOnlySpan<IReceiver<T>> dst)
        {
            var kSources = src.Length;
            var kTargets = dst.Length;
            for(var i=0; i<kSources; i++)
            {
                ref readonly var input = ref skip(src,i);
                for(var j=0; j<kTargets; j++)
                    skip(dst,j).Deposit(input);
            }
        }

        [Op, Closures(Closure)]
        public static uint transmit<T>(BufferedProjector<T> src, BufferedProjector<T> dst)
        {
            var count = 0u;
            while(src.Emit(out var cell))
            {
                dst.Deposit(cell);
                count++;
            }
            return count;
        }

        [Op, Closures(Closure)]
        public static uint transmit<T>(ReadOnlySpan<T> src, BufferedProjector<T> dst)
        {
            var count = (uint)src.Length;
            for(var i=0; i<count; i++)
                dst.Deposit(skip(src,i));
            return count;
        }

        /// <summary>
        /// Creates a <see cref='EmissionSink'/>
        /// </summary>
        public static IEmissionSink sink()
            => new EmissionSink();

        /// <summary>
        /// Creates a <see cref='Sink{T}'/> from a <see cref='Receiver{T}'/>
        /// </summary>
        /// <param name="dst">The target receiver</param>
        /// <typeparam name="T">The reception type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static Sink<T> sink<T>(Receiver<T> dst)
            => new Sink<T>(dst);

        /// <summary>
        /// Creates a <see cref='Sink{T}'/> from a <see cref='StreamWriter'/>
        /// </summary>
        /// <param name="dst">The target writer</param>
        /// <typeparam name="T">The reception type</typeparam>
        public static Sink<T> sink<T>(StreamWriter dst)
        {
            void Target(in T src) => dst.WriteLine(src);
            return new Sink<T>(Target);
        }

        /// <summary>
        /// Creates a <see cref='Sink{T}'/> from a <see cref='StreamWriter'/>
        /// </summary>
        /// <param name="dst">The target writer</param>
        /// <typeparam name="T">The reception type</typeparam>
        public static Sink<T> sink<T>(FileStream dst)
        {
            void Target(in T src)
                => FS.write(src?.ToString() ?? EmptyString, dst);

            return new Sink<T>(Target);
        }

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