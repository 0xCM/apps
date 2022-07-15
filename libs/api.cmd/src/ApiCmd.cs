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

        ToolBox ToolBox => Wf.ToolBox();

        [CmdOp("archives/memory/check")]
        void CheckMemoryArchives()
        {

        }

        [CmdOp("tools/env")]
        void ShowToolEnv()
            => iter(ToolBox.LoadEnv(), s => Write(s));

        [CmdOp("tool/script")]
        Outcome ToolScript(CmdArgs args)
            => ToolBox.RunScript(arg(args,0).Value, arg(args,1).Value);

        [CmdOp("tool/setup")]
        void ConfigureTool(CmdArgs args)
            => iter(ToolBox.Setup(tool(args)), entry => Write(entry));

        static Actor tool(CmdArgs args, byte index = 0)
            => arg(args,index).Value;

        [CmdOp("tool/docs")]
        void ToolDocs(CmdArgs args)
            => iter(ToolBox.LoadDocs(arg(args,0).Value), doc => Write(doc));

        [CmdOp("tool/config")]
        void ToolConfig(CmdArgs args)
        {
            var tool = arg(args,0);
            var src = AppDb.Toolbase().Sources(tool).Path(tool, FileKind.Config);
            Write($"{tool}:{src.ToUri()}");
            var settings = ToolWs.config(src);
            var count = settings.Count;
            for(var i=0; i<count; i++)
            {
                ref readonly var setting = ref settings[i];
                Write($"{setting}");
            }
        }

        //CsLang CsLang => Wf.CsLang();

        ApiMemory ApiMemory => Wf.ApiMemory();

        public Index<BitMaskInfo> ApiBitMasks
            => Data(K.BitMasks, () => BitMask.masks(typeof(BitMaskLiterals)));

        [CmdOp("api/emit/bitmasks")]
        void EmitApiBitMasks()
            => Emit(ApiBitMasks);

        // [CmdOp("api/emit/classes")]
        // Outcome EmitApiClasses(CmdArgs args)
        // {
        //     var classifier = Classifiers.classifier<AsmSigTokens.GpRmToken,byte>();
        //     var dst = text.emitter();
        //     Classifiers.render(classifier,dst);
        //     Write(dst.Emit());
        //     return true;
        // }

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

        [CmdOp("api/emit/heap")]
        void ApiEmitHeaps()
            => ApiMemory.EmitSymHeap(Heaps.symbols(ApiMd.SymLits));


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

        // [CmdOp("gen/replicants")]
        // Outcome GenEnums(CmdArgs args)
        // {
        //     const string Name = "api.types.enums";
        //     var src = AppDb.ApiTargets().Path(Name, FileKind.List);
        //     var types = ApiMd.LoadTypes(src);
        //     var name = "EnumDefs";
        //     CsLang.EmitReplicants(CsLang.replicant(AppDb.CgStage(name).Root, out var spec), types, AppDb.CgStage(name).Root);
        //     return true;
        // }
    }
}