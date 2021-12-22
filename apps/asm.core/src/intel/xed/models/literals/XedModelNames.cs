//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using M = XedModels;

    partial struct XedModels
    {
        [LiteralProvider("xed.models.names")]
        readonly struct Names
        {
            const string xed = "xed.";

            public const string nonterminal = xed + nameof(nonterminal);

            public const string reg = xed + nameof(reg);

            public const string optype = xed + nameof(optype);

            public const string opwidth = xed + nameof(opwidth);

            public const string iform = xed + nameof(iform);
        }
    }
}
