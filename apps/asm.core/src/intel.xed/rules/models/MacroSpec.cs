//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedModels;

    partial class XedRules
    {
        [StructLayout(LayoutKind.Sequential,Pack=1)]
        public struct MacroSpec
        {
            public readonly RuleMacroName Name;

            public Index<FieldAssignment> Assignments;

            [MethodImpl(Inline)]
            public MacroSpec(RuleMacroName name, params FieldAssignment[] assign)
            {
                Name = name;
                Assignments = assign;
            }

            public string Format()
                => format(this);

            public override string ToString()
                => Format();

            public static MacroSpec Empty => new MacroSpec(RuleMacroName.None, FieldAssignment.Empty);
        }
    }
}