//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [ApiHost]
    public partial class WfRuntime : IWfRuntime
    {
        public IWfContext Context {get;}

        public PartId Id {get;}

        public IApiParts ApiParts {get;}

        public IEventBroker EventBroker {get;}

        public string[] Args {get;}

        public IAppPaths AppPaths {get;}

        public IJsonSettings Settings {get;}

        public PartToken Ct {get;}

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
            Ct = PartToken.create(config.ControlId);
            EventBroker = WfBroker.create(config.LogConfig);
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
            Emissions = Loggers.emission(config.LogConfig.LogId, Env);
        }

        public IEventSink EventSink
        {
            [MethodImpl(Inline)]
            get => EventBroker.Sink;
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

        [MethodImpl(Inline)]
        public ExecToken NextExecToken()
            => Tokens.Open();

        public ExecToken Completed(WfExecFlow src)
            => Tokens.Close(src.Token);

        public ExecToken Completed<T>(WfExecFlow<T> src)
            => Tokens.Close(src.Token);


        public void Dispose()
        {
            EventBroker.Dispose();
            //EventSink.Dispose();
            Emissions?.Dispose();
        }
        string ITextual.Format()
            => AppName;
    }
}