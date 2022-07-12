//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    [ApiHost]
    public class Cmd
    {
        const NumericKind Closure = UnsignedInts;

        public static CmdActions actions<T>(T src)
        {
            var dst = dict<string,IActionRunner>();
            var methods = typeof(T).DeclaredInstanceMethods().Where(x => x.Tagged<CmdOpAttribute>());
            foreach(var m in methods)
            {
                var tag = m.Tag<CmdOpAttribute>().Require();
                dst.TryAdd(tag.CommandName, new ActionInvoker(tag.CommandName, src, m));
            }
            return new CmdActions(dst);
        }

        public static CmdActions join(ICmdActions[] src)
        {
            var dst = dict<string,IActionRunner>();
            foreach(var a in src)
                iter(a.Invokers,  a => dst.TryAdd(a.CmdName, a));
            return new CmdActions(dst);
        }

        public static CmdSource source<S>(S provider, IDispatcher src)
            where S : ICmdProvider, new()
        {
            var actions = src.Commands.Specs.Index().Sort().Index();
            var part = src.Controller;
            var count = actions.Count;
            var buffer = sys.alloc<Setting64>(count);
            var dst = Settings64.load(buffer);
            for(var i=0; i<actions.Count; i++)
                seek(buffer,i) = Settings.setting(string.Format("{0}[{1:D3}]", part, i), (asci64)actions[i]);
            return new CmdSource(provider.GetType().DisplayName(), dst);
        }

        public static CmdCatalog catalog<S>(S provider, IDispatcher dispatcher)
            where S : ICmdProvider, new()
        {
            ref readonly var defs = ref dispatcher.Commands.Defs;
            var count = defs.Count;
            var dst = alloc<ShellCmdDef>(count);
            for(var i=0; i<count; i++)
                seek(dst,i) = defs[i];
            var type = provider.GetType();
            return new CmdCatalog(type.Assembly.Id(), type.DisplayName(), dst);
        }

        public static CmdDispatcher dispatcher<T>(T svc, WfEventLogger log, ICmdActions actions)
            where T : ICmdService
                => Cmd.dispatcher(svc.GetType().DisplayName(), actions, log);

        public static void emit(ICmdSource src, FS.FilePath dst, WfEventLogger log)
        {
            log(Events.emittingFile(dst));
            var commands = src.Commands;
            using var writer = dst.AsciWriter();
            for(var i=0; i<src.Count; i++)
            {
                ref readonly var cmd = ref commands[i];
                var fmt = cmd.Format();
                log(Events.row(fmt));
                writer.WriteLine(fmt);
            }

            log(Events.emittedFile(dst, src.Count));
        }

        public static void emit(CmdCatalog src, FS.FilePath dst, WfEventLogger log)
        {
            log(Events.emittingFile(dst));
            using var writer = dst.AsciWriter();
            ref readonly var commands = ref src.ShellCommands;
            for(var i=0; i<commands.Count; i++)
            {
                ref readonly var def = ref commands[i];
                ref readonly var uri = ref def.Uri;
                var kvp = string.Format("{0}[{1:D3}]:{2}", src.Host, i, uri);
                log(Events.row(kvp));
                writer.WriteLine(kvp);
            }

            log(Events.emittedFile(dst, commands.Count));
        }

        public static Settings<Name,asci64> commands(IDispatcher src)
        {
            var actions = src.Commands.Specs.Index().Sort().Index();
            var part = src.Controller;
            var count = actions.Count;
            var dst = sys.alloc<Setting<Name,asci64>>(count);
            var settings = Settings.asci(dst);

            for(var i=0; i<actions.Count; i++)
                seek(dst,i) = Settings.asci(string.Format("{0}[{1:D3}]", part, i), (asci64)actions[i]);
            return Settings.asci(dst);
        }

        public static CmdLogger logger<T>(IEnvPaths paths, T id)
            where T : unmanaged
                => logger(paths, id.ToString());

        public static CmdLogger logger(IEnvPaths paths, string name)
            => new CmdLogger(paths.CmdLogRoot() + FS.file(name, FS.StatusLog));

        [MethodImpl(Inline)]
        public static DataFlow<Actor,S,T> flow<S,T>(Tool tool, S src, T dst)
            => new DataFlow<Actor,S,T>(FlowId.identify(tool,src,dst), tool,src,dst);

        [MethodImpl(Inline)]
        public static FileFlow flow(in CmdFlow src)
            => new FileFlow(flow(src.Tool, src.SourcePath.ToUri(), src.TargetPath.ToUri()));

        public static ReadOnlySpan<CmdFlow> flows(ReadOnlySpan<TextLine> src)
        {
            var count = src.Length;
            var counter = 0u;
            var dst = span<CmdFlow>(count);
            for(var i=0; i<count; i++)
            {
                ref readonly var line = ref skip(src,i);
                if(line.IsEmpty)
                    continue;

                var content = line.Content;
                var j = text.index(content, Chars.Colon);
                if(j >= 0)
                {
                    Tool tool = text.left(content, j);
                    var flow = Fenced.unfence(text.right(content,j), Fenced.Bracketed);

                    j = text.index(flow, "--");
                    if(j == NotFound)
                        j = text.index(flow, "->");

                    if(j>=0)
                    {
                        var a = text.left(flow,j).Trim();
                        var b = text.right(flow,j+2).Trim();
                        if(nonempty(a) && nonempty(b))
                            seek(dst,counter++) = new CmdFlow(tool, FS.path(a), FS.path(b));
                    }
                }
            }

            return slice(dst,0,counter);
        }

        public static CmdDispatcher dispatcher(asci32 provider, ICmdActions actions, WfEventLogger log)
            => new CmdDispatcher(provider, actions, log);

        public static Index<ICmdReactor> reactors(IWfRuntime wf)
        {
            var types = wf.Components.Types();
            var reactors = types.Concrete().Tagged<CmdReactorAttribute>().Select(t => (ICmdReactor)Activator.CreateInstance(t));
            iter(reactors, r => r.Init(wf));
            return reactors;
        }

        public static CmdDispatcher dispatcher<T>(T svc, WfEventLogger log,  Index<ICmdProvider> providers)
        {
            var dst = dict<string,ActionInvoker>();
            var _dst = bag<ICmdActions>();
            _dst.Add(actions(svc));
            iter(providers, x => _dst.Add(x.Actions));
            return dispatcher(svc.GetType().DisplayName(), Cmd.join(_dst.ToArray()), log);
        }

        [Op]
        public static ActionInvoker invoker(string name, object host, MethodInfo method)
            => new ActionInvoker(name,host,method);

        [Op]
        public static Index<ActionInvoker> invokers(object host)
        {
            var methods = host.GetType().Methods().Tagged<CmdOpAttribute>();
            var buffer = alloc<ActionInvoker>(methods.Length);
            actions(host, methods,buffer);
            return buffer;
        }

        static void actions(object host, ReadOnlySpan<MethodInfo> src, Span<ActionInvoker> dst)
        {
            var count = src.Length;
            for(var i=0; i<count; i++)
            {
                ref readonly var method = ref skip(src,i);
                var tag = method.Tag<CmdOpAttribute>().Require();
                seek(dst,i) = invoker(tag.CommandName, host, method);
            }
        }
    }
}