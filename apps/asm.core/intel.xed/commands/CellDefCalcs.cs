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
    using R = XedRules.CellRole;

    partial class XedCmdProvider
    {
        [CmdOp("xed/emit/defs")]
        Outcome EmitDefs(CmdArgs args)
        {
            var rules = Xed.Rules.CalcRules();
            EmitCellDefs(CellDefCalcs.CalcDefs(rules));
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

            FileEmit(dst.Emit(),keys.Length, XedPaths.RuleTargets() + FS.file("xed.rules.expressions", FS.Csv), TextEncodingKind.Asci);
        }
    }

    partial class XedRules
    {
        public readonly struct CellDefCalcs
        {
            public static void CalcExprLookup(Index<CellTableSpec> src, Dictionary<RuleExprKey,CellDef> dst)
            {
                for(var i=0; i<src.Count; i++)
                    CalcExprLookup(src[i], dst);
            }

            public static void defs(RuleTables rules)
            {
                var src = rules.TableSpecs();
                var count = src.Count;
                var dst = alloc<CellTableDef>(count);
                tables(src, dst);
            }

            public static void tables(Index<CellTableSpec> src, Span<CellTableDef> dst)
            {
                for(var i=0; i<src.Count; i++)
                {

                    seek(dst,i) = table(src[i]);
                }
            }

            public static CellTableDef table(in CellTableSpec src)
            {
                var rows = alloc<CellRowDef>(src.RowCount);
                for(var i=z16; i<src.RowCount; i++)
                {
                    ref readonly var spec = ref src[i];
                    ref readonly var a = ref spec.Antecedant;
                    ref readonly var c = ref spec.Consequent;

                    var count = (a.Count != 0 ? a.Count + 1 : 0) + c.Count;
                    var defs = alloc<CellDef>(count);
                    var k=z8;
                    for(byte j=0; j<a.Count; j++, k++)
                    {
                        seek(defs,k) = celldef(a[j]);
                    }

                    if(a.Count !=0 && c.Count != 0)
                    {
                        seek(defs,k++) = new (RuleOperator.Impl);
                    }

                    for(byte j=0; j<c.Count; j++, k++)
                    {
                        seek(defs,k) = celldef(c[j]);
                    }

                }

                return new((ushort)src.TableId, src.Sig, rows);
            }

            public static CellDef celldef(in CellSpec src)
            {
                var type = celltype(src);
                var dst = new CellDef(src.Field,src.Operator, type, value(type,src), src.Data);

                return dst;
            }

            public static CellValue value(in CellType type, in CellSpec spec)
            {
                return CellValue.Empty;
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

            public static CellDef celldef(string src)
            {
                var dst = CellDef.Empty;
                if(CellParser.parse(src, out RuleCriterion c))
                    dst = new CellDef(c.Field, c.Operator, celltype(c.Field, src), value(c), src);
                return dst;
            }

            static void CalcExprLookup(in CellTableSpec src, Dictionary<RuleExprKey,CellDef> dst)
            {
                for(var i=z16; i<src.RowCount; i++)
                    CalcExprLookup(i, src, dst);
            }

            static void CalcExprLookup(ushort row, in CellTableSpec table, Dictionary<RuleExprKey,CellDef> dst)
            {
                CalcExprLookup(row, table, 'P', table[row].Antecedant, dst);
                CalcExprLookup(row, table, 'C', table[row].Consequent, dst);
            }

            static void CalcExprLookup(ushort row, in CellTableSpec table, char logic, Index<CellSpec> src, Dictionary<RuleExprKey,CellDef> dst)
            {
                for(var i=z8; i<src.Count; i++)
                {
                    var key = new RuleExprKey(table.Sig.TableKind, table.TableId, row, logic, i);
                    var cexpr = celldef(src[i].Data);
                    if(!dst.TryAdd(key, cexpr))
                        Errors.Throw(string.Format("Duplicate:({0},'{1}')", key, cexpr));
                }
            }

            public static CellValue value(in RuleCriterion src)
            {
                var fmt = EmptyString;
                var value = CellValue.Empty;
                switch(src.Role)
                {
                    case R.None:
                        break;
                    case R.Branch:
                    case R.Null:
                    case R.Error:
                    case R.Wildcard:
                    case R.Default:
                    case R.Keyword:
                        value = new (src.ToKeyword(), src.Role);
                    break;
                    case R.BinaryLiteral:
                        value = new(src.Field, src.ToBinaryLiteral(), src.Role);
                    break;
                    case R.IntLiteral:
                        value = new(src.Field, src.ToIntLiteral(), src.Role);
                    break;
                    case R.HexLiteral:
                        value = new(src.Field, src.ToHexLiteral(), src.Role);
                    break;
                    case R.Operator:
                        value = new(src.ToOperator(), src.Role);
                    break;
                    case R.Seg:
                        value = new (src.ToBfSeg(), src.Role);
                    break;
                    case R.BfSpec:
                        value = new (src.ToBfSpec(), src.Role);
                    break;
                    case R.DispSpec:
                        value = new(src.ToDispSpec(), src.Role);
                    break;
                    case R.DispSeg:
                        value = new(src.Field,src.ToDispSeg(), src.Role);
                    break;
                    case R.ImmSpec:
                        value = new(src.ToImmSpec(), src.Role);
                    break;
                    case R.ImmSeg:
                        value = new(src.Field,src.ToImmSeg(), src.Role);
                    break;
                    case R.NontermCall:
                        value = new(src.Field, src.ToNontermCall(), src.Role);
                    break;
                    case R.BfSegExpr:
                        value = new(src.ToBfSeg(), src.Role);
                    break;
                    case R.NontermExpr:
                        value = new(src.Field, src.ToNontermCall(), src.Role);
                    break;
                    case R.EqExpr:
                        value = src.ToFieldExpr().Value;
                    break;
                    case R.NeqExpr:
                        value = src.ToFieldExpr().Value;
                    break;
                    default:
                        Errors.Throw(string.Format("Missing case: {0}", src.Role));
                    break;

                }
                return value;
            }

            public static CellClass @class(string data)
            {
                var input = CellParser.normalize(data);
                var dst = CK.None;
                if(CellParser.IsExpr(input))
                {
                    if(CellParser.IsEq(input))
                        dst = CK.EqExpr;
                    else if(CellParser.IsNeq(input))
                        dst = CK.NeqExpr;
                    else if(XedParsers.IsNontermCall(input))
                        dst = CK.NontermExpr;
                    else if(CellParser.IsBfSeg(input))
                        dst = CK.SegExpr;
                }
                else
                {
                    if(XedParsers.IsIntLiteral(data))
                        dst = CK.IntLiteral;
                    else if(XedParsers.IsHexLiteral(data))
                        dst = CK.HexLiteral;
                    else if(XedParsers.IsBinaryLiteral(data))
                        dst = CK.BinaryLiteral;
                    else if(CellParser.IsImpl(input))
                        dst = CK.Operator;
                    else if(CellParser.IsImmSeg(input))
                        dst = CK.Seg;
                    else if(CellParser.IsDispSeg(input))
                        dst = CK.Seg;
                    else if(CellParser.IsBfSeg(input))
                        dst = CK.Seg;
                    else if(CellParser.IsBfSpec(input))
                        dst = CK.SegSpec;
                    else if(XedParsers.IsNontermCall(input))
                        dst = CK.Nonterm;
                    else if(RuleKeyword.parse(input, out var keyword))
                        dst = CK.Keyword;
                }
                return dst;
            }


            public static RuleExprLookup CalcDefs(RuleTables rules)
            {
                var dst = dict<RuleExprKey,CellDef>();
                CalcExprLookup(rules.EncTableSpecs(), dst);
                CalcExprLookup(rules.DecTableSpecs(), dst);
                return dst;
            }


            static CellType celltype(FieldKind field, string data)
            {
                var dst =  CellType.Empty;
                dst.Field = field;
                dst.Class = @class(data);
                CellParser.parse(data, out dst.Operator);
                var spec = XedLookups.Service.FieldSpec(field);
                dst.DataType = spec.DeclaredType.Text;
                dst.EffectiveType = spec.EffectiveType.Text;
                return dst;
            }

       }
    }
}