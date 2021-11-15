//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public readonly struct ExecutorContext
    {
        public dynamic State {get;}

        [MethodImpl(Inline)]
        public ExecutorContext(dynamic state)
            => State = state;
    }
}