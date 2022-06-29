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
    public class CmdActions : ICmdActions
    {
        public static CmdActions discover<T>(T src)
        {
            var dst = dict<string,ICmdActionInvoker>();
            var methods = typeof(T).DeclaredInstanceMethods().Where(x => x.Tagged<CmdOpAttribute>());
            foreach(var m in methods)
            {
                var tag = m.Tag<CmdOpAttribute>().Require();
                dst.TryAdd(tag.CommandName, new ActionInvoker(tag.CommandName, src, m));
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

        readonly Dictionary<string,ICmdActionInvoker> Invokers;

        CmdActions(Dictionary<string,ICmdActionInvoker> src)
        {
            Invokers = src;
        }

        public bool Find(string spec, out ICmdActionInvoker runner)
        {
            return Invokers.TryGetValue(spec, out runner);
        }

        public IEnumerable<string> Specs
        {
            [MethodImpl(Inline)]
            get => Invokers.Keys;
        }
    }
}