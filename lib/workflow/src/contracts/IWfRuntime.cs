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

        IWfRuntime WithSource(IPolySource source);

        ExecToken Ran(WfExecFlow src);

        ExecToken Ran<T>(WfExecFlow<T> src);

        ExecToken Ran<T,D>(WfExecFlow<T> flow, D data);

        IWfEmissionLog Emissions {get;}

        void RedirectEmissions(IWfEmissionLog dst);

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

        /// <summary>
        /// Provides a <see cref='IWfDb'/> rooted at a shell-configured location
        /// </summary>
        IWfDb Db(FS.FolderPath root)
            => new WfDb(this, root);

        EventId Raise<E>(in E e)
            where E : IWfEvent
        {
            EventSink.Deposit(e);
            return e.EventId;
        }

        void Status<T>(T data)
            => signal(this).Status(data);

        void Babble<T>(T data)
            => signal(this).Babble(data);

        void Warn<T>(T content)
            => signal(this).Warn(content);

        void Error(Exception e, [Caller] string caller = null, [File] string file = null, [Line]int? line = null)
            => signal(this).Error(e, EventFactory.originate("WorkflowError", caller, file, line));

        void Error<T>(T data, [Caller] string caller = null, [File] string file = null, [Line]int? line = null)
            => signal(this).Error(data, EventFactory.originate("WorkflowError", caller, file, line));

        void Disposed()
        {
            if(Verbosity.IsBabble())
                Raise(EventFactory.disposed(Host.StepId, Ct));
        }

        WfExecFlow<T> Creating<T>(T data)
        {
            signal(this).Creating(data);
            return Flow(data);
        }

        ExecToken Created<T>(WfExecFlow<T> flow)
        {
            signal(this).Created(flow.Data);
            return Ran(flow);
        }

        WfTableFlow<T> EmittingTable<T>(FS.FilePath dst)
            where T : struct
        {
            signal(this).EmittingTable<T>(dst);
            return Emissions.LogEmission(TableFlow<T>(dst));
        }

        ExecToken EmittedTable<T>(WfTableFlow<T> flow, Count count, FS.FilePath? dst = null)
            where T : struct
        {
            var completed = Ran(flow);
            var counted = flow.WithCount(count).WithToken(completed);
            signal(this).EmittedTable<T>(count, counted.Target);
            Emissions.LogEmission(counted);
            return completed;
        }

        WfFileFlow EmittingFile(FS.FilePath dst)
        {
            signal(this).EmittingFile(dst);
            return Emissions.LogEmission(Flow(dst));
        }

        ExecToken EmittedFile(WfFileFlow flow, Count count)
        {
            var completed = Ran(flow);
            var counted = flow.WithCount(count).WithToken(completed);
            signal(this).EmittedFile(count, counted.Target);
            Emissions.LogEmission(counted);
            return completed;
        }

        WfExecFlow<string> Running([Caller] string operation = null)
        {
            signal(this).Running(operation);
            return Flow(operation);
        }

        WfExecFlow<T> Running<T>(T data, [Caller] string operation = null)
        {
            signal(this).Running(operation, data);
            return Flow(data);
        }

        void Row<T>(T data, FlairKind? flair = null)
            => signal(this).Data(data,flair);

        void Babble<T>(WfHost host, T data)
            => signal(this, host).Babble(data);

        void Status<T>(WfHost host,T data)
            => signal(this, host).Status(data);

        void Warn<T>(WfHost host, T content)
            => signal(this, host).Warn(content);

        void Error<T>(WfHost host, T data, [Caller] string caller = null, [File] string file = null, [Line]int? line = null)
            => signal(this).Error(data, EventFactory.originate("WorkflowError", caller, file, line));

        WfFileFlow EmittingFile(WfHost host, FS.FilePath dst)
        {
            signal(this,host).EmittingFile(dst);
            return Emissions.LogEmission(Flow(dst));
        }

        ExecToken EmittedFile(WfHost host, WfFileFlow flow, Count count)
        {
            var completed = Ran(flow);
            var counted = flow.WithCount(count).WithToken(completed);
            signal(this, host).EmittedFile(count, counted.Target);
            Emissions.LogEmission(counted);
            return completed;
        }

        WfExecFlow<string> Running(WfHost host, [Caller] string operation = null)
        {
            signal(this, host).Running(operation);
            return Flow(operation);
        }
    }
}