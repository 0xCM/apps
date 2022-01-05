//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    using System.Runtime.CompilerServices;

    using Asm;

    using static Root;

    partial struct AsmSyntaxModel
    {
        public struct ImmOperand<T> : IOperand<AsmOpClass,T>
            where T : unmanaged, IImm<T>
        {
            public T Value {get;}

            [MethodImpl(Inline)]
            public ImmOperand(T value)
            {
                Value = value;
            }

            public AsmOpClass Kind => AsmOpClass.Imm;

            [MethodImpl(Inline)]
            public static implicit operator ImmOperand(ImmOperand<T> src)
                => new ImmOperand(new ImmOp(src.Value));
        }
    }
}