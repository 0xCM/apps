//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    partial class LlvmCmdProvider
    {
        [CmdOp("llvm/emit/relations")]
        void EmitDefRelations()
        {
            var relations = DataProvider.DefDependencies();
            Query.FileEmit("llvm.defs.relations", relations.View);
        }
    }
}