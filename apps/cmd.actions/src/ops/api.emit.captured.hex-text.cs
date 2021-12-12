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
            const uint BufferLength = Pow2.T16;
            var blocks = ApiHexPacks.LoadBlocks(ApiPackArchive.HexPackRoot()).View;
            var count = blocks.Length;
            var buffer = span<char>(BufferLength);
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

        [CmdOp("api/emit/captured/hex-functions")]
        Outcome ApiEmitAsmHexTextBlocks(CmdArgs args)
        {
            var result = Outcome.Success;
            var blocks = ApiHexPacks.LoadBlocks(ApiPackArchive.HexPackRoot()).View;
            var count = blocks.Length;
            var emitter = Wf.HexEmitter();
            var apidb = ProjectDb.Subdir("api") + FS.folder("hex");
            for(var i=0; i<count; i++)
            {
                ref readonly var block = ref skip(blocks,i);
                var outpath = apidb + FS.file(block.Origin.Format(), FS.Hex);
                emitter.EmitBasedRows(block.View, 64, outpath);
            }

            return result;
        }
    }
}