//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    partial class AsmCmdService
    {
        [CmdOp(".respack-unpack")]
        Outcome UnpackRespack(CmdArgs args)
        {
            var unpacker = ApiResPackUnpacker.create(Wf);
            var dst = OutWs.Subdir("respack");
            unpacker.Emit(dst);
            return true;
        }
    }
}