//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    public class ApiRuntime
    {
        public static FS.FolderPath home(Assembly control)
            => FS.path(control.Location).FolderPath;

        public static IWfRuntime create()
            => create(parts(), array<string>(), EmptyString);

        public static IWfRuntime create(string[] args)
            => create(parts(controller(), args), args, EmptyString);

        public static IWfRuntime create(PartId[] ids, string[] args)
            => create(parts(controller(), ids, true), args, EmptyString);

        public static IWfRuntime create(PartId[] ids, string[] args, string log)
            => create(parts(controller(), ids, true), args, log);

        public static IWfRuntime create(IApiParts parts, string[] args)
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
            dst.LogConfig = Loggers.configure();
            dst.ApiParts = parts;
            dst.Args = args;
            dst.Paths = AppPaths.create();
            dst.AppName = id.PartName();
            dst.EventBroker = WfBroker.create(dst.LogConfig);
            dst.Host = new WfHost(typeof(WfRuntime));
            dst.EmissionLog = Loggers.emission(control, dst.Env.Logs);
            //dst.EmissionLog = Loggers.emission(dst.LogConfig.LogId, dst.Env);
            var wf = new WfRuntime(dst);
            term.inform(AppMsg.status(InitializedRuntime.Format(now(), clock.Elapsed())));
            return wf;
        }

        public static Assembly[] assemblies(bool justParts, bool libonly)
            => assemblies(location(), justParts, libonly);

        public static Index<Assembly> assemblies(FS.FolderPath dir, PartId[] parts)
        {
            var dst = list<Assembly>();
            var candidates = dir.TopFiles;
            foreach(var path in candidates)
            {
                if((path.Is(FS.Dll) || path.Is(FS.Exe)) && FS.managed(path))
                {
                    foreach(var id in parts)
                    {
                        var match = dir + FS.component(id, path.Ext);
                        if(match.Equals(path))
                            dst.Add(Assembly.LoadFrom(match.Name));
                    }
                }
            }

            return dst.ToArray();
        }

        public static IApiParts parts()
            => parts(controller(), Environment.GetCommandLineArgs());

        public static IApiParts parts(Assembly control)
            => new ApiParts(control, home(control), managed(home(control), true) , array(control.Id()));

        public static IApiParts parts(string[] args)
            => parts(controller(), args);

        public static IApiParts parts(Assembly control, string[] args)
        {
            var dir = home(control);
            var sources = managed(dir, true);

            if(args.Length == 0)
                return new ApiParts(control, dir, sources, assemblies(dir, true, true).Select(x => x.Id()));
            var ids = parts(args, true);
            if(ids.Length != 0)
                return new ApiParts(control, dir, sources, array<PartId>(control.Id()));
            else
                return new ApiParts(control, dir, sources, ids);
        }

        const PartId FirstShell = PartId.CgShell;

        [Op]
        public static Index<PartId> parts(ReadOnlySpan<string> src, bool libonly)
        {
            var count = src.Length;
            if(count == 0)
                return sys.empty<PartId>();

            var symbols = Symbols.index<PartId>();
            var dst = span<PartId>(count);
            var counter = 0u;
            for(var i=0; i<count; i++)
            {
                ref readonly var name = ref skip(src,i);
                if(symbols.Lookup(name, out var sym))
                {
                    if(libonly && sym.Kind >= FirstShell)
                        continue;
                    seek(dst, counter++) = sym.Kind;
                }
            }
            return slice(dst, 0, counter).ToArray();
        }

        [Op]
        public static IApiParts parts(Assembly control, PartId[] ids, bool libonly)
        {
            var folder = home(control);
            var sources = managed(folder, libonly);
            if(ids.Length != 0)
               return new ApiParts(control, folder, sources, ids);
            else
            {
                return new ApiParts(control, folder, sources, ApiRuntimeLoader.catalog(sources));
            }
        }

        public static Assembly[] assemblies(FS.FilePath[] src)
            => src.Where(x => FS.managed(x)).Map(assembly).Where(x => x.IsSome()).Select(x => x.Value);

        public static Assembly[] assemblies(FS.FolderPath dir, bool justParts, bool libonly)
        {
            var dst = list<Assembly>();
            var candidates = managed(dir, libonly);
            foreach(var path in candidates)
            {
                var component = Assembly.LoadFrom(path.Name);
                if(justParts)
                {
                    if(component.Id() != 0)
                        dst.Add(component);
                }
                else
                    dst.Add(component);
            }

            return dst.ToArray();
        }

        static Option<Assembly> assembly(FS.FilePath src)
        {
            try
            {
                return Assembly.LoadFrom(src.Name);
            }
            catch(Exception e)
            {
                term.warn(string.Format("Unable to load {0}: {1}", src.ToUri(), e.Message));
                return default;
            }
        }

        static FolderFiles managed(FS.FolderPath dir, bool libonly)
        {
            var src = dir.Exclude("System.Private.CoreLib");
            if(libonly)
                src = src.Where(x => !x.Format().EndsWith(".exe"));
            return new FolderFiles(dir, src.Where(f => FS.managed(f)));
        }


        static FS.FolderPath location()
            => FS.path(controller().Location).FolderPath;


        internal static IWfRuntime create(IApiParts parts, string[] args, string logname = EmptyString)
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
            dst.LogConfig = Loggers.configure(logname);
            dst.ApiParts = parts;
            dst.Args = args;
            dst.Paths = AppPaths.create();
            dst.AppName = id.PartName();
            dst.EventBroker = WfBroker.create(dst.LogConfig);
            dst.Host = new WfHost(typeof(WfRuntime));
            dst.EmissionLog = Loggers.emission(control, dst.Env.Logs, core.timestamp());
            var wf = new WfRuntime(dst);
            term.inform(AppMsg.status(InitializedRuntime.Format(now(), clock.Elapsed())));
            return wf;
        }

        static MsgPattern<Timestamp> InitializingRuntime => "Initializing runtime at {0}";

        static MsgPattern<Timestamp,Duration> InitializedRuntime => "Initialized runtime at {0} in {1}";
    }
}