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
            Write(nameof(XedDataTypes.IntrinsicNumeric));
            iter(XedDataTypes.IntrinsicNumeric, t => Write(string.Format("{0,-8} | {1,-8} | {2}", t.Key, t.Format(), t.Width)));
            return true;
        }
    }
}