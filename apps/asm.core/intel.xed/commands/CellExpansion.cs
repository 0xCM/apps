//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedRules;
    using static XedModels;
    using static core;

    partial class XedRules
    {
        public struct CellExpansion
        {
            enum DataKind : byte
            {
                None,

                Literal,

                Seg,

                Nonterm,

                NontermExpr,
            }

            const byte IndexPos = 12;

            const byte NonEmptyPos = 13;

            const byte KindPos = 14;

            const byte FieldPos = 15;

            ByteBlock16 Data;

            [MethodImpl(Inline)]
            public CellExpansion(Seg seg)
            {
                var data = ByteBlock16.Empty;
                @as<Seg>(data.First) = seg;
                data[NonEmptyPos] = (bit)seg.IsNonEmpty;
                data[KindPos] = (byte)DataKind.Seg;
                data[FieldPos] = (byte)seg.Field;
                Data = data;
            }

            [MethodImpl(Inline)]
            public CellExpansion(byte literal)
            {
                var data = ByteBlock16.Empty;
                data.First = literal;
                data[NonEmptyPos] = 1;
                data[KindPos] = (byte)DataKind.Literal;
                data[FieldPos] = 0;
                Data = data;
            }

            [MethodImpl(Inline)]
            public CellExpansion(Nonterminal nt)
            {
                var data = ByteBlock16.Empty;
                @as<Nonterminal>(data.First) = nt;
                data[NonEmptyPos] = (bit)nt.IsNonEmpty;
                data[KindPos] = (byte)DataKind.Nonterm;
                data[FieldPos] = 0;
                Data = data;
            }

            [MethodImpl(Inline)]
            public CellExpansion(NontermExpr ntfx)
            {
                var data = ByteBlock16.Empty;
                @as<NontermExpr>(data.First) = ntfx;
                data[NonEmptyPos] = (bit)ntfx.IsNonEmpty;
                data[KindPos] = (byte)DataKind.NontermExpr;
                data[FieldPos] = (byte)ntfx.Field;
                Data = data;
            }

            public ref byte Index
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

            DataKind Kind
            {
                [MethodImpl(Inline)]
                get => @as<DataKind>(Data[KindPos]);
            }

            public bool IsLiteral
            {
                [MethodImpl(Inline)]
                get => Kind == DataKind.Literal;
            }

            public bool IsNonterm
            {
                [MethodImpl(Inline)]
                get => Kind == DataKind.Nonterm;
            }

            public bool IsNontermExpr
            {
                [MethodImpl(Inline)]
                get => Kind == DataKind.NontermExpr;
            }

            public bool IsSeg
            {
                [MethodImpl(Inline)]
                get => Kind == DataKind.Seg;
            }

            ref FieldKind Field
            {
                [MethodImpl(Inline)]
                get => ref @as<FieldKind>(Data[FieldPos]);
            }

            ref Seg Seg
            {
                [MethodImpl(Inline)]
                get => ref @as<Seg>(Data.First);
            }

            ref Hex8 Literal
            {
                [MethodImpl(Inline)]
                get => ref @as<Hex8>(Data.First);
            }

            ref Nonterminal Nonterm
            {
                [MethodImpl(Inline)]
                get => ref @as<Nonterminal>(Data.First);
            }

            ref NontermExpr NontermExpr
            {
                [MethodImpl(Inline)]
                get => ref @as<NontermExpr>(Data.First);
            }

            public string Format()
            {
                var dst = EmptyString;
                if(IsNonEmpty)
                {
                    if(IsLiteral)
                        dst = XedRender.format(Literal);
                    else if(IsNonterm)
                        dst = Nonterm.Format();
                    else if(IsNontermExpr)
                        dst = NontermExpr.Format();
                    else if(IsSeg)
                        dst = Seg.Format();
                }
                return dst;
            }

            public override string ToString()
                => Format();

            public static CellExpansion Empty => default;

            [MethodImpl(Inline)]
            public static implicit operator CellExpansion(byte src)
                => new CellExpansion(src);

            [MethodImpl(Inline)]
            public static implicit operator CellExpansion(Seg src)
                => new CellExpansion(src);

            [MethodImpl(Inline)]
            public static implicit operator CellExpansion(Nonterminal src)
                => new CellExpansion(src);

            [MethodImpl(Inline)]
            public static implicit operator CellExpansion(NontermKind src)
                => new CellExpansion(src);

            [MethodImpl(Inline)]
            public static implicit operator CellExpansion(NontermExpr src)
                => new CellExpansion(src);
        }
    }
}