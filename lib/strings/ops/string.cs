//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial struct strings
    {
        [MethodImpl(Inline)]
        static T generic<T>(long src)
            where T : unmanaged
                => @as<T>(bytes(src));

        [MethodImpl(Inline)]
        static T generic<T>(ulong src)
            where T : unmanaged
                => @as<T>(bytes(src));

        [MethodImpl(Inline)]
        public static MemoryString<K> @string<K>(in MemoryStrings<K> src, K index)
            where K : unmanaged
                => new MemoryString<K>(src.CharBase + offset(src, index), (int)length(src,index));

        [MethodImpl(Inline)]
        public static MemoryString<K> @string<K>(in MemoryStrings<K> src, uint index)
            where K : unmanaged
                => new MemoryString<K>(src.CharBase + offset(src,index), (int)length(src,index));
    }
}