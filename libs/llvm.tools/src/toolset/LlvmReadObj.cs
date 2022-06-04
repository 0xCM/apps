//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    [Tool(ToolId)]
    public sealed partial class LlvmReadObjSvc : ToolService<LlvmReadObjSvc>
    {
        public const string ToolId = ToolNames.llvm_readobj;

        public LlvmReadObjSvc()
            : base(ToolId)
        {

        }
   }
}