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
            public readonly FieldKind Field;

            public readonly RuleOperator Operator;

            public readonly string Data;

            [MethodImpl(Inline)]
            public CellSpec(string data)
            {
                Require.invariant(data.Length < 48);
                Field = XedFields.kind(data);
                Data = text.ifempty(data, EmptyString);
                CellParser.parse(data, out Operator);
            }

            [MethodImpl(Inline)]
            public CellSpec(RuleOperator op)
            {
                Field = 0;
                Data = EmptyString;
                Operator = op;
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

            public bool IsImplication
            {
                [MethodImpl(Inline)]
                get => Operator == RuleOperator.Impl;
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

            public bool IsNontermExpr
            {
                [MethodImpl(Inline)]
                get =>  IsFieldExpr && IsNontermCall;
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
                {
                    dst = string.Format("{0}{1}{2}", XedRender.format(Field), XedRender.format(Operator), Value());
                }
                else if(IsImplication)
                {
                    dst = XedRender.format(Operator);
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