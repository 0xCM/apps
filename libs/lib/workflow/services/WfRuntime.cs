//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [ApiHost]
    public partial class WfRuntime : IWfRuntime
    {
        public IApiParts ApiParts {get;}

        public IEventBroker EventBroker {get;}

        public string[] Args {get;}

        public IFileArchive AppPaths {get;}

        public IJsonSettings Settings {get;}

        public IApiCatalog ApiCatalog {get;}

        public string AppName {get;}

        public WfController Controller {get;}

        public WfHost Host {get; private set;}

        public LogLevel Verbosity {get; private set;}

        public IWfEmissionLog Emissions {get; private set;}

        TokenDispenser Tokens;

        [MethodImpl(Inline)]
        public WfRuntime(WfInit init)
        {
            Tokens = init.Tokens;
            EventBroker = init.EventBroker;
            Host = init.Host;
            Verbosity = LogLevel.Status;
            Args = init.Args;
            Settings = init.Settings;
            ApiParts = init.ApiParts;
            ApiCatalog = init.ApiParts.Catalog;
            Controller = init.Control;
            AppName = init.AppName.Format();
            Emissions = init.EmissionLog;
        }

        public IWfEventSink EventSink
        {
            [MethodImpl(Inline)]
            get => EventBroker.Sink;
        }

        public void RedirectEmissions(IWfEmissionLog dst)
        {
            Emissions.Close();
            Emissions = dst;
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
            Emissions?.Dispose();
        }
        string ITextual.Format()
            => AppName;
    }
}