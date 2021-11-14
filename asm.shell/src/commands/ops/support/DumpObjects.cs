//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using llvm;

    partial class AsmCmdService
    {
        [CmdOp(".dump-objects")]
        Outcome DumpObjects(CmdArgs args)
        {
            var result = Outcome.Success;
            var src = State.Files(FS.Obj, FS.Exe, FS.Lib, FS.Dll).View;
            var count = src.Length;
            var tool = LlvmNames.Tools.llvm_objdump;
            var outdir = GetToolOut(tool);
            var svc = Wf.LlvmObjDump();
            return svc.DumpObjects(src,outdir, response => Write(response));
        }
    }
}