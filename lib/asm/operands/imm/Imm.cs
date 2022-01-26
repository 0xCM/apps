//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;

    using static Root;

    using Asm;

    [DataType("imm"), StructLayout(LayoutKind.Sequential, Pack=1)]
    public readonly struct Imm : IImm<Imm,ulong>
    {

        [Op]
        internal static string format(in Imm src)
            => src.ImmKind switch
            {
                ImmKind.Imm8 => HexFormatter.format(w8, src.Imm8, HexPadStyle.Unpadded, prespec:true, @case:UpperCase),
                ImmKind.Imm8i => HexFormatter.format(w8i, src.Imm8i, HexPadStyle.Unpadded, prespec:true, @case:UpperCase),
                ImmKind.Imm16 => HexFormatter.format(w16, src.Imm16, HexPadStyle.Unpadded, prespec:true, @case:UpperCase),
                ImmKind.Imm16i => HexFormatter.format(w16i, src.Imm16i, HexPadStyle.Unpadded, prespec:true, @case:UpperCase),
                ImmKind.Imm32 => HexFormatter.format(w32, src.Imm32, HexPadStyle.Unpadded, prespec:true, @case:UpperCase),
                ImmKind.Imm32i => HexFormatter.format(w32, src.Imm32, HexPadStyle.Unpadded, prespec:true, @case:UpperCase),
                ImmKind.Imm64 => HexFormatter.format(w64, src.Imm64, HexPadStyle.Unpadded, prespec:true, @case:UpperCase),
                ImmKind.Imm64i => HexFormatter.format(w64, src.Imm64, HexPadStyle.Unpadded, prespec:true, @case:UpperCase),
                _ => string.Format("{0}:<1>", HexFormatter.format(w64, src.Imm64, HexPadStyle.Unpadded, prespec:true, @case:UpperCase), src.ImmKind),
            };

        public ulong Value {get;}

        public ImmKind ImmKind {get;}

        [MethodImpl(Inline)]
        public Imm(ImmKind kind, ulong src)
        {
            ImmKind = kind;
            Value = src;
        }

        [MethodImpl(Inline)]
        public Imm(ImmKind kind, long src)
        {
            ImmKind = kind;
            Value = (ulong)src;
        }

        public ImmBitWidth Width
        {
            [MethodImpl(Inline)]
            get => ImmKind.Width();
        }

        public NativeSize Size
        {
            [MethodImpl(Inline)]
            get => NativeSize.from((BitWidth)(byte)Width);
        }

        public bool Signed
        {
            [MethodImpl(Inline)]
            get => ((byte)ImmKind & Pow2.T07) != 0;
        }

        public ulong Imm64
        {
            [MethodImpl(Inline)]
            get => Value;
        }

        public long Imm64i
        {
            [MethodImpl(Inline)]
            get => (long)Value;
        }

        public uint Imm32
        {
            [MethodImpl(Inline)]
            get => (uint)Value;
        }

        public int Imm32i
        {
            [MethodImpl(Inline)]
            get => (int)Value;
        }

        public ushort Imm16
        {
            [MethodImpl(Inline)]
            get => (ushort)Value;
        }

        public short Imm16i
        {
            [MethodImpl(Inline)]
            get => (short)Value;
        }

        public byte Imm8
        {
            [MethodImpl(Inline)]
            get => (byte)Value;
        }

        public sbyte Imm8i
        {
            [MethodImpl(Inline)]
            get => (sbyte)Value;
        }

        public string Format()
            => format(this);

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator AsmOperand(Imm src)
            => new AsmOperand(src);

        public static Imm Empty => default;
    }
}