//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;

    using static XedRules;
    using static XedModels;
    using static XedPatterns;
    using static core;

    using CK = XedRules.RuleCellKind;

    partial class XedCmdProvider
    {
        [CmdOp("xed/emit/defs")]
        Outcome EmitDefs(CmdArgs args)
        {
            var rules = Xed.Rules.CalcRules();
            var defs = CellDefCalcs.defs(rules);
            var specs = rules.TableSpecs().Select(x => (x.Sig, x)).ToDictionary();

            var lookup = defs.SelectMany(x => x.Rows).SelectMany(x => x.Cells).Select(x => (x.Key, x)).ToDictionary();
            EmitCellDefs(lookup);
            // for(var i=0; i<defs.Count; i++)
            // {
            //     ref readonly var def = ref defs[i];
            //     ref readonly var sig = ref def.Sig;
            //     for(var j=0; j<def.RowCount; j++)
            //     {
            //         ref readonly var row = ref def[j];
            //         for(var k=0; k< row.CellCount; k++)
            //         {
            //             ref readonly var cell = ref row[k];
            //             ref readonly var key = ref cell.Key;
            //             if(key.IsEmpty)
            //             {
            //                 //var table = specs[sig];
            //                 Write(sig.Format(), FlairKind.Error);
            //             }
            //         }
            //     }
            // }
            return true;
        }

        void EmitCellDefs(RuleExprLookup defs)
        {
            var rules = Xed.Rules.CalcRules();
            var specs = rules.TableSpecs().Select(x => (x.TableId, x)).ToDictionary();

            const string Sep = " | ";
            var cols = new Pairings<string,byte>(new Paired<string,byte>[]{
                ("CellType",32), ("Field", 22), ("Op", 8), ("Value", 48),
                ("Def",48), ("Key", 18), ("TableId", 12), ("TableKind", 12),
                ("TableName", 32), ("Row", 8),  ("Source",1)
                });

            var count = cols.Count;
            var widths = alloc<byte>(count);
            iteri(count, i=> seek(widths,i) = cols[i].Right);
            var slots = mapi(widths, (i,w) => RP.slot((byte)i, (short)-w));
            var names = alloc<string>(count);
            iteri(count, i => names[i] = cols[i].Left);
            var RenderPattern = slots.Intersperse(" | ").Concat();
            var header = string.Format(RenderPattern, names);

            var keys = defs.Keys;
            var dst = text.buffer();
            dst.AppendLine(header);
            for(var i=0; i<keys.Length; i++)
            {
                ref readonly var key = ref skip(keys,i);
                var expr = defs[key];
                dst.AppendLineFormat(RenderPattern,
                    expr.Type, XedRender.format(expr.Field), expr.Operator, expr.Value,expr.Format(),
                    key, key.TableId.FormatHex(), key.TableKind, specs[key.TableId].ShortName,
                    key.RowIndex, expr.Source
                    );
            }

            FileEmit(dst.Emit(), keys.Length, XedPaths.RuleTargets() + FS.file("xed.rules.expressions", FS.Csv), TextEncodingKind.Asci);
        }
    }

    partial class XedRules
    {
        public readonly struct CellDefCalcs
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
                    var k=z8;
                    var counter = z8;

                    counter += celldefs(src, spec.Antecedant, LogicKind.Antecedant, i, ref k, cells);

                    if(a.Count != 0 && c.Count !=0)
                    {
                        seek(cells,k) = new (new CellKey(sig.TableKind, table, i, LogicKind.Operator, k), RuleOperator.Impl);
                        k++;
                        counter++;
                    }

                    counter += celldefs(src, spec.Consequent, LogicKind.Consequent, i, ref k, cells);

                    seek(rows,i) = new (table, i, cells);
                }

                return new(table, sig, rows);
            }

            public static byte celldefs(in CellTableSpec table, Index<CellSpec> src, LogicClass logic, ushort row, ref byte k, Span<CellDef> dst)
            {
                var i0 = k;
                for(var j=0; j<src.Count; j++, k++)
                    seek(dst,k) = celldef(new CellKey(table.TableKind, table.TableId, row, logic, k), src[j]);
                return (byte)(k - i0);
            }

            public static CellDef celldef(CellKey key, in CellSpec src)
            {
                Require.invariant(key.IsNonEmpty);
                var type = celltype(src);
                return new CellDef(key, src.Field, src.Operator, type, value(type,src), src.Data);
            }

            public static CellValueExpr value(in CellType type, in CellSpec spec)
            {
                if(type.Class.IsExpr)
                {
                    switch(type.Class.Kind)
                    {
                        case CK.NontermExpr:
                        break;
                        case CK.NeqExpr:
                        break;
                        case CK.EqExpr:
                        break;
                        case CK.SegExpr:
                        break;
                    }
                }
                else
                {
                    switch(type.Class.Kind)
                    {
                        case CK.IntLiteral:
                        break;
                        case CK.BinaryLiteral:
                        break;
                        case CK.HexLiteral:
                        break;
                        case CK.Char:
                        break;
                        case CK.String:
                        break;
                        case CK.Keyword:
                        break;
                        case CK.Seg:
                        break;
                        case CK.SegSpec:
                        break;
                        case CK.Operator:
                        break;
                        case CK.Nonterm:
                        break;
                    }
                }

                return CellValueExpr.Empty;
            }

            public static CellType celltype(in CellSpec src)
            {
                var dst = CellType.Empty;
                var field = XedLookups.Service.FieldSpec(src.Field);
                dst.Field = field.FieldKind;
                dst.DataType = field.DeclaredType.Text;
                dst.EffectiveType = field.EffectiveType.Text;
                dst.Class = @class(src.Data);
                CellParser.parse(src.Data, out dst.Operator);
                return dst;
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
                        dst = CK.Seg;
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