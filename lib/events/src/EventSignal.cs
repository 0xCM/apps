//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static EventFactory;
    using static Root;

    public class EventSignal
    {
        readonly IEventSink Sink;

        readonly WfHost Source;

        [MethodImpl(Inline)]
        internal EventSignal(IEventSink sink, WfHost src)
        {
            Source = src;
            Sink = sink;
        }

        public EventId Raise<E>(in E e)
            where E : IWfEvent
        {
            Sink.Deposit(e);
            return e.EventId;
        }

        public RanEvent<T> Ran<T>(T data)
        {
            var e = ran(Source, data);
            Raise(e);
            return e;
        }

        public RanCmdEvent Ran(CmdResult cmd)
        {
            var e = new RanCmdEvent(cmd);
            Raise(e);
            return e;
        }

        public RunningEvent Running()
        {
            var e = running(Source);
            Raise(e);
            return e;
        }

        public RunningEvent Running(WfHost host)
        {
            var e = running(host);
            Raise(e);
            return e;
        }

        public RunningEvent<T> Running<T>(WfHost host, T data)
        {
            var e = running(host, data);
            Raise(e);
            return e;
        }

        public RunningEvent<T> Running<T>(T data)
        {
            var e = running(Source, data);
            Raise(e);
            return e;
        }

        public RunningEvent<T> Running<T>(string operation, T data)
        {
            var e = running(Source, operation, data);
            Raise(e);
            return e;
        }

        public ProcessingFileEvent Processing(FS.FilePath src)
        {
            var e = processingFile(Source,src);
             Raise(e);
             return e;
        }

        public ProcessedFileEvent Processed(FS.FilePath src)
        {
            var e = processedFile(Source,src);
             Raise(e);
             return e;
        }

        public CreatingEvent<T> Creating<T>(T data)
        {
            var e = creating(Source, data);
            Raise(e);
            return e;
        }

        public CreatedEvent<T> Created<T>(T data)
        {
            var e = created(Source, data);
            Raise(e);
            return e;
        }

        public EmittingTableEvent EmittingTable(Type type, FS.FilePath dst)
        {
            var e = emittingTable(Source, type, dst);
            Raise(e);
            return e;
        }

        public EmittingTableEvent<T> EmittingTable<T>(FS.FilePath dst)
            where T : struct
        {
            var e = emittingTable<T>(Source, dst);
            Raise(e);
            return e;
        }

        public EmittedTableEvent<T> EmittedTable<T>(Count count, FS.FilePath dst)
            where T : struct
        {
            var e = emittedTable<T>(Source, count, dst);
            Raise(e);
            return e;
        }

        public EmittedTableEvent<T> EmittedTable<T>(FS.FilePath dst)
            where T : struct
        {
            var e = emittedTable<T>(Source, dst);
            Raise(e);
            return e;
        }

        public EmittedTableEvent EmittedTable(Type type, Count count, FS.FilePath dst)
        {
            var e = emittedTable(Source, TableId.identify(type), count, dst);
            Raise(e);
            return e;
        }

        public EmittedTableEvent EmittedTable(Type type, FS.FilePath dst)
        {
            var e = emittedTable(Source, TableId.identify(type), dst);
            Raise(e);
            return e;
        }

        public EmittingFileEvent EmittingFile(FS.FilePath dst)
        {
            var e = emittingFile(Source, dst);
            Raise(e);
            return e;
        }

        public EmittedFileEvent EmittedFile(FS.FilePath dst)
        {
            var e = emittedFile(Source, dst);
            Raise(e);
            return e;
        }

        public EmittedFileEvent EmittedFile(Count count, FS.FilePath dst)
        {
            var e = emittedFile(Source, dst, count);
            Raise(e);
            return e;
        }

        public EmittingFileEvent<T> EmittingFile<T>(T payload, FS.FilePath dst)
        {
            var e = emittingFile<T>(Source, payload, dst);
            Raise(e);
            return e;
        }

        public EmittedFileEvent<T> EmittedFile<T>(T payload, Count count, FS.FilePath dst)
        {
            var e = emittedFile(Source, payload, count, dst);
            Raise(e);
            return e;
        }

        public EmittedFileEvent<T> EmittedFile<T>(T payload, FS.FilePath dst)
        {
            var e = emittedFile(Source, payload, dst);
            Raise(e);
            return e;
        }

        public StatusEvent<T> Status<T>(WfStepId step, T data)
        {
            var e = status(step, data);
            Raise(e);
            return e;
        }

        public StatusEvent<T> Status<T>(T data)
        {
            var e = status(Source, data);
            Raise(e);
            return e;
        }

        public BabbleEvent<T> Babble<T>(WfStepId step, T data)
        {
            var e = babble(step, data);
            Raise(e);
            return e;
        }

        public BabbleEvent<T> Babble<T>(T data)
        {
            var e = babble(Source, data);
            Raise(e);
            return e;
        }

        public ErrorEvent<T> Error<T>(T body)
        {
            var e = error(Source.Identifier, body);
            Raise(e);
            return e;
        }

        public ErrorEvent<T> Error<T>(WfStepId step, T body, EventOrigin source)
        {
            var e = error(step, body, source);
            Raise(e);
            return e;
        }

        public ErrorEvent<Exception> Error(WfStepId step, Exception e, EventOrigin source)
        {
            var ev = error(step, e, source);
            Raise(ev);
            return ev;
        }

        public void Error(Exception e, EventOrigin source)
        {
            var ev = error(Source, e, source);
            Raise(ev);
        }

        public ErrorEvent<T> Error<T>(T body, EventOrigin source)
            => Error(Source, body, source);

        public WarnEvent<T> Warn<T>(WfStepId step, T content)
        {
            var e = warn(step, content);
            Raise(e);
            return e;
        }

        public WarnEvent<T> Warn<T>(T content)
            => Warn(Source, content);

        public DataEvent<T> Data<T>(T data, FlairKind? flair = null)
        {
            var e = EventFactory.data(data, flair);
            Raise(e);
            return e;
        }
    }
}