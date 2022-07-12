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
        internal readonly Dictionary<string,ICmdActionInvoker> Lookup;

        readonly ReadOnlySeq<ShellCmdDef> CmdDefs;

        internal CmdActions(Dictionary<string,ICmdActionInvoker> src)
        {
            Lookup = src;
            CmdDefs = src.Values.Select(x => x.Def).ToSeq();
        }

        public bool Find(string spec, out ICmdActionInvoker runner)
            => Lookup.TryGetValue(spec, out runner);

        public IEnumerable<string> Specs
        {
            [MethodImpl(Inline)]
            get => Lookup.Keys;
        }

        public ICollection<ICmdActionInvoker> Invokers
            => Lookup.Values;

        public ref readonly ReadOnlySeq<ShellCmdDef> Defs
        {
            [MethodImpl(Inline)]
            get => ref CmdDefs;
        }
    }
}