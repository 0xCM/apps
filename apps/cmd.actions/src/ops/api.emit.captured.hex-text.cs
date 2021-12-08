//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;
    using static core;

    partial class GlobalCommands
    {
        [CmdOp("api/emit/captured/hex-text")]
        Outcome ApiEmitAsmHexText(CmdArgs args)
        {
            var result = Outcome.Success;
            var blocks = ApiHexPacks.LoadBlocks(ApiPackArchive.HexPackRoot()).View;
            var count = blocks.Length;
            var buffer = span<char>(Pow2.T16);
            var dst = ProjectDb.Subdir("api") + FS.file("api", FS.Hex);
            using var writer = dst.AsciWriter();
            for(var i=0u; i<count; i++)
            {
                buffer.Clear();
                ref readonly var block = ref skip(blocks,i);
                var length = Hex.hexarray(block.View, buffer);
                var content = text.format(slice(buffer,0,length));
                writer.WriteLine(content);
            }
            Write(string.Format("Emitted {0} hex blocks to {1}", count, dst.ToUri()));
            return result;
        }
    }
}