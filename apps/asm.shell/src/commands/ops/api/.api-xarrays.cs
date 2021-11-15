//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using static core;

    partial class AsmCmdService
    {
        [CmdOp(".api-xarrays")]
        Outcome ApiHexArrays(CmdArgs args)
        {
            var result = Outcome.Success;
            var blocks = ApiHexPacks.LoadBlocks(ApiArchive.HexPackRoot()).View;
            var count = blocks.Length;
            var buffer = span<char>(Pow2.T16);
            var outpath = AsmWs.Root + FS.folder("data") + FS.file("api", FS.XArray);
            using var writer = outpath.AsciWriter();
            for(var i=0u; i<count; i++)
            {
                buffer.Clear();
                ref readonly var block = ref skip(blocks,i);
                var length = Hex.hexarray(block.View, buffer);
                var content = text.format(slice(buffer,0,length));
                writer.WriteLine(content);
            }
            Write(string.Format("Emitted {0} array blocks to {1}", count, outpath.ToUri()));
            return result;
        }
    }
}