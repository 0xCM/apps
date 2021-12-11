//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;
    using System;

    using static core;

    partial class GlobalCommands
    {
        [CmdOp("api/emit/asmdocs")]
        Outcome EmitAsmDocs(CmdArgs args)
        {
            EmitRexDocs();
            EmitSibDocs();
            EmitModRmDocs();
            EmitConditionDocs();
            return true;
        }

        void EmitRexDocs()
        {
            var dst = ProjectDb.Subdir("asm/docs") + FS.file("asm.docs.rex", FS.ext("bits") + FS.Csv);
            var emitting = EmittingFile(dst);
            var bits = RexPrefix.Range();
            using var writer = dst.AsciWriter();
            var buffer = text.buffer();
            var count = AsmPrefix.RexTable(buffer);
            writer.Write(buffer.Emit());
            EmittedFile(emitting,count);
        }

        void EmitSibDocs()
        {
            var result = Outcome.Success;
            var path = ProjectDb.Subdir("asm/docs") + FS.file("asm.docs.sib", FS.ext("bits") + FS.Csv);
            var rows = AsmBits.SibRows().View;
            TableEmit(rows, SibBitfieldRow.RenderWidths, path);
        }

        void EmitModRmDocs()
        {
            var path = ProjectDb.Subdir("asm/docs") + FS.file("asm.docs.modrm", FS.ext("bits") + FS.Csv);
            var flow = Wf.EmittingFile(path);
            using var writer = path.AsciWriter();
            var dst = span<char>(256*128);
            var count = AsmBits.ModRmTable(dst);
            var rendered = slice(dst,0,count);
            writer.Write(rendered);
            Wf.EmittedFile(flow,count);
        }

        FS.FolderPath AsmDocs()
            => ProjectDb.Subdir("asmdocs");

        void EmitConditionDocs()
        {
            var db = AsmDocs();
            var jcc8 = db + FS.file("jcc8", FS.Txt);
            EmitConditionDocs(Conditions.jcc8(), jcc8);
            using var jcc8Reader = jcc8.AsciLineReader();
            while(jcc8Reader.Next(out var line))
                Write(text.format(line.Codes));

            var jcc32 = db + FS.file("jcc32", FS.Txt);
            EmitConditionDocs(Conditions.jcc32(), jcc32);
            using var jcc32Reader = jcc32.AsciLineReader();
            while(jcc32Reader.Next(out var line))
                Write(text.format(line.Codes));
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