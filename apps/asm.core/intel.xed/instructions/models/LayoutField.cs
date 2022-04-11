//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedModels;
    using static core;

    using C = XedRules.InstFieldClass;
    using K = XedRules.InstFieldKind;

    partial class XedRules
    {
        public readonly struct LayoutField
        {
            const byte IndexPos = 12;

            const byte NonEmptyPos = 13;

            const byte ClassPos = 14;

            const byte KindPos = 15;

            readonly ByteBlock16 Data;

            [MethodImpl(Inline)]
            public LayoutField(byte index, Seg src)
            {
                var data = ByteBlock16.Empty;
                data[IndexPos] = index;
                @as<Seg>(data.First) = src;
                data[NonEmptyPos] = (bit)src.IsNonEmpty;
                data[ClassPos] = (byte)C.Seg;
                data[KindPos] = (byte)K.Seg;
                Data = data;
            }

            [MethodImpl(Inline)]
            public LayoutField(byte index, Hex8 src)
            {
                var data = ByteBlock16.Empty;
                data[IndexPos] = index;
                data.First = src;
                data[NonEmptyPos] = 1;
                data[ClassPos] = (byte)C.Literal;
                data[KindPos] = (byte)K.HexLiteral;
                Data = data;
            }

            [MethodImpl(Inline)]
            public LayoutField(byte index, uint5 src)
            {
                var data = ByteBlock16.Empty;
                data[IndexPos] = index;
                data.First = src;
                data[NonEmptyPos] = 1;
                data[ClassPos] = (byte)C.Literal;
                data[KindPos] = (byte)K.BitLiteral;
                Data = data;
            }

            [MethodImpl(Inline)]
            public LayoutField(byte index, Nonterminal nt)
            {
                var data = ByteBlock16.Empty;
                data[IndexPos] = index;
                @as<Nonterminal>(data.First) = nt;
                data[NonEmptyPos] = (bit)nt.IsNonEmpty;
                data[ClassPos] = (byte)C.Nonterm;
                data[KindPos] = (byte)K.Nonterm;
                Data = data;
            }

            public ref readonly byte Index
            {
                [MethodImpl(Inline)]
                get => ref Data[IndexPos];
            }

            public bool IsNonEmpty
            {
                [MethodImpl(Inline)]
                get => (bit)Data[NonEmptyPos];
            }

            public bool Ismpty
            {
                [MethodImpl(Inline)]
                get => !IsNonEmpty;
            }

            public ref readonly C Class
            {
                [MethodImpl(Inline)]
                get => ref @as<C>(Data[ClassPos]);
            }

            public ref readonly K Kind
            {
                [MethodImpl(Inline)]
                get => ref @as<K>(Data[KindPos]);
            }

            [MethodImpl(Inline)]
            public ref readonly Seg AsSeg()
                => ref @as<Seg>(Data.First);

            [MethodImpl(Inline)]
            public ref readonly uint5 AsBitLit()
                => ref @as<uint5>(Data.First);

            [MethodImpl(Inline)]
            public ref Hex8 AsHexLit()
                => ref @as<Hex8>(Data.First);

            [MethodImpl(Inline)]
            public ref Nonterminal AsNonterm()
                => ref @as<Nonterminal>(Data.First);

            public string Format()
            {
                var dst = EmptyString;
                switch(Kind)
                {
                    case K.BitLiteral:
                        dst = XedRender.format(AsBitLit());
                    break;
                    case K.HexLiteral:
                        dst = XedRender.format(AsHexLit());
                    break;
                    case K.Nonterm:
                        dst = XedRender.format(AsNonterm());
                    break;
                    case K.Seg:
                        dst = XedRender.format(AsSeg());
                    break;
                }
                return dst;
            }

            public override string ToString()
                => Format();

            public static LayoutField Empty => default;
        }
    }
}