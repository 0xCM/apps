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
    public struct AsmOpCode
    {
        public uint Key;

        public AsmOpCodeBits Bits;

        public CharBlock48 Expr;

        [MethodImpl(Inline)]
        public AsmOpCode(uint key, AsmOpCodeBits bits, CharBlock48 expr)
        {
            Key = key;
            Bits = bits;
            Expr = expr;
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
            => Expr.Format();

        public override string ToString()
            => Format();

        public static AsmOpCode Empty
            => default;
    }
}