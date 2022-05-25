//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    sealed class ServiceCache : ServiceCache<ServiceCache>
    {


    }

    public static class XSvc
    {
        static ServiceCache Services = new();

    }
}