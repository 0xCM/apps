//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System;

    using static core;

    public class SdmSigOpRules : AppService<SdmSigOpRules>
    {
        Productions DecompRules;

        Productions ExpansionRules;

        public SdmSigOpRules()
        {

        }

        protected override void OnInit()
        {
            LoadRules();
        }

        void LoadRules()
        {
            DecompRules = Rules.productions(ProjectDb.Settings("asm.sigs.decomp", FS.ext("map")));
            ExpansionRules = Rules.productions(ProjectDb.Settings("asm.sigs.expansions", FS.ext("map")));
        }

        public Index<SdmOpCodeSig> DecomposeSigs(ReadOnlySpan<SdmSigOpCode> codes)
        {
            var records = list<SdmOpCodeSig>();
            var count = codes.Length;
            var seq =0u;
            foreach(var code in codes)
            {
                foreach(var decomp in Decompose(code))
                {
                    var record = new SdmOpCodeSig();
                    record.Seq = seq++;
                    record.Sig = decomp.Sig;
                    record.OpCode = decomp.OpCode;
                    var __count = decomp.Sig.OperandCount;
                    var __operands = decomp.Sig.Operands();
                    switch(__count)
                    {
                        case 4:
                            record.Op3 = skip(__operands,3);
                            record.Op2 = skip(__operands,2);
                            record.Op1 = skip(__operands,1);
                            record.Op0 = skip(__operands,0);
                            break;
                        case 3:
                            record.Op3 = AsmSigOpExpr.Empty;
                            record.Op2 = skip(__operands,2);
                            record.Op1 = skip(__operands,1);
                            record.Op0 = skip(__operands,0);
                            break;
                        case 2:
                            record.Op3 = AsmSigOpExpr.Empty;
                            record.Op2 = AsmSigOpExpr.Empty;
                            record.Op1 = skip(__operands,1);
                            record.Op0 = skip(__operands,0);
                            break;
                        case 1:
                            record.Op3 = AsmSigOpExpr.Empty;
                            record.Op2 = AsmSigOpExpr.Empty;
                            record.Op1 = AsmSigOpExpr.Empty;
                            record.Op0 = skip(__operands,0);
                            break;
                    }

                    records.Add(record);
                }
            }

            return records.ToArray();
        }

        Index<SdmSigOpCode> Decompose(in SdmSigOpCode entry)
        {
            var opcount = entry.Sig.Operands().Length;
            var sigops = ExprSets(entry);
            var sigbase = entry.Sig;
            for(byte j=0; j<opcount; j++)
                sigbase = sigbase.WithOperand(j, sigops[j].Expressions.First);

            var buffer = hashset<SdmSigOpCode>();
            for(byte j=0; j<opcount; j++)
            {
                var dstops = sigops[j].Expressions;
                for(var k=0; k<dstops.Count; k++)
                {
                    ref readonly var dstop = ref dstops[k];
                    buffer.Add(new SdmSigOpCode(sigbase.WithOperand(j, dstop), entry.OpCode));
                }
            }

            return buffer.Array().Sort();
        }

        AsmSigOpExprSets ExprSets(in SdmSigOpCode entry)
        {
            var dst = new AsmSigOpExprSets();
            ref readonly var sig = ref entry.Sig;
            ref readonly var opcode = ref entry.OpCode;
            var operands = sig.Operands();
            var opcount = operands.Length;
            for(byte j=0; j<opcount; j++)
            {
                ref readonly var opexpr = ref skip(operands,j);
                dst.Include(j, DecomposeExpr(opexpr));
            }
            return dst;
        }

        Index<AsmSigOpExpr> DecomposeExpr(AsmSigOpExpr src)
        {
            var names = core.array(src.Text);
            if(DecompRules.Find(src.Text, out var decomp))
                names = decomp;
            return names.Map(x => (AsmSigOpExpr)x);
        }
    }
}