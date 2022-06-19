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