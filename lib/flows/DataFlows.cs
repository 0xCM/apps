//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Runtime.CompilerServices;

    using static Root;

    public readonly struct DataFlows
    {
        const NumericKind Closure = UnsignedInts;

        public static string format<A,S,T>(DataFlow<A,S,T> flow)
            where S : IType
            where T : IType
            where A : IActor
                => string.Format("{0}:{1} -> {2}", flow.Actor, flow.Source, flow.Target);
    }
}
