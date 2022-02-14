//-----------------------------------------------------------------------------
// Copyright   : Intel Corporation, 2020
// License     : Apache
// Source      : xed-state-bits.txt
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct XedRecords
    {
        /// <summary>
        /// Defines 3-bit emission codes for vex map specification as determined by the presence
        /// of a <see cref='VectorLengthKind'/> value and a <see cef='VexPrefixKind'/> value
        /// </summary>
        [SymSource(xed,NumericBaseKind.Base2), DataWidth(3)]
        public enum VexRXB : byte
        {
            /// <summary>
            /// VL128 VEX_PREFIX=0  ->	emit 0b000
            /// </summary>
            [Symbol("L0 + VNP")]
            L0_VNP = 0b000,

            /// <summary>
            /// VL128 VEX_PREFIX=1  ->	emit 0b001
            /// </summary>
            [Symbol("L0 + V0F")]
            L0_V0F = 0b001,

            /// <summary>
            /// VL128 VEX_PREFIX=2  ->	emit 0b011
            /// </summary>
            [Symbol("L0 + V0F38")]
            L0_V0F38 = 0b011,

            /// <summary>
            /// VL128 VEX_PREFIX=3  ->	emit 0b010
            /// </summary>
            [Symbol("L0 + V0F3A")]
            L0_V0F3A = 0b010,

            /// <summary>
            /// VL256 VEX_PREFIX=0  ->	emit 0b100
            /// </summary>
            [Symbol("L1 + VNP")]
            L1_VNP = 0b100,

            /// <summary>
            /// VL256 VEX_PREFIX=1  ->	emit 0b101
            /// </summary>
            [Symbol("L1 + V0F")]
            L1_V0F = 0b101,

            /// <summary>
            /// VL256 VEX_PREFIX=2  ->	emit 0b111
            /// </summary>
            [Symbol("L1 + V0F38")]
            L1_V0F38 = 0b111,

            /// <summary>
            /// VL256 VEX_PREFIX=3  ->	emit 0b110
            /// </summary>
            [Symbol("L1 + V0F3A")]
            L1_V0F3A = 0b110,
        }
    }
}