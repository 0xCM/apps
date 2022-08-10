//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    public class ApiRuntime
    {
        // public static IWfRuntime create()
        //     => create(parts(), array<string>(), EmptyString);

        public static IWfRuntime create(string[] args)
            => create(parts(controller(), args), args, EmptyString);

        // public static IWfRuntime create(PartId[] src)
        //     => create(parts(controller(), src, true), sys.empty<string>(), EmptyString);

        public static IWfRuntime create(IApiParts parts, string[] args)
        {
            term.inform(InitializingRuntime.Format(now()));
            var clock = Time.counter(true);
            var control = controller();
            var id = control.Id();
            var dst = new WfInit();
            dst.Ct = PartToken.create(id);
            dst.Tokens = TokenDispenser.create();
            dst.Settings = JsonSettings.load(control);
            dst.Control = control;
            dst.ControlId = id;
            dst.LogConfig = Loggers.configure();
            dst.ApiParts = parts;
            dst.Args = args;
            dst.AppName = id.PartName();
            dst.EventBroker = Events.broker(dst.LogConfig);
            dst.Host = new WfHost(typeof(WfRuntime));
            dst.EmissionLog = Loggers.emission(control);
            var wf = new WfRuntime(dst);
            term.inform(AppMsg.status(InitializedRuntime.Format(now(), clock.Elapsed())));
            return wf;
        }

        public static IApiParts parts()
            => parts(controller(), Environment.GetCommandLineArgs());

        static FS.FolderPath home(Assembly control)
            => FS.path(control.Location).FolderPath;

        public static IApiParts parts(Assembly control, string[] args)
        {
            var dir = home(control);
            var sources = managed(dir);

            if(args.Length == 0)
                return new ApiParts(control, dir, sources, assemblies(dir, true).Select(x => x.Id()));
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

        // [Op]
        // public static IApiParts parts(Assembly control, PartId[] ids, bool libonly)
        // {
        //     var folder = home(control);
        //     var sources = managed(folder);
        //     if(ids.Length != 0)
        //        return new ApiParts(control, folder, sources, ids);
        //     else
        //     {
        //         return new ApiParts(control, folder, sources, ApiLoader.catalog(sources));
        //     }
        // }

        public static Assembly[] assemblies(FS.FolderPath dir, bool justParts)
        {
            var dst = list<Assembly>();
            var candidates = managed(dir);
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

        static FolderFiles managed(FS.FolderPath src, bool libonly = true)
        {            
            var candidates = src.Files(FileKind.Dll);
            var dst = list<FS.FilePath>();
            foreach(var file in candidates)
            {
                if(file.FileName.Contains("System.Private.CoreLib"))
                    continue;

                if(FS.managed(file))
                    dst.Add(file);
            }

            return new FolderFiles(src, dst.Array());
        }

        static IWfRuntime create(IApiParts parts, string[] args, string logname = EmptyString)
        {
            term.inform(InitializingRuntime.Format(now()));
            var clock = Time.counter(true);
            var control = controller();
            var id = control.Id();
            var dst = new WfInit();
            dst.Ct = PartToken.create(id);
            dst.Tokens = TokenDispenser.create();
            dst.Settings = JsonSettings.load(control);
            dst.Control = control;
            dst.ControlId = id;
            dst.LogConfig = Loggers.configure(logname);
            dst.ApiParts = parts;
            dst.Args = args;
            dst.AppName = id.PartName();
            dst.EventBroker = Events.broker(dst.LogConfig);
            dst.Host = new WfHost(typeof(WfRuntime));
            dst.EmissionLog = Loggers.emission(control, core.timestamp());
            var wf = new WfRuntime(dst);
            term.inform(AppMsg.status(InitializedRuntime.Format(now(), clock.Elapsed())));
            return wf;
        }

        static MsgPattern<Timestamp> InitializingRuntime => "Initializing runtime at {0}";

        static MsgPattern<Timestamp,Duration> InitializedRuntime => "Initialized runtime at {0} in {1}";
    }
}