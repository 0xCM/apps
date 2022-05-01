//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedRules;

    partial class XedMachine
    {
        [MethodImpl(Inline)]
        TableSpec RuleTable(in RuleSig sig)
        {
            var dst = TableSpec.Empty;
            ref readonly var specs = ref RuleTables.Specs();
            specs.Find(sig,out dst);
            return dst;
        }

        [MethodImpl(Inline)]
        public bool IsNontermOp(byte index)
            => Op(index).NonTerm.IsNonEmpty;

        [MethodImpl(Inline)]
        public ref readonly InstOpDetail Op(byte index)
            => ref Ops[index];

        [MethodImpl(Inline)]
        public void Transition(InstPattern src, Action f)
        {
            LoadPattern() = src;
            f();
        }

        [MethodImpl(Inline)]
        public void Transition(Index<InstPattern> seq, Action f)
        {
            for(var i=0; i<seq.Count; i++)
            {
                LoadPattern() = seq[i];
                f();
            }
        }
    }
}