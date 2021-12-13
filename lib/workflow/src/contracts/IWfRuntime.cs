//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Reflection;
    using System.Threading.Tasks;

    using static WfEvents;

    using Caller = System.Runtime.CompilerServices.CallerMemberNameAttribute;
    using File = System.Runtime.CompilerServices.CallerFilePathAttribute;
    using Line = System.Runtime.CompilerServices.CallerLineNumberAttribute;

    public interface IWfRuntime : IDisposable, ITextual, IServiceContext
    {
        IJsonSettings Settings {get;}

        IApiParts ApiParts {get;}

        CorrelationToken Ct {get;}

        string[] Args {get;}

        string AppName {get;}

        WfController Controller {get;}

        IApiCatalog ApiCatalog {get;}

        IWfContext Context {get;}

        IEventBroker EventBroker {get;}

        ICmdRouter Router {get;}

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
                Raise(EventFactory.disposed(Host.StepId, Ct));
        }

        WfExecFlow<T> Running<T>(T data)
        {
            signal(this).Running(data);
            return Flow(data);
        }

        WfExecFlow<T> Running<T>(WfHost host, T data)
        {
            signal(this, host).Running(data);
            return Flow(data);
        }

        WfExecFlow<T> Running<T>(T data, string operation)
        {
            signal(this).Running(operation, data);
            return Flow(data);
        }

        WfExecFlow<T> Running<T>(WfHost host, T data, string operation)
        {
            signal(this, host).Running(operation, data);
            return Flow(data);
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

        ExecToken Ran<T>(WfHost host, WfExecFlow<T> src)
        {
            var token = Completed(src);
            WfEvents.signal(this, host).Ran(src.Data);
            return token;
        }

        ExecToken Ran<T,D>(WfExecFlow<T> src, D data)
        {
            var token = Completed(src);
            WfEvents.signal(this).Ran(data);
            return token;
        }

        ExecToken Ran<T,D>(WfHost host, WfExecFlow<T> src, D data)
        {
            var token = Completed(src);
            WfEvents.signal(this, host).Ran(data);
            return token;
        }

        Assembly[] Components
            => Context.ApiParts.Components;

        string ITextual.Format()
            => AppName;

        WfExecFlow<T> Flow<T>(T data)
            => new WfExecFlow<T>(this, data, NextExecToken());

        WfTableFlow<T> TableFlow<T>(FS.FilePath dst)
            where T : struct
                => new WfTableFlow<T>(this, dst, NextExecToken());

        WfFileFlow Flow(FS.FilePath dst)
            => new WfFileFlow(this, dst, NextExecToken());

        Task<CmdResult> Dispatch(ICmd cmd)
            => Task.Factory.StartNew(() => Router.Dispatch(cmd));

        CmdResult Execute(ICmd cmd)
            => Router.Dispatch(cmd);

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

        void Status<T>(T data)
            => signal(this).Status(data);

        void Status<T>(WfHost host,T data)
            => signal(this, host).Status(data);

        void Warn<T>(T content)
            => signal(this).Warn(content);

        void Warn<T>(WfHost host, T content)
            => signal(this, host).Warn(content);

        void Error(Exception e, [Caller] string caller = null, [File] string file = null, [Line]int? line = null)
            => signal(this).Error(e, EventFactory.originate("WorkflowError", caller, file, line));

        void Error(WfHost host, Exception e, [Caller] string caller = null, [File] string file = null, [Line]int? line = null)
            => signal(this, host).Error(e, EventFactory.originate("WorkflowError", caller, file, line));

        void Error<T>(T data, [Caller] string caller = null, [File] string file = null, [Line]int? line = null)
            => signal(this).Error(data, EventFactory.originate("WorkflowError", caller, file, line));

        void Error<T>(WfHost host, T data, [Caller] string caller = null, [File] string file = null, [Line]int? line = null)
            => signal(this, host).Error(data, EventFactory.originate("WorkflowError", caller, file, line));

        WfExecFlow<T> Creating<T>(T data)
        {
            signal(this).Creating(data);
            return Flow(data);
        }

        WfExecFlow<T> Creating<T>(WfHost host, T data)
        {
            signal(this, host).Creating(data);
            return Flow(data);
        }

        ExecToken Created<T>(WfExecFlow<T> flow)
        {
            signal(this).Created(flow.Data);
            return Completed(flow);
        }

        ExecToken Created<T>(WfHost host, WfExecFlow<T> flow)
        {
            signal(this, host).Created(flow.Data);
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

        WfFileFlow EmittingFile(FS.FilePath dst)
        {
            signal(this).EmittingFile(dst);
            return Emissions.LogEmission(Flow(dst));
        }

        WfFileFlow EmittingFile(WfHost host, FS.FilePath dst)
        {
            signal(this,host).EmittingFile(dst);
            return Emissions.LogEmission(Flow(dst));
        }

        ExecToken EmittedFile(WfFileFlow flow, Count count)
        {
            var completed = Completed(flow);
            var counted = flow.WithCount(count).WithToken(completed);
            signal(this).EmittedFile(count, counted.Target);
            Emissions.LogEmission(counted);
            return completed;
        }

        ExecToken EmittedFile(WfHost host, WfFileFlow flow, Count count)
        {
            var completed = Completed(flow);
            var counted = flow.WithCount(count).WithToken(completed);
            signal(this, host).EmittedFile(count, counted.Target);
            Emissions.LogEmission(counted);
            return completed;
        }

        void Row<T>(T data, FlairKind? flair = null)
            => signal(this).Data(data,flair);

        void Row<T>(WfHost host, T data, FlairKind? flair = null)
            => signal(this, host).Data(data,flair);
    }
}