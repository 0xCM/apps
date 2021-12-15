//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    using static core;
    using static LlvmNames;

    partial class LlvmDataProvider
    {
        public LineMap<Identifier> SelectX86DefMap()
            => SelectLineMap(LlvmPaths.ImportMap(Datasets.X86Defs));
    }
}