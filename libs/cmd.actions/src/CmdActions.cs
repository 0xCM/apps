//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    /// <summary>
    /// Correlates command names with command realizations
    /// </summary>
    public class CmdActions
    {
        public static Index<ICmdReactor> reactors(IWfRuntime wf)
        {
            var types = wf.Components.Types();
            var reactors = types.Concrete().Tagged<CmdReactorAttribute>().Select(t => (ICmdReactor)Activator.CreateInstance(t));
            iter(reactors, r => r.Init(wf));
            return reactors;
        }

        public static CmdDispatch dispatch(IWfRuntime wf, params ICmdReactor[] reactors)
            => CmdDispatch.create(wf,reactors);

        public static CmdActionDispatcher dispatcher(CmdActions actions, Func<string,CmdArgs,Outcome> fallback = null)
            => new CmdActionDispatcher(actions, fallback);

        [Op]
        public static CmdActionInvoker invoker(string name, object host, MethodInfo method)
            => new CmdActionInvoker(name,host,method);

        static void actions(object host, ReadOnlySpan<MethodInfo> src, Span<CmdActionInvoker> dst)
        {
            var count = src.Length;
            for(var i=0; i<count; i++)
            {
                ref readonly var method = ref skip(src,i);
                var tag = method.Tag<CmdOpAttribute>().Require();
                seek(dst,i) = invoker(tag.CommandName, host, method);
            }
        }

        public static CmdActions discover<T>(T src)
        {
            var dst = dict<string,CmdActionInvoker>();
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
            var dst = dict<string,CmdActionInvoker>();
            foreach(var a in src)
                iter(a.Data,  a => dst.TryAdd(a.Key,a.Value));
            return new CmdActions(dst);
        }

        readonly Dictionary<string,CmdActionInvoker> Data;

        CmdActions(Dictionary<string,CmdActionInvoker> src)
        {
            Data = src;
        }

        public bool Find(string spec, out CmdActionInvoker runner)
        {
            return Data.TryGetValue(spec, out runner);
        }

        public IEnumerable<string> Specs
        {
            [MethodImpl(Inline)]
            get => Data.Keys;
        }
    }
}