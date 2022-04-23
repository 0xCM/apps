//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;

    using static XedRules;
    using static XedModels;
    using static core;

    using FK = XedRules.InstFieldKind;

    partial class XedCmdProvider
    {
        public static KeyedCellRecord record(uint seq, in KeyedCell src)
        {
            ref readonly var field = ref src.Value;
            ref readonly var key = ref src.Key;
            var dst = KeyedCellRecord.Empty;
            ref readonly var fk = ref field.FieldKind;
            ref readonly var dk = ref src.Value.DataKind;
            dst.Seq = seq;
            dst.CellIndex = key.CellIndex;
            dst.Field = fk;
            dst.Logic = key.Logic;
            dst.RowIndex = key.RowIndex;
            dst.TableName = key.TableSig.TableName;
            dst.TableKind = key.TableSig.TableKind;
            dst.TableId = key.TableId;
            if(fk == 0 && dk != FK.Operator)
            {

            }
            switch(src.Value.DataKind)
            {
                case FK.EqExpr:
                case FK.NeqExpr:
                case FK.NontermExpr:
                {
                    var expr = field.ToFieldExpr();
                    dst.Op = expr.Operator;
                    dst.Value = expr.Value;
                }
                break;

                case FK.BitLiteral:
                    dst.Value = field.AsBitLit();
                break;

                case FK.IntLiteral:
                    dst.Value = field.AsIntLit();
                break;

                case FK.HexLiteral:
                    dst.Value = field.AsHexLit();
                break;

                case FK.SegVar:
                    dst.Value = field.AsSegVar();
                break;

                case FK.Keyword:
                    dst.Value = field.AsKeyword();
                break;

                case FK.NontermCall:
                    dst.Value = field.AsNonterminal();
                break;

                case FK.Operator:
                    dst.Op = field.AsOperator();
                    dst.Value = EmptyString;
                break;

                case FK.SegField:
                    dst.Value = field.AsSegField();
                break;
            }



            return dst;
        }

        public static Index<KeyedCellRecord> records(SortedLookup<RuleSig,Index<KeyedCell>> src)
        {
            var dst = list<KeyedCellRecord>();
            var k=0u;
            var sigs = src.Keys;
            for(var i=z16; i<sigs.Length; i++)
            {
                ref readonly var sig = ref skip(sigs,i);
                if(src.Find(sig, out var cells))
                {
                    for(var j=z16; j<cells.Count; j++, k++)
                        dst.Add(record(k, cells[j]));
                }
            }

            return dst.ToIndex();
        }


        [CmdOp("xed/check/rules")]
        Outcome CheckLayouts(CmdArgs args)
        {
            var rules = Xed.Rules.CalcRules();
            var lookup = Xed.Rules.CalcRuleFields(rules);
            var src = records(lookup);
            TableEmit(src.View, KeyedCellRecord.RenderWidths, XedPaths.RuleTable<KeyedCellRecord>());

            // var inst = CalcInstSegs();
            // iter(inst, x => Write(x));
            return true;
        }

        Index<SegField> CalcInstSegs()
        {
            var patterns = Xed.Rules.CalcInstPatterns();
            var layouts = Xed.Rules.CalcInstLayouts(patterns);
            var literals = hashset<SegField>();
            var symbolics = hashset<SegField>();
            var combined = hashset<SegField>();
            for(var i=0; i<layouts.Count; i++)
            {
                ref readonly var layout = ref layouts[i];
                ref readonly var fields = ref layout.Fields;
                for(var j=0; j<fields.Count; j++)
                {
                    ref readonly var field = ref fields[j];
                    if(field.IsSeg)
                    {
                        ref readonly var seg = ref field.AsSeg();
                        combined.Add(seg);
                        if(seg.IsLiteral)
                            literals.Add(seg);
                        else
                            symbolics.Add(seg);
                    }
                }
            }

            var symbolic = symbolics.Array().Sort();
            var literal = literals.Array().Sort();
            var result = combined.Array().Sort();
            return result;
        }
        void CheckSegs()
        {
            var regVal = seg(FieldKind.REG,(uint3)0b010);
            Write(regVal.Format());

            var regVar = seg(FieldKind.REG,'r', 'r', 'r');
            Write(regVar.Format());

            var modVal = seg(FieldKind.MOD,(uint2)0b11);
            Write(modVal.Format());

            var modVar = seg(FieldKind.MOD, 'm', 'm');
            Write(modVar.Format());

            var rmVar = seg(FieldKind.RM,'n','n','n');
            Write(rmVar.Format());

            var rmVal= seg(FieldKind.RM,(uint3)0b011);
            Write(rmVal.Format());
        }

        void CheckNonTerms2()
        {
            //var dst = Nonterminals.create();
            var src = Symbols.index<NontermKind>();
            var kinds = src.Kinds;
            var dst = FunctionSet.init(kinds);
            var buffer = alloc<NontermKind>(FunctionSet.MaxCount);
            var count = dst.Members(buffer);
            for(var i=0; i<kinds.Length; i++)
            {
                ref readonly var kind = ref skip(kinds,i);
                if(kind != 0)
                    Require.invariant(dst.Contains(kind));
            }

            var smaller = slice(kinds,100,150);
            dst = smaller;
            for(var i=0; i<FunctionSet.MaxCount; i++)
            {
                var min = skip(smaller,0);
                var max = skip(smaller,smaller.Length - 1);
                var kind = (NontermKind)i;
                if(kind != 0)
                {
                    if(kind >= min & kind<= max)
                        Require.invariant(dst.Contains(kind));
                    else
                        Require.invariant(!dst.Contains(kind));
                }
            }
        }

        [CmdOp("gen/bits/patterns")]
        Outcome GenBitfield(CmdArgs args)
        {
            var modrm = BitfieldPatterns.infer(ModRm.BitPattern);
            Write(modrm.Descriptor);

            var rex = BitfieldPatterns.infer(RexPrefix.BitPattern);
            Write(rex.Descriptor);

            var vexC4 = BitfieldPatterns.infer(VexPrefixC4.BitPattern);
            Write(vexC4.Descriptor);

            var vexC5 = BitfieldPatterns.infer(VexPrefixC5.BitPattern);
            Write(vexC5.Descriptor);

            var sib = BitfieldPatterns.infer(Sib.BitPattern);
            Write(sib.Descriptor);

            byte data = 0b10_110_011;
            Write(BitfieldPatterns.bitstring(sib, data));
            return true;
        }
    }
}