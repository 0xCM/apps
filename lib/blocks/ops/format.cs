//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial struct Storage
    {
        public static string format<T>(in T src)
            where T : unmanaged, IStorageBlock<T>
                => src.Bytes.FormatHex();

        public static string format<T>(in T src, char sep, bool prespec=false, bool uppercase = false)
            where T : unmanaged, IStorageBlock<T>
                => src.Bytes.FormatHex(sep, prespec:prespec, uppercase:uppercase);

        public static string format<T>(in T src, in HexFormatOptions options)
            where T : unmanaged, IStorageBlock<T>
                => src.Bytes.FormatHex(options);

        public static string format<T>(in TrimmedBlock<T> src)
            where T : unmanaged, IStorageBlock<T>
        {
            var sz = size(src);
            if(sz == 0)
                sz = 1;
            return core.slice(src.BlockData, 0, sz).FormatHex();
        }

        public static string format<T>(in TrimmedBlock<T> src, in HexFormatOptions options)
            where T : unmanaged, IStorageBlock<T>
                => core.slice(src.BlockData, 0, size(src)).FormatHex(options);
    }
}