//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    partial class AsmCmdService
    {
        [CmdOp(".asci-bytes")]
        Outcome AsciBytes(CmdArgs args)
        {
            var name = arg(args,0).Value;
            var content = arg(args,1).Value;
            var bytes = Wf.AsciLookups();
            var spec = bytes.DefineByteSpan(name, content);
            var data = spec.Format();
            Write(data);
            return true;
        }

        string RenderAsciByteSpan(Identifier name, string data)
        {
            var dst = text.buffer();
            SpanRes.ascirender(8, name, data, dst);
            return dst.Emit();
        }

        void EmitAsciBytes(Identifier name, string content, FS.FilePath dst)
        {
            var flow = Wf.EmittingFile(dst);
            using var writer = dst.Writer();
            var bytespan = RenderAsciByteSpan(name, content);
            Wf.Row(bytespan);
            writer.WriteLine(bytespan);
            Wf.EmittedFile(flow,content.Length);
        }

        public void EmitAsciBytes()
        {
            var name = "Uppercase";
            EmitAsciBytes(name, "ABCDEFGHIJKLMNOPQRSTUVWXYZ", Db.AppLog(name, FS.Cs));
        }
    }
}