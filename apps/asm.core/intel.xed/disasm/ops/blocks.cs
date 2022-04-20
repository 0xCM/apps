//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial class XedDisasm
    {
        public static Index<DetailBlock> blocks(WsContext context, in FileRef src)
            => blocks(summary(context,src));

        public static Index<DetailBlock> blocks(Summary src, bool pll = true)
        {
            var dst = bag<DetailBlock>();
            var summaries = src.Lines;
            iter(summaries, summary => dst.Add(new DetailBlock(row(summary), summary)), pll);
            return resequence(dst.Array());
        }
    }
}