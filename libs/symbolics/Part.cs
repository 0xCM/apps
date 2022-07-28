//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
[assembly: PartId(PartId.Symbolics)]

namespace Z0.Parts
{
    public sealed class Symbolics : Part<Symbolics>
    {

    }
}

namespace Z0
{
    public static partial class XTend
    {
        [MethodImpl(Inline)]
        public static bool Test<E>(this E src, E flag)
            where E : unmanaged, Enum
                => (core.bw64(src) & core.bw64(flag)) != 0;

    }
}
