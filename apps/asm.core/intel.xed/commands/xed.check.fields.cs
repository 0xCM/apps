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

    partial class XedCmdProvider
    {
        [CmdOp("xed/check/fields")]
        Outcome CheckFields(CmdArgs args)
        {
            var patterns = Xed.Rules.CalcInstPatterns();
            for(var i=0; i<patterns.Count; i++)
            {
                ref readonly var pattern = ref patterns[i];
                var layout = XedPatterns.layout(pattern.Body);
                var @class = pattern.Classifier;
                var oc = pattern.OpCode;
                Write(string.Format("{0,-8} | {1,-18} | {2,-8} | {3,-18} | {4}", pattern.PatternId, @class, oc.Kind, oc.Value, layout));
            }
            return true;
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

        void ChecFieldSets()
        {
            var data = XedFields.fields();
            ref readonly var reg1 = ref data.Update(FieldKind.REG1, XedRegId.AX);
            ref readonly var reg4 = ref data.Update(FieldKind.REG4, XedRegId.BX);
            ref readonly var reg8 = ref data.Update(FieldKind.REG8, XedRegId.DX);
            var members = ByteBlock128.Empty;
            var kinds = recover<FieldKind>(members.Bytes);
            var count = data.Members().Members(kinds);
            for(var i=0; i<count; i++)
            {
                ref readonly var kind = ref skip(kinds,i);
                ref readonly var field = ref data[kind];
                Write(field.Format());
            }
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