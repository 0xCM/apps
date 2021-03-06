//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct EnvPaths : IEnvPaths
    {
        public EnvData Env {get;}

        [MethodImpl(Inline)]
        public EnvPaths(EnvData env)
        {
            Env = env;
        }
    }
}