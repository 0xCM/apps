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
        public XedOpCode opcode(in RulePatternInfo src)
            => new XedOpCode(src.Class, src.OpCodeKind, XedOpCodeParser.value(src));

        public XedOpCode opcode(OpCodeKind kind, IClass @class, string pattern)
            => new XedOpCode(@class, kind, XedOpCodeParser.value(pattern));
    }
}