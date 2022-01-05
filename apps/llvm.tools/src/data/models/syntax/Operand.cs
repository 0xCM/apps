//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    using System.Runtime.InteropServices;
    using System.Runtime.CompilerServices;

    using Asm;

    using static Root;

    partial struct AsmSyntaxModel
    {
        [StructLayout(LayoutKind.Sequential, Pack=1)]
        public struct Operand : IOperand<AsmOpClass,Cell256>
        {
            public AsmOpClass Kind {get;}

            public Cell256 Value {get;}

            [MethodImpl(Inline)]
            public Operand(AsmOpClass kind, Cell256 value)
            {
                Kind = kind;
                Value = value;
            }
        }
    }
}