//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    using Asm;

    partial struct AsmSyntaxModel
    {
        public struct ImmOperand : IOperand<AsmOpClass,Imm>
        {
            public Imm Value {get;}

            public AsmOpClass Kind => AsmOpClass.Imm;

            [MethodImpl(Inline)]
            public ImmOperand(Imm value)
            {
                Value = value;
            }
        }
    }
}