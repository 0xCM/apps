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

        [MethodImpl(Inline), Op]
        public static CmdVarInfo varinfo(Name name, TextBlock purpose)
            => new (name,purpose);

        public static string join(CmdArgs args)
        {
            var dst = text.emitter();
            for(var i=0; i<args.Count; i++)
            {
                if(i != 0)
                    dst.Append(Chars.Space);
                dst.Append(args[i].Value);
            }

            return dst.Emit();
        }

        public static CmdLine cmd(string spec)
            => string.Format("cmd.exe /c {0}", spec);

        public static CmdLine pwsh(string spec)
            => string.Format("pwsh.exe {0}", spec);

        public static CmdActions actions<T>(T src)
        {
            var dst = dict<string,IActionRunner>();
            var methods = typeof(T).DeclaredInstanceMethods().Where(x => x.Tagged<CmdOpAttribute>());
            foreach(var m in methods)
            {
                var tag = m.Tag<CmdOpAttribute>().Require();
                dst.TryAdd(tag.CommandName, new ActionRunner(tag.CommandName, src, m));
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
            var specs = src.Commands.Specs.Index().Sort().Index();
            var part = src.Controller;
            var count = specs.Count;
            var buffer = sys.alloc<Setting64>(count);
            var dst = Settings.from(buffer);
            for(var i=0; i<specs.Count; i++)
                seek(buffer,i) = SettingIndex.setting(string.Format("{0}[{1:D3}]", part, i), (asci64)specs[i]);
            return new CmdSource(provider.Name, dst);
        }

        public static CmdCatalog catalog(IDispatcher src)
        {
            ref readonly var defs = ref src.Commands.Defs;
            var count = defs.Count;
            var dst = alloc<CmdUri>(count);
            for(var i=0; i<count; i++)
                seek(dst,i) = defs[i].Uri;
            return new CmdCatalog(dst);
        }

        public static CmdDispatcher dispatcher<T>(T svc, WfEventLogger log, ICmdActions actions)
            where T : ICmdService
                => Cmd.dispatcher(svc.GetType().DisplayName(), actions, log);

        public static void emit(ICmdSource src, FS.FilePath dst, WfEventLogger log)
        {
            log(Events.emittingFile(src.GetType(),dst));
            var commands = src.Commands;
            using var writer = dst.AsciWriter();
            for(var i=0; i<src.Count; i++)
            {
                ref readonly var cmd = ref commands[i];
                var fmt = cmd.Format();
                log(Events.row(fmt));
                writer.WriteLine(fmt);
            }

            log(Events.emittedFile(src.GetType(), dst, src.Count));
        }

        public static void emit(CmdCatalog src, FS.FilePath dst, IWfEventTarget log)
        {
            var data = src.Entries;
            iter(data, x => log.Deposit(Events.row(x.Uri.Name)));
            Tables.emit(log, data.View, dst);
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
            var dst = dict<string,ActionRunner>();
            var _dst = bag<ICmdActions>();
            _dst.Add(actions(svc));
            iter(providers, x => _dst.Add(x.Actions));
            return dispatcher(svc.GetType().DisplayName(), Cmd.join(_dst.ToArray()), log);
        }

        [Op]
        public static ActionRunner invoker(string name, object host, MethodInfo method)
            => new ActionRunner(name,host,method);

        [Op]
        public static Index<ActionRunner> invokers(object host)
        {
            var methods = host.GetType().Methods().Tagged<CmdOpAttribute>();
            var buffer = alloc<ActionRunner>(methods.Length);
            actions(host, methods,buffer);
            return buffer;
        }

        static void actions(object host, ReadOnlySpan<MethodInfo> src, Span<ActionRunner> dst)
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