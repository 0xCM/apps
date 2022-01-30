//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;
    using System;

    using static core;

    partial class CodeGenProvider
    {
        static AsmBlockSpec block(in SdmSigOpCode src)
        {
            const string Content = "    ret\n\n";
            var comment = asm.comment(string.Format("{0} | {1}", src.Sig.Format(), src.OpCode.Format()));
            var label = asm.label(AsmForm.identify(AsmFormExpr.define(src.Sig, src.OpCode)));
            return AsmBlockSpec.define(comment, label, Content);
        }

        static Index<AsmComment> comments(ReadOnlySpan<SdmSigOpCode> sigs)
        {
            var formatted = map(sigs, sig => sig.Sig.Format());
            var len = formatted.Select(f => f.Length).Max();
            var pattern = RP.pad(-len - 2) + " | {1}";
            return map(sigs, sig => asm.comment(string.Format(pattern, sig.Sig.Format(), sig.OpCode.Format())));
        }

        static Index<AsmBlockSpec> blocks(ReadOnlySpan<SdmSigOpCode> sigs)
        {
            var count = sigs.Length;
            var dst = alloc<AsmBlockSpec>(count);
            for(var i=0; i<count; i++)
            {
                seek(dst,i) = block(skip(sigs,i));
            }

            return dst;
        }

        [CmdOp("gen/asm/files")]
        Outcome GenAsmFiles(CmdArgs args)
        {
            // const uint Max = 256;
            // var running = Running();
            // var g = CodeGen.AsmFiles();
            // var src = SdmRules.LoadSigProductions();
            // var count = src.Count;
            // var mnemonic = src.First.Target.Mnemonic;
            // var buffer = span<SdmSigOpCode>(Max);
            // var counter = 0u;
            // var content = text.buffer();
            // var outdir = ProjectDb.Logs() + FS.folder("asm");


            // FS.FilePath Emit(AsmMnemonic mnemonic, ReadOnlySpan<SdmSigOpCode> sigs)
            // {
            //     var file = AsmFiles.specify(mnemonic.Format(), blocks(sigs));
            //     return g.Emit(file, outdir);
            // }

            // for(var i=0; i<count && counter < Max; i++)
            // {
            //     ref readonly var sig = ref src[i];
            //     var m = sig.Target.Mnemonic;
            //     if(m != mnemonic)
            //     {
            //         if(counter != 0)
            //         {
            //             Babble(AppMsg.EmittedFile.Format(Emit(mnemonic, slice(buffer,0,counter))));
            //             mnemonic = m;
            //             buffer.Clear();
            //             counter = 0;
            //             seek(buffer,counter++) = sig;
            //         }
            //     }
            //     else
            //     {
            //         seek(buffer, counter++) = sig;
            //     }
            // }

            // if(counter != 0)
            //     Babble(AppMsg.EmittedFile.Format(Emit(mnemonic, slice(buffer,0,counter))));

            // Ran(running);

            return true;
        }
    }
}