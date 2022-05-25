//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public partial class CheckCmd : AppCmdProvider<CheckCmd>
    {
        AppDb AppDb => Service(Wf.AppDb);

        Parsers Parsers => Service(Wf.Parsers);

        AppSvcOps AppSvc => Wf.AppSvc();
    }
}