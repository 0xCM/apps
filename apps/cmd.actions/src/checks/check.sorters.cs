//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static Rules;

    partial class CheckCmdProvider
    {
        [CmdOp("check/sorters")]
        Outcome RunSorters(CmdArgs args)
        {
            var result = Outcome.Success;
            var sorter = SortingNetworks.define<byte>();
            byte x0 = 9, x1 = 5, x2 = 2, x3 = 6;
            sorter.Send(x0, x1, x2, x3, out var y0, out var y1, out var y2, out var y3);
            Write(string.Format("{0} -> {1}", x0, y0));
            Write(string.Format("{0} -> {1}", x1, y1));
            Write(string.Format("{0} -> {1}", x2, y2));
            Write(string.Format("{0} -> {1}", x3, y3));
            return result;
        }

        [CmdOp("check/rules/replace")]
        Outcome CheckReplaceRules(CmdArgs args)
        {
            var rule = new SeqRange<string>("a","b");
            //var rule = new ReplaceRule<string>("a","b");


            return true;
        }
    }
}