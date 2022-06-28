//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public abstract class CmdServices<T> : Services<T>
        where T : CmdServices<T>, new()
    {
        public static S service<S>(IWfRuntime wf)
            where S : ICmdService, new()
                => (S)Instance.Lookup.GetOrAdd(svcid<S>(), _ => {
                    var service = new S();
                    service.Init(wf);
                    return service;
                });

        public static S service<S>(IWfRuntime wf, string name, Func<IWfRuntime,S> factory)
            where S : ICmdService, new()
                => (S)Instance.Lookup.GetOrAdd(svcid<S>(name), _ => factory(wf));

        public static S service<S>(IWfRuntime wf, Func<IWfRuntime,S> factory)
            where S : ICmdService, new()
                => (S)Instance.Lookup.GetOrAdd(svcid<S>(), _ => factory(wf));

        public S Service<S>(IWfRuntime wf)
            where S : ICmdService, new()
                => service<S>(wf);

        public S Service<S>(IWfRuntime wf, string name, Func<IWfRuntime,S> factory)
            where S : ICmdService, new()
                => service<S>(wf, name, factory);

        public S Service<S>(IWfRuntime wf, Func<IWfRuntime,S> factory)
            where S : ICmdService, new()
                => service<S>(wf, factory);
    }
}