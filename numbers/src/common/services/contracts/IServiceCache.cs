//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IServiceCache
    {
        S Service<S>(IWfRuntime wf)
            where S : AppService<S>, new();
    }
}