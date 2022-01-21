//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public readonly struct ApiDataFlow<S,T> : IDataFlow<S,T>
    {
        readonly IDataFlow<S,T> Flow;

        [MethodImpl(Inline)]
        public ApiDataFlow(IDataFlow<S,T> flow)
        {
            Flow = flow;
        }

        public IActor Actor => Flow.Actor;

        public S Source => Flow.Source;

        public T Target => Flow.Target;

        public string Format()
            => Flow.Format();

        public override string ToString()
            => Format();

        public static implicit operator ApiDataFlow<S,T>(ApiDataFlow src)
            => ApiDataFlow.typed<S,T>(src);
    }
}