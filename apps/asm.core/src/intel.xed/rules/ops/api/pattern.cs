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
        public static RulePattern pattern(IClass @class, OpCodeKind kind, AsmOcValue value, params RuleToken[] tokens)
            => new RulePattern(@class, kind, value,tokens);
    }
}