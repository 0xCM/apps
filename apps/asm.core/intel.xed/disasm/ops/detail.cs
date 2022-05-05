//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial class XedDisasm
    {
        public static Detail detail(WsContext context, in FileRef src)
            => detail(context, datafile(context, src));

        public static Detail detail(WsContext context, in DataFile src)
            => detail(summary(context,src));

        public static Detail detail(Summary summary, bool pll = true)
        {
            var dst = bag<DetailBlock>();
            iter(summary.LineIndex, lines => dst.Add(block(lines)), pll);
            return new Detail(summary.DataFile, resequence(dst.ToArray()));
        }

        static DetailBlock block(in SummaryLines src)
        {
            parse(src, out Instruction inst).Require();
            return new DetailBlock(row(src), src, inst);
        }
    }
}