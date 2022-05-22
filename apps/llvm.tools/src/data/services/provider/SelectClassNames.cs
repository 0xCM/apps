//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{

    partial class LlvmDataProvider
    {
        public Index<Identifier> SelectClassNames()
            => X86ClassMap().Intervals.Select(x => x.Id);
    }
}