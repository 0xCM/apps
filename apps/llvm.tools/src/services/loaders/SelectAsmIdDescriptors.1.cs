//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    using static core;

    partial class LlvmDataProvider
    {
        public Index<ToolHelpDoc> SelectToolHelp()
        {
            return (Index<ToolHelpDoc>)DataSets.GetOrAdd(nameof(SelectToolHelp), key => Load());

            Index<ToolHelpDoc> Load()
            {
                return Toolset.ToolHelp();
            }
        }
    }
}