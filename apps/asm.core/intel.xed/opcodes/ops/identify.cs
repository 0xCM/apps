//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedRules;
    using static XedModels;

    partial class XedOpCodes
    {
        public static Index<OpCodeId> identify(Index<PatternOpCode> src)
            => OpCodeIdentity.identify(src);
    }
}