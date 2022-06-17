//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    using static LlvmNames;

    partial class LlvmDataProvider
    {
        public LineMap<string> X86ClassMap()
            => LineMap(LlvmPaths.ImportMap(LlvmDatasets.X86Classes));
    }
}