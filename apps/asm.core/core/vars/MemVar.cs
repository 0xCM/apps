//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    public class MemVar : AsmOpVar<MemVar,MemOp>
    {
        public MemVar(VarSymbol name)
            : base(name)
        {

        }

        public MemVar(VarSymbol name, MemOp value)
            : base(name, value)
        {

        }
    }
}