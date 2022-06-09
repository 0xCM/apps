//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedModels;

    partial class AsmCoreCmd
    {
        [CmdOp("mem/check/heaps")]
        void CheckHeaps2()
        {
            var src = Heaps.symbols<InstFormType>(w32,w8);
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

        void CheckHeaps1()
        {
            var src = CodeFiles.PartFiles(PartId.Assets);
            var hex = src.Hex.ReadLines();

        }
        [CmdOp("assets/check")]
        void CheckAssets2()
        {
            var src = Assets.strings(typeof(AsciText));
            for(var i=0; i<src.Count; i++)
            {
                ref readonly var res = ref src[i];
                Write(res);
            }
        }
    }
}