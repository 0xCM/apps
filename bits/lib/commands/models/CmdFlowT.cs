//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public readonly struct CmdFlow<T>
    {
        public readonly IActor Actor;

        public readonly T Source;

        public readonly T Target;

        [MethodImpl(Inline)]
        public CmdFlow(IActor actor, T src, T dst)
        {
            Actor = actor;
            Source = src;
            Target = dst;
        }

        public string Format()
            => string.Format("{0}:{1} -> {2}", Actor, Source, Target);

        public override string ToString()
            => Format();
    }
}