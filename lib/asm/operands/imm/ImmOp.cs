//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    [DataType("immop")]
    public readonly struct ImmOp : IImm<ImmOp,ulong>
    {
        public static ImmOp define(NativeSize size, bool signed, ulong value)
        {
            var kind = ImmKind.None;
            switch(size.Code)
            {
                case NativeSizeCode.W8:
                    kind = signed ? ImmKind.Imm8i : ImmKind.Imm8;
                break;
                case NativeSizeCode.W16:
                    kind = signed ? ImmKind.Imm16i : ImmKind.Imm16;
                break;
                case NativeSizeCode.W32:
                    kind = signed ? ImmKind.Imm32i : ImmKind.Imm32;
                break;
                case NativeSizeCode.W64:
                    kind = signed ? ImmKind.Imm64i : ImmKind.Imm64;
                break;
            }
            return new ImmOp(kind, value);
        }

        [MethodImpl(Inline)]
        public static ImmOp define(ImmKind kind, ulong value)
            => new ImmOp(kind, value);

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

        public static ImmOp Empty => default;
    }
}