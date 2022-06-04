//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    using System;

    partial class LlvmDataEmitter
    {
        public void EmitInstDefs()
            => Emit(DataProvider.InstDefs());

        public void Emit(ReadOnlySpan<LlvmInstDef> src)
            => AppSvc.TableEmit(src, LlvmPaths.Table<LlvmInstDef>());
    }
}