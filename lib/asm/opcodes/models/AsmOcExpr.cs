//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;

    using static Root;
    using static core;

    [StructLayout(LayoutKind.Sequential, Pack=1)]
    public struct AsmOcExpr
    {
        public AsmOpCodeBits Bits;

        public CharBlock36 Content;

        [MethodImpl(Inline)]
        public AsmOcExpr(AsmOpCodeBits bits, CharBlock36 expr)
        {
            Bits = bits;
            Content = expr;
        }

        public ref byte Lead
        {
            [MethodImpl(Inline)]
            get => ref seek(Bytes,0);
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => Bits.IsEmpty;
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => Bits.IsNonEmpty;
        }

        Span<byte> Bytes
        {
            [MethodImpl(Inline)]
            get => slice(bytes(Bits),0, 3);
        }

        public string Format()
            => Content.Format();

        public override string ToString()
            => Format();

        public static AsmOcExpr Empty
            => default;
    }
}