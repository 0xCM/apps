//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class GlobalSvc : AppServices<GlobalSvc>
    {
        public AppDb AppDb => Service<AppDb>();
    }
}