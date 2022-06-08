//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    public readonly struct WfAppLoader
    {
        public static IWfRuntime load(string logname = EmptyString, bool libonly = true)
            => create(ApiRuntimeLoader.parts(controller(), libonly), array<string>(), logname);

        public static IWfRuntime load(string[] args, string logname = EmptyString, bool libonly = true)
            => create(ApiRuntimeLoader.parts(controller(), args, libonly), args, logname);

        public static IWfRuntime load(PartId[] parts, string[] args, string logname = EmptyString)
            => create(ApiRuntimeLoader.parts(parts, true), args, logname);

        public static IWfRuntime load(IApiParts parts, string[] args, string logname = EmptyString)
            => create(parts, args, logname);

        static IWfRuntime create(IApiParts parts, string[] args, string logname = EmptyString)
        {
            term.inform(InitializingRuntime.Format(now()));
            var clock = Time.counter(true);
            var control = controller();
            var id = control.Id();
            var paths = AppPaths.create();
            var dst = new WfInit();
            dst.Env = Env.load().Data;
            dst.Ct = PartToken.create(id);
            dst.Tokens = TokenDispenser.create();
            dst.Settings = JsonSettings.load(control);
            dst.Control = control;
            dst.ControlId = id;
            dst.LogConfig = Loggers.configure(id, paths.Root, logname);
            dst.ApiParts = parts;
            dst.Args = args;
            dst.Paths = AppPaths.create();
            dst.AppName = id.PartName();
            dst.EventBroker = WfBroker.create(dst.LogConfig);
            dst.Host = new WfHost(typeof(WfRuntime), typeof(WfRuntime));
            dst.EmissionLog = Loggers.emission(dst.LogConfig.LogId, dst.Env);
            var wf = new WfRuntime(dst);
            term.inform(AppMsg.status(InitializedRuntime.Format(now(), clock.Elapsed())));
            return wf;
        }

        static MsgPattern<Timestamp> InitializingRuntime => "Initializing runtime at {0}";

        static MsgPattern<Timestamp,Duration> InitializedRuntime => "Initialized runtime at {0} in {1}";
    }
}