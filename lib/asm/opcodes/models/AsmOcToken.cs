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

    [StructLayout(LayoutKind.Sequential, Size=2)]
    public readonly struct AsmOcToken : IAsmOpCodeToken
    {
        public byte Value {get;}

        public AsmOcTokenKind Kind {get;}

        [MethodImpl(Inline)]
        public AsmOcToken(AsmOcTokenKind kind, byte value)
        {
            Value = value;
            Kind = kind;
        }

        [MethodImpl(Inline)]
        public AsmOcToken(ushort src)
        {
            Value = (byte)src;
            Kind = (AsmOcTokenKind)(src >> 8);
        }

        [MethodImpl(Inline)]
        public static implicit operator ushort(AsmOcToken src)
            => core.bw16(src);

        [MethodImpl(Inline)]
        public static implicit operator AsmOcToken(ushort src)
            => new AsmOcToken(src);
    }
}