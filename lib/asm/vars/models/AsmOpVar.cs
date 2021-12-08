//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System;

    public class AsmOpVar : AsmOpVar<AsmOperand>
    {
        public AsmOpVar(byte index,Func<byte,AsmOperand> resolver)
            : base(index,resolver)
        {

        }

        protected override ref readonly AsmOperand Resolve(uint seq, out AsmOperand dst)
        {
            dst = Resolve(seq);
            return ref dst;
        }
    }
}