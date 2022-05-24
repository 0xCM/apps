//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedModels;
    using static XedRules;

    partial class XedDisasmModels
    {

    }

    partial class XedDisasm
    {
        [StructLayout(LayoutKind.Sequential, Pack=1)]
        public record struct OpDetail
        {
            public OpSpec Spec;

            public OpWidthRecord OpWidth;

            public OpName OpName;

            public Operand Def;

            public @string RuleDescription;

            public TextBlock DefDescription;

            public OpAction Action
            {
                [MethodImpl(Inline)]
                get => Spec.Action;
            }

            public string Format()
                => DefDescription;

            public override string ToString()
                => Format();
        }
    }
}