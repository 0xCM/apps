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

    partial class XedCmdProvider
    {
        [CmdOp("xed/check/fields")]
        Outcome CheckFields(CmdArgs args)
        {

            EmitRuleExpr();

            return true;
        }

        void EmitRuleExpr()
        {
            var rules = Xed.Rules.CalcRules();
            var lookup = RuleTableCalcs.CalcExprLookup(rules);
            var specs = rules.TableSpecs().Select(x => (x.TableId, x)).ToDictionary();

            const string Sep = " | ";
            var cols = new Pairings<string,byte>(new Paired<string,byte>[]{
                ("Key", 18),
                ("TableId", 12),
                ("TableKind", 12),
                ("TableName", 32),
                ("CellKind", 16),
                ("CellType",24),
                ("Row", 8),
                ("Field", 22),
                ("Op", 8),
                ("Value", 48),
                ("Expr",48),
                ("Source",1)
                });
            var count = cols.Count;
            var widths = alloc<byte>(count);
            iteri(count, i=> seek(widths,i) = cols[i].Right);
            var slots = mapi(widths, (i,w) => RP.slot((byte)i, (short)-w));
            var names = alloc<string>(count);
            iteri(count, i => names[i] = cols[i].Left);
            var RenderPattern = slots.Intersperse(" | ").Concat();
            var header = string.Format(RenderPattern, names);

            var keys = lookup.Keys;
            var dst = text.buffer();
            dst.AppendLine(header);
            for(var i=0; i<keys.Length; i++)
            {
                ref readonly var key = ref skip(keys,i);
                var expr = lookup[key];
                dst.AppendLineFormat(RenderPattern,
                    key,
                    key.TableId.FormatHex(),
                    key.TableKind,
                    specs[key.TableId].ShortName,
                    expr.CellType.Role,
                    expr.CellType,
                    key.RowIndex,
                    XedRender.format(expr.Field),
                    expr.Operator,
                    expr.Value,
                    expr.Format(),
                    expr.Source
                    );
            }

            FileEmit(dst.Emit(),keys.Length, XedPaths.RuleTargets() + FS.file("xed.rules.expressions", FS.Csv), TextEncodingKind.Asci);
        }

        void EmitSomt()
        {
            const string RenderPattern = "{0} -> {1}";
            var cols = new string[]{"Kind", "Criterion", "Table", "Nonterminals"};
            var rules = Xed.Rules.CalcRules();
            var dst = text.buffer();
            dst.AppendLine("digraph {");
            ref readonly var tables = ref rules.Tables();
            Span<NontermKind> buffer = stackalloc NontermKind[(int)FunctionSet.MaxCount];

            for(var i=0; i<tables.Count; i++)
            {
                ref readonly var table = ref tables[i];
                var deps = table.Functions(true);
                var count = 0u;
                count = deps.Members(buffer);
                for(var j=0; j<count; j++)
                    dst.AppendLineFormat(RenderPattern, text.enquote(string.Format("{0}:{1}:{2}", table.TableKind, "A", table.Sig.ShortName)), text.enquote(XedRender.format(skip(buffer,j))));

                deps = table.Functions(false);
                count = deps.Members(buffer);
                for(var j=0; j<count; j++)
                    dst.AppendLineFormat(RenderPattern, text.enquote(string.Format("{0}:{1}:{2}", table.TableKind, "C", table.Sig.ShortName)), text.enquote(XedRender.format(skip(buffer,j))));
            }

            dst.AppendLine("}");

            FileEmit(dst.Emit(),tables.Count, XedPaths.RuleTargets() + FS.file("xed.rules.nonterms", FS.Dot), TextEncodingKind.Asci);

        }
        void EmitOpNonTerminals()
        {
            var patterns = Xed.Rules.CalcInstPatterns();
            var nonterms = FunctionSet.Empty;
            var buffer = list<Nonterminal>();
            var output = text.buffer();
            var counter = 0u;
            for(var i=0; i<patterns.Count; i++)
            {
                buffer.Clear();
                nonterms = nonterms.Clear();
                ref readonly var pattern = ref patterns[i];
                var count = pattern.NontermOps(ref nonterms);
                if(count != 0)
                {
                    nonterms.Members(k => buffer.Add(k));
                    for(var j=0; j<buffer.Count; j++)
                    {
                        output.AppendLineFormat("{0,-18} | {1,-28} | {2}", pattern.Classifier, pattern.OpCode, buffer[j]);
                        counter++;
                    }
                }
            }

            FileEmit(output.Emit(), counter, XedPaths.Targets() + FS.file("xed.nonterms.ops", FS.Csv), TextEncodingKind.Asci);

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

        void EmitRuleFieldDeps()
        {
            var rules = Xed.Rules.CalcRules();
            var dst = text.buffer();
            ref readonly var tables = ref rules.Tables();
            var count =z8;

            for(var i=0; i<tables.Count; i++)
            {
                ref readonly var table = ref tables[i];
                var source = table.Deps(true);
                var target = table.Deps(false);

                dst.AppendLineFormat("{0}:{1}{2} -> {3}", table.TableKind, table.Sig.ShortName, source, target);
            }

            FileEmit(dst.Emit(),tables.Count, XedPaths.RuleTargets() + FS.file("xed.rules.fields", FS.Txt), TextEncodingKind.Asci);
        }

        void CheckFields0()
        {
            var p = FieldPotential.create();
            ref readonly var regs = ref p.Regs;
            for(var i=0; i<regs.Count; i++)
            {
                ref readonly var reg = ref regs[i];
                Write(reg.ToString());

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