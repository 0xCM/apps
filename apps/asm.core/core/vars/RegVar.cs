//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    public class RegVar : AsmOpVar<RegOp>
    {
        public RegVar(VarSymbol name)
            : base(name, RegOp.Invalid)
        {

        }

        public RegVar(VarSymbol name, RegOp value)
            : base(name, value)
        {

        }
    }
}