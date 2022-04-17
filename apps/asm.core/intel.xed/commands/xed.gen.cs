//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;
    using static XedDisasm;
    using static XedMachine;
    using static XedRules;

    partial class XedCmdProvider
    {
        [CmdOp("xed/gen")]
        Outcome XedGen(CmdArgs args)
        {
            var context = Context();
            var pll = true;
            var sources = XedDisasm.sources(context);

            foreach(var file in sources)
            {
                var summary = XedDisasm.summary(context,file);
                Write(string.Format("{0,-8} | {1}", summary.RowCount, file));
            }
            // var dst = sources.Select(file => (file, Index<DetailBlock>.Empty)).ToConcurrentDictionary();
            // iter(dst, b => dst.TryAdd(b.Key, XedDisasm.blocks(context,b.Key)), pll);


            // var files = dst.Keys.Array().Sort();
            // for(var i=0; i<files.Length; i++)
            // {
            //     ref readonly var file = ref skip(files,i);
            //     var blocks = dst[file];
            //     Write(string.Format("{0,-8} | {1,-8} | {2}", i, blocks.Count, file));
            // }

            // ref readonly var fields = ref XedFields.ByPosition;
            // var bits = fields[0,51];
            // var dst = BitVector64.Zero;
            // var set = FieldSet.create();
            // for(var i=z8; i<bits.Length; i++)
            // {
            //     ref readonly var field = ref skip(bits,i);
            //     Write(string.Format("{0,-8} | {1,-24} | {2}", field.Pos, field.Field, field.FieldSize));

            // }


            return true;
        }

    }
}