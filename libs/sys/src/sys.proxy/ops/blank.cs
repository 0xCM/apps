//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static ApiOpaqueClass;

    partial struct proxy
    {
        [MethodImpl(Options), Opaque(EmptyStringTest)]
        public static bool blank(string src)
            => string.IsNullOrWhiteSpace(src);
    }
}