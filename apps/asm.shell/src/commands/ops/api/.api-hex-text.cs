//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using static core;

    partial class AsmCmdService
    {
        [CmdOp(".api-hex-text")]
        Outcome EmitHexText(CmdArgs args)
        {
            var result = Outcome.Success;
            var blocks = ApiHexPacks.LoadBlocks(ApiPackArchive.HexPackRoot()).View;
            var count = blocks.Length;
            var emitter = Wf.HexEmitter();
            var apidb = Ws.Project("db").Subdir("api");
            for(var i=0; i<count; i++)
            {
                ref readonly var block = ref skip(blocks,i);
                var outpath = apidb + FS.file(block.Origin.Format(), FS.Hex);
                emitter.EmitHexText(block.View, 64, outpath);
            }

            return result;
        }
    }
}