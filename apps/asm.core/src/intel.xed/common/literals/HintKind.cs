//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct XedModels
    {
        [SymSource(xed), DataWidth(3)]
        public enum HintKind : byte
        {
            [Symbol("", "No hint")]
            None = 0,

            [Symbol("UNTAKEN_CS", "CS PREFIX OBSERVED (NOT TAKEN)")]
            UNTAKEN_CS= 1,

            [Symbol("UNTAKEN_CS", "DS PREFIX OBSERVED (TAKEN)")]
            TAKEN_DS = 2,

            [Symbol("UNTAKEN_VALIDATED", "NOT TAKEN HINT VALIDATED for a BRANCH")]
            UNTAKEN_VALIDATED = 3,

            [Symbol("TAKEN_VALIDATED", "TAKEN HINT VALIDATED for a BRANCH")]
            TAKEN_VALIDATED = 4
        }
    }
}