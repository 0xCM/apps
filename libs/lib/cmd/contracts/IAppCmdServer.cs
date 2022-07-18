//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IAppCmdServer
    {
        void With(params ICmdProvider[] src);

        Deferred<ICmdProvider> Providers {get;}
    }
}