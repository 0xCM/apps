//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    public readonly struct StorageBlocks
    {
        const NumericKind Closure = UnsignedInts;

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref T cell<T>(ref T src, int index)
            where T : unmanaged, IStorageBlock<T>
                => ref seek(recover<T>(src.Bytes),index);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static Span<T> span<T>(ref T src)
            where T : unmanaged, IStorageBlock<T>
                => recover<T>(src.Bytes);

        public static string format<T>(in T src)
            where T : unmanaged, IStorageBlock<T>
                => src.Bytes.FormatHex();

        public static string format<T>(in T src, in HexFormatOptions options)
            where T : unmanaged, IStorageBlock<T>
                => src.Bytes.FormatHex(options);

        [MethodImpl(Inline)]
        public static TrimmedBlock<T> trim<T>(in T src)
            where T : unmanaged, IStorageBlock<T>
                => src;

        [MethodImpl(Inline)]
        public static ByteSize size<T>(in TrimmedBlock<T> src)
            where T : unmanaged, IStorageBlock<T>
        {
            var data = src.BlockData;
            var length = (int)src.BlockSize;
            var size = 0;
            for(var i=length-1; i>=0; i--)
            {
                ref readonly var b = ref skip(data,i);
                if(b == 0)
                    continue;
                else
                {
                    size = i + 1;
                    break;
                }

            }
            return size;
        }

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

        [MethodImpl(Inline)]
        public static bool empty<T>(in T src)
            where T : unmanaged, IStorageBlock<T>
        {
            var b = src.Bytes;
            var count = b.Length;
            var empty = true;
            for(var i=0; i<count; i++)
            {
                if(skip(b,i) != 0)
                {
                    empty=false;
                    break;
                }
            }
            return empty;
        }
    }
}