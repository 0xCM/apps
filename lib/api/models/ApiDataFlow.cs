//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public readonly struct ApiDataFlow : ITextual
    {
        readonly IDataFlow Flow;

        public Name Actor => Flow.Actor.Name;

        public Name Source => Flow.SourceName;

        public Name Target => Flow.TargetName;

        [MethodImpl(Inline)]
        public ApiDataFlow(IDataFlow flow)
        {
            Flow = flow;
        }

        public string Format()
            => Flow.Format();

        public override string ToString()
            => Format();
    }
}