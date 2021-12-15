//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    partial class LlvmDataProvider
    {
        public RegIdentifiers SelectRegIdentifiers()
        {
            return (RegIdentifiers)DataSets.GetOrAdd(nameof(SelectRegIdentifiers), key => TableLoader.LoadRegIdentifiers());
        }
    }
}