//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct CilPaths : ICilPaths
    {
        public EnvData Env {get;}

        [MethodImpl(Inline)]
        public CilPaths(EnvData env)
        {
            Env = env;
        }

        [MethodImpl(Inline)]
        public static implicit operator CilPaths(EnvData env)
            => new CilPaths(env);
    }
}