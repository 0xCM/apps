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
        public readonly partial struct CellDefCalcs
        {
            public static Index<CellTableDef> defs(RuleTables rules)
            {
                var src = rules.TableSpecs();
                var count = src.Count;
                var dst = alloc<CellTableDef>(count);
                tables(src, dst);
                return dst;
            }

            public static void tables(Index<CellTableSpec> src, Span<CellTableDef> dst)
            {
                for(var i=0; i<src.Count; i++)
                    seek(dst,i) = table(src[i]);
            }

            public static CellTableDef table(in CellTableSpec src)
            {
                ref readonly var sig = ref src.Sig;
                var table = (ushort)src.TableId;
                var rows = alloc<CellRowDef>(src.RowCount);
                for(var i=z16; i<src.RowCount; i++)
                {
                    ref readonly var spec = ref src[i];
                    ref readonly var a = ref spec.Antecedant;
                    ref readonly var c = ref spec.Consequent;
                    var count =  a.Count + c.Count;
                    if(a.Count != 0 && c.Count !=0)
                        count++;

                    var cells = alloc<CellDef>(count);
                    var k = z8;
                    var counter = z8;

                    counter += celldefs(src, spec.Antecedant, LogicKind.Antecedant, i, ref k, cells);

                    if(a.Count != 0 && c.Count !=0)
                    {
                        seek(cells,k) = new (new CellKey(sig.TableKind, table, i, LogicKind.Operator, k), RuleOperator.Impl);
                        k++;
                        counter++;
                    }

                    counter += celldefs(src, spec.Consequent, LogicKind.Consequent, i, ref k, cells);

                    seek(rows,i) = new CellRowDef(table, i, cells);
                }

                return new CellTableDef(table, sig, rows);
            }

            public static byte celldefs(in CellTableSpec table, Index<CellSpec> src, LogicClass logic, ushort row, ref byte k, Span<CellDef> dst)
            {
                var i0 = k;
                for(var j=0; j<src.Count; j++, k++)
                    seek(dst,k) = celldef(new CellKey(table.TableKind, table.TableId, row, logic, k), src[j]);
                return (byte)(k - i0);
            }

            public static CellDef celldef(in CellKey key, in CellSpec src)
            {
                Require.invariant(key.IsNonEmpty);
                var type = celltype(src);
                return new CellDef(key, src.Field, src.Operator, type, value(src), src.Data);
            }

            static CellValueExpr value(in CellSpec src, in CellType type, FieldKind fk, string data)
            {
                var dst = CellValueExpr.Empty;
                var result = false;
                if(fk != 0)
                {
                    result = parse(data, fk, out FieldPack fp);
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

            public static CellType celltype(in CellSpec src)
            {
                var field = XedLookups.Service.FieldSpec(src.Field);
                CellParser.parse(src.Data, out RuleOperator op);
                return new (field.FieldKind, @class(src.Data), op,
                    field.DeclaredType.Text, (byte)field.DataWidth,
                    field.EffectiveType.Text, (byte)field.EffectiveWidth
                    );
            }

            public static CellClass @class(string data)
            {
                var result = false;
                var input = CellParser.normalize(data);
                var dst = CellClass.Empty;
                var isNonTerm = text.contains(input, "()");

                if(CellParser.IsExpr(input))
                {
                    result = CellParser.parse(input, out RuleOperator op);
                    if(!result)
                        Errors.Throw(AppMsg.ParseFailure.Format(nameof(RuleOperator), input));

                    switch(op.Kind)
                    {
                        case OperatorKind.Eq:
                            if(isNonTerm)
                                dst = CK.NontermExpr;
                            else
                                dst = CK.EqExpr;
                        break;
                        case OperatorKind.Neq:
                            dst = CK.NeqExpr;
                        break;
                        case OperatorKind.And:
                        case OperatorKind.Impl:
                            dst = CK.Operator;
                        break;
                    }
                }
                else
                {
                    if(isNonTerm)
                        dst = CK.Nonterm;
                    else if(XedParsers.IsIntLiteral(data))
                        dst = CK.IntLiteral;
                    else if(XedParsers.IsHexLiteral(data))
                        dst = CK.HexLiteral;
                    else if(XedParsers.IsBinaryLiteral(data))
                        dst = CK.BinaryLiteral;
                    else if(CellParser.IsImpl(input))
                        dst = CK.Operator;
                    else if(CellParser.IsSeg(input))
                    {
                        CellParser.SegData(input, out var sd);
                        if(XedParsers.IsBinaryLiteral(sd))
                            dst = CK.SegLiteral;
                        else
                            dst = CK.SegVar;
                    }
                    else if(RuleKeyword.parse(input, out var keyword))
                        dst = CK.Keyword;
                    else
                        dst = CK.SegSpec;
                }
                Require.invariant(dst.IsNonEmpty);
                return dst;
            }
       }
    }
}