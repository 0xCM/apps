//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static PeRecords;
    partial class ProjectCmdProvider
    {
        [CmdOp("objdump/recode")]
        Outcome ObjDumpRecode(CmdArgs args)
        {
            LlvmObjDump.Recode(Project());
            return  true;
        }

    }
}