//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    using System;

    partial class LlvmDataEmitter
    {
        public FS.FilePath Emit(ReadOnlySpan<LlvmAsmOpCode> src)
        {
            var dst = LlvmPaths.Table<LlvmAsmOpCode>();
            TableEmit(src, dst);
            return dst;
        }
    }
}