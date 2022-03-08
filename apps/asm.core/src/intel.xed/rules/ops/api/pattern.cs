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
        [MethodImpl(Inline), Op]
        public static RulePattern pattern(uint seq, IClass @class, OpCodeKind kind, AsmOcValue value, params RuleToken[] tokens)
            => new RulePattern(seq,@class, kind, ocvalue(tokens), tokens);
    }
}