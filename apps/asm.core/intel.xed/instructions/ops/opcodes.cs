//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedRules;

    partial class XedPatterns
    {
        public static Index<XedOpCode> opcodes(Index<InstPattern> src)
            => src.Map(x => x.Spec.OpCode).Sort();
    }
}