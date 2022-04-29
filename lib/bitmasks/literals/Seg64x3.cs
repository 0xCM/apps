//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct BitMaskLiterals
    {
        /// <summary>
        ///       0b_000_000_000_000_000_000_000_000_000_000_000_000_000_000_000_000_000_000_000_000_111
        /// </summary>
        [BitMask("0b_000_000_000_000_000_000_000_000_000_000_000_000_000_000_000_000_000_000_000_000_111")]
        public const ulong Seg64x3x0 = 0b_000_000_000_000_000_000_000_000_000_000_000_000_000_000_000_000_000_000_000_000_111;

        /// <summary>
        ///       0b_000_000_000_000_000_000_000_000_000_000_000_000_000_000_000_000_000_000_000_111_000
        /// </summary>
        [BitMask("0b_000_000_000_000_000_000_000_000_000_000_000_000_000_000_000_000_000_000_000_111_000")]
        public const ulong Seg64x3x1 = Seg64x3x0 << 3;

        /// <summary>
        ///       0b_000_000_000_000_000_000_000_000_000_000_000_000_000_000_000_000_000_000_111_000_000
        /// </summary>
        [BitMask("0b_000_000_000_000_000_000_000_000_000_000_000_000_000_000_000_000_000_000_111_000_000")]
        public const ulong Seg64x3x2 = Seg64x3x1 << 3;

        /// <summary>
        ///       0b_000_000_000_000_000_000_000_000_000_000_000_000_000_000_000_000_000_111_000_000_000
        /// </summary>
        [BitMask("0b_000_000_000_000_000_000_000_000_000_000_000_000_000_000_000_000_000_111_000_000_000")]
        public const ulong Seg64x3x3 = Seg64x3x2 << 3;

        /// <summary>
        ///       0b_000_000_000_000_000_000_000_000_000_000_000_000_000_000_000_000_111_000_000_000_000
        /// </summary>
        [BitMask("0b_000_000_000_000_000_000_000_000_000_000_000_000_000_000_000_000_111_000_000_000_000")]
        public const ulong Seg64x3x4 = Seg64x3x3 << 3;

        /// <summary>
        ///       0b_000_000_000_000_000_000_000_000_000_000_000_000_000_000_000_111_000_000_000_000_000
        /// </summary>
        [BitMask("0b_000_000_000_000_000_000_000_000_000_000_000_000_000_000_000_111_000_000_000_000_000")]
        public const ulong Seg64x3x5 = Seg64x3x4 << 3;

        /// <summary>
        ///       0b_000_000_000_000_000_000_000_000_000_000_000_000_000_000_111_000_000_000_000_000_000
        /// </summary>
        [BitMask("0b_000_000_000_000_000_000_000_000_000_000_000_000_000_000_111_000_000_000_000_000_000")]
        public const ulong Seg64x3x6 = Seg64x3x5 << 3;

        /// <summary>
        ///       0b_000_000_000_000_000_000_000_000_000_000_000_000_000_111_000_000_000_000_000_000_000
        /// </summary>
        [BitMask("0b_000_000_000_000_000_000_000_000_000_000_000_000_000_111_000_000_000_000_000_000_000")]
        public const ulong Seg64x3x7 = Seg64x3x6 << 3;

        /// <summary>
        ///       0b_000_000_000_000_000_000_000_000_000_000_000_000_111_000_000_000_000_000_000_000_000
        /// </summary>
        [BitMask("0b_000_000_000_000_000_000_000_000_000_000_000_000_111_000_000_000_000_000_000_000_000")]
        public const ulong Seg64x3x8 = Seg64x3x7 << 3;

        /// <summary>
        ///       0b_000_000_000_000_000_000_000_000_000_000_000_111_000_000_000_000_000_000_000_000_000
        /// </summary>
        [BitMask("0b_000_000_000_000_000_000_000_000_000_000_000_111_000_000_000_000_000_000_000_000_000")]
        public const ulong Seg64x3x9 = Seg64x3x8 << 3;

        /// <summary>
        ///       0b_000_000_000_000_000_000_000_000_000_000_111_000_000_000_000_000_000_000_000_000_000
        /// </summary>
        [BitMask("0b_000_000_000_000_000_000_000_000_000_000_111_000_000_000_000_000_000_000_000_000_000")]
        public const ulong Seg64x3x10 = Seg64x3x9 << 3;

        /// <summary>
        ///       0b_000_000_000_000_000_000_000_000_000_111_000_000_000_000_000_000_000_000_000_000_000
        /// </summary>
        [BitMask("0b_000_000_000_000_000_000_000_000_000_111_000_000_000_000_000_000_000_000_000_000_000")]
        public const ulong Seg64x3x11 = Seg64x3x10 << 3;

        /// <summary>
        ///       0b_000_000_000_000_000_000_000_000_111_000_000_000_000_000_000_000_000_000_000_000_000
        /// </summary>
        [BitMask("0b_000_000_000_000_000_000_000_000_111_000_000_000_000_000_000_000_000_000_000_000_000")]
        public const ulong Seg64x3x12 = Seg64x3x11 << 3;

        /// <summary>
        ///       0b_000_000_000_000_000_000_000_111_000_000_000_000_000_000_000_000_000_000_000_000_000
        /// </summary>
        [BitMask("0b_000_000_000_000_000_000_000_111_000_000_000_000_000_000_000_000_000_000_000_000_000")]
        public const ulong Seg64x3x13 = Seg64x3x12 << 3;

        /// <summary>
        ///       0b_000_000_000_000_000_000_111_000_000_000_000_000_000_000_000_000_000_000_000_000_000
        /// </summary>
        [BitMask("0b_000_000_000_000_000_000_111_000_000_000_000_000_000_000_000_000_000_000_000_000_000")]
        public const ulong Seg64x3x14 = Seg64x3x13 << 3;

        /// <summary>
        ///       0b_000_000_000_000_000_111_000_000_000_000_000_000_000_000_000_000_000_000_000_000_000
        /// </summary>
        [BitMask("0b_000_000_000_000_000_111_000_000_000_000_000_000_000_000_000_000_000_000_000_000_000")]
        public const ulong Seg64x3x15 = Seg64x3x14 << 3;

        /// <summary>
        ///       0b_000_000_000_000_111_000_000_000_000_000_000_000_000_000_000_000_000_000_000_000_000
        /// </summary>
        [BitMask("0b_000_000_000_000_111_000_000_000_000_000_000_000_000_000_000_000_000_000_000_000_000")]
        public const ulong Seg64x3x16 = Seg64x3x15 << 3;

        /// <summary>
        ///       0b_000_000_000_111_000_000_000_000_000_000_000_000_000_000_000_000_000_000_000_000_000
        /// </summary>
        [BitMask("0b_000_000_000_111_000_000_000_000_000_000_000_000_000_000_000_000_000_000_000_000_000")]
        public const ulong Seg64x3x17 = Seg64x3x16 << 3;

        /// <summary>
        ///       0b_000_000_111_000_000_000_000_000_000_000_000_000_000_000_000_000_000_000_000_000_000
        /// </summary>
        [BitMask("0b_000_000_111_000_000_000_000_000_000_000_000_000_000_000_000_000_000_000_000_000_000")]
        public const ulong Seg64x3x18 = Seg64x3x17 << 3;

        /// <summary>
        ///       0b_000_111_000_000_000_000_000_000_000_000_000_000_000_000_000_000_000_000_000_000_000
        /// </summary>
        [BitMask("0b_000_111_000_000_000_000_000_000_000_000_000_000_000_000_000_000_000_000_000_000_000")]
        public const ulong Seg64x3x19 = Seg64x3x18 << 3;

        /// <summary>
        ///       0b_111_000_000_000_000_000_000_000_000_000_000_000_000_000_000_000_000_000_000_000_000
        /// </summary>
        [BitMask("0b_111_000_000_000_000_000_000_000_000_000_000_000_000_000_000_000_000_000_000_000_000")]
        public const ulong Seg64x3x20 = Seg64x3x19 << 3;
    }
}