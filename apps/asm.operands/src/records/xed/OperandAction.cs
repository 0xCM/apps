//-----------------------------------------------------------------------------
// Copyright   : Intel Corporation, 2020
// License     : Apache
// Source      : xed-iclass-enum.h
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct XedRecords
    {
        /// <summary>
        /// datafiles/xed-operand-action-enum.txt
        /// </summary>
        [SymSource(xed)]
        public enum OperandAction : byte
        {
            /// <summary>
            /// Read and written (must write)
            /// </summary>
            [Symbol("rw", "Read and written (must write)")]
            RW,

            /// <summary>
            /// Read-only
            /// </summary>
            [Symbol("r", "Read-only")]
            R,

            /// <summary>
            /// Write-only (must write)
            /// </summary>
            [Symbol("w", "Write-only (must write)")]
            W,

            /// <summary>
            /// Read and conditionlly written (may write)
            /// </summary>
            [Symbol("rcw", "Read and conditionlly written (may write)")]
            RCW,

            /// <summary>
            /// Conditionlly written (may write)
            /// </summary>
            [Symbol("cw", "Conditionlly written (may write)")]
            CW,

            /// <summary>
            /// Conditionlly read, always written (must write)
            /// </summary>
            [Symbol("crw", "Conditionlly read, always written (must write)")]
            CRW,

            /// <summary>
            /// Conditional read
            /// </summary>
            [Symbol("cr", "Conditional read")]
            CR
        }
    }
}