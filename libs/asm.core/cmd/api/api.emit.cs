//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;

    using static core;

    partial class AsmCoreCmd
    {
        ApiComments ApiComments => Wf.ApiComments();

        ApiPackArchive ApiPacks => ApiPackArchive.create(AppDb.ApiTargets("capture/packs"));

        ApiCodeFiles ApiFiles => Wf.ApiCodeFiles();

        ApiMd ApiMd => Wf.ApiMetadata();

        HexEmitter HexEmitter => Wf.HexEmitter();

        const string il = nameof(il);


        [CmdOp("api/emit/hexrows")]
        void EmitApiHexRows()
        {
            var blocks = ApiCode.LoadMemoryBlocks(ApiPacks.HexPackRoot()).View;
            var count = blocks.Length;
            var dir = AppDb.ApiTargets("capture.hex").Dir("rows");
            for(var i=0; i<count; i++)
            {
                ref readonly var block = ref skip(blocks,i);
                HexEmitter.EmitBasedRows(block.View, 64, dir + FS.file(block.Origin.Format(), FS.Hex));
            }
        }

        [CmdOp("api/emit/classes")]
        Outcome EmitApiClasses(CmdArgs args)
        {
            var classifier = Classifiers.classifier<AsmSigTokens.GpRmToken,byte>();
            var dst = text.emitter();
            Classifiers.render(classifier,dst);
            Write(dst.Emit());
            return true;
        }
   }
}