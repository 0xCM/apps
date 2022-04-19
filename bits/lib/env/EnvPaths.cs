//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public readonly struct EnvPaths : IEnvPaths
    {
        [MethodImpl(Inline)]
        public static IEnvPaths create()
            => new EnvPaths(Z0.Env.load().Data);

        public EnvData Env {get;}

        [MethodImpl(Inline)]
        public EnvPaths(EnvData env)
        {
            Env = env;
        }
    }
}