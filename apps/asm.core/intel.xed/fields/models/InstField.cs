//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;
    using static XedModels;

    partial class XedRules
    {
        public struct InstField : IEquatable<InstField>, IComparable<InstField>
        {
            readonly ByteBlock16 Data;

            const byte OpIndex = 11;

            const byte PosIndex = 12;

            const byte FieldIndex = 14;

            const byte ClassIndex = 15;

            [MethodImpl(Inline)]
            public InstField(byte src)
            {
                var data = ByteBlock16.Empty;
                data.First = src;
                data[ClassIndex] = (byte)RuleCellKind.IntLiteral;
                Data = data;
            }

            [MethodImpl(Inline)]
            public InstField(uint5 src)
            {
                var data = ByteBlock16.Empty;
                data.First = src;
                data[ClassIndex] = (byte)RuleCellKind.BitLiteral;
                Data = data;
            }

            [MethodImpl(Inline)]
            public InstField(Hex8 src)
            {
                var data = ByteBlock16.Empty;
                data[0] = src;
                data[ClassIndex] = (byte)RuleCellKind.HexLiteral;
                Data = data;
            }

            [MethodImpl(Inline)]
            public InstField(RuleKeyword src)
            {
                var data = ByteBlock16.Empty;
                data[0] = (byte)src.KeywordKind;
                data[ClassIndex] = (byte)RuleCellKind.Keyword;
                Data = data;
            }

            [MethodImpl(Inline)]
            public InstField(RuleOperator src)
            {
                var data = ByteBlock16.Empty;
                data[0] = (byte)src.Kind;
                data[ClassIndex] = (byte)RuleCellKind.Operator;
                Data = data;
            }

            [MethodImpl(Inline)]
            public InstField(InstSeg src)
            {
                var data = ByteBlock16.Empty;
                core.@as<InstSeg>(data.First) = src;
                data[FieldIndex] = (byte)src.Field;
                data[ClassIndex] = (byte)RuleCellKind.InstSeg;
                Data = data;
            }

            [MethodImpl(Inline)]
            public InstField(SegVar src)
            {
                var data = ByteBlock16.Empty;
                data.A = (ulong)src;
                data[ClassIndex] = (byte)RuleCellKind.SegVar;
                Data = data;
            }

            [MethodImpl(Inline)]
            public InstField(SegField src)
            {
                var data = ByteBlock16.Empty;
                data.A = (ulong)src.Seg;
                data[FieldIndex] = (byte)src.Field;
                data[ClassIndex] = (byte)RuleCellKind.SegField;
                Data = data;
            }

            [MethodImpl(Inline)]
            public InstField(CellExpr src)
            {
                var data = ByteBlock16.Empty;
                if(src.IsNonterm)
                {
                    @as<RuleName>(data.First) = src.Value.ToRuleName();
                    data[ClassIndex] = (byte)RuleCellKind.NontermExpr;
                    data[OpIndex] = (byte)src.Operator;
                    data[FieldIndex] = (byte)src.Field;
                }
                else
                {
                    @as<ulong>(data.First) = src.Value.Data;
                    data[OpIndex] = (byte)src.Operator;
                    data[FieldIndex] = (byte)src.Field;
                    switch(src.Operator.Kind)
                    {
                        case OperatorKind.Eq:
                            data[ClassIndex] = (byte)RuleCellKind.EqExpr;
                        break;
                        case OperatorKind.Neq:
                            data[ClassIndex] = (byte)RuleCellKind.NeqExpr;
                        break;
                        case OperatorKind.Impl:
                            data[ClassIndex] = (byte)RuleCellKind.Operator;
                        break;
                    }
                }
                Data = data;
            }

            [MethodImpl(Inline)]
            public InstField(Nonterminal src)
            {
                var data = ByteBlock16.Empty;
                data = (uint)src;
                data[ClassIndex] = (byte)RuleCellKind.NontermCall;
                Data = data;
            }

            [MethodImpl(Inline)]
            InstField(ByteBlock16 data)
            {
                Data = data;
            }

            public ref readonly RuleCellKind DataKind
            {
                [MethodImpl(Inline)]
                get => ref @as<RuleCellKind>(Data[ClassIndex]);
            }

            public ref readonly FieldKind FieldKind
            {
                [MethodImpl(Inline)]
                get => ref @as<FieldKind>(Data[FieldIndex]);
            }

            public ref readonly CellClass FieldClass
            {
                [MethodImpl(Inline)]
                get => ref @as<CellClass>(Data[ClassIndex]);
            }

            public bool IsFieldExpr
            {
                [MethodImpl(Inline)]
                get => DataKind == RuleCellKind.EqExpr || DataKind == RuleCellKind.NeqExpr || DataKind == RuleCellKind.NontermExpr;
            }

            public bool IsOperator
            {
                [MethodImpl(Inline)]
                get => DataKind == RuleCellKind.Operator;
            }

            public bool IsSegVar
            {
                [MethodImpl(Inline)]
                get => DataKind == RuleCellKind.SegVar;
            }

            public bool IsKeyword
            {
                [MethodImpl(Inline)]
                get => DataKind == RuleCellKind.Keyword;
            }

            public bool IsLiteral
            {
                [MethodImpl(Inline)]
                get => DataKind == RuleCellKind.BitLiteral || DataKind == RuleCellKind.HexLiteral || DataKind == RuleCellKind.IntLiteral;
            }

            public ref readonly byte Position
            {
                [MethodImpl(Inline)]
                get => ref Data[PosIndex];
            }

            [MethodImpl(Inline)]
            public InstField WithPosition(byte pos)
            {
                var dst = InstField.Empty;
                var data = Data;
                data[PosIndex] = pos;
                return new InstField(data);
            }

            [MethodImpl(Inline)]
            public bool Equals(InstField src)
                => Data.Equals(src.Data);

            public override int GetHashCode()
                => Data.GetHashCode();

            public override bool Equals(object src)
                => src is InstField p && Equals(p);

            [MethodImpl(Inline)]
            public ref readonly Hex8 AsHexLit()
                => ref @as<Hex8>(Data.First);

            [MethodImpl(Inline)]
            public ref readonly SegVar AsSegVar()
                => ref @as<SegVar>(Data.First);

            [MethodImpl(Inline)]
            public ref readonly byte AsIntLit()
                => ref @as<byte>(Data.First);

            [MethodImpl(Inline)]
            public ref readonly Nonterminal AsNonterm()
                => ref @as<Nonterminal>(Data.First);

            [MethodImpl(Inline)]
            public CellExpr ToFieldExpr()
                => new CellExpr(
                    (OperatorKind)Data[OpIndex],
                    new CellValue(FieldKind, @as<ulong>(Data.First), FieldClass)
                    );

            [MethodImpl(Inline)]
            public ref readonly uint5 AsBitLit()
                => ref @as<uint5>(Data.First);

            [MethodImpl(Inline)]
            public ref readonly RuleOperator AsOperator()
                => ref @as<RuleOperator>(Data.First);

            [MethodImpl(Inline)]
            public RuleKeyword ToKeyword()
                => RuleKeyword.from(@as<KeywordKind>(Data.First));

            [MethodImpl(Inline)]
            public ref readonly InstSeg AsInstSeg()
                => ref @as<InstSeg>(Data.First);

            [MethodImpl(Inline)]
            public ref readonly SegField AsSegField()
                => ref @as<SegField>(Data.First);

            public string Format()
                => XedRender.format(this);

            public override string ToString()
                => Format();

            [MethodImpl(Inline)]
            public int CompareTo(InstField src)
                => Position.CompareTo(src.Position);

            [MethodImpl(Inline)]
            public static implicit operator InstField(byte src)
                => new InstField(src);

            [MethodImpl(Inline)]
            public static implicit operator InstField(Hex8 src)
                => new InstField(src);

            [MethodImpl(Inline)]
            public static implicit operator InstField(uint5 src)
                => new InstField(src);

            [MethodImpl(Inline)]
            public static implicit operator InstField(RuleKeyword src)
                => new InstField(src);

            [MethodImpl(Inline)]
            public static implicit operator InstField(RuleOperator src)
                => new InstField(src);

            [MethodImpl(Inline)]
            public static implicit operator InstField(CellExpr src)
                => new InstField(src);

            [MethodImpl(Inline)]
            public static implicit operator InstField(SegField src)
                => new InstField(src);

            [MethodImpl(Inline)]
            public static implicit operator InstField(InstSeg src)
                => new InstField(src);

            [MethodImpl(Inline)]
            public static implicit operator InstField(SegVar src)
                => new InstField(src);

            // [MethodImpl(Inline)]
            // public static implicit operator InstField(RuleName src)
            //     => new InstField(src);

            [MethodImpl(Inline)]
            public static implicit operator InstField(Nonterminal src)
                => new InstField(src);

            public static InstField Empty => default;
        }
    }
}