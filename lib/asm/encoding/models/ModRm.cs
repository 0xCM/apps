//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    /// <summary>
    /// ModRM[mod[7:6] | reg[5:3] | r/m[2:0]]
    /// </summary>
    [ApiComplete]
    public struct ModRm
    {
        byte Data;

        [MethodImpl(Inline)]
        public ModRm(byte src)
            => Data = src;

        /// <summary>
        /// Reads bits [2:0] of the modrm byte
        /// </summary>
        [MethodImpl(Inline)]
        public byte Rm()
            => bits.segment(Data, 0, 2);

        [MethodImpl(Inline)]
        public void Rm(byte rm)
            => Data = bits.replace(Data, 0, 2, rm);

        /// <summary>
        /// Reads bits [5:3], which specifies a register operand or extends the operation encoding
        /// </summary>
        [MethodImpl(Inline)]
        public byte Reg()
            => bits.segment(Data, 3, 5);

        /// <summary>
        /// Specifies bits [5:3], which specifies a register operand or extends the operation encoding
        /// </summary>
        [MethodImpl(Inline)]
        public void Reg(byte reg)
            => Data = bits.replace(Data, 3, 5, reg);

        /// <summary>
        /// Reads bits [7:6] of the modrm byte that, together with the r/m field, specifies an operand addressing mode
        /// </summary>
        [MethodImpl(Inline)]
        public byte Mod()
            => bits.segment(Data, 6, 7);

        [MethodImpl(Inline)]
        public void Mod(byte mod)
            => Data = bits.replace(Data, 6, 7, mod);

        /// <summary>
        /// The encoded bitfield value
        /// </summary>
        public byte Encoded
        {
            [MethodImpl(Inline)]
            get => Data;
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => (byte)Data != 0;
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => (byte)Data == 0;
        }

        [MethodImpl(Inline)]
        public static ModRm operator ^(ModRm a, ModRm b)
            => new ModRm(math.xor(a.Data, b.Data));

        [MethodImpl(Inline)]
        public static ModRm operator |(ModRm a, ModRm b)
            => new ModRm(math.or(a.Data, b.Data));

        [MethodImpl(Inline)]
        public static implicit operator byte(ModRm src)
            => src.Encoded;

        public static ModRm Empty => default;
    }
}