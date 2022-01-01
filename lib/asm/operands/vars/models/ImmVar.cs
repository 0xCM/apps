//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    public class ImmVar : AsmOpVar<ImmVar,ImmOp>
    {

        public ImmVar(VarSymbol name)
            : base(name)
        {

        }

        public ImmVar(VarSymbol name, ImmOp value)
            : base(name, value)
        {

        }
    }
}