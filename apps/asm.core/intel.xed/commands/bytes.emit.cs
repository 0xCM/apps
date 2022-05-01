//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedCmdProvider
    {
        [CmdOp("bytes/emit")]
        Outcome BytesEmit(CmdArgs args)
        {
            var dst = text.emitter();
            var offset = 8u;
            Bytes.RenderByteSpan<ushort>(0, Pow2.T11m1, offset, dst);
            FileEmit(dst.Emit(), 4, AppDb.CgStage() + FS.file("UnpackedBytes", FS.Cs));
            return true;
        }
    }
}