//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System;
    using System.Collections.Generic;

    using static core;
    using static Root;

    public class SdmSigOpRules : AppService<SdmSigOpRules>
    {
        Productions DecompRules;

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
            Normalizations = Rules.textmap(SdmPaths.SigNormalRules());
            OpMaskRules = Rules.productions(SdmPaths.SigOpMaskRules());
        }

        public Index<SdmSigOpCode> EmitSigDecomps(ReadOnlySpan<SdmOpCodeDetail> details)
        {
            var records = dict<Identifier,SdmSigOpCode>();
            var codes = details.Select(x => SdmOps.form(x));
            var count = codes.Length;
            var seq = 0u;
            var dupSeq = 0u;
            var dupes = list<SdmSigOpCode>();

            foreach(var code in codes)
            {
                foreach(var decomp in Decompose(code))
                {
                    var record = new SdmSigOpCode();
                    var identity = AsmSigs.identify(asm.form(decomp.Sig, decomp.OpCode));
                    record.Identity = identity;
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

                    if(!records.TryAdd(record.Identity, record))
                        dupes.Add(record);
                }
            }

            var dataset = records.Values.Array().Sort();
            for(var i=0u; i<dataset.Length; i++)
                seek(dataset,i).Seq = i;
            TableEmit(@readonly(dataset), SdmSigOpCode.RenderWidths, SdmPaths.SigDecompTable());

            if(dupes.Count != 0)
            {
                var _dupes = dupes.Array().Sort();
                for(var i=0u; i<_dupes.Length; i++)
                    seek(_dupes,i).Seq = i;

                TableEmit(@readonly(_dupes), SdmSigOpCode.RenderWidths, SdmPaths.SigDuplicateTable());
            }
            return dataset;
        }

        public AsmSigRule<IRuleExpr> Symbolize(in AsmSigExpr src)
        {
            var ops = SymbolizeOperands(src);
            var dst = AsmSigs.rule<IRuleExpr>(src.Mnemonic, (byte)ops.EntryCount);
            for(byte i=0; i<ops.EntryCount; i++)
                dst = dst.WithOperand(i, ops[i]);
            return dst;
        }

        ConstLookup<byte,IRuleExpr> SymbolizeOperands(in AsmSigExpr sig)
        {
            var opcount = sig.OperandCount;
            var dst = dict<byte,Index<string>>();
            var operands = sig.Operands();
            for(byte i=0; i<opcount; i++)
            {
                ref readonly var op = ref skip(operands,i);
                if(DecompRules.Find(op.Text, out var choices))
                    dst[i] = choices;
                else
                    dst[i] = array(op.Text);
            }

            return SymbolizeOpMasks(dst);
        }

        ConstLookup<byte,IRuleExpr> SymbolizeOpMasks(ConstLookup<byte,Index<string>> src)
        {
            var opcount = src.EntryCount;
            var dst = dict<byte,IRuleExpr>();
            var i = z8;
            foreach(var entry in src.Entries)
            {
                var input = entry.Value;
                var output = DecomposeOpMasks(input);
                if(input.Count == 1 && output.Count == 2)
                {
                    dst[i++] = Rules.value(output[0]);
                    dst[i++] = Rules.option(output[1]);
                }
                else
                {
                    dst[i++] = input.Count > 1 ? Rules.choices(input) : Rules.value(input.First);
                }
            }
            return dst;
        }

        Index<string> DecomposeOpMasks(Index<string> src)
        {
            var dst = list<string>();
            foreach(var item in src)
            {
                if(OpMaskRules.Find(item, out var decomp))
                    dst.AddRange(decomp);
                else
                    dst.Add(item);
            }

            return dst.Array();
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