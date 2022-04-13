//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedModels;
    using static core;

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

            public static Outcome bits(string src, out byte n, out byte dst)
            {
                var result = Outcome.Success;
                dst = 0;
                n = 0;
                var number = z32;
                if(XedParsers.IsBinaryLiteral(src))
                {
                    var input = text.trim(text.remove(text.replace(src,"0b",EmptyString), Chars.Underscore));
                    n = (byte)input.Length;
                    if(n > 6)
                    {
                        result = (false, "Unsupported bit length");
                        term.error(result.Message);
                    }
                    else
                    {
                        var data = span(input);
                        var storage = ByteBlock8.Empty;
                        var buffer = recover<bit>(storage.Bytes);

                        var k=n-1;
                        for(var i=0; i<n; i++,k--)
                        {
                            ref readonly var c = ref skip(data,i);
                            if(c == '0')
                                buffer[k] = bit.Off;
                            else if(c == '1')
                                buffer[k] = bit.On;
                            else
                            {
                                result = (false, $"Unsupported character '{c}'");
                                term.error(result.Message);
                                break;
                            }
                        }

                        if(result)
                            dst = BitPack.scalar<byte>(buffer);
                    }
                }
                return result;
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
                    var result = bits(Data, out byte n, out byte b);
                    switch(n)
                    {
                        case 1:
                        {
                            uint1 value = b;
                            dst = XedRender.format(value);
                            break;
                        }
                        case 2:
                        {
                            uint2 value = b;
                            dst = XedRender.format(value);
                            break;
                        }
                        case 3:
                        {
                            uint3 value = b;
                            dst = XedRender.format(value);
                            break;
                        }
                        case 4:
                        {
                            uint4 value = b;
                            dst = XedRender.format(value);
                            break;
                        }
                        case 5:
                        {
                            uint5 value = b;
                            dst = XedRender.format(value);
                            break;
                        }
                        case 6:
                        {
                            uint6 value = b;
                            dst = XedRender.format(value);
                            break;
                        }
                    }
                    // var input = text.trim(text.remove(text.remove(Data,Chars.Underscore), "0b"));
                    // var result = false;
                    // switch(input.Length)
                    // {
                    //     case 1:
                    //         result = bit.parse(input, out bit b1);
                    //         dst = XedRender.format((uint1)b1);
                    //     break;
                    //     case 2:
                    //         result = XedParsers.parse(input, out uint2 u2);
                    //         dst = XedRender.format(u2);
                    //     break;
                    //     case 3:
                    //         result = XedParsers.parse(input, out uint3 u3);
                    //         dst = XedRender.format(u3);
                    //     break;
                    //     case 4:
                    //         result = XedParsers.parse(input, out uint4 u4);
                    //         dst = XedRender.format(u4);
                    //     break;
                    //     case 5:
                    //         result = XedParsers.parse(input, out uint5 u5);
                    //         dst = XedRender.format(u5);
                    //     break;
                    // }
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