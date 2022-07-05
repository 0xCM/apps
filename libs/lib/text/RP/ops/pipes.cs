//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct RpOps
    {
        [MethodImpl(Inline)]
        public static RenderCapture piped<A0,A1>(A0 a0, A1 a1)
            => capture(pattern<A0,A1>(RpOps.PSx2), a0, a1);

        [MethodImpl(Inline)]
        public static RenderCapture piped<A0,A1,A2>(A0 a0, A1 a1, A2 a2)
            => capture(pattern<A0,A1,A2>(RpOps.PSx3), a0, a1, a2);
    }
}