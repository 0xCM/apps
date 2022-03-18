//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedRules
    {
        [StructLayout(LayoutKind.Sequential,Pack=1)]
        public struct MacroSpec2 : IComparable<MacroSpec2>
        {
            public readonly RuleMacroKind Name;

            public Index<MacroExpansion> Expansions;

            [MethodImpl(Inline)]
            public MacroSpec2(RuleMacroKind name, params MacroExpansion[] expansions)
            {
                Name = name;
                Expansions = expansions;
            }

            public bool IsEmpty
            {
                [MethodImpl(Inline)]
                get => Name == 0;
            }

            public bool IsNonEmpty
            {
                [MethodImpl(Inline)]
                get => Name != 0;
            }

            public string Format()
                => EmptyString;

            public override string ToString()
                => Format();

            [MethodImpl(Inline)]
            public int CompareTo(MacroSpec2 src)
                => ((uint)Name).CompareTo((uint)src.Name);

            public static MacroSpec2 Empty => new MacroSpec2(RuleMacroKind.nothing, sys.empty<MacroExpansion>());
        }
    }
}