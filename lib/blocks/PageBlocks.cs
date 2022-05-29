//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    [ApiHost]
    public unsafe readonly struct PageBlocks
    {
        /// <summary>
        /// Windows page size = 4096 bytes
        /// </summary>
        public const uint PageSize = PageBlock.PageSize;

        [MethodImpl(Inline), Op]
        public static PageBlockInfo describe(PageBlock src)
            => new PageBlockInfo(src.Range);

        [MethodImpl(Inline)]
        public static MemoryCells<T> cells<T>(PageBlock src)
            where T : unmanaged
                => new MemoryCells<T>(src.Range);

        [MethodImpl(Inline)]
        public static void alloc(out PageBlock16x4 dst)
        {
            dst = default;
        }

        [MethodImpl(Inline)]
        public static void alloc(out PageBlock128 dst)
        {
            dst = default;
        }

        [MethodImpl(Inline)]
        public static void alloc(out PageBlock256 dst)
        {
            dst = default;
        }

        [MethodImpl(Inline)]
        public static uint PageCount<T>()
            where T : unmanaged, IPageBlock<T>
                => size<T>()/PageSize;

        [MethodImpl(Inline), Op]
        public static void Read(byte* pSrc, ref PageBlock dst)
            => Bytes.read4096(pSrc, ref dst);

        // [MethodImpl(Inline), Op]
        // public static void read32(ref byte* pSrc, ref PageBlock dst, ref ushort offset)
        // {
        //     ref var target = ref u8(dst);
        //     cpu.vstore(cpu.vload(w256, pSrc), ref target, (int)offset);
        //     pSrc +=32;
        //     offset+= 32;
        // }

        // [MethodImpl(Inline), Op]
        // public static void read64(ref byte* pSrc, ref PageBlock dst, ref ushort offset)
        // {
        //     read32(ref pSrc, ref dst, ref offset);
        //     read32(ref pSrc, ref dst, ref offset);
        // }

        // [MethodImpl(Inline), Op]
        // public static void read128(ref byte* pSrc, ref PageBlock dst, ref ushort offset)
        // {
        //     read64(ref pSrc, ref dst, ref offset);
        //     read64(ref pSrc, ref dst, ref offset);
        // }

        // [MethodImpl(Inline), Op]
        // public static void read256(ref byte* pSrc, ref PageBlock dst, ref ushort offset)
        // {
        //     read128(ref pSrc, ref dst, ref offset);
        //     read128(ref pSrc, ref dst, ref offset);
        // }

        // [MethodImpl(Inline), Op]
        // public static void read512(ref byte* pSrc, ref PageBlock dst, ref ushort offset)
        // {
        //     read256(ref pSrc, ref dst, ref offset);
        //     read256(ref pSrc, ref dst, ref offset);
        // }

        // [MethodImpl(Inline), Op]
        // public static void read1024(ref byte* pSrc, ref PageBlock dst, ref ushort offset)
        // {
        //     read512(ref pSrc, ref dst, ref offset);
        //     read512(ref pSrc, ref dst, ref offset);
        // }

        // [MethodImpl(Inline), Op]
        // public static void read2048(ref byte* pSrc, ref PageBlock dst, ref ushort offset)
        // {
        //     read1024(ref pSrc, ref dst, ref offset);
        //     read1024(ref pSrc, ref dst, ref offset);
        // }
   }
}