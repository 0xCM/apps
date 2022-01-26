//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    public class ImmVar : AsmOpVar<Imm>
    {
        public ImmVar(VarSymbol name)
            : base(name, Imm.Empty)
        {

        }

        public ImmVar(VarSymbol name, Imm value)
            : base(name, value)
        {

        }
    }
}