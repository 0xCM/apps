//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    partial class AsmCmdService
    {
        [CmdOp(".asm-rex-docs")]
        Outcome EmitRexFields(CmdArgs args)
        {
            var dst = AsmDocs() + FS.file("bitfields.rex", FS.ext("bits"));
            var emitting = Wf.EmittingFile(dst);
            var bits = RexPrefix.Range();
            using var writer = dst.AsciWriter();
            var buffer = text.buffer();
            var count = AsmPrefix.RexTable(buffer);
            writer.Write(buffer.Emit());
            Wf.EmittedFile(emitting,count);
            return true;
        }
    }
}