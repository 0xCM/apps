//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedCmdProvider
    {
        [CmdOp("xed/emit/analysis")]
        Outcome EmitAnalysis(CmdArgs args)
        {
            var src = CalcRuleCells();
            var analyzer = new RuleAnalyzer(this, (data,count,path) => FileEmit(data, count,path, TextEncodingKind.Asci));
            analyzer.Run(src);
            return true;
        }
    }
}