//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial class XedRules
    {
        public struct CellPrimitive
        {
            public static CellPrimitive from(in CellInfo src)
            {
                var dst = default(CellPrimitive);
                if(src.IsFieldExpr)
                    dst = new (src.Field, src.Operator, CellRender.value(src));
                else if(src.IsOperator)
                    dst = new (src.Operator);
                else if(src.IsBinLit)
                {
                    LiteralBits.parse(src.Data, out var b).Require();
                    dst = new (b);
                }
                else if(src.IsHexLit)
                {
                    if(XedParsers.parse(src.Data, out Hex8 x))
                        dst = new (x);
                    else
                        Errors.Throw(AppMsg.ParseFailure.Format(nameof(RuleCellKind.HexLiteral), src.Data));
                }
                else if(src.IsKeyword)
                {
                    if(XedParsers.parse(src.Data, out RuleKeyword kw))
                        dst = new (kw);
                }
                else if(src.IsSeg)
                {
                    XedParsers.segdata(src.Data, out var data);
                    dst = new (src.Field, SegVar.parse(data));
                }
                else if(src.IsNontermCall)
                {
                    XedParsers.parse(src.Data, out Nonterminal x);
                    dst = new (x);
                }
                else
                {
                    XedParsers.parse(src.Data, out SegVar x);
                    dst = new (x);
                }

                return dst;
            }

            public FieldKind Field;

            public RuleOperator Operator;

            public byte ValueSize
            {
                [MethodImpl(Inline)]
                get => (byte)_ExprValue.Length;
            }

            LiteralBits _BitLit;

            asci32 _ExprValue;

            Hex8 _HexLit;

            RuleKeyword _Keyword;

            SegVar _SegData;

            Nonterminal _NTC;

            SegVar _AssembledSeg;

            Kind _Kind;

            public bool IsOperator
            {
                [MethodImpl(Inline)]
                get => _Kind == Kind.Op;
            }

            enum Kind : byte
            {
                None,

                Expr,

                NT,

                SegField,

                SegAssemly,

                Op,

                BitLit,

                HexLit,

                KW,
            }

            internal CellPrimitive(FieldKind field, RuleOperator op, asci32 value)
                : this()
            {
                Field = field;
                Operator = op;
                _ExprValue = value;
                _Kind = Kind.Expr;

            }

            internal CellPrimitive(FieldKind field, SegVar data)
                : this()
            {
                Field = field;
                _SegData = data;
                _Kind = Kind.SegField;
            }

            internal CellPrimitive(SegVar assembled)
                : this()
            {
                _AssembledSeg = assembled;
                _Kind = Kind.SegAssemly;
            }

            internal CellPrimitive(RuleOperator op)
                : this()
            {
                Operator = op;
                _Kind = Kind.Op;
            }

            internal CellPrimitive(LiteralBits bits)
                : this()
            {
                _BitLit = bits;
                _Kind = Kind.BitLit;
            }

            internal CellPrimitive(Hex8 hex)
                : this()
            {
                _HexLit = hex;
                _Kind = Kind.HexLit;
            }

            internal CellPrimitive(RuleKeyword kw)
                : this()
            {
                _Keyword = kw;
                _Kind = Kind.KW;
            }

            internal CellPrimitive(Nonterminal nt)
                : this()
            {
                _NTC = nt;
                _Kind = Kind.NT;
            }

            public string Format()
            {
                var dst = EmptyString;
                switch(_Kind)
                {
                    case Kind.Expr:
                        dst = string.Format("{0}{1}{2}", XedRender.format(Field), XedRender.format(Operator), _ExprValue);
                    break;
                    case Kind.Op:
                        dst = XedRender.format(Operator);
                    break;
                    case Kind.SegField:
                        dst = string.Format("{0}[{1}]", XedRender.format(Field), _SegData);
                    break;
                    case Kind.SegAssemly:
                        dst = _AssembledSeg.Format();
                    break;
                    case Kind.BitLit:
                        dst = _BitLit.Format();
                    break;
                    case Kind.HexLit:
                        dst = XedRender.format(_HexLit);
                    break;
                    case Kind.NT:
                        dst = XedRender.format(_NTC);
                    break;
                    case Kind.KW:
                        dst = XedRender.format(_Keyword);
                    break;
                }

                return dst;
            }

            public override string ToString()
                => Format();
        }
    }
}