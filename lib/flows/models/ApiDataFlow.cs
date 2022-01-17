//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Runtime.CompilerServices;

    using static Root;

    public readonly struct ApiDataFlow : IDataFlow
    {
        readonly IDataFlow Flow;


        [MethodImpl(Inline)]
        public ApiDataFlow(IDataFlow flow)
        {
            Flow = flow;
        }

        public IActor Actor => Flow.Actor;

        public dynamic Source => Flow.Source;

        public dynamic Target => Flow.Target;

        public string Format()
            => Flow.Format();

        public override string ToString()
            => Format();
    }
}