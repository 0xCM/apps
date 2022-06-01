//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class AsmCoreCmd
    {
        [CmdOp("gen/bytes")]
        Outcome BytesEmit(CmdArgs args)
        {
            var dst = text.emitter();
            var offset = 8u;
            RenderByteSpans(offset,dst);
            FileEmit(dst.Emit(), 4, AppDb.CgStage().Path("UnpackedBytes", FileKind.Cs));
            return true;
        }


        public static void RenderByteSpans(uint offset, ITextEmitter dst)
        {
            Bytes.bytespan<byte>(0,255,offset,dst);
            Bytes.bytespan<ushort>(0,255,offset,dst);
            Bytes.bytespan<uint>(0,255,offset,dst);
            Bytes.bytespan<ulong>(0,255,offset,dst);
            Bytes.bytespan<ushort>(0, 511, offset, dst);
            Bytes.bytespan<ushort>(0, Pow2.T11m1, offset, dst);
        }
    }
}
