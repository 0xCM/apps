//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{

    using static XedModels;

    partial class AsmCoreCmd
    {
        [CmdOp("symbols/check")]
        void CheckSymHeaps()
        {
            var src = Heaps.symbols<IFormType>(w32,w8);
            var count = src.EntryCount;
            var size = src.Size;
            var remainder = src.Size/2;
            for(var i=0u; i<count; i++)
            {
                ref readonly var entry = ref src.Entry(i);
                var symbol = src.Symbol(entry);
                var length  = (uint)Require.equal(entry.Length, symbol.Length);
                remainder -= length;
                Write(string.Format("{0,-8} | {1,-8} | {2,-8} | {3,-8} | {4,-64} | '{5}'",
                    i,
                    entry.Offset,
                    entry.Length,
                    remainder,
                    entry.Index,
                    text.format(symbol)
                    ));
            }
        }
    }
}