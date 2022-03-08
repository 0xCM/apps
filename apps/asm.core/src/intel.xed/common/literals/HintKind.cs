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
            None = 0,

            CsUntaken = 1,

            DsTaken = 2,

            ValidatedUntaken = 3,

            ValidatedTaken = 4
        }
    }
}