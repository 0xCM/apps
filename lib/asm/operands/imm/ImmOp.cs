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
        public ulong Content {get;}

        public ImmKind Kind {get;}

        [MethodImpl(Inline)]

        public ImmOp(ImmKind kind, ulong src)
        {
            Kind = kind;
            Content = src;
        }

        public ImmBitWidth Width
        {
            [MethodImpl(Inline)]
            get => Kind.Width();
        }

        public NativeSize Size
        {
            [MethodImpl(Inline)]
            get => NativeSize.from((BitWidth)(byte)Width);
        }

        public ulong Imm64
        {
            [MethodImpl(Inline)]
            get => Content;
        }

        public uint Imm32
        {
            [MethodImpl(Inline)]
            get => (uint)Content;
        }

        public ushort Imm16
        {
            [MethodImpl(Inline)]
            get => (ushort)Content;
        }

        public byte Imm8
        {
            [MethodImpl(Inline)]
            get => (byte)Content;
        }

        public string Format()
            => Width switch
            {
                ImmBitWidth.W8 => HexFormatter.format(w8, Content, true),
                ImmBitWidth.W16 => HexFormatter.format(w16, Content, true),
                ImmBitWidth.W32 => HexFormatter.format(w32, Content, true),
                ImmBitWidth.W64 => HexFormatter.format(w64, Content, true),
                _ => EmptyString
            };

        public override string ToString()
            => Format();
    }
}