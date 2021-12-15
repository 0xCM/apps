//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    partial class LlvmDataProvider
    {
        public Index<ToolHelpDoc> SelectToolHelp()
        {
            return (Index<ToolHelpDoc>)DataSets.GetOrAdd(nameof(SelectToolHelp), key => Toolset.ToolHelp());
        }
    }
}