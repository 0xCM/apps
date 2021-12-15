//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    using System;

    partial class LlvmDataEmitter
    {
        public Index<LlvmInstDef> EmitInstDefs()
        {
            var src = DataProvider.SelectInstDefs();
            Emit(src);
            return src;
        }

        public void Emit(ReadOnlySpan<LlvmInstDef> src)
        {
            TableEmit(src, LlvmInstDef.RenderWidths, LlvmPaths.Table<LlvmInstDef>());
        }
    }
}