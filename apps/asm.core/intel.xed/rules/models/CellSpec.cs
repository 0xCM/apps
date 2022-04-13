//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedModels;

    partial class XedRules
    {
        [StructLayout(LayoutKind.Sequential,Pack=1)]
        public readonly struct CellSpec
        {
            public static CellType celltype(string data)
            {
                Require.invariant(data.Length < 48);
                var field = XedLookups.Service.FieldSpec(XedFields.kind(data));
                CellParser.parse(data, out RuleOperator op);
                return new (field.Field,
                    CellParser.@class(field.Field,data),
                    op,
                    field.FieldType,
                    (byte)field.FieldWidth,
                    field.EffectiveType,
                    (byte)field.EffectiveWidth
                    );
            }

            public readonly CellType Type;

            public readonly string Data;

            [MethodImpl(Inline)]
            public CellSpec(string data)
            {
                Type = celltype(data);
                Data = text.ifempty(data, EmptyString);
            }

            [MethodImpl(Inline)]
            public CellSpec(RuleOperator op)
            {
                Type = CellType.@operator(op);
                Data = EmptyString;
            }

            public CellClass Class
            {
                [MethodImpl(Inline)]
                get => Type.Class;
            }

            public readonly FieldKind Field
            {
                [MethodImpl(Inline)]
                get => Type.Field;
            }

            public readonly RuleOperator Operator
            {
                [MethodImpl(Inline)]
                get => Type.Operator;
            }

            public bool IsOperator
            {
                [MethodImpl(Inline)]
                get => Field == 0 && Operator.IsNonEmpty;
            }

            public bool IsEmpty
            {
                [MethodImpl(Inline)]
                get => text.empty(Data) && Operator.IsEmpty && Field == 0;
            }

            public bool IsFieldExpr
            {
                [MethodImpl(Inline)]
                get => Field != 0 && Operator.IsNonEmpty;
            }

            public bool IsSeg
            {
                [MethodImpl(Inline)]
                get => CellParser.IsSeg(Data);
            }

            public bool IsNontermCall
            {
                [MethodImpl(Inline)]
                get => XedParsers.IsNontermCall(Data);
            }

            string Value()
            {
                var dst = EmptyString;
                if(IsFieldExpr)
                {
                    switch(Operator.Kind)
                    {
                        case OperatorKind.Eq:
                        {
                            var i = text.index(Data, Chars.Eq);
                            dst = text.right(Data,i);
                        }
                        break;
                        case OperatorKind.Neq:
                        {
                            var i = text.index(Data, Chars.Bang);
                            dst = text.right(Data,i+1);
                        }
                        break;
                        case OperatorKind.And:
                        {
                            var i = text.index(Data, Chars.Amp);
                            dst = text.right(Data,i);
                        }
                        break;
                    }
                }
                return dst;
            }

            public string Format()
            {
                var dst = EmptyString;
                if(IsFieldExpr)
                    dst = string.Format("{0}{1}{2}", XedRender.format(Field), XedRender.format(Operator), Value());
                else if(IsOperator)
                    dst = XedRender.format(Operator);
                else if(Class.IsBinLit)
                {
                    var result = CellBits.parse(Data, out var b);
                    if(result.Fail)
                        Errors.Throw(result.Message);
                    dst = b.Format();
                }
                else if(Class.IsHexLit)
                {
                    if(XedParsers.parse(Data, out Hex8 x))
                        dst = XedRender.format(x);
                    else
                        Errors.Throw(AppMsg.ParseFailure.Format(nameof(RuleCellKind.HexLiteral), Data));
                }
                else if(Class.IsKeyword)
                {
                    if(XedParsers.parse(Data, out RuleKeyword kw))
                        dst = kw.Format();
                }
                else if(IsSeg)
                {
                    CellParser.SegData(Data, out var data);
                    dst = string.Format("{0}[{1}]", XedRender.format(Field), data);
                }
                else if(IsNontermCall)
                {
                    XedParsers.parse(Data, out Nonterminal x);
                    dst = x.Format();
                }
                else
                    dst = RP.squote(Data);
                return dst;
            }

            public override string ToString()
                => Format();
        }
    }
}