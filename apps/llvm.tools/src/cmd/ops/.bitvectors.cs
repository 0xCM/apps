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
            // var result = Outcome.Success;
            // var dir = LlvmData.Tables(lists);
            // var src = @readonly(dir.Files(FS.Csv));
            // var dst = LlvmData.Subdir("bitvectors");
            GenBitVectors();
            return true;
        }

        BitfieldServices Bitfields => Service(Wf.Bitfields);

        void GenBitVectors()
        {

            // var src = AppDb.LlvmSources().Scoped("tables").Files(FileKind.Csv).Where(f => f.FileName.StartsWith("llvm.lists"));
            // var dst = AppDb.LlvmTargets().Scoped("emitted").Targets("bitvectors");
            // var models = Bitfields.EmitBitVectors(src, dst);
        }
    }
}