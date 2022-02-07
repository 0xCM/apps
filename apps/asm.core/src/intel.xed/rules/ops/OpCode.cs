//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    using static XedModels;
    using static core;

    partial class XedRules
    {
        public XedOpCode OpCode(in RulePattern src)
            => new XedOpCode(src.Class, src.OpCodeKind, XedOpCodeParser.value(src));

        public XedOpCode OpCode(OpCodeKind kind, IClass @class, string pattern)
            => new XedOpCode(@class, kind, XedOpCodeParser.value(pattern));
    }
}