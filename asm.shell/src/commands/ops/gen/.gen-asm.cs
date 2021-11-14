//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    partial class AsmCmdService
    {
        Outcome GenAsm(CmdArgs args)
        {
            const string mnemonic = "kandb";
            const string RenderPattern = mnemonic + " {0}";

            var dst = Ws.Projects().SrcDir("asm") + FS.file(mnemonic, FS.Asm);
            using var writer = dst.AsciWriter();
            writer.WriteLine("bits 64");

            // a in RCX, b in RDX, c in R8, d in R9
            var counter = 0u;
            var r0 = RegSets.MaskRegs();
            var r1 = r0.Replicate();
            var r2 = r0.Replicate();
            for(var i=0u; i<r0.Count; i++)
            for(var j=0u; j<r1.Count; j++)
            for(var k=0u; k<r2.Count; k++)
            {
                if(i==0)
                    continue;

                if(i == j && j == k)
                    continue;

                var asm = string.Format(RenderPattern, format(r0[i], r1[j], r2[k]));
                writer.WriteLine(asm);
                counter++;
            }
            Write(EmittedInstructions.Format(counter,dst));
            return true;
        }

        Outcome GenAsm2(CmdArgs args)
        {
            const string AsmPattern = "{0} {1},{2}";
            const string LabelPattern = "{0}:";
            const string SectionPattern = "{0}";
            const string TextSection = ".text";
            const string McSyntax = "mc";
            const string MlSyntax = "ml";
            const string NasmSyntax = "nasm";
            const string CommentPattern = "# {0}";

            var ocinfo = "BSR(r16,r/m16) = 0F BD /r";
            var result = Outcome.Success;
            var asmid = "bsr";
            var label = "bsr_r16_r16";
            var syntax = McSyntax;
            var w0 = NativeSizeCode.W16;
            var w1 = NativeSizeCode.W16;
            var r0 = RegSets.GpRegs(w0);
            var r1 = RegSets.GpRegs(w1);
            var dst = Ws.Projects().SrcDir("asm") + FS.file(asmid, FS.Asm);
            var indent = 0u;
            var buffer = text.buffer();
            buffer.AppendLine(string.Format(SectionPattern, TextSection));
            buffer.AppendLine();
            buffer.AppendLineFormat(CommentPattern, ocinfo);
            buffer.AppendLine(string.Format(LabelPattern,label));

            indent += 4;
            for(var i=0u; i<r0.Count; i++)
            for(var j=0u; j<r1.Count; j++)
            {
                buffer.IndentLine(indent, string.Format(AsmPattern, asmid, r0[i], r1[j]));
            }

            indent -= 4;

            dst.Overwrite(buffer.Emit(), TextEncodingKind.Asci);

            Emitted(dst);

            //OmniScript.RunAsmScript(asmid, ToolScriptId.mc, true, out var flows);

            return result;
        }


        static string format(RegOp op0, RegOp op1, RegOp op2)
            => string.Format("{0},{1},{2}", op0, op1, op2);
    }
}