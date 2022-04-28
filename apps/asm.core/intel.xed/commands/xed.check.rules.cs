//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedModels;
    using static Char5;
    using static XedRules;


    partial class XedCmdProvider
    {
        [CmdOp("xed/check/rules")]
        Outcome CheckRules(CmdArgs args)
        {
            var src = CalcRuleCells();
            var analyzer = new RuleAnalyzer(this, (data,count,path) => FileEmit(data, count,path, TextEncodingKind.Asci));
            analyzer.Run(src);
            return true;
        }

        [CmdOp("bitfields/check")]
        Outcome CheckBitfields(CmdArgs args)
        {
            var bf = RuleFieldBits.create();
            Write(bf.Dataset.Intervals.Format());
            return true;
        }
    }
}