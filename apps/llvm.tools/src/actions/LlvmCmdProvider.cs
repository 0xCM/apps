//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    using Asm;

    using static core;

    public partial class LlvmCmdProvider : AppCmdProvider<LlvmCmdProvider>
    {
        LlvmDataImporter DataImporter => Service(Wf.LlvmDataImporter);

        LlvmToolset Toolset => Service(Wf.LLvmToolset);

        LlvmPaths LlvmPaths => Service(Wf.LlvmPaths);

        LlvmProjectCollector ProjectCollector => Service(Wf.LlvmProjectCollector);

        LlvmRepo LlvmRepo => Service(Wf.LlvmRepo);

        LlvmReadObj ReadObj => Service(Wf.LlvmReadObj);

        LlvmDataProvider DataProvider => Service(Wf.LlvmDataProvider);

        LlvmDataEmitter DataEmitter => Service(Wf.LlvmDataEmitter);

        LlvmCodeGen CodeGen => Service(Wf.LlvmCodeGen);

        LlvmDistiller Distiller => Service(Wf.LlvmDistiller);

        LlvmConfig LlvmConfig => Service(Wf.LlvmConfig);
    }
}