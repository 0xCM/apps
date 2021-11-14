//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System;

    using static core;
    using static WsAtoms;
    using static AsmOperands;
    using static ProjectScriptNames;

    partial class AsmCmdService
    {
        [CmdOp(".asm-gen")]
        Outcome AsmGen(CmdArgs args)
        {
            var result = Outcome.Success;
            var project = Ws.Project("mc.models");
            var path = project.SrcFile("asm", "bsf", FileKind.Asm);
            using var writer = path.AsciWriter();
            r16 a = AsmRegOps.ax;
            r16 b = AsmRegOps.ax;
            writer.WriteLine("bsf_r16_r16:");
            for(var i=0; i<16; i++, a++)
            {
                for(var j=0; j<16; j++, b++)
                {
                    if(i != j)
                        writer.WriteLine(AsmStatements.bsf(a,b));
                }

            }

            RunProjectScript(project, path, McBuild);

            return result;
        }

        [CmdOp(".asm-cc")]
        Outcome DocCc(CmdArgs args)
        {
            const string Pattern = "{0,-4} rel{1} [{2}:{3}b] => {4}";
            var result = Outcome.Success;
            var jcc8 = Ws.Tables().Subdir(machine) + FS.file("jcc8", FS.Txt);
            EmitConditionDocs(Conditions.jcc8(), jcc8);
            using var jcc8Reader = jcc8.AsciLineReader();
            while(jcc8Reader.Next(out var line))
                Write(text.format(line.Codes));

            var jcc32 = Ws.Tables().Subdir(machine) + FS.file("jcc32", FS.Txt);
            EmitConditionDocs(Conditions.jcc32(), jcc32);
            using var jcc32Reader = jcc32.AsciLineReader();
            while(jcc32Reader.Next(out var line))
                Write(text.format(line.Codes));

            return result;
        }

        uint EmitConditionDocs<T>(ReadOnlySpan<T> src, FS.FilePath dst)
            where T : IConditional
        {
            using var writer = dst.AsciWriter();
            var count = src.Length;
            var counter = 0u;
            for(var i=0; i<count; i++)
            {
                ref readonly var info = ref skip(src,i);
                writer.WriteLine(info.Format(false));
                counter++;
                if(!info.Identical)
                {
                    writer.WriteLine(info.Format(true));
                    counter++;
                }
            }
            Emitted(dst);
            return counter;
        }
    }
}