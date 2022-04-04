//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public partial class GenCmdProvider : AppCmdService<GenCmdProvider,CmdShellState>
    {
        AppDb AppDb => Service(Wf.AppDb);

        CgSvc CodeGen => Service(Wf.CodeGen);
    }
}