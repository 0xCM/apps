//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct XedModels
    {
        [SymSource(xed)]
        public enum RuleDocKind : byte
        {
            [Symbol("all-enc-instructions")]
            EncInstDef,

            [Symbol("all-dec-instructions")]
            DecInstDef,

            [Symbol("all-enc-patterns")]
            EncRuleTable,

            [Symbol("all-dec-patterns")]
            DecRuleTable,

            [Symbol("all-enc-dec-patterns")]
            EncDecRuleTable,

            [Symbol("all-widths")]
            Widths,

            [Symbol("all-pointer-names")]
            PointerWidths,

            Patterns,
        }
    }
}