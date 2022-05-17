//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public partial class PolyBits : AppService<PolyBits>
    {
        const string DbScope = "polybits";

        AppServices AppSvc => Service(Wf.AppServices);

        AppDb AppDb => Service(Wf.AppDb);

        DbTargets Targets => AppDb.Targets().Targets(DbScope);
    }
}