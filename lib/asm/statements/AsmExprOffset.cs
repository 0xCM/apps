//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public readonly struct AsmExprOffset
    {
        public AsmExpr Asm {get;}

        public MemoryAddress Offset {get;}

        [MethodImpl(Inline)]
        public AsmExprOffset(AsmExpr expr, MemoryAddress offset)
        {
            Asm = expr;
            Offset = offset;
        }

        public AsmOffsetLabel Label
        {
            [MethodImpl(Inline)]
            get => asm.label((byte)(bits.effsize(Offset)*8), Offset);
        }

        public string Format()
            => string.Format("{0,-6} {1}", Label, Asm);

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator AsmExprOffset((AsmExpr expr, MemoryAddress offset) src)
            => new AsmExprOffset(src.expr, src.offset);

        [MethodImpl(Inline)]
        public static implicit operator AsmExprOffset((string expr, MemoryAddress offset) src)
            => new AsmExprOffset(src.expr, src.offset);

        [MethodImpl(Inline)]
        public static implicit operator AsmExprOffset((AsmExpr expr, Address32 offset) src)
            => new AsmExprOffset(src.expr, src.offset);

        [MethodImpl(Inline)]
        public static implicit operator AsmExprOffset((string expr, Address32 offset) src)
            => new AsmExprOffset(src.expr, src.offset);

        [MethodImpl(Inline)]
        public static implicit operator AsmExprOffset((AsmExpr expr, Address16 offset) src)
            => new AsmExprOffset(src.expr, src.offset);

        [MethodImpl(Inline)]
        public static implicit operator AsmExprOffset((string expr, Address16 offset) src)
            => new AsmExprOffset(src.expr, src.offset);
    }
}