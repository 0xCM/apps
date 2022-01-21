//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System;

    using static Root;
    using static core;

    partial class IntelSdm
    {
        public void EmitSigDecomps()
        {
            var records = list<SdmOpCodeSig>();
            var decompRules = Rules.productions(ProjectDb.Settings("asm.sigs.decomp", FS.ext("map")));
            var codes = LoadImportedSigOpCodes();
            var count = codes.Count;
            var seq =0u;
            foreach(var code in codes)
            {
                foreach(var decomp in DecomposeEntry(code))
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

            TableEmit(records.ViewDeposited(), SdmOpCodeSig.RenderWidths, ProjectDb.TablePath<SdmOpCodeSig>("sdm", "decomposed"));

            static string format(in SdmSigOpCode entry)
            {
                var dst = text.buffer();
                ref readonly var sig = ref entry.Sig;
                ref readonly var opcode = ref entry.OpCode;
                var operands = sig.Operands();
                var count = operands.Length;
                dst.AppendLine(string.Format("## {0,-36}", sig.Format()));
                dst.AppendLine(string.Format("   {0}", opcode.Expr.Format()));
                for(var j=0; j<count; j++)
                {
                    ref readonly var op = ref skip(operands,j);
                        dst.AppendLine(string.Format("       {0} | {1}", j, op.Format()));
                }
                return dst.Emit();
            }

            static bool composite(AsmSigOpExpr src)
            {
                if(text.contains(src.Text, Chars.FSlash))
                    return true;
                return false;
            }

            Index<AsmSigOpExpr> DecomposeExpr(AsmSigOpExpr src)
            {
                var names = core.array(src.Text);
                if(decompRules.Find(src.Text, out var decomp))
                    names = decomp;
                return names.Map(x => (AsmSigOpExpr)x);
            }


            Index<SdmSigOpCode> DecomposeEntry(in SdmSigOpCode entry)
            {
                ref readonly var sig = ref entry.Sig;
                ref readonly var opcode = ref entry.OpCode;
                var operands = sig.Operands();
                var opcount = operands.Length;
                var ops = dict<byte,Index<AsmSigOpExpr>>();

                for(byte j=0; j<opcount; j++)
                {
                    ref readonly var op = ref skip(operands,j);
                    if(composite(op))
                    {
                        ops[j] = DecomposeExpr(op);
                    }
                    else
                        ops[j] = array(op);
                }

                var total = ops.Map(x => x.Value.Count).Sum();
                var buffer = alloc<SdmSigOpCode>(total);
                var _buffer = hashset<SdmSigOpCode>();
                var i=0;
                var sigbase = entry.Sig;
                for(byte j=0; j<opcount; j++)
                {
                    var dstops = ops[j];
                    sigbase = sigbase.WithOperand(j, dstops.First);
                }

                for(byte j=0; j<opcount; j++)
                {
                    var dstops = ops[j];
                    for(var k=0; k<dstops.Count; k++)
                    {
                        ref readonly var dstop = ref dstops[k];
                        var dst = seek(buffer,i++);
                        dst.Sig = sigbase.WithOperand(j, dstop);
                        dst.OpCode = entry.OpCode;
                        _buffer.Add(dst);
                    }
                }

                return _buffer.Array().Sort();
            }
        }
    }
}