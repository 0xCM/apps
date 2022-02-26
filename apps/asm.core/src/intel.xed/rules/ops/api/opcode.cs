//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedModels;

    partial class XedRules
    {
        public XedOpCode opcode(in RulePattern src)
            => new XedOpCode(src.Class, src.OpCodeKind, XedOpCodeParser.value(src));

        public XedOpCode opcode(OpCodeKind kind, IClass @class, string pattern)
            => new XedOpCode(@class, kind, XedOpCodeParser.value(pattern));
    }
}