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
        ApiServices ApiSvc => Service(Wf.ApiServices);

        ApiEmitters ApiEmitters => ApiSvc.Emitters;

        ApiComments ApiComments => ApiSvc.Comments;

        ApiPackArchive ApiPacks => ApiPackArchive.create(AppDb.ApiTargets("capture"));

        ApiMd ApiMetadata => Service(Wf.ApiMetadata);

        ApiHexPacks HexPacks => Wf.HexPack();

        HexEmitter HexEmitter => Wf.HexEmitter();

        const string il = nameof(il);

        [CmdOp("api/emit/msil")]
        void EmitMsil()
        {
            AppDb.MsilTargets().Delete();
            ApiMetadata.EmitMsil(ApiRuntimeCatalog.ApiHosts, AppDb.MsilTargets(il));
        }

        [CmdOp("api/emit/hex")]
        void EmitApiHex()
        {
            var result = Outcome.Success;
            const uint BufferLength = Pow2.T16;
            var blocks = HexPacks.LoadBlocks(ApiPacks.HexPackRoot()).View;
            var count = blocks.Length;
            var buffer = span<char>(BufferLength);
            var dst = ProjectDb.Api() + FS.file("api", FS.Hex);
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
        }

        [CmdOp("api/emit/hexrows")]
        void EmitApiHexRows()
        {
            var blocks = HexPacks.LoadBlocks(ApiPacks.HexPackRoot()).View;
            var count = blocks.Length;
            var dir = AppDb.ApiTargets("capture.hex").Dir("rows");
            for(var i=0; i<count; i++)
            {
                ref readonly var block = ref skip(blocks,i);
                HexEmitter.EmitBasedRows(block.View, 64, dir + FS.file(block.Origin.Format(), FS.Hex));
            }
        }

        [CmdOp("api/emit")]
        void ApiEmit()
        {
            ApiEmitters.Emit();
        }

        [CmdOp("api/tables")]
        void ApiTables()
        {
            var src = Tables.reflected(ApiRuntimeCatalog.Components);
            for(var i=0; i<src.Count; i++)
            {
                ref readonly var table = ref src[i];
                ref readonly var fields = ref table.Fields;
                for(var j=0; j<fields.Count; j++)
                {
                    ref readonly var field = ref fields[j];
                    Write(string.Format("{0,-24} | {1,-12} | {2,-12} | {3,-12} | {4,-12}",
                        table.Type.DisplayName(),
                        table.Layout,
                        table.Pack,
                        field.FieldIndex,
                        field.FieldWidth
                        ));
                }
            }

        }

        [CmdOp("api/emit/comments")]
        void ApiEmitComments()
        {
            var ds = ApiComments.Calc();
            ref readonly var xmlsources = ref ds.XmlSources;
            iter(xmlsources, path => Write(path.ToUri()));

            ref readonly var csvtargets = ref ds.CsvRowLookup;
            iter(csvtargets.Keys, key => Write(key.ToUri().Format()));

            ref readonly var sources = ref ds.Sources;
            iter(sources, source => Write(source.ToUri()));
        }

        [CmdOp("api/emit/index")]
        void EmitRuntimeMembers()
        {
            var service = ApiRuntime.create(Wf);
            var members = service.EmitRuntimeIndex();
        }

        [CmdOp("api/emit/classes")]
        Outcome EmitApiClasses(CmdArgs args)
        {
            var classifier = Classifiers.classifier<AsmSigTokens.GpRmToken,byte>();
            var count = classifier.ClassCount;
            for(var i=0; i<count; i++)
            {
                ref readonly var c = ref classifier[i];
                Write(string.Format("{0,-4} | {1,-16} | {2,-16} | {3, -16} | {4}", c.Ordinal, c.ClassName, c.Identifier, c.Symbol, c.Value));
            }
            var dst = text.emitter();
            RenderApiClasses<AsmSigTokens.GpRmToken,byte>(dst);
            Write(dst.Emit());
            return true;
        }

        void RenderApiClasses<K,T>(ITextEmitter dst, bool header = true)
            where K : unmanaged, Enum
            where T : unmanaged
        {
            const string Format = "{0,-4} | {1,-16} | {2,-16} | {3, -16} | {4}";
            var k = Classifiers.classifier<K,T>();
            var count = k.ClassCount;
            if(header)
                dst.AppendLineFormat(Format,
                    nameof(ValueClass.Ordinal),
                    nameof(ValueClass.ClassName),
                    nameof(ValueClass.Identifier),
                    nameof(ValueClass.Symbol),
                    nameof(ValueClass.Value)
                    );
            iteri(count, i => dst.AppendLineFormat(Format, k[i].Ordinal, k[i].ClassName, k[i].Identifier, k[i].Symbol, k[i].Value));
        }
   }
}