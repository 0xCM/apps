//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;

    using static core;

    partial class XedDisasm
    {
        public static Detail detail(WsContext context, in FileRef src)
            => detail(context, datafile(context, src));

        public static Detail detail(WsContext context, in DataFile src)
        {
            var dst = bag<DetailBlock>();
            blocks(summary(context, src), dst);
            return new Detail(src, dst.ToArray().Sort());
        }

        static ConstLookup<Summary,Detail> details(Index<Summary> src, bool pll = true)
        {
            var dst = cdict<Summary,Detail>();
            iter(src, doc => dst.TryAdd(doc, new Detail(doc.DataFile, blocks(doc))), pll);
            return dst;
        }

        static DetailBlock block(in SummaryLines src)
        {
            parse(src, out Instruction inst).Require();
            return new DetailBlock(row(src), src, inst);
        }

        static Index<DetailBlock> blocks(Summary src, bool pll = true)
        {
            var dst = bag<DetailBlock>();
            iter(src.LineIndex, summary => dst.Add(block(summary)), pll);
            return resequence(dst.Array());
        }

        public static Detail detail(WsContext context, Summary summary)
        {
            var dst = bag<DetailBlock>();
            blocks(summary, dst);
            return new Detail(summary.DataFile, dst.ToArray().Sort());
        }

        static void blocks(Summary doc, ConcurrentBag<DetailBlock> dst)
        {
            var _lines = doc.LineIndex;
            Require.equal(doc.LineIndex.Count, doc.RowCount);
            for(var i=0; i<doc.LineIndex.Count; i++)
            {
                ref readonly var lines = ref doc.LineIndex[i];
                parse(lines, out Instruction inst).Require();
                dst.Add(new (row(lines), lines, inst));
            }
        }
    }
}