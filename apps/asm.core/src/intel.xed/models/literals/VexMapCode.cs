//-----------------------------------------------------------------------------
// Copyright   : Intel Corporation, 2020
// License     : Apache
// Source      : xed-state-bits.txt
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct XedModels
    {
        /// <summary>
        /// Defines 3-bit emission codes for vex map specification as determined by the presence
        /// of a <see cref='VexLengthKind'/> value and a <see cef='VexPrefixKind'/> value
        /// </summary>
        [SymSource(NumericBaseKind.Base2), DataWidth(3)]
        public enum VexMapCode : byte
        {
            /// <summary>
            /// VL128 VEX_PREFIX=0  ->	emit 0b000
            /// </summary>
            [Symbol("VL0 + VNP")]
            VL0_VNP = 0b000,

            /// <summary>
            /// VL128 VEX_PREFIX=1  ->	emit 0b001
            /// </summary>
            [Symbol("VL0 + V0F")]
            VL0_V0F = 0b001,

            /// <summary>
            /// VL128 VEX_PREFIX=2  ->	emit 0b011
            /// </summary>
            [Symbol("VL0 + V0F38")]
            VL0_V0F38 = 0b011,

            /// <summary>
            /// VL128 VEX_PREFIX=3  ->	emit 0b010
            /// </summary>
            [Symbol("VL0 + V0F3A")]
            VL0_V0F3A = 0b010,

            /// <summary>
            /// VL256 VEX_PREFIX=0  ->	emit 0b100
            /// </summary>
            [Symbol("VL1 + VNP")]
            VL1_VNP = 0b100,

            /// <summary>
            /// VL256 VEX_PREFIX=1  ->	emit 0b101
            /// </summary>
            [Symbol("VL0 + V0F")]
            VL1_V0F = 0b101,

            /// <summary>
            /// VL256 VEX_PREFIX=2  ->	emit 0b111
            /// </summary>
            [Symbol("VL0 + V0F38")]
            VL1_V0F38 = 0b111,

            /// <summary>
            /// VL256 VEX_PREFIX=3  ->	emit 0b110
            /// </summary>
            [Symbol("VL0 + V0F3A")]
            VL1_V0F3A = 0b110,
        }
    }
}