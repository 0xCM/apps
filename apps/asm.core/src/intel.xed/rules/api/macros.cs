//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedRules
    {
        public static Index<MacroSpec> macros()
            => RuleMacros.specs();

        [MethodImpl(Inline)]
        public static MacroSpec macro(RuleMacroKind kind)
            => MacroLookup[kind];
    }
}