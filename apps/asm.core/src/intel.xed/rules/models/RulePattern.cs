//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;

    using static XedModels;

    partial class XedRules
    {
        [StructLayout(LayoutKind.Sequential, Pack=1)]
        public readonly struct RulePattern
        {
            public readonly uint Seq;

            public readonly IClass Class;

            public readonly OpCodeKind OcKind;

            public readonly AsmOcValue OcValue;

            public readonly Index<RuleToken> Tokens;

            [MethodImpl(Inline)]
            public RulePattern(uint seq, IClass @class, OpCodeKind kind, AsmOcValue value, RuleToken[] tokens)
            {
                Seq = seq;
                Class = @class;
                OcKind = kind;
                Tokens = tokens;
                OcValue = value;
            }

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