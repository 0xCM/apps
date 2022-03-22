//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using S = XedPatterns.OpCodeSymbols;

    partial struct XedModels
    {
        [SymSource(xed)]
        public enum LegacyMapKind : byte
        {
            [Symbol(S.L0)]
            LEGACY_MAP0 = 0,

            [Symbol(S.L1)]
            LEGACY_MAP1 = 1,

            [Symbol(S.L2)]
            LEGACY_MAP2 = 2,

            [Symbol(S.L3)]
            LEGACY_MAP3 = 3,

            [Symbol(S.D3)]
            AMD_3DNOW = 4,
        }
    }
}