//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System;
    using System.Collections.Generic;

    using static core;

    public class SdmSigOpRules : AppService<SdmSigOpRules>
    {
        Productions DecompRules;

        Productions Expansions;

        TextMap Normalizations;

        Productions OpMaskRules;

        IntelSdmPaths SdmPaths => Service(Wf.SdmPaths);

        AsmOpMasks OpMasks;

        public SdmSigOpRules()
        {
            OpMasks = new();
        }

        protected override void OnInit()
        {
            LoadRules();
        }

        void LoadRules()
        {
            DecompRules = Rules.productions(SdmPaths.SigDecompRules());
            Expansions = Rules.productions(SdmPaths.SigExpansionRules());
            Normalizations = Rules.textmap(SdmPaths.SigNormalRules());
            OpMaskRules = Rules.productions(SdmPaths.SigOpMaskRules());
        }

        public Index<SdmSigOpCode> DecomposeSigs(ReadOnlySpan<AsmFormExpr> codes)
        {
            var records = hashset<SdmSigOpCode>();
            var count = codes.Length;
            var seq =0u;
            foreach(var code in codes)
            {
                foreach(var decomp in Decompose(code))
                {
                    var record = new SdmSigOpCode();
                    record.Seq = seq++;
                    record.Identity = AsmSigs.identify(asm.form(decomp.Sig,decomp.OpCode));
                    record.Sig = decomp.Sig;
                    record.OpCode = decomp.OpCode;
                    var __count = decomp.Sig.OperandCount;
                    var __operands = decomp.Sig.Operands();
                    switch(__count)
                    {
                        case 1:
                            record.Op0 = skip(__operands,0);
                            record.Op1 = AsmSigOpExpr.Empty;
                            record.Op2 = AsmSigOpExpr.Empty;
                            record.Op3 = AsmSigOpExpr.Empty;
                            record.Op4 = AsmSigOpExpr.Empty;
                            break;
                        case 2:
                            record.Op0 = skip(__operands,0);
                            record.Op1 = skip(__operands,1);
                            record.Op2 = AsmSigOpExpr.Empty;
                            record.Op3 = AsmSigOpExpr.Empty;
                            record.Op4 = AsmSigOpExpr.Empty;
                            break;
                        case 3:
                            record.Op0 = skip(__operands,0);
                            record.Op1 = skip(__operands,1);
                            record.Op2 = skip(__operands,2);
                            record.Op3 = AsmSigOpExpr.Empty;
                            record.Op4 = AsmSigOpExpr.Empty;
                            break;
                        case 4:
                            record.Op0 = skip(__operands,0);
                            record.Op1 = skip(__operands,1);
                            record.Op2 = skip(__operands,2);
                            record.Op3 = skip(__operands,3);
                            record.Op4 = AsmSigOpExpr.Empty;
                            break;
                        case 5:
                            record.Op0 = skip(__operands,0);
                            record.Op1 = skip(__operands,1);
                            record.Op2 = skip(__operands,2);
                            record.Op3 = skip(__operands,3);
                            record.Op4 = skip(__operands,4);
                            break;
                    }

                    records.Add(record);
                }
            }

            return records.Array().Sort();
        }

        string Format(in AsmFormExpr src)
        {
            var ops = src.Sig.Operands();
            var count = ops.Length;
            var dst = text.buffer();
            dst.Append(src.Sig.Mnemonic.Format());
            for(var i=0; i<count-1; i++)
            {
                ref readonly var current = ref skip(ops,i);
                ref readonly var next = ref skip(ops,i+1);
                if(OpMasks.Test(current))
                    continue;

                if(OpMasks.Test(next))
                    dst.AppendFormat("{0} {1}", current.Text, next.Text);
                else
                    dst.Append(current.Text);

            }
            if(!OpMasks.Test(skip(ops, count - 1)))
            {
                dst.Append(skip(ops, count - 1).Text);
            }

            return dst.Emit();
        }

        Index<AsmFormExpr> Decompose(in AsmFormExpr entry)
        {
            var opcount = entry.Sig.Operands().Length;
            var sigops = ExprSets(entry);
            var sigbase = entry.Sig;
            for(byte j=0; j<opcount; j++)
                sigbase = sigbase.WithOperand(j, sigops[j].Expressions.First);

            var buffer = dict<string, AsmFormExpr>(opcount);
            byte m=0;
            for(byte j=0; j<opcount; j++)
            {
                var dstops = sigops[j].Expressions;
                for(var k=0; k<dstops.Count; k++)
                {
                    ref readonly var dstop = ref dstops[k];
                    if(OpMasks.Test(dstop))
                    {
                        if(OpMasks.Split(dstop, out var x, out var y))
                        {
                            var formX = new AsmFormExpr(sigbase.WithOperand(m++, x), entry.OpCode);
                            buffer.TryAdd(formX.Format(), formX);

                            var formY = new AsmFormExpr(sigbase.WithOperand(m++, y), entry.OpCode);
                            buffer.TryAdd(formY.Format(), formY);
                        }
                    }
                    else
                    {
                        var form = new AsmFormExpr(sigbase.WithOperand(m++, dstop), entry.OpCode);
                        buffer.TryAdd(form.Format(), form);
                    }
                }
            }

            return buffer.Values.Array().Sort();
        }

        AsmSigOpExprSets ExprSets(in AsmFormExpr entry)
        {
            var dst = new AsmSigOpExprSets();
            var operands = entry.Sig.Operands();
            var opcount = operands.Length;
            for(byte j=0; j<opcount; j++)
                dst.Include(j, DecomposeExpr(skip(operands,j)));
            return dst;
        }

        Index<AsmSigOpExpr> DecomposeExpr(AsmSigOpExpr src)
        {
            var names = list<string>();
            if(DecompRules.Find(src.Text, out var decomp))
                names.AddRange(decomp);
            else
                names.Add(src.Text);

            return DecomposeOpMasks(names).Map(x => (AsmSigOpExpr)x);
        }

        List<string> DecomposeOpMasks(List<string> src)
        {
            var dst = list<string>();
            foreach(var item in src)
            {
                if(OpMaskRules.Find(item, out var decomp))
                    dst.AddRange(decomp);
                else
                    dst.Add(item);
            }

            return dst;
        }
    }
}