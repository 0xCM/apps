//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using static AsmOpCodeTokens;

    public enum AsmOcTokenKind : byte
    {
        /// <summary>
        /// Classifies the untoken
        /// </summary>
        None = 0,

        /// <summary>
        /// Classifies the 256 literal hex bytes [0xOO, 0x01, ..., 0xFF]
        /// </summary>
        Byte = 1,

        /// <summary>
        /// Classifies <see cref='RexToken'/> tokens
        /// </summary>
        Rex = 2,

        /// <summary>
        /// Classifies <see cref='VexToken'/> tokens
        /// </summary>
        Vex = 3,

        /// <summary>
        /// Classifies <see cref='EvexToken'/> tokens
        /// </summary>
        Evex = 4,

        /// <summary>
        /// Classifies <see cref='EscapeToken'/> prefix tokens
        /// </summary>
        Escape = 5,

        /// <summary>
        /// <summary>
        /// Classifies <see cref='RexBToken'/> tokens
        /// </summary>
        RexBExtension = 6,

        /// <summary>
        /// Classifies <see cref='OcExtension'/> tokens
        /// </summary>
        OcExtension = 7,

        /// <summary>
        /// Classifies <see cref='SegOverrideToken'/> tokens
        /// </summary>
        SegOverride = 8,

        /// <summary>
        /// Classifies <see cref='DispToken'/> tokens
        /// </summary>
        Disp = 9,

        /// <summary>
        /// Classifies <see cref='ImmSizeToken'/> tokens
        /// </summary>
        ImmSize = 10,

        /// <summary>
        /// Classifies <see cref='ExclusionToken'/> tokens
        /// </summary>
        Exclusion = 11,

        /// <summary>
        /// Classifies <see cref='FpuDigitToken'/> tokens
        /// </summary>
        FpuDigit = 12,

        /// <summary>
        /// Classifies <see cref='MaskToken'/> tokens
        /// </summary>
        Mask = 13,

        /// <summary>
        /// Classifies <see cref='OpCodeOperator'/> tokens
        /// </summary>
        Operator = 14,
    }
}