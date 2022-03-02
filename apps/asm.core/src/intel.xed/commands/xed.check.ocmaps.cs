//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedModels;

    partial class XedCmdProvider
    {
        [CmdOp("xed/check/ocmaps")]
        Outcome CheckOcmaps(CmdArgs args)
        {
            var result = Outcome.Success;
            var patterns = Xed.Rules.LoadEncRulePatterns();
            var reader = patterns.Reader();
            var maps = Symbols.index<OpCodeKind>();
            var counts = maps.Counts();
            while(reader.Next(out var pattern))
                counts.Inc(pattern.OpCodeKind);

            var total = counts.Total();
            Require.equal(total, patterns.Count);

            Write(counts.Format());
            return result;
        }
    }
}