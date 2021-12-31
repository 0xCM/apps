//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;
    using static core;

    using RFI = AsmPrefixCodes.RexFieldIndex;

    using static AsmPrefixCodes;

    /// <summary>
    /// REX = [ 0100 | REX.W:4 | R:3 | X:2 | B:1 ]
    /// </summary>
    [ApiComplete]
    public struct RexPrefix : IAsmPrefix<RexPrefix>, IAsmByte<RexPrefix>
    {
        [MethodImpl(Inline)]
        public static RexPrefix init()
            => new RexPrefix(0x40);

        byte Data;

        [MethodImpl(Inline)]
        public RexPrefix(byte src)
            => Data = src;

        [MethodImpl(Inline)]
        public readonly bit W()
            => bit.test(Data, (byte)RFI.W);

        /// <summary>
        /// When enabled, indicates a 64-bit operand size; if not, operand size determined by CS.D
        /// </summary>
        [MethodImpl(Inline)]
        public void W(bit w)
            => Data = bit.set(Data, (byte)RFI.W, w);

        [MethodImpl(Inline)]
        public readonly bit R()
            => bit.test(Data, (byte)RFI.R);

        [MethodImpl(Inline)]
        public void R(bit r)
            => Data = bit.set(Data, (byte)RFI.R, r);

        [MethodImpl(Inline)]
        public readonly bit X()
            => bit.test(Data, (byte)RFI.X);

        /// <summary>
        /// Indicates an extension of the SIB index field
        /// </summary>
        [MethodImpl(Inline)]
        public void X(bit x)
            => Data = bit.set(Data, (byte)RFI.X, x);

        [MethodImpl(Inline)]
        public readonly bit B()
            => bit.test(Data, (byte)RFI.B);

        /// <summary>
        /// Indicates an extension of the ModR/M r/m field, SIB base field, or Opcode reg field
        /// </summary>
        [MethodImpl(Inline)]
        public void B(bit b)
            => Data = bit.set(Data, (byte)RFI.B, b);

        public readonly byte Encoded
        {
            [MethodImpl(Inline)]
            get => Data;
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => Data == 0;
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => Data != 0;
        }

        [MethodImpl(Inline)]
        public byte Value()
            => Data;

        public string Format()
            => AsmRender.asmbyte(this);

        public string ToBitString()
            => BitRender.format8x4(Data);

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator Hex8(RexPrefix src)
            => src.Data;

        [MethodImpl(Inline)]
        public static implicit operator RexPrefix(RexPrefixCode src)
            => new RexPrefix((byte)src);

        [MethodImpl(Inline)]
        public static implicit operator byte(RexPrefix src)
            => src.Data;

        [MethodImpl(Inline)]
        public static implicit operator RexPrefix(byte src)
            => new RexPrefix(src);

        public static RexPrefix Empty
            => new RexPrefix(0);

        [MethodImpl(Inline), Op]
        public static ReadOnlySpan<RexPrefix> Range()
            => recover<RexPrefix>(RexPrefix._Range);

        static ReadOnlySpan<byte> _Range
            => new byte[16]{0x40,0x41,0x42,0x43,0x44,0x45,0x46,0x47,0x48,0x49,0x4A,0x4B,0x4C,0x4D,0x4E,0x4F};
    }
}