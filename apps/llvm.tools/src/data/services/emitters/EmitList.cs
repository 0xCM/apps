//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    partial class LlvmDataEmitter
    {
        public FS.FilePath EmitList(LlvmList src)
        {
            var dst = LlvmPaths.ListImportPath(src.Name);
            EmitList(src,dst);
            return dst;
        }

        public void EmitList(LlvmList src, FS.FilePath dst)
            => TableEmit(src.Items, dst);
    }
}