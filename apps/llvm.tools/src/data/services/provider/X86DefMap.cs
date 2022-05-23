//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    using static LlvmNames;

    partial class LlvmDataProvider
    {
        public LineMap<Identifier> X86DefMap()
            => LineMap(LlvmPaths.ImportMap(Datasets.X86Defs));
    }
}