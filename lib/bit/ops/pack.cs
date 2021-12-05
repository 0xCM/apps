//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    partial struct bit
    {
        /// <summary>
        /// Packs 2 source bits into the least 2 bits of a byte
        /// </summary>
        [MethodImpl(Inline), Pack]
        public static byte pack(bit b0, bit b1)
        {
            var dst = (uint)b0;
            dst |= ((uint)b1 << 1);
            return (byte)dst;
        }

        /// <summary>
        /// Packs 3 source bits into the least 2 bits of a byte
        /// </summary>
        [MethodImpl(Inline), Pack]
        public static byte pack(bit b0, bit b1, bit b2)
        {
            var dst = (uint)b0;
            dst |= ((uint)b1 << 1);
            dst |= ((uint)b2 << 2);
            return (byte)dst;
        }

        /// <summary>
        /// Packs 4 source bits into the least 4 bits of a byte
        /// </summary>
        [MethodImpl(Inline), Pack]
        public static byte pack(bit b0, bit b1, bit b2, bit b3)
        {
            var dst = (uint)b0;
            dst |= ((uint)b1 << 1);
            dst |= ((uint)b2 << 2);
            dst |= ((uint)b3 << 3);
            return (byte)dst;
        }

        /// <summary>
        /// Packs 8 source bits into a byte
        /// </summary>
        [MethodImpl(Inline), Pack]
        public static byte pack(bit b0, bit b1, bit b2, bit b3, bit b4, bit b5, bit b6, bit b7)
        {
            var dst = (uint)b0;
            dst |= ((uint)b1 << 1);
            dst |= ((uint)b2 << 2);
            dst |= ((uint)b3 << 3);
            dst |= ((uint)b4 << 4);
            dst |= ((uint)b5 << 5);
            dst |= ((uint)b6 << 6);
            dst |= ((uint)b7 << 7);
            return (byte)dst;
        }

        /// <summary>
        /// Packs 5 source bits into the least 5 bits of a byte
        /// </summary>
        [MethodImpl(Inline), Pack]
        public static byte pack(bit b0, bit b1, bit b2, bit b3, bit b4)
        {
            var dst = (uint)b0;
            dst |= ((uint)b1 << 1);
            dst |= ((uint)b2 << 2);
            dst |= ((uint)b3 << 3);
            dst |= ((uint)b4 << 4);
            return (byte)dst;
        }

        /// <summary>
        /// Packs 6 source bits into the least 6 bits of a byte
        /// </summary>
        [MethodImpl(Inline), Pack]
        public static byte pack(bit b0, bit b1, bit b2, bit b3, bit b4, bit b5)
        {
            var dst = (uint)b0;
            dst |= ((uint)b1 << 1);
            dst |= ((uint)b2 << 2);
            dst |= ((uint)b3 << 3);
            dst |= ((uint)b4 << 4);
            dst |= ((uint)b5 << 5);
            return (byte)dst;
        }

        /// <summary>
        /// Packs 7 source bits into the least 7 bits of a byte
        /// </summary>
        [MethodImpl(Inline), Pack]
        public static byte pack(bit b0, bit b1, bit b2, bit b3, bit b4, bit b5, bit b6)
        {
            var dst = (uint)b0;
            dst |= ((uint)b1 << 1);
            dst |= ((uint)b2 << 2);
            dst |= ((uint)b3 << 3);
            dst |= ((uint)b4 << 4);
            dst |= ((uint)b5 << 5);
            dst |= ((uint)b6 << 6);
            return (byte)dst;
        }
    }
}