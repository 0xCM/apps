//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;

    using static core;

    partial class GlobalCommands
    {
        [CmdOp("asm/docs/emit")]
        Outcome EmitAsmDocs(CmdArgs args)
        {
            EmitRexDocs();
            EmitSibDocs();
            EmitModRmDocs();
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
    }
}