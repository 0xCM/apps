//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.InteropServices;
    using System.Runtime.CompilerServices;

    using static Root;
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
        public static void alloc(out PageBlock32x4 dst)
        {
            dst = default;
        }

        [MethodImpl(Inline)]
        public static void alloc(out PageBlock64x4 dst)
        {
            dst = default;
        }

        [MethodImpl(Inline)]
        public static uint PageCount<T>()
            where T : unmanaged, IPageBlock<T>
                => size<T>()/PageSize;

        [MethodImpl(Inline), Op]
        public static void Read(byte* pSrc, ref PageBlock dst)
        {
            ReadLo(pSrc, ref dst);
            ReadHi(pSrc, ref dst);
        }

        [Op]
        static void ReadLo(byte* pSrc, ref PageBlock dst)
        {
            var pData = pSrc;
            var offset = z16;
            read2048(ref pData, ref dst, ref offset);
        }

        [Op]
        static void ReadHi(byte* pSrc, ref PageBlock dst)
        {
            const ushort Half = Root.PageSize/2;
            var pData = pSrc + Half;
            var offset = Half;
            read2048(ref pData, ref dst, ref offset);
        }

        [MethodImpl(Inline), Op]
        static void read32(ref byte* pSrc, ref PageBlock dst, ref ushort offset)
        {
            ref var target = ref u8(dst);
            vcore.vstore(vcore.vload(w256, pSrc), ref target, (int)offset);
            pSrc +=32;
            offset+= 32;
        }

        [MethodImpl(Inline), Op]
        static void read64(ref byte* pSrc, ref PageBlock dst, ref ushort offset)
        {
            read32(ref pSrc, ref dst, ref offset);
            read32(ref pSrc, ref dst, ref offset);
        }

        [MethodImpl(Inline), Op]
        static void read128(ref byte* pSrc, ref PageBlock dst, ref ushort offset)
        {
            read64(ref pSrc, ref dst, ref offset);
            read64(ref pSrc, ref dst, ref offset);
        }

        [MethodImpl(Inline), Op]
        static void read256(ref byte* pSrc, ref PageBlock dst, ref ushort offset)
        {
            read128(ref pSrc, ref dst, ref offset);
            read128(ref pSrc, ref dst, ref offset);
        }

        [MethodImpl(Inline), Op]
        static void read512(ref byte* pSrc, ref PageBlock dst, ref ushort offset)
        {
            read256(ref pSrc, ref dst, ref offset);
            read256(ref pSrc, ref dst, ref offset);
        }

        [MethodImpl(Inline), Op]
        static void read1024(ref byte* pSrc, ref PageBlock dst, ref ushort offset)
        {
            read512(ref pSrc, ref dst, ref offset);
            read512(ref pSrc, ref dst, ref offset);
        }

        [MethodImpl(Inline), Op]
        static void read2048(ref byte* pSrc, ref PageBlock dst, ref ushort offset)
        {
            read1024(ref pSrc, ref dst, ref offset);
            read1024(ref pSrc, ref dst, ref offset);
        }

        /// <summary>
        /// Reserves 1 pages of memory that covers 2^12 = 4096 bytes
        /// </summary>
        [StructLayout(LayoutKind.Sequential, Size = (int)SZ)]
        internal struct PageBlock1 : IPageBlock<PageBlock1>
        {
            public const uint SZ = PageSize;
        }

        /// <summary>
        /// Reserves 2 pages of memory that cover 2^13 = 8,192 bytes
        /// </summary>
        [StructLayout(LayoutKind.Sequential, Size = (int)SZ)]
        internal struct PageBlock2 : IPageBlock<PageBlock2>
        {
            public const uint SZ = Pow2.T13;

            public const uint PageCount = SZ/PageSize;
        }

        /// <summary>
        /// Reserves 3 pages of memory
        /// </summary>
        [StructLayout(LayoutKind.Sequential, Size = (int)SZ)]
        internal struct PageBlock3 : IPageBlock<PageBlock3>
        {
            public const uint SZ = PageBlock2.SZ + PageBlock1.SZ;

            public const uint PageCount = SZ/PageSize;
        }

        /// <summary>
        /// Reserves 4 pages of memory that cover 2^14 = 16,384 bytes
        /// </summary>
        [StructLayout(LayoutKind.Sequential, Size = (int)SZ)]
        internal struct PageBlock4 : IPageBlock<PageBlock4>
        {
            public const uint SZ = Pow2.T14;

            public const uint PageCount = SZ/PageSize;
        }

        /// <summary>
        /// Reserves 5 pages of memory
        /// </summary>
        [StructLayout(LayoutKind.Sequential, Size = (int)SZ)]
        internal struct PageBlock5 : IPageBlock<PageBlock5>
        {
            public const uint SZ = PageBlock4.SZ + PageBlock1.SZ;

            public const uint PageCount = SZ/PageSize;
        }

        /// <summary>
        /// Reserves 6 pages of memory
        /// </summary>
        [StructLayout(LayoutKind.Sequential, Size = (int)SZ)]
        internal struct PageBlock6 : IPageBlock<PageBlock6>
        {
            public const uint SZ = PageBlock5.SZ + PageBlock1.SZ;

            public const uint PageCount = SZ/PageSize;
        }

        /// <summary>
        /// Reserves 7 pages of memory
        /// </summary>
        [StructLayout(LayoutKind.Sequential, Size = (int)SZ)]
        internal struct PageBlock7 : IPageBlock<PageBlock6>
        {
            public const uint SZ = PageBlock6.SZ + PageBlock1.SZ;

            public const uint PageCount = SZ/PageSize;
        }

        /// <summary>
        /// Reserves 8 pages of memory that covers 2^15 = 32,768 bytes
        /// </summary>
        [StructLayout(LayoutKind.Sequential, Size = (int)SZ)]
        internal struct PageBlock8 : IPageBlock<PageBlock8>
        {
            public const uint SZ = Pow2.T15;

            public const uint PageCount = SZ/PageSize;
        }

        /// <summary>
        /// Reserves 16 pages of memory that covers 2^16 = 65,536 bytes
        /// </summary>
        [StructLayout(LayoutKind.Sequential, Size = (int)SZ)]
        internal struct PageBlock16 : IPageBlock<PageBlock16>
        {
            public const uint SZ = Pow2.T16;

            public const uint PageCount = SZ/PageSize;
        }

        /// <summary>
        /// Reserves 16 pages of memory that covers 2^17 = 131,072 bytes
        /// </summary>
        [StructLayout(LayoutKind.Sequential, Size = (int)SZ)]
        internal struct PageBlock32 : IPageBlock<PageBlock32>
        {
            public const uint SZ = Pow2.T17;

            public const uint PageCount = SZ/PageSize;
        }

        /// <summary>
        /// Reserves 16 pages of memory that covers 2^18 = 262,144 bytes
        /// </summary>
        [StructLayout(LayoutKind.Sequential, Size = (int)SZ)]
        internal struct PageBlock64 : IPageBlock<PageBlock64>
        {
            public const uint SZ = Pow2.T18;

            public const uint PageCount = SZ/PageSize;
        }

        [StructLayout(LayoutKind.Sequential, Size = (int)SZ)]
        public struct PageBlock16x4 : IPageBlock<PageBlock16x4>
        {
            public const uint SZ = PageBlock16.SZ*4;

            public const uint PageCount = SZ/PageSize;

            PageBlocks.PageBlock16 Block0;

            PageBlocks.PageBlock16 Block1;

            PageBlocks.PageBlock16 Block2;

            PageBlocks.PageBlock16 Block3;
        }

        [StructLayout(LayoutKind.Sequential, Size = (int)SZ)]
        public struct PageBlock32x4 : IPageBlock<PageBlock32x4>
        {
            public const uint SZ = PageBlock32.SZ*4;

            public const uint PageCount = SZ/PageSize;

            PageBlocks.PageBlock32 Block0;

            PageBlocks.PageBlock32 Block1;

            PageBlocks.PageBlock32 Block2;

            PageBlocks.PageBlock32 Block3;
        }

        [StructLayout(LayoutKind.Sequential, Size = (int)SZ)]
        public struct PageBlock64x4 : IPageBlock<PageBlock64x4>
        {
            public const uint SZ = PageBlock64.SZ*4;

            public const uint PageCount = SZ/PageSize;

            PageBlocks.PageBlock64 Block0;

            PageBlocks.PageBlock64 Block1;

            PageBlocks.PageBlock64 Block2;

            PageBlocks.PageBlock64 Block3;
        }
    }
}