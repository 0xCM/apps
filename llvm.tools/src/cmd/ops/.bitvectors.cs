//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    using static core;
    using static WsAtoms;

    partial class LlvmCmd
    {
        IProjectWs LlvmData => Ws.Project("llvm.data");

        [CmdOp(".bitvectors")]
        Outcome EmitBitVectors(CmdArgs args)
        {
            var result = Outcome.Success;
            var dir = LlvmData.Tables(lists);
            var src = @readonly(dir.Files(FS.Csv));
            var dst = LlvmData.Subdir("bitvectors");
            Wf.Bitfields().EmitBitVectors(src, dst);
            return result;
        }
    }
}