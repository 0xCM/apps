//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    using static LlvmNames;

    partial class LlvmDataProvider
    {
        public LineMap<Identifier> X86ClassMap()
            => LineMap(LlvmPaths.ImportMap(Datasets.X86Classes));
    }
}