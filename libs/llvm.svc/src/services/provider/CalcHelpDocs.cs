//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    partial class LlvmDataProvider
    {
        Toolsets Toolsets => Wf.Toolsets();

        public Index<ToolHelpDoc> CalcHelpDocs()
            => Toolsets.LoadHelpDocs(LlvmPaths.HelpSouces()).Values.ToArray().Index();
    }
}