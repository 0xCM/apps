//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedModels;

    using Asm;

    partial class XedRules
    {
        [StructLayout(LayoutKind.Sequential, Pack=1)]
        public readonly struct RulePattern
        {
            public readonly IClass Class;

            public readonly OpCodeKind OcKind;

            public readonly AsmOcValue OcValue;

            public readonly Index<RuleToken> Tokens;

            [MethodImpl(Inline)]
            public RulePattern(IClass @class, OpCodeKind kind, AsmOcValue value, RuleToken[] tokens)
            {
                Class = @class;
                OcKind = kind;
                OcValue = value;
                Tokens = tokens;
            }

            [MethodImpl(Inline)]
            public RulePattern WithTokens(RuleToken[] tokens)
                => new RulePattern(Class,OcKind,OcValue,tokens);

            public bool IsEmpty
            {
                [MethodImpl(Inline)]
                get => Tokens.IsEmpty;
            }

            public bool IsNonEmpty
            {
                [MethodImpl(Inline)]
                get => Tokens.IsNonEmpty;
            }
        }
    }
}