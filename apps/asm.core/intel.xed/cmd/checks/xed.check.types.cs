//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedRules;
    using static core;

    partial class AsmCoreCmd
    {
        [CmdOp("xed/check/types")]
        Outcome CheckTypes(CmdArgs args)
        {
            Write(nameof(XedTypes.Numeric));
            iter(XedTypes.Numeric, t => Write(string.Format("{0,-8} | {1,-8} | {2}", t.Key, t.Format(), t.Size)));

            Write(nameof(XedTypes.Primitives));
            iter(XedTypes.Primitives, t => Write(string.Format("{0,-8} | {1,-8} | {2}", t.PrimalKind, t.Format(), t.Size)));
            return true;
        }
    }
}