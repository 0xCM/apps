//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    public enum AsmOcTokenKind : byte
    {
        /// <summary>
        /// Classifies the untoken
        /// </summary>
        None = 0,

        /// <summary>
        /// Classifies the 256 literal hex bytes [0x00, 0x01, ..., 0xFF] defined by <see cref='Hex8Kind'/>
        /// </summary>
        Hex8 = 2,

        /// <summary>
        /// Classifies <see cref='RexToken'/> tokens
        /// </summary>
        Rex = 3,

        /// <summary>
        /// Classifies <see cref='VexToken'/> tokens
        /// </summary>
        Vex = 4,

        /// <summary>
        /// Classifies <see cref='EvexToken'/> tokens
        /// </summary>
        Evex = 5,

        /// <summary>
        /// Classifies <see cref='RexBToken'/> tokens
        /// </summary>
        RexB = 6,

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
        /// Classifies <see cref='OperatorToken'/> tokens
        /// </summary>
        Operator = 14,

        /// <summary>
        /// Classifies <see cref='ModRmToken'/> tokens
        /// </summary>
        ModRm = 15,

        /// <summary>
        /// Classifies two adjacent hex bytes
        /// </summary>
        OcLiteral = 16,

        /// <summary>
        /// Classifies <see cref='RepToken'/> tokens
        /// </summary>
        Rep = 17,

        /// <summary>
        /// Classifies <see cref='SizeToken'/> tokens
        /// </summary>
        Size = 18,

        /// <summary>
        /// Classifies <see cref='LockToken'/> tokens
        /// </summary>
        Lock = 19,
    }
}