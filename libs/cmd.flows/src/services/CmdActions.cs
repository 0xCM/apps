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
        internal readonly Dictionary<string,ICmdActionInvoker> Invokers;

        internal CmdActions(Dictionary<string,ICmdActionInvoker> src)
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