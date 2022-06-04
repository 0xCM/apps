//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    partial class LlvmDataEmitter
    {
        public void EmitChildRelations(ReadOnlySpan<LlvmEntity> src)
            => AppSvc.TableEmit(DataCalcs.CalcChildRelations(src), LlvmPaths.Table<ChildRelation>());
    }
}