//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    partial class AsmCmdService
    {
        static MsgPattern CapacityExceeded => "Capacity exceeded";

        static MsgPattern ToolUnspecified
            => "Tool unspecified";

        static MsgPattern<ToolId> UndefinedTool
            => "Undefined tool:{0}";

        static MsgPattern<ProjectId> UndefinedProject
            => "Undefined project:{0}";

        static MsgPattern<Count,FS.FileUri> EmittedQueryResults
            => "Directed {0} query result rows to {1}";

        MsgPattern<Count,FS.FileUri> EmittedInstructions
            => "Emitted {0} instructions to {1}";
    }
}