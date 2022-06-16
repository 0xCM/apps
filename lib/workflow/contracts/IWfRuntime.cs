//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static WfEvents;

    using Caller = System.Runtime.CompilerServices.CallerMemberNameAttribute;
    using File = System.Runtime.CompilerServices.CallerFilePathAttribute;
    using Line = System.Runtime.CompilerServices.CallerLineNumberAttribute;

    public interface IWfRuntime : IDisposable, ITextual, IServiceContext
    {
        IJsonSettings Settings {get;}

        IApiParts ApiParts {get;}

        PartToken Ct {get;}

        string[] Args {get;}

        string AppName {get;}

        WfController Controller {get;}

        IApiCatalog ApiCatalog {get;}

        IEventBroker EventBroker {get;}

        IPolySource Polysource {get;}

        WfHost Host {get;}

        LogLevel Verbosity {get;}

        ExecToken NextExecToken();

        ExecToken Completed(WfExecFlow src);

        ExecToken Completed<T>(WfExecFlow<T> src);

        IWfRuntime WithSource(IPolySource source);

        IWfEmissionLog Emissions {get;}

        void RedirectEmissions(IWfEmissionLog dst);

        void Disposed()
        {
            if(Verbosity.IsBabble())
                Raise(EventFactory.disposed(Host.Type));
        }

        WfExecFlow<T> Running<T>(T data)
        {
            signal(this).Running(data);
            return Flow(data);
        }

        WfExecFlow<T> Running<T>(WfHost host, T msg)
        {
            signal(this, host).Running(msg);
            return Flow(msg);
        }

        WfExecFlow<string> Running(WfHost host, [Caller] string operation = null)
        {
            signal(this, host).Running(operation);
            return Flow(operation);
        }

        ExecToken Ran<T>(WfExecFlow<T> src)
        {
            var token = Completed(src);
            WfEvents.signal(this).Ran(src.Data);
            return token;
        }

        ExecToken Ran<T>(WfExecFlow<T> src, FlairKind flair)
        {
            var token = Completed(src);
            WfEvents.signal(this).Ran(src.Data);
            return token;
        }

        ExecToken Ran<T>(WfHost host, WfExecFlow<T> src, FlairKind flair = FlairKind.Ran)
        {
            var token = Completed(src);
            WfEvents.signal(this, host).Ran(src.Data);
            return token;
        }

        ExecToken Ran<T,D>(WfExecFlow<T> src, D data, FlairKind flair = FlairKind.Ran)
        {
            var token = Completed(src);
            WfEvents.signal(this).Ran(data);
            return token;
        }

        ExecToken Ran<T,D>(WfHost host, WfExecFlow<T> src, D data, FlairKind flair = FlairKind.Ran)
        {
            var token = Completed(src);
            WfEvents.signal(this, host).Ran(data);
            return token;
        }

        Assembly[] Components
            => ApiCatalog.Components;

        string ITextual.Format()
            => AppName;

        WfExecFlow<T> Flow<T>(T data)
            => new WfExecFlow<T>(this, data, NextExecToken());

        WfTableFlow<T> TableFlow<T>(FS.FilePath dst)
            where T : struct
                => new WfTableFlow<T>(this, dst, NextExecToken());

        WfFileWritten Flow(FS.FilePath dst)
            => new WfFileWritten(this, dst, NextExecToken());

        /// <summary>
        /// Provides a <see cref='IWfDb'/> rooted at a shell-configured location
        /// </summary>
        IWfDb Db()
            => new WfDb(this, Env.Db);

        IWfDb Db(FS.FolderPath root)
            => new WfDb(this, root);

        EventId Raise<E>(in E e)
            where E : IWfEvent
        {
            EventSink.Deposit(e);
            return e.EventId;
        }

        void Babble<T>(T data)
            => signal(this).Babble(data);

        void Babble<T>(WfHost host, T data)
            => signal(this, host).Babble(data);

        void Status<T>(T data, FlairKind flair = FlairKind.Status)
            => signal(this).Status(data, flair);

        void Status<T>(WfHost host,T data, FlairKind flair = FlairKind.Status)
            => signal(this, host).Status(data, flair);

        void Warn<T>(T content)
            => signal(this).Warn(content);

        void Warn<T>(WfHost host, T content)
            => signal(this, host).Warn(content);

        void Error(Exception e, [Caller] string caller = null, [File] string file = null, [Line]int? line = null)
            => signal(this).Error(e, EventFactory.originate("WorkflowError", caller, file, line));

        void Error<T>(T msg, [Caller] string caller = null, [File] string file = null, [Line]int? line = null)
            => signal(this).Error(msg, EventFactory.originate("WorkflowError", caller, file, line));

        void Error<T>(WfHost host, T data, [Caller] string caller = null, [File] string file = null, [Line]int? line = null)
            => signal(this, host).Error(data, EventFactory.originate("WorkflowError", caller, file, line));


        WfExecFlow<Type> Creating(Type host)
        {
            signal(this, host).Creating(host);
            return Flow(host);
        }

        ExecToken Created(WfExecFlow<Type> flow)
        {
            signal(this, flow.Data).Created(flow.Data);
            return Completed(flow);
        }

        WfTableFlow<T> EmittingTable<T>(FS.FilePath dst)
            where T : struct
        {
            signal(this).EmittingTable<T>(dst);
            return Emissions.LogEmission(TableFlow<T>(dst));
        }

        WfTableFlow<T> EmittingTable<T>(WfHost host, FS.FilePath dst)
            where T : struct
        {
            signal(this, host).EmittingTable<T>(dst);
            return Emissions.LogEmission(TableFlow<T>(dst));
        }

        ExecToken EmittedTable<T>(WfTableFlow<T> flow, Count count, FS.FilePath? dst = null)
            where T : struct
        {
            var completed = Completed(flow);
            var counted = flow.WithCount(count).WithToken(completed);
            signal(this).EmittedTable<T>(count, counted.Target);
            Emissions.LogEmission(counted);
            return completed;
        }

        ExecToken EmittedTable<T>(WfHost host, WfTableFlow<T> flow, Count count, FS.FilePath? dst = null)
            where T : struct
        {
            var completed = Completed(flow);
            var counted = flow.WithCount(count).WithToken(completed);
            signal(this, host).EmittedTable<T>(count, counted.Target);
            Emissions.LogEmission(counted);
            return completed;
        }

        WfFileWritten EmittingFile(FS.FilePath dst)
        {
            signal(this).EmittingFile(dst);
            return Emissions.LogEmission(Flow(dst));
        }

        WfFileWritten EmittingFile(WfHost host, FS.FilePath dst)
        {
            signal(this, host).EmittingFile(dst);
            return Emissions.LogEmission(Flow(dst));
        }

        ExecToken EmittedFile(WfFileWritten flow, Count count)
        {
            var completed = Completed(flow);
            var counted = flow.WithCount(count).WithToken(completed);
            signal(this).EmittedFile(count, counted.Target);
            Emissions.LogEmission(counted);
            return completed;
        }

        ExecToken EmittedFile(WfHost host, WfFileWritten flow, Count count)
        {
            var completed = Completed(flow);
            var counted = flow.WithCount(count).WithToken(completed);
            signal(this, host).EmittedFile(count, counted.Target);
            Emissions.LogEmission(counted);
            return completed;
        }

        void Row<T>(T data)
            => signal(this).Data(data);

        void Row<T>(T data, FlairKind flair)
            => signal(this).Data(data, flair);

        void Row<T>(WfHost host, T data)
            => signal(this).Data(data);

        void Row<T>(WfHost host, T data, FlairKind flair)
            => signal(this).Data(data, flair);
    }
}