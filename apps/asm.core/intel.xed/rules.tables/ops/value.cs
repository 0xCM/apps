//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;
    using static XedModels;

    using CK = XedRules.RuleCellKind;

    partial class XedRules
    {
        partial struct TableCalcs
        {
            public static CellValueExpr value(in CellSpec src)
            {
                var type = celltype(src);
                var dst = CellValueExpr.Empty;
                var data = src.Data;
                var fk = FieldKind.INVALID;
                var fv = EmptyString;
                if(type.Class.IsExpr)
                    dst = ValueFromExpr(src);
                else
                    dst = value(src, type, src.Field, data);
                return dst;
            }

            static CellValueExpr ValueFromExpr(in CellSpec src)
            {
                var type = celltype(src);
                if(!type.IsExpr)
                    Errors.Throw(string.Format("'{0}' is not an expression", src.Data));

                var dst = CellValueExpr.Empty;
                var data = src.Data;
                var fk = FieldKind.INVALID;
                var fv = EmptyString;
                if(!CellParser.parse(data, out RuleOperator op))
                    Errors.Throw(AppMsg.ParseFailure.Format(nameof(RuleOperator), data));

                switch(op.Kind)
                {
                    case OperatorKind.Eq:
                    {
                        var i = text.index(data,Chars.Eq);
                        var j = text.index(data,Chars.LBracket);
                        var k = text.index(data, Chars.RBracket);
                        var left = j>0 ? text.left(data,j) : text.left(data,i);
                        var right = k>0 ? text.right(data,k) : text.right(data,i);
                        XedParsers.parse(left, out fk);
                        if(fk == 0)
                            Errors.Throw(AppMsg.ParseFailure.Format(nameof(FieldKind), left));
                        fv = right;
                        dst = value(src, type, fk, fv);
                    }
                    break;
                    case OperatorKind.Neq:
                    {
                        var i = text.index(data,Chars.Bang);
                        var j = text.index(data,Chars.LBracket);
                        var k = text.index(data, Chars.RBracket);
                        var left =  j>0 ? text.left(data,j) : text.left(data,i);
                        var right = k>0 ? text.right(data,k+1) : text.right(data,i+1);
                        XedParsers.parse(left, out fk);
                        if(fk == 0)
                            Errors.Throw(AppMsg.ParseFailure.Format(nameof(FieldKind), left));
                        fv = right;
                        dst = value(src, type, fk, fv);
                    }
                    break;
                    default:
                        Errors.Throw(string.Format("Unhandled case: {0}", op.Kind));
                    break;

                }
                return dst;
            }

            static CellValueExpr value(in CellSpec src, in CellType type, FieldKind fk, string data)
            {
                var dst = CellValueExpr.Empty;
                var result = false;
                if(fk != 0)
                {
                    result = TableCalcs.parse(data, fk, out FieldPack fp);
                    dst = new(type, fp);
                }
                else
                {
                    switch(type.Class.Kind)
                    {
                        case CK.IntLiteral:
                        {
                            result = XedParsers.parse(data, out byte x);
                            dst = new(type,x);
                        }
                        break;
                        case CK.BinaryLiteral:
                        {
                            result = XedParsers.parse(data, out uint8b x);
                            dst = new(type,x);
                        }
                        break;
                        case CK.HexLiteral:
                        {
                            result = XedParsers.parse(data, out Hex8 x);
                            dst = new(type,x);
                        }
                        break;
                        case CK.Char:
                        {
                            Require.equal(data.Length,1);
                            dst = new(data[0]);
                            result = true;
                        }
                        break;
                        case CK.String:
                        {
                            dst = new (type,data);
                            result = true;
                        }
                        break;
                        case CK.Keyword:
                        {
                            result = RuleKeyword.parse(data, out RuleKeyword x);
                            dst = new(x);
                        }
                        break;
                        case CK.Seg:
                        {
                            result = CellParser.SegData(data, out var x);
                            if(XedParsers.IsBinaryLiteral(x))
                            {
                                result = XedParsers.parse(x, out uint8b literal);
                                dst = new (type,literal);
                            }
                            else
                            {
                                result = SegSpecs.parse(src.Field, x, out SegSpec ss);
                                if(result)
                                    dst = new(type,ss);
                                else
                                {
                                    dst = new(type, x);
                                    result = true;
                                }
                            }
                        }
                        break;
                        case CK.SegSpec:
                        {
                            dst = new (type,data);
                            result = true;
                        }
                        break;
                        case CK.Operator:
                        {
                            result = CellParser.parse(data, out RuleOperator x);
                            dst = new (x);
                        }
                        break;
                        case CK.Nonterm:
                        {
                            result = XedParsers.parse(data, out Nonterminal x);
                            dst = new (type,x);
                        }
                        break;
                    }
                }

                if(dst.IsEmpty)
                {
                    Errors.Throw(AppMsg.ParseFailure.Format(nameof(CellValueExpr), data));
                }
                return dst;
            }
        }
    }
}