//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;
    using static core;


    partial class AsmCoreCmd
    {
        PolyBits PolyBits => Service(Wf.PolyBits);

        [CmdOp("bytes/emit")]
        Outcome BytesEmit(CmdArgs args)
        {
            var dst = text.emitter();
            var offset = 8u;
            Bytes.RenderByteSpan<ushort>(0, Pow2.T11m1, offset, dst);
            FileEmit(dst.Emit(), 4, AppDb.CgStage().Path("UnpackedBytes", FileKind.Cs));
            return true;
        }

        [CmdOp("pb/bv/emit")]
        Outcome GenBitVectors(CmdArgs args)
        {
            var result = Outcome.Success;
            var filter = "llvm.lists";
            var sources = AppDb.LlvmSources().Scoped("tables");
            var targets = AppDb.LlvmTargets().Scoped("emitted");
            var dst = targets.Targets("bitvectors");
            dst.Clear();
            PolyBits.BvEmit(sources, filter, dst);
            return result;
        }
    }
}