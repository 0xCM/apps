//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    public class DispVar : AsmOpVar<DispVar,Disp>
    {

        public DispVar(VarSymbol name)
            : base(name)
        {

        }

        public DispVar(VarSymbol name, Disp value)
            : base(name, value)
        {

        }
    }
}