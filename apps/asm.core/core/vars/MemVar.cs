//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    public class MemVar : AsmOpVar<MemOp>
    {
        public MemVar(VarSymbol name)
            : base(name, MemOp.Empty)
        {

        }

        public MemVar(VarSymbol name, MemOp value)
            : base(name, value)
        {

        }
    }
}