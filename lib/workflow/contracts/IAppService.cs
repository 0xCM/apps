//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    using static Root;

    using Free = System.Security.SuppressUnmanagedCodeSecurityAttribute;

    [Free]
    public interface IAppService : IService, IDisposable
    {
        IWfRuntime Wf {get;}

        IWfDb Db
            => Wf.Db();

        EnvData IEnvProvider.Env
            => Wf.Env;

        void Init(IWfRuntime wf);


        void IDisposable.Dispose() {}
    }

    /// <summary>
    /// Characterizes a workflow service implementation
    /// </summary>
    /// <typeparam name="H">The reifying type</typeparam>
    [Free]
    public interface IAppService<H> : IAppService, IService<H>
        where H : IAppService<H>, new()
    {

    }
}