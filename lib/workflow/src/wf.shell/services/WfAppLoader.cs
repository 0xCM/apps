//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Reflection;

    using static Root;
    using static core;

    public readonly struct WfAppLoader
    {
        [Op]
        public static Index<ICmdReactor> reactors(IWfRuntime wf)
        {
            var types = wf.Components.Types();
            var reactors = types.Concrete().Tagged<CmdReactorAttribute>().Select(t => (ICmdReactor)Activator.CreateInstance(t));
            iter(reactors, r => r.Init(wf));
            return reactors;
        }

        public static IWfRuntime load(string logname = EmptyString)
            => create(ApiRuntimeLoader.parts(controller()), array<string>(), logname);

        public static IWfRuntime load(string[] args, string logname = EmptyString)
            => create(ApiRuntimeLoader.parts(controller(), args), args, logname);

        public static IWfRuntime load(PartId[] parts, string[] args, string logname = EmptyString)
            => create(ApiRuntimeLoader.parts(parts), args, logname);

        public static IWfRuntime load(IApiParts parts, string[] args, string logname = EmptyString)
            => create(parts, args, logname);

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

        static IWfRuntime create(IApiParts parts, string[] args, string logname = EmptyString)
        {
            term.inform(InitializingRuntime.Format(now()));
            var clock = Time.counter(true);
            var verbose = true;
            var control = controller();
            var ctx = context(control, parts, args);
            if(verbose)
                term.inform(AppMsg.status(TextProp.define("Parts", text.embrace(text.join(RP.CommaJoin, ctx.PartIdentities)))));

            var init = new WfInit(ctx, Loggers.configure(ctx.ControlId, ctx.Paths.Root, logname), ctx.PartIdentities);
            var wf = new WfRuntime(init);
            var react = reactors(wf);
            if(react.IsNonEmpty)
                wf.Router.Enlist(react);

            term.inform(AppMsg.status(InitializedRuntime.Format(now(), clock.Elapsed())));

            return wf;
        }

        static MsgPattern<Timestamp> InitializingRuntime => "Initializing runtime at {0}";

        static MsgPattern<Timestamp,Duration> InitializedRuntime => "Initialized runtime at {0} in {1}";
    }
}