//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    partial class AsmCmdService
    {
        [CmdOp(".split")]
        Outcome Split(CmdArgs args)
        {
            var a0 = arg(args,0).Value;
            var a1 = arg(args,1).Value;
            var a2 = uint.Parse(arg(args,2).Value);
            var src = State.CurrentDir().IsNonEmpty ? State.CurrentDir() + FS.file(a0) : FS.path(a0);
            var dst = OutRoot() + FS.folder(a1);
            var spec = new FileSplitSpec(src,a2,dst, TextEncodingKind.Asci);
            Write(string.Format("{0} -> ({1})*", src, dst));
            var results = Wf.FileSplitter().Run(spec);
            return true;
        }
    }
}