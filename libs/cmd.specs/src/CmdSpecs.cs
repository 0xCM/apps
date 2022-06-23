//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    [ApiHost]
    public class CmdSpecs
    {
        const NumericKind Closure = UnsignedInts;

        [MethodImpl(Inline)]
        public static Relation<K,S,T> relation<K,S,T>(K kind, S src, T dst)
            where K : unmanaged
            where S : unmanaged
            where T : unmanaged
                => new Relation<K,S,T>(FlowId.identify(kind,src,dst), kind, src, dst);
    }
}