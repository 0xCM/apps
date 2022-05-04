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
            public static Index<CellPrimitive> primitives(in RowSpec src)
            {
                var count = src.ColCount;
                var dst = alloc<CellPrimitive>(count);
                for(var i=z8; i<count; i++)
                    seek(dst,i) = CellPrimitive.from(src[i]);
                return dst;
            }

            public static CellPrimitive from(in CellInfo src)
            {
                var dst = default(CellPrimitive);
                if(src.IsFieldExpr)
                    dst = new (src.Field, src.Operator, CellRender.value(src));
                else if(src.IsOperator)
                    dst = new (src.Operator);
                else if(src.IsBitLit)
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

            public static string format(Index<CellPrimitive> src)
            {
                var dst = text.emitter();
                var count = src.Count;
                for(var i=z8; i<count; i++)
                {
                    ref readonly var cell = ref src[i];
                    if(cell.IsOperator && i == count - 1)
                        break;

                    if(i !=0)
                        dst.Append(Chars.Space);

                    dst.Append(cell.Format());
                }
                return dst.Emit();
            }

            public readonly FieldKind Field;

            public readonly asci32 Value;

            public readonly Kind Sort;

            public bool IsOperator
            {
                [MethodImpl(Inline)]
                get => Sort == Kind.Op;
            }

            public enum Kind : byte
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

            internal CellPrimitive(FieldKind field, RuleOperator op, asci32 src)
            {
                Field = field;
                Sort = Kind.Expr;
                Value = string.Format("{0}{1}{2}", field,op, src);

            }

            internal CellPrimitive(FieldKind field, SegVar src)
            {
                Field = field;
                Sort = Kind.SegField;
                Value = string.Format("{0}[{1}]", XedRender.format(field), src);
            }

            internal CellPrimitive(SegVar src)
            {
                Field = FieldKind.INVALID;
                Sort = Kind.SegAssemly;
                Value = XedRender.format(src);
            }

            internal CellPrimitive(RuleOperator src)
            {
                Field = FieldKind.INVALID;
                Sort = Kind.Op;
                Value = XedRender.format(src);
            }

            internal CellPrimitive(LiteralBits src)
            {
                Field = FieldKind.INVALID;
                Sort = Kind.BitLit;
                Value = src.Format();
            }

            internal CellPrimitive(Hex8 src)
            {
                Field = FieldKind.INVALID;
                Sort = Kind.HexLit;
                Value = XedRender.format(src);
            }

            internal CellPrimitive(RuleKeyword src)
            {
                Field = FieldKind.INVALID;
                Sort = Kind.KW;
                Value = XedRender.format(src);
            }

            internal CellPrimitive(Nonterminal src)
            {
                Field = FieldKind.INVALID;
                Sort = Kind.NT;
                Value = XedRender.format(src);
            }

            public string Format()
                => Value.Format();

            public override string ToString()
                => Format();
        }
    }
}