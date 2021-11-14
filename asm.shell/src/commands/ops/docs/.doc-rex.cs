//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    partial class AsmCmdService
    {
        [CmdOp(".doc-rex")]
        Outcome EmitRexFields(CmdArgs args)
        {
            var path = Ws.Docs().Path("bitfields", "rex", FS.ext("bits"));
            var flow = Wf.EmittingFile(path);
            var bits = RexPrefix.Range();
            using var writer = path.AsciWriter();
            var buffer = text.buffer();
            var count = AsmPrefix.RexTable(buffer);
            writer.Write(buffer.Emit());
            Wf.EmittedFile(flow,count);
            return true;
        }
    }
}