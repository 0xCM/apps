//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Runtime.CompilerServices;

    using static Root;

    partial struct RP
    {
        [MethodImpl(Inline)]
        public static RenderPattern<A0> pattern<A0>(string content)
            => content;

        [MethodImpl(Inline)]
        public static RenderPattern<A0,A1> pattern<A0,A1>(string content)
            => content;

        [MethodImpl(Inline)]
        public static RenderPattern<A0,A1,A2> pattern<A0,A1,A2>(string content)
            => content;

        [MethodImpl(Inline)]
        public static RenderPattern<A0,A1,A2,A3> pattern<A0,A1,A2,A3>(string content)
            => content;
    }
}