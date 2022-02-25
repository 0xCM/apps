//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{

    using static core;

    [Tool(ToolId)]
    public sealed class LlvmNmSvc : ToolService<LlvmNmSvc>
    {
        public const string ToolId = ToolNames.llvm_nm;

        public LlvmNmSvc()
            : base(ToolId)
        {
        }

    }
}