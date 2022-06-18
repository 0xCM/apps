//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class GlobalSvc : AppServices<GlobalSvc>
    {
        public S Inject<S>(S svc)
            => (S)Lookup.GetOrAdd(typeof(S), svc);

        public S Injected<S>()
            => (S)Lookup[typeof(S)];
    }
}