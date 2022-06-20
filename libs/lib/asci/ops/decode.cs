//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;
    using static AsciSymbols;

    using C = AsciCode;

    partial struct Asci
    {
        [MethodImpl(Inline), Op]
        public static ReadOnlySpan<char> decode(in asci2 src)
        {
            var storage = 0u;
            ref var dst = ref @as<uint,char>(storage);
            seek(dst, 0) = (char)(byte)(src.Storage >> 0);
            seek(dst, 1) = (char)(byte)(src.Storage >> 8);
            return core.cover(dst, 2);
        }

    }
}