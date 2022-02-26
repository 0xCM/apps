//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    using Asm;

    partial struct AsmSyntaxModel
    {
        [StructLayout(LayoutKind.Sequential, Pack=1)]
        public struct RegOperand : IOperand<AsmOpClass,RegIdentifier>
        {
            public RegIdentifier Value {get;}

            [MethodImpl(Inline)]
            public RegOperand(RegIdentifier value)
            {
                Value = value;
            }

            public AsmOpClass Kind => AsmOpClass.Reg;
        }
    }
}