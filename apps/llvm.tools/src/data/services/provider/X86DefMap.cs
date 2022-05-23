//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    using static LlvmNames;

    partial class LlvmDataProvider
    {
        public LineMap<string> X86DefMap()
            => LineMap(LlvmPaths.ImportMap(Datasets.X86Defs));
    }
}