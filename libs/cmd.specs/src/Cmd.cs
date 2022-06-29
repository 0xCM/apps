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
                    ToolId tool = text.left(content, j);
                    var flow = text.unfence(text.right(content,j), RenderFence.Bracketed);

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

        public static ActionDispatcher dispatcher<T>(T svc, CmdActions actions)
            where T : ICmdService
                => dispatcher(actions);

        public static ActionDispatcher dispatcher(CmdActions actions, Func<string,CmdArgs,Outcome> fallback = null)
            => new ActionDispatcher(actions, fallback);

        public static Index<ICmdReactor> reactors(IWfRuntime wf)
        {
            var types = wf.Components.Types();
            var reactors = types.Concrete().Tagged<CmdReactorAttribute>().Select(t => (ICmdReactor)Activator.CreateInstance(t));
            iter(reactors, r => r.Init(wf));
            return reactors;
        }

        public static ActionDispatcher dispatcher<T>(T svc, Index<ICmdProvider> providers)
        {
            var dst = dict<string,ActionInvoker>();
            var _dst = bag<CmdActions>();
            _dst.Add(CmdActions.discover(svc));
            iter(providers, x => _dst.Add(x.Actions));
            return dispatcher(CmdActions.join(_dst.ToArray()));
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