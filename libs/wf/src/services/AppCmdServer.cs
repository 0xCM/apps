//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static Algs;

    class AppCmdServer : AppService<AppCmdServer>, IAppCmdServer
    {
        ConcurrentDictionary<Name,ICmdProvider> ProviderLookup;

        public Deferred<ICmdProvider> Providers
            => new Deferred<ICmdProvider>(ProviderLookup.Values);

        public void With(params ICmdProvider[] src)
            => iter(src, x => ProviderLookup.TryAdd(x.Name,x));
    }
}