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

        static void blocks(Summary doc, ConcurrentBag<DetailBlock> dst)
        {
            var lines = doc.Lines;
            Require.equal(lines.Count, doc.RowCount);
            for(var i=0; i<lines.Count; i++)
                dst.Add(new (row(lines[i]), lines[i]));
        }
    }
}