//-----------------------------------------------------------------------------
// Copyright   : Intel Corporation, 2020
// License     : Apache
// Source      : all-state.txt
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedModels;

    public class XedRuleState
    {
        MachineState Machine;

        OpState Ops;

        Index<NonterminalKind, Index<XedRegId>> Regs;

        Symbols<NonterminalKind> Nonterminals;

        public XedRuleState()
        {
            Machine = new();
            Ops = new();
            Nonterminals = Symbols.index<NonterminalKind>();

        }

        public XedRegId ArAX()
        {
            var reg = XedRegId.INVALID;
            switch(Ops.easz)
            {
                case EASZ.EASZ16:
                    reg = XedRegId.AX;
                break;
                case EASZ.EASZ32:
                    reg = XedRegId.EAX;
                break;
                case EASZ.EASZ64:
                    reg = XedRegId.RAX;
                break;
            }
            return reg;
        }

        [MethodImpl(Inline)]
        public ref bit needrex()
            => ref Ops.needrex;
    }
}