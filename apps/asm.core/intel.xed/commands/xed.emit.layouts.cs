//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;

    using static XedRules;
    using static XedModels;
    using static Datasets;
    using static core;

    partial class XedCmdProvider
    {
        [CmdOp("xed/emit/layouts")]
        Outcome EmitLayouts(CmdArgs args)
        {
            var patterns = Xed.Rules.CalcInstPatterns();
            var groups = Xed.Rules.CalcInstGroups(patterns);
            var layouts = Xed.Rules.CalcInstLayouts(groups);
            Xed.Rules.EmitInstLayouts(layouts);
            return true;
        }

        [CmdOp("xed/check/layouts")]
        Outcome CheckLayouts(CmdArgs args)
        {
            var inst = CalcInstSegs();
            iter(inst, x => Write(x));
            var rules = CalcRuleSegs();
            return true;
        }

        [CmdOp("xed/emit/cells")]
        Outcome EmitRuleCells(CmdArgs args)
        {
            var cols = new TableColumns(
                ("TableId", 10),
                ("TableKind", 10),
                ("TableName", 32),
                ("RowIndex", 10),
                ("CellIndex", 10),
                ("Type", 24),
                ("Field", 22),
                ("Op", 4),
                ("Value", 16)
                );

            var dst = text.buffer();
            var buffer = cols.Buffer();
            buffer.EmitHeader(dst);
            var rules = Xed.Rules.CalcRules();
            var tables = rules.TableSpecs().Select(x => (x.TableId, x)).ToDictionary();
            var cells = rules.CalcCellLookup();
            var keys = cells.Keys;
            var tid = z16;
            var segvars = hashset<Seg>();
            //var segspecs =
            for(var i=0; i<keys.Length; i++)
            {
                ref readonly var key = ref skip(keys,i);
                if(i != 0)
                {
                    if(key.TableId != tid)
                    {
                        tid = key.TableId;
                        segvars.Clear();
                    }
                }


                var logic = key.Logic;
                var cell = cells[key];
                var type = cell.Type;
                if(type.Class.IsSegVar)
                {
                    if(CellParser.parse(cell.Data, out Seg seg))
                        segvars.Add(seg);
                    else
                    {
                        Error(cell.Data);
                        break;
                    }
                }
                if(type.Class.IsString)
                {
                    if(segvars.Count != 0 && logic.IsConsequent)
                    {

                    }
                }
                var table = tables[tid];
                buffer.Write(tid);
                buffer.Write(table.TableKind);
                buffer.Write(table.TableName);
                buffer.Write(key.RowIndex);
                buffer.Write(key.CellIndex);
                buffer.Write(type);
                buffer.Write(XedRender.format(cell.Field));
                buffer.Write(cell.Operator);
                buffer.Write(cell);
                buffer.EmitLine(dst);
            }

            FileEmit(dst.Emit(), keys.Length, XedPaths.RuleTargets() + FS.file("xed.rules.cells", FS.Csv), TextEncodingKind.Asci);


            return true;
        }
        Index<Seg> CalcRuleSegs()
        {
            var segs = hashset<Seg>();
            var rules = Xed.Rules.CalcRules();
            var tables = rules.TableSpecs().Select(x => (x.TableId, x)).ToDictionary();
            var cells = rules.CalcCellLookup();
            var keys = cells.Keys;
            for(var i=0; i<keys.Length; i++)
            {
                ref readonly var key = ref skip(keys,i);
                var cell = cells[key];
                var table = tables[key.TableId];
            }
            return segs.Array().Sort();
        }
        Index<Seg> CalcInstSegs()
        {
            var layouts = Xed.Rules.CalcInstLayouts();
            var literals = hashset<Seg>();
            var symbolics = hashset<Seg>();
            var combined = hashset<Seg>();

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
            var regVal = seg(n3, FieldKind.REG,0b010);
            Write(regVal.Format());

            var regVar = seg(FieldKind.REG,'r', 'r', 'r');
            Write(regVar.Format());

            var modVal = seg(n2,FieldKind.MOD,0b11);
            Write(modVal.Format());

            var modVar = seg(FieldKind.MOD, 'm', 'm');
            Write(modVar.Format());

            var rmVar = seg(FieldKind.RM,'n','n','n');
            Write(rmVar.Format());

            var rmVal= seg(n3,FieldKind.RM,0b011);
            Write(rmVal.Format());
        }

        void CheckFieldSets()
        {
            var data = XedFields.fields();
            data.Update(FieldKind.REG1, XedRegId.AX);
            data.Update(FieldKind.REG4, XedRegId.BX);
            data.Update(FieldKind.REG8, XedRegId.DX);

            var members = ByteBlock128.Empty;
            var kinds = recover<FieldKind>(members.Bytes);
            var count = data.Members().Members(kinds);
            for(var i=0; i<count; i++)
            {
                ref readonly var kind = ref skip(kinds,i);
                ref readonly var field = ref data[kind];
                Write(string.Format("{0}:{1}", kind, field.Format()));
            }
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