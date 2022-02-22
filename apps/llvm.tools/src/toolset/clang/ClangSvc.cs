//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    [Tool(ToolId)]
    public class ClangSvc : ToolService<ClangSvc>
    {
        public const string ToolId = ToolNames.clang;

        public ClangSvc()
            : base(ToolId)
        {

        }
    }
}