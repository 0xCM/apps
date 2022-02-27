//-----------------------------------------------------------------------------
// Copyright   : Intel Corporation, 2020
// License     : Apache
// Source      : all-state.txt
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedModels;

    partial struct XedModels
    {
        public class RuleState
        {
            MachineState Machine;

            FieldState Ops;

            Index<NonterminalKind, Index<XedRegId>> Regs;

            Symbols<NonterminalKind> Nonterminals;

            public RuleState()
            {
                Machine = new();
                Ops = new();
                Nonterminals = Symbols.index<NonterminalKind>();

            }

            public XedRegId ArAX()
            {
                var reg = XedRegId.INVALID;
                switch(Ops.EASZ)
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
        }
    }
}