//-----------------------------------------------------------------------------
// Copyright   : Intel Corporation, 2020
// License     : Apache
// Source      : xed-iclass-enum.h
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct XedModels
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
            [Symbol("RW", "Read and written (must write)")]
            RW,

            /// <summary>
            /// Read-only
            /// </summary>
            [Symbol("R", "Read-only")]
            R,

            /// <summary>
            /// Write-only (must write)
            /// </summary>
            [Symbol("W", "Write-only (must write)")]
            W,

            /// <summary>
            /// Read and conditionlly written (may write)
            /// </summary>
            [Symbol("RCW", "Read and conditionlly written (may write)")]
            RCW,

            /// <summary>
            /// Conditionlly written (may write)
            /// </summary>
            [Symbol("CW", "Conditionlly written (may write)")]
            CW,

            /// <summary>
            /// Conditionlly read, always written (must write)
            /// </summary>
            [Symbol("CRW", "Conditionlly read, always written (must write)")]
            CRW,

            /// <summary>
            /// Conditional read
            /// </summary>
            [Symbol("CR", "Conditional read")]
            CR
        }
    }
}