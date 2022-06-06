//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    [Tool(ToolId)]
    public partial class LlvmMcSvc : ToolService<LlvmMcSvc>
    {
        public const string ToolId = ToolNames.llvm_mc;

        public LlvmMcSvc()
            : base(ToolId)
        {

        }
    }
}