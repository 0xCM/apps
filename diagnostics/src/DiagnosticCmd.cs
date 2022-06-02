//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class DiagnosticCmd  : AppCmdService<DiagnosticCmd>
    {
        AppSvcOps AppSvc => Wf.AppSvc();

        Runtime RuntimeServices => Wf.Runtime();

        ApiCodeFiles ApiFiles => Wf.ApiCodeFiles();

        [CmdOp("memory/dump")]
        void EmitDump()
        {
            RuntimeServices.EmitContext();
        }
    }
}