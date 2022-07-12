//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class CmdActions : ICmdActions
    {
        internal readonly Dictionary<string,IActionRunner> Lookup;

        readonly ReadOnlySeq<ShellCmdDef> CmdDefs;

        internal CmdActions(Dictionary<string,IActionRunner> src)
        {
            Lookup = src;
            CmdDefs = src.Values.Select(x => x.Def).ToSeq();
        }

        public bool Find(string spec, out IActionRunner runner)
            => Lookup.TryGetValue(spec, out runner);

        public IEnumerable<string> Specs
        {
            [MethodImpl(Inline)]
            get => Lookup.Keys;
        }

        public ICollection<IActionRunner> Invokers
            => Lookup.Values;

        public ref readonly ReadOnlySeq<ShellCmdDef> Defs
        {
            [MethodImpl(Inline)]
            get => ref CmdDefs;
        }
    }
}