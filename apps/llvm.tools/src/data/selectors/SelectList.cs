//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    partial class LlvmDataProvider
    {
        public LlvmList SelectList(string id)
            => (LlvmList)DataSets.GetOrAdd("llvm.lists." + id, key => TableLoader.LoadList(id));
    }
}