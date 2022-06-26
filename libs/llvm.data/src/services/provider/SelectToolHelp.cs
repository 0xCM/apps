//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    partial class LlvmDataProvider
    {
        public Index<ToolHelpDoc> SelectToolHelp()
            => (Index<ToolHelpDoc>)DataSets.GetOrAdd(nameof(ToolHelpDoc), () => CalcHelpDocs());

        Toolsets Toolsets => Wf.Toolsets();

        Index<ToolHelpDoc> CalcHelpDocs()
            => Toolsets.LoadHelpDocs(AppDb.Toolbase().Targets("llvm").Root).Values.ToArray().Index();

    }
}