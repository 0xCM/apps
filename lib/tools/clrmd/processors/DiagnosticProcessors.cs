//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public readonly partial struct DiagnosticProcessors
    {
        [MethodImpl(Inline)]
        public static ModuleProcessor module(IEventSink sink, bool pll = true)
            => new ModuleProcessor(sink, pll);
   }
}