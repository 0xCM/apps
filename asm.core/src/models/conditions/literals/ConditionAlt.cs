//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using static BitSeq;

    using K = ConditionCodes.ConditionKind;

    partial struct ConditionCodes
    {
        [SymSource(K.CodeAlt)]
        public enum ConditionAlt : byte
        {
            /// <summary>
            /// Overflow
            /// </summary>
            [Symbol("O", "Overflow")]
            O = b0000,

            /// <summary>
            /// Not Overflow
            /// </summary>
            [Symbol("NO", "Not Overflow")]
            NO = b0001,

            /// <summary>
            /// Below, not above or equal
            /// </summary>
            [Symbol("NAE", "Not Above or Equal")]
            NAE = b0010,

            /// <summary>
            /// Not Below
            /// </summary>
            [Symbol("AE", "Above or Equal")]
            AE = b0011,

            /// <summary>
            /// Equal; Zero
            /// </summary>
            [Symbol("Z", "Zero")]
            Z = b0100,

            /// <summary>
            /// Not Equal; Not Zero
            /// </summary>
            [Symbol("NZ", "Not Zero")]
            NZ = b0101,

            /// <summary>
            /// Below or equal, Not above
            /// </summary>
            [Symbol("NA", "Not Above")]
            NA = b0110,

            /// <summary>
            /// Not below or equal, Above
            /// </summary>
            [Symbol("A", "Above")]
            A = b0111,

            /// <summary>
            /// Sign
            /// </summary>
            [Symbol("S", "Sign")]
            S = b1000,

            /// <summary>
            /// Not sign
            /// </summary>
            [Symbol("NS", "Not Signed")]
            NS = b1001,

            /// <summary>
            /// Parity Even
            /// </summary>
            [Symbol("PE", "Parity Even")]
            PE = b1010,

            /// <summary>
            /// Parity Odd
            /// </summary>
            [Symbol("PO", "Parity Odd")]
            PO = b1011,

            /// <summary>
            /// Less than; Not greater than or equal to
            /// </summary>
            [Symbol("NGE", "Not Greater Than or Equal")]
            NGE = b1100,

            /// <summary>
            /// Not less than, Greater than or equal to
            /// </summary>
            [Symbol("GE", "Greater Than or Equal")]
            GE = b1101,

            /// <summary>
            /// Less than or equal to, Not greater than
            /// </summary>
            [Symbol("NGT", "Not Greater Than")]
            NGT = b1110,

            /// <summary>
            /// Not less than or equal to, Greater than
            /// </summary>
            [Symbol("GT", "Greater Than")]
            GT = b1111,
        }
    }
}