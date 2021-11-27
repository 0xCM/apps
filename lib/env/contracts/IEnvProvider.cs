//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IEnvProvider
    {
        EnvData Env {get;}

        IEnvPaths EnvPaths
            => new EnvPaths(Env);
    }
}