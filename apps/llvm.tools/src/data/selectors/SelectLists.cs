//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    partial class LlvmDataProvider
    {
        public Index<LlvmList> SelectLists()
            => LlvmPaths.ListNames().Map(SelectList);
    }
}