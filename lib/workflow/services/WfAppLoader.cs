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
            var verbose = true;
            var control = controller();
            var ctx = context(control, parts, args);
            var wf = new WfRuntime(new WfInit(ctx, Loggers.configure(ctx.ControlId, ctx.Paths.Root, logname), ctx.PartIdentities));
            term.inform(AppMsg.status(InitializedRuntime.Format(now(), clock.Elapsed())));
            return wf;
        }

        static WfContext context(Assembly control, IApiParts parts, string[] args)
        {
            var ctx = new WfContext();
            ctx.Controller = control;
            ctx.ApiParts = parts;
            ctx.Args = args;
            ctx.ControlId = control.Id();
            ctx.Paths = AppPaths.create();
            ctx.Settings = JsonSettings.Load(ctx.Paths.Root + FS.folder("settings") + FS.file(ctx.ControlId.Format(), FS.JsonConfig));
            ctx.PartIdentities = ctx.ApiParts.Catalog.PartIdentities;
            return ctx;
        }

        static MsgPattern<Timestamp> InitializingRuntime => "Initializing runtime at {0}";

        static MsgPattern<Timestamp,Duration> InitializedRuntime => "Initialized runtime at {0} in {1}";
    }
}