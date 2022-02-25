//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public partial class CheckCmdProvider : AppCmdProvider<CheckCmdProvider>
    {
        AppDb AppDb => Service(Wf.AppDb);

        Parsers Parsers => Service(Wf.Parsers);
    }
}