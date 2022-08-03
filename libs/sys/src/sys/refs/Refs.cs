//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static System.Runtime.CompilerServices.Unsafe;

    [ApiHost,Free]
    public partial class Refs
    {
        const NumericKind Closure = UnsignedInts;

        [MethodImpl(Inline), Op, Closures(Closure)]
        static uint size<T>()
            => (uint)SizeOf<T>();

        [MethodImpl(Inline), Op]
        internal static ReadOnlySpan<char> span(string src)
            => src;
    }
}
