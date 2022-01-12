//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;
    using System;

    using static core;

    partial class ApiCmdProvider
    {
        [CmdOp("api/emit/docs")]
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
            var dst = ApiDoc("asm.docs.rex", FS.ext("bits") + FS.Csv);
            var emitting = EmittingFile(dst);
            var bits = RexPrefix.Range();
            using var writer = dst.AsciWriter();
            var buffer = text.buffer();
            var count = RexPrefix.table(buffer);
            writer.Write(buffer.Emit());
            EmittedFile(emitting,count);
        }

        void EmitSibDocs()
        {
            var result = Outcome.Success;
            var path = ApiDoc("asm.docs.sib", FS.ext("bits") + FS.Csv);
            var rows = AsmBits.SibRows().View;
            TableEmit(rows, SibBitfieldRow.RenderWidths, path);
        }

        void EmitModRmDocs()
        {
            var path = ApiDoc("asm.docs.modrm", FS.ext("bits") + FS.Csv);
            var flow = EmittingFile(path);
            using var writer = path.AsciWriter();
            var dst = span<char>(256*128);
            var count = AsmBits.ModRmTable(dst);
            var rendered = slice(dst,0,count);
            writer.Write(rendered);
            EmittedFile(flow,count);
        }

        FS.FolderPath ApiDocs()
            => ProjectDb.Api() + FS.folder("docs");

        FS.FilePath ApiDoc(string name, FS.FileExt ext)
            => ApiDocs() + FS.file(name, ext);

        void EmitConditionDocs()
        {
            var jcc8 = ApiDoc("jcc8", FS.Txt);
            EmitConditionDocs(Conditions.jcc8(), jcc8);
            using var jcc8Reader = jcc8.AsciLineReader();
            while(jcc8Reader.Next(out var line))
                Write(text.format(line.Codes));

            var jcc32 = ApiDoc("jcc32", FS.Txt);
            EmitConditionDocs(Conditions.jcc32(), jcc32);
            using var jcc32Reader = jcc32.AsciLineReader();
            while(jcc32Reader.Next(out var line))
                Write(text.format(line.Codes));
        }

        uint EmitConditionDocs<T>(ReadOnlySpan<T> src, FS.FilePath dst)
            where T : IConditional
        {
            var emitting = EmittingFile(dst);
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
            EmittedFile(emitting,counter);
            return counter;
        }
    }
}