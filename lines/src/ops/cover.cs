//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class AsciLines
    {
        [MethodImpl(Inline)]
        public static AsciLine<T> cover<T>(ReadOnlySpan<T> src)
            where T : unmanaged
                => new AsciLine<T>(src);

        [MethodImpl(Inline), Op]
        public static AsciLine cover(ReadOnlySpan<byte> src)
            => new AsciLine(src);
    }
}