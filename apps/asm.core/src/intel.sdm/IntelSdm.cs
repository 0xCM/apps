//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System;

    using Asm;

    using static core;

    [ApiHost]
    public partial class IntelSdm : AppService<IntelSdm>
    {
        CharMapper CharMapper;

        IntelSdmPaths SdmPaths;

        TextMap SigOpNormal;

        TextMap SigOpProd;

        Productions SigAtomics;

        Productions SigDecomp;

        protected override void OnInit()
        {
            CharMapper = Wf.CharMapper();
            SdmPaths = IntelSdmPaths.create(Wf);
            SigOpNormal = rules.textmap(ProjectDb.Settings("asm.sigs.normal", FS.ext("map")));
            SigOpProd = rules.textmap(ProjectDb.Settings("asm.sigs.productions", FS.ext("map")));
            SigAtomics = rules.productions(ProjectDb.Settings("asm.sigs.atomics", FS.ext("map")));
        }

        public void ClearTargets()
        {
            SdmPaths.Targets().Clear();
        }

        void LoadSigDecomp()
        {
            SigDecomp = rules.productions(ProjectDb.Settings("asm.sigs.decomp", FS.ext("map")));
        }

        public void EmitOpCodeSigs()
        {
            var records = list<SdmOpCodeSig>();
            LoadSigDecomp();
            var codes = LoadImportedOpCodes();
            var count = codes.Count;
            var dst = ProjectDb.TablePath<SdmOpCodeSig>("sdm");
            //var emitting = EmittingFile(dst);
            var seq =0u;
            //using var writer = dst.AsciWriter();
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
                    //writer.WriteLine(format(decomp));
                }
            }

            //EmittedFile(emitting,count);

            TableEmit(records.ViewDeposited(), SdmOpCodeSig.RenderWidths, ProjectDb.TablePath<SdmOpCodeSig>("sdm"));

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
        }

        Index<AsmSigOpExpr> Decompose(AsmSigOpExpr src)
        {
            var names = core.array(src.Text);
            if(SigDecomp.Find(src.Text, out var decomp))
                names = decomp;
            return names.Map(x => (AsmSigOpExpr)x);
        }

        static bool composite(AsmSigOpExpr src)
        {
            if(text.contains(src.Text,Chars.FSlash))
                return true;
            return false;
        }

        Index<SdmSigOpCode> Decompose(in SdmSigOpCode entry)
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
                    ops[j] = Decompose(op);
                }
                else
                    ops[j] = array(op);
            }

            var total = ops.Map(x => x.Value.Count).Sum();
            var buffer = alloc<SdmSigOpCode>(total);
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

                    ref var dst = ref seek(buffer,i++);
                    dst = entry;
                    sigbase = sigbase.WithOperand(j, dstop);
                    dst.Sig = sigbase;
                }
            }
            return buffer;
        }

        public Outcome Import()
        {
            var result = Outcome.Success;

            try
            {
                ClearTargets();

                ImportOpCodes();

                result = EmitCharMaps();
                if(result.Fail)
                    return result;

                result = ImportVolume(1);
                if(result.Fail)
                    return result;

                result = ImportVolume(2);
                if(result.Fail)
                    return result;

                result = ImportVolume(3);
                if(result.Fail)
                    return result;

                result = ImportVolume(4);
                if(result.Fail)
                    return result;

                result = EmitSdmSplits();
                if(result.Fail)
                    return result;

                result = EmitCombinedToc();
                if(result.Fail)
                    return result;

                result = EmitTocRecords();
                if(result.Fail)
                    return result;

            }
            catch(Exception e)
            {
                result = e;
            }

            return result;
        }
    }
}