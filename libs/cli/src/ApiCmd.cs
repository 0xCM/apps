//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    using K = ApiMdKind;

    public class ApiCmd : AppCmdService<ApiCmd>
    {
        ApiMd ApiMd => Wf.ApiMetadata();

        Cli Cli => Wf.Cli();

        Runtime Runtime => Wf.Runtime();

        CsLang CsLang => Wf.CsLang();


        public Index<BitMaskInfo> ApiBitMasks
            => Data(K.BitMasks, () => BitMask.masks(typeof(BitMaskLiterals)));

        [CmdOp("api/emit/bitmasks")]
        void EmitApiBitMasks()
            => Emit(ApiBitMasks);

        [CmdOp("api/emit/classes")]
        Outcome EmitApiClasses(CmdArgs args)
        {
            var classifier = Classifiers.classifier<AsmSigTokens.GpRmToken,byte>();
            var dst = text.emitter();
            Classifiers.render(classifier,dst);
            Write(dst.Emit());
            return true;
        }

        public void Emit(Index<BitMaskInfo> src)
            => TableEmit(src, ProjectDb.ApiTablePath<BitMaskInfo>());

        [CmdOp("api/packs/list")]
        void ListApiPacks()
        {
            var src = AppDb.apipacks();
            for(var i=0; i<src.Count; i++)
            {
                ref readonly var pack = ref src[i];
                Write($"{i}", pack.Timestamp);
            }

        }

        [CmdOp("api/pack/list")]
        Outcome ListApiPack(CmdArgs args)
        {
            var result = Outcome.Failure;
            var src = AppDb.apipacks();
            var pack = default(IApiPack);
            if(args.Count > 0)
            {
                result = DataParser.parse(arg(args,0), out int i);
                if(result)
                {
                    var count = src.Length;
                    if(i<count-1)
                    {
                        pack = src[i];
                        result = true;
                    }
                }
            }
            else
            {
                if(src.Count >= 0)
                {
                    pack = src.Last;
                    result = true;
                }
            }

            if(result)
            {
                var listing = FS.listing(pack.Files());
                var dst = AppDb.App().PrefixedTable<ListedFile>($"api.pack.{pack.Timestamp}");
                TableEmit(listing, dst);
            }

            return result;
        }

        [CmdOp("api/deps")]
        void ShowDependencies()
        {
            var src = ExecutingPart.Component;
            var name = src.GetSimpleName();
            var deps = JsonDeps.load(src);
            var dst = list<string>();
            iteri(deps.RuntimeLibs(), (i,lib) => dst.Add(string.Format("{0:D4}:{1}",i,lib)));
            var emitter = text.emitter();
            iter(dst, line => emitter.AppendLine(line));
            FileEmit(emitter.Emit(), dst.Count, AppDb.Apps().Path($"{name}.deps",FileKind.List));
        }

        [CmdOp("api/etl")]
        void ApiEmit()
            => ApiMd.EmitDatasets(AppDb.apipack());

        [CmdOp("api/emit/context")]
        void EmitContext()
            => Runtime.EmitContext(AppDb.apipack());

        [CmdOp("api/emit/hex")]
        void EmitApiHex()
        {
            //CliEmitter.
        }

        [CmdOp("api/emit/refs")]
        void EmitApiRefs()
        {
            //CliEmitter.EmitAssemblyRefs();
        }

        [CmdOp("api/emit/blobs")]
        void EmitBlobs()
        {
            //CliEmitter.EmitBlobs();
        }


        [CmdOp("api/emit/heaps")]
        void ApiEmitHeaps()
            => Heaps.symbols(ApiMd.SymLits);

        [CmdOp("api/emit/msil-host")]
        void EmitHostMsil(CmdArgs args)
            => Cli.EmitHostMsil(arg(args,0), AppDb.apipack());

        [CmdOp("api/emit/msil")]
        void EmitMsil()
            => Cli.EmitMsil(AppDb.apipack());

        [CmdOp("api/emit/corelib")]
        void EmitCorLib()
        {
            var src = Clr.corlib();
            var reader = CliReader.create(src);
            var blobs = reader.ReadBlobs();
            for(var i=0; i<blobs.Length; i++)
            {
                ref readonly var blob = ref skip(blobs,i);
                Write(string.Format("{0,-8} | {1,-8} | {2,-8}", blob.Seq, blob.Offset, blob.DataSize));
            }

            // var dst = AppDb.ApiTargets("metadata").Path(src.GetSimpleName(),FileKind.Txt);
            // CliEmitter.EmitMetadump(src,dst);
        }


        [CmdOp("api/emit/index")]
        void EmitRuntimeMembers()
            => ApiMd.EmitIndex(ApiMd.CalcRuntimeMembers());

        [CmdOp("api/parts")]
        void Parts()
            => iter(ApiMd.Parts, part => Write(part.Name));

        [CmdOp("api/components")]
        void Components()
            => iter(ApiMd.Components, part => Write(part.GetSimpleName()));

        [CmdOp("api/emit/comments")]
        void ApiEmitComments()
            => ApiMd.EmitComments();

        [CmdOp("gen/replicants")]
        Outcome GenEnums(CmdArgs args)
        {
            const string Name = "api.types.enums";
            var src = AppDb.ApiTargets().Path(Name, FileKind.List);
            var types = ApiMd.LoadTypes(src);
            var name = "EnumDefs";
            CsLang.EmitReplicants(CsLang.replicant(AppDb.CgStage(name).Root, out var spec), types, AppDb.CgStage(name).Root);
            return true;
        }
    }
}