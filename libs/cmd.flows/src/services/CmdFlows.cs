//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    public class CmdFlows : WfSvc<CmdFlows>, ICmdRouter
    {
        ICmdRouter Router;

        public static ICmd reify(Type src)
            => (ICmd)Activator.CreateInstance(src);

        [Op]
        public static ICmd[] reify(Assembly src)
            => CmdTypes.tagged(src).Select(reify);

        [MethodImpl(Inline)]
        public static DataFlow<Actor,S,T> flow<S,T>(Tool tool, S src, T dst)
            => new DataFlow<Actor,S,T>(FlowId.identify(tool,src,dst), tool,src,dst);

        [MethodImpl(Inline)]
        public static FileFlow flow(in CmdFlow src)
            => new FileFlow(flow(src.Tool, src.SourcePath.ToUri(), src.TargetPath.ToUri()));

        public static CmdActionDispatcher dispatcher(CmdActions actions, Func<string,CmdArgs,Outcome> fallback = null)
            => new CmdActionDispatcher(actions, fallback);

        public static CmdActionInvoker invoker(string name, object host, MethodInfo method)
            => new CmdActionInvoker(name,host,method);

        public static CmdActionDispatcher dispatcher<T>(T service, Index<ICmdProvider> providers)
        {
            var dst = dict<string,CmdActionInvoker>();
            var _dst = bag<CmdActions>();
            _dst.Add(actions(service));
            iter(providers, x => _dst.Add(x.Actions));
            return dispatcher(join(_dst.ToArray()));
        }

        public static CmdActions actions<T>(T src)
        {
            var dst = dict<string,ICmdActionInvoker>();
            var methods = typeof(T).DeclaredInstanceMethods().Where(x => x.Tagged<CmdOpAttribute>());
            foreach(var m in methods)
            {
                var tag = m.Tag<CmdOpAttribute>().Require();
                dst.TryAdd(tag.CommandName, new CmdActionInvoker(tag.CommandName, src, m));
            }
            return new CmdActions(dst);
        }

        public static CmdActions join(CmdActions[] src)
        {
            var dst = dict<string,ICmdActionInvoker>();
            foreach(var a in src)
                iter(a.Invokers,  a => dst.TryAdd(a.Key,a.Value));
            return new CmdActions(dst);
        }

        public static Index<ICmdReactor> reactors(IWfRuntime wf)
        {
            var types = wf.Components.Types();
            var reactors = types.Concrete().Tagged<CmdReactorAttribute>().Select(t => (ICmdReactor)Activator.CreateInstance(t));
            iter(reactors, r => r.Init(wf));
            return reactors;
        }

        public static CmdFlows create(IWfRuntime wf, ICmdReactor[] reactors)
        {
            var router = new WfCmdRouter(wf);
            router.Enlist(reactors);
            var dst = create(wf);
            dst.Router = router;
            return dst;
        }

        public Task<CmdResult> Dispatch<T>(T cmd)
            where T : struct, ICmd
                => Task.Factory.StartNew(() => Router.Dispatch(cmd));

        public CmdResult Run<T>(T cmd)
            where T : struct, ICmd
                => Dispatch(cmd).Result;

        void ICmdRouter.Enlist(Index<ICmdReactor> reactors)
            => Router.Enlist(reactors);

        ReadOnlySpan<CmdId> ICmdRouter.SupportedCommands
            => Router.SupportedCommands;

        CmdResult ICmdRouter.Dispatch(ICmd cmd)
            => Router.Dispatch(cmd);

        CmdResult ICmdRouter.Dispatch(ICmd cmd, string msg)
            => Router.Dispatch(cmd, msg);

        public static ReadOnlySpan<CmdFlow> parse(ReadOnlySpan<TextLine> src)
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
    }
}