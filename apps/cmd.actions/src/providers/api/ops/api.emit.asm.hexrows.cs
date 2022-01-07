//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial class ApiCmdProvider
    {
        [CmdOp("api/emit/asm/hexrows")]
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