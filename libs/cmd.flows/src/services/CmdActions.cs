//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Correlates command names with command realizations
    /// </summary>
    public class CmdActions : ICmdActions
    {
        internal readonly Dictionary<string,CmdActionInvoker> Invokers;

        internal CmdActions(Dictionary<string,CmdActionInvoker> src)
        {
            Invokers = src;
        }

        public bool Find(string spec, out CmdActionInvoker runner)
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