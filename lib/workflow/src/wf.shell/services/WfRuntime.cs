//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    [ApiHost]
    public partial class WfRuntime : IWfRuntime
    {
        public IWfContext Context {get;}

        public PartId Id {get;}

        public IApiParts ApiParts {get;}

        public IEventSink EventSink {get;}

        public IEventBroker EventBroker {get;}

        public ICmdRouter Router {get;}

        public string[] Args {get;}

        public IAppPaths AppPaths {get;}

        public IJsonSettings Settings {get;}

        public CorrelationToken Ct {get;}

        public IApiCatalog ApiCatalog {get;}

        public string AppName {get;}

        public WfController Controller {get;}

        public IPolySource Polysource {get; private set;}

        public WfHost Host {get; private set;}

        public LogLevel Verbosity {get; private set;}

        public EnvData Env {get;}

        public IWfEmissionLog Emissions {get; private set;}

        TokenDispenser Tokens;

        [MethodImpl(Inline)]
        public WfRuntime(IWfInit config)
        {
            Tokens = TokenDispenser.create();
            Env = Z0.Env.load().Data;
            Context = config.Shell;
            Id = config.ControlId;
            Ct = CorrelationToken.create(config.ControlId);
            EventSink = Loggers.events(config.LogConfig);
            EventBroker = new WfBroker(EventSink, Ct);
            Host = new WfHost(typeof(WfRuntime), typeof(WfRuntime));
            Polysource = default;
            Verbosity = LogLevel.Status;
            AppPaths = config.Shell.Paths;
            Args = config.Shell.Args;
            Settings = config.Shell.Settings;
            ApiParts = config.ApiParts;
            ApiCatalog = config.ApiParts.Catalog;
            Controller = config.Control;
            AppName = config.Shell.AppName;
            Router = new WfCmdRouter(this);
            Emissions = WfEmissionLog.create(config.Shell.AppName, Env);
        }

        public void RedirectEmissions(IWfEmissionLog dst)
        {
            Emissions?.Dispose();
            Emissions = dst;
        }

        public IWfRuntime WithSource(IPolySource random)
        {
            Polysource = random;
            return this;
        }

        public ExecToken Ran(WfExecFlow src)
        {
            var token = Tokens.Close(src.Token);
            return token;
        }

        public ExecToken Ran<T>(WfExecFlow<T> src)
        {
            var token = Tokens.Close(src.Token);
            WfEvents.signal(this).Ran(src.Data);
            return token;
        }

        public ExecToken Ran<T,D>(WfExecFlow<T> src, D data)
        {
            var token = Tokens.Close(src.Token);
            WfEvents.signal(this).Ran(data);
            return token;
        }

        [MethodImpl(Inline)]
        public ExecToken NextExecToken()
            => Tokens.Open();


        public void Dispose()
        {
            EventBroker.Dispose();
            EventSink.Dispose();
            Emissions?.Dispose();
        }
        string ITextual.Format()
            => AppName;
    }
}