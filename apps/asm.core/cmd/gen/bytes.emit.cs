//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class AsmCoreCmd
    {
        [CmdOp("bytes/emit")]
        Outcome BytesEmit(CmdArgs args)
        {
            var dst = text.emitter();
            var offset = 8u;
            Bytes.RenderByteSpan<ushort>(0, Pow2.T11m1, offset, dst);
            FileEmit(dst.Emit(), 4, AppDb.CgStage().Path("UnpackedBytes", FileKind.Cs));
            return true;
        }
    }
}
