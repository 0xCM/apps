//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using Caller = System.Runtime.CompilerServices.CallerMemberNameAttribute;
    using File = System.Runtime.CompilerServices.CallerFilePathAttribute;
    using Line = System.Runtime.CompilerServices.CallerLineNumberAttribute;

    using static Root;

    [ApiHost]
    public readonly struct EventFactory
    {
        const NumericKind Closure = UInt64k;

        const string HandlerNotFound = "Handler for {0} not found";

        /// <summary>
        /// Creates a <see cref='BabbleEvent{T}'/> message
        /// </summary>
        /// <param name="step">The executing step</param>
        /// <param name="content">The status content</param>
        /// <param name="ct">The correlation token</param>
        /// <typeparam name="T">The content type</typeparam>
        [Op, Closures(Closure)]
        public static BabbleEvent<T> babble<T>(WfStepId step, T content, CorrelationToken ct = default)
            => new BabbleEvent<T>(step, content, ct);

        /// <summary>
        /// Creates a <see cref='StatusEvent{T}'/> message
        /// </summary>
        /// <param name="step">The executing step</param>
        /// <param name="content">The status content</param>
        /// <param name="ct">The correlation token</param>
        /// <typeparam name="T">The content type</typeparam>
        [Op, Closures(Closure)]
        public static StatusEvent<T> status<T>(WfStepId step, T content)
            => new StatusEvent<T>(step, content);

        [Op, Closures(Closure)]
        public static StatusEvent<T> status<T>(Type host, T content)
            => new StatusEvent<T>(host, content);

        [Op, Closures(Closure)]
        public static WarnEvent<T> warn<T>(WfStepId step, T body)
            => new WarnEvent<T>(step, body);

        [Op, Closures(Closure)]
        public static ErrorEvent<T> error<T>(string label, T data, [Caller] string caller = null, [File] string file = null, [Line] int? line = null)
            => new ErrorEvent<T>(label, data, originate(caller, caller,file, line ?? 0));

        [Op, Closures(UInt64k)]
        public static ErrorEvent<T> error<T>(WfStepId step, T data, EventOrigin source)
            => new ErrorEvent<T>(step, data, source);

        [Op]
        public static ErrorEvent<WfHost> error(WfHost host, Exception e, EventOrigin source)
            => new ErrorEvent<WfHost>(e, host, source);

        [Op]
        public static ErrorEvent<string> missing(CmdId cmd, EventOrigin source)
            => new ErrorEvent<string>(cmd, string.Format(HandlerNotFound, cmd.GetType().Name), source);

        [Op, Closures(Closure)]
        public static ProcessedEvent<T> processed<T>(WfStepId step, T content, CorrelationToken ct = default)
            => new ProcessedEvent<T>(step, content);

        /// <summary>
        /// Defines a <see cref='EventOrigin'/>
        /// </summary>
        /// <param name="name">The origin name</param>
        /// <param name="caller">The calling member</param>
        /// <param name="file">The file in which the calling member is defined</param>
        /// <param name="line">The invocation line number</param>
        [Op]
        public static EventOrigin originate(string name, [Caller] string caller = null, [File] string file = null, [Line] int? line = null)
            => new EventOrigin(name, new CallingMember(caller, file, line ?? 0));

        /// <summary>
        /// Defines a <see cref='EventOrigin'/>
        /// </summary>
        /// <param name="type">The origin type</param>
        /// <param name="caller">The calling member</param>
        /// <param name="file">The file in which the calling member is defined</param>
        /// <param name="line">The invocation line number</param>
        /// <typeparam name="T">The orgin type</typeparam>
        [Op]
        public static EventOrigin originate(Type type,[Caller] string caller = null, [File] string file = null, [Line] int? line = null)
            => originate(type.Name, caller, file, line);

        /// <summary>
        /// Defines a <see cref='EventOrigin'/>
        /// </summary>
        /// <param name="caller">The calling member</param>
        /// <param name="file">The file in which the calling member is defined</param>
        /// <param name="line">The invocation line number</param>
        /// <typeparam name="T">The orgin type</typeparam>
        [Op]
        public static EventOrigin originate<T>([Caller] string caller = null, [File] string file = null, [Line] int? line = null)
            => originate(typeof(T), caller, file, line);

        [Op, Closures(Closure)]
        public static EmittingFileEvent<T> emittingFile<T>(WfStepId step, T payload, FS.FilePath dst, CorrelationToken ct = default)
            => new EmittingFileEvent<T>(step, payload, dst, ct);

        [Op, Closures(Closure)]
        public static EmittedFileEvent<T> emittedFile<T>(WfStepId step, T payload, Count count, FS.FilePath dst, CorrelationToken ct = default)
            => new EmittedFileEvent<T>(step, payload, count, dst, ct);

        [Op, Closures(Closure)]
        public static EmittedFileEvent<T> emittedFile<T>(WfStepId step, T payload, FS.FilePath dst, CorrelationToken ct = default)
            => new EmittedFileEvent<T>(step, payload, dst, ct);

        [Op, Closures(Closure)]
        public static EmittingFileEvent emittingFile(WfStepId step, FS.FilePath dst, CorrelationToken ct = default)
            => new EmittingFileEvent(step, dst, ct);

        [Op]
        public static EmittedFileEvent emittedFile(WfStepId step, FS.FilePath path, Count segments, CorrelationToken ct = default)
            => new EmittedFileEvent(step, path, segments, ct);

        [Op]
        public static EmittedFileEvent emittedFile(WfStepId step, FS.FilePath path, CorrelationToken ct = default)
            => new EmittedFileEvent(step, path, ct);

        [Op]
        public static ProcessingFileEvent processingFile(WfStepId step, FS.FilePath dst, CorrelationToken ct = default)
            => new ProcessingFileEvent(step, dst, ct);

        [Op]
        public static ProcessedFileEvent processedFile(WfStepId step, FS.FilePath dst, CorrelationToken ct = default)
            => new ProcessedFileEvent(step, dst, ct);

        [Op, Closures(Closure)]
        public static EmittingTableEvent<T> emittingTable<T>(WfStepId step, FS.FilePath dst)
            where  T : struct
                => new EmittingTableEvent<T>(step, dst);

        [Op, Closures(Closure)]
        public static EmittedTableEvent<T> emittedTable<T>(WfStepId step, Count count, FS.FilePath dst)
            where  T : struct
                => new EmittedTableEvent<T>(step, count, dst);

        [Op]
        public static EmittingTableEvent emittingTable(WfStepId step, Type src, FS.FilePath dst)
            => new EmittingTableEvent(step, src, dst);

        [Op]
        public static EmittedTableEvent emittedTable(WfStepId step, TableId table, uint count, FS.FilePath dst)
            => new EmittedTableEvent(step, table, count, dst);

        [Op]
        public static EmittedTableEvent emittedTable(WfStepId step, TableId table, FS.FilePath dst)
            => new EmittedTableEvent(step, table, dst);

        [Op, Closures(Closure)]
        public static EmittedTableEvent<T> emittedTable<T>(WfStepId step, FS.FilePath dst)
            where  T : struct
                => new EmittedTableEvent<T>(step, dst);

        [MethodImpl(Inline)]
        public static RanEvent<T> ran<H,T>(H host, T data, CorrelationToken ct = default)
            where H : IWfHost<H>, new()
                => new RanEvent<T>(host.StepId, data, ct);

        [Op]
        public static RunningEvent running(WfStepId step, CorrelationToken ct = default)
            => new RunningEvent(step, ct);

        [MethodImpl(Inline)]
        public static RunningEvent<T> running<T>(WfHost host, string operation, T data, CorrelationToken ct = default)
            => new RunningEvent<T>(host, operation, data, ct);

        [MethodImpl(Inline)]
        public static RunningEvent<T> running<H,T>(H host, T data, CorrelationToken ct = default)
            where H : IWfHost<H>, new()
                => new RunningEvent<T>(host.StepId, data, ct);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static DataEvent<T> data<T>(T data, FlairKind? flair = null)
            => flair.HasValue ? new DataEvent<T>(data, flair.Value) : new DataEvent<T>(data);

        /// <summary>
        /// Defines a <see cref='CreatedEvent{T}'/> event
        /// </summary>
        /// <param name="id">The step identifier</param>
        /// <param name="ct">The correlation token</param>
        /// <param name="flair">The flair</param>
        [Op, Closures(Closure)]
        public static CreatingEvent<T> creating<T>(WfStepId id, T content, CorrelationToken ct = default)
            => new CreatingEvent<T>(id, content, ct);

        /// <summary>
        /// Defines a <see cref='CreatedEvent{T}'/> event
        /// </summary>
        /// <param name="id">The step identifier</param>
        /// <param name="ct">The correlation token</param>
        /// <param name="flair">The flair</param>
        [Op, Closures(Closure)]
        public static CreatedEvent<T> created<T>(WfStepId id, T content, CorrelationToken ct = default)
            => new CreatedEvent<T>(id, content, ct);

        /// <summary>
        /// Defines a <see cref='DisposedEvent'/> event
        /// </summary>
        /// <param name="id">The step identifier</param>
        /// <param name="ct">The correlation token</param>
        [Op]
        public static DisposedEvent disposed(WfStepId step, CorrelationToken ct = default)
            => new DisposedEvent(step,ct);

        /// <summary>
        /// Defines a <see cref='Disposed{T}'/> event that carries a specified payload
        /// </summary>
        /// <param name="id">The step identifier</param>
        /// <param name="payload">The payload data</param>
        /// <param name="ct">The correlation token</param>
        [Op, Closures(Closure)]
        public static Disposed<T> disposed<T>(WfStepId step, T payload, CorrelationToken ct = default)
            => new Disposed<T>(step, payload, ct);
    }
}