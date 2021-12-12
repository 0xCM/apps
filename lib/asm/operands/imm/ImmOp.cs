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
    public readonly struct ImmOp : IImm<ImmOp,ulong>
    {
        public ulong Value {get;}

        public ImmKind ImmKind {get;}

        [MethodImpl(Inline)]

        public ImmOp(ImmKind kind, ulong src)
        {
            ImmKind = kind;
            Value = src;
        }

        [MethodImpl(Inline)]
        public ImmOp(IImm src)
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

        public uint Imm32
        {
            [MethodImpl(Inline)]
            get => (uint)Value;
        }

        public ushort Imm16
        {
            [MethodImpl(Inline)]
            get => (ushort)Value;
        }

        public byte Imm8
        {
            [MethodImpl(Inline)]
            get => (byte)Value;
        }

        public string Format()
            => Width switch
            {
                ImmBitWidth.W8 => HexFormatter.format(w8, Value, true),
                ImmBitWidth.W16 => HexFormatter.format(w16, Value, true),
                ImmBitWidth.W32 => HexFormatter.format(w32, Value, true),
                ImmBitWidth.W64 => HexFormatter.format(w64, Value, true),
                _ => EmptyString
            };

        public override string ToString()
            => Format();
    }
}