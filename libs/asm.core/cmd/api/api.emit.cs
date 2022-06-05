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

        [CmdOp("api/emit/hex")]
        void EmitApiHex()
        {
            var result = Outcome.Success;
            const uint BufferLength = Pow2.T16;
            var blocks = ApiCode.LoadMemoryBlocks(ApiPacks.HexPackRoot()).View;
            var count = blocks.Length;
            var buffer = span<char>(BufferLength);
            var dst = ProjectDb.Api() + FS.file("api", FS.Hex);
            // using var writer = dst.AsciWriter();
            // for(var i=0u; i<count; i++)
            // {
            //     buffer.Clear();
            //     ref readonly var block = ref skip(blocks,i);
            //     var length = Hex.hexarray(block.View, buffer);
            //     var content = text.format(slice(buffer,0,length));
            //     writer.WriteLine(content);
            // }
            // Write(string.Format("Emitted {0} hex blocks to {1}", count, dst.ToUri()));
        }

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