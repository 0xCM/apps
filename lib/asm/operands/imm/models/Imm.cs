//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    [DataType("imm")]
    public readonly struct Imm : IImm<Imm,ulong>
    {
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

        [MethodImpl(Inline)]
        public Imm(IImm src)
        {
            ImmKind = src.ImmKind;
            Value = src.Value;
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
            => Width switch
            {
                ImmBitWidth.W8 => HexFormatter.format(w8, Imm8, prespec:true, @case:UpperCase),
                ImmBitWidth.W16 => HexFormatter.format(w16, Imm16, prespec:true, @case:UpperCase),
                ImmBitWidth.W32 => HexFormatter.format(w32, Imm32, prespec:true, @case:UpperCase),
                ImmBitWidth.W64 => HexFormatter.format(w64, Imm64, prespec:true, @case:UpperCase),
                _ => EmptyString
            };

        public override string ToString()
            => Format();

        public static Imm Empty => default;
    }
}