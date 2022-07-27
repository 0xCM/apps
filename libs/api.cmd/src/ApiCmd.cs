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
        ApiMd ApiMd => Wf.ApiMd();

        ApiMemory ApiMemory => Wf.ApiMemory();

        IApiPack ApiPack => Z0.ApiPack.create();

        public Index<BitMaskInfo> ApiBitMasks
            => Data(K.BitMasks, () => BitMask.masks(typeof(BitMaskLiterals)));

        [CmdOp("api/emit/bitmasks")]
        void EmitApiBitMasks()
            => Emit(ApiBitMasks);

        public void Emit(Index<BitMaskInfo> src)
            => TableEmit(src, AppDb.ApiTargets().Table<BitMaskInfo>());

        [CmdOp("api/packs/list")]
        void ListApiPacks()
        {
            var src = Z0.ApiPack.discover();
            for(var i=0; i<src.Count; i++)
            {
                Write($"{i}", src[i].Timestamp);
            }
        }

        [CmdOp("api/pack/list")]
        Outcome ListApiPack(CmdArgs args)
        {
            var result = Outcome.Failure;
            var src = Z0.ApiPack.discover();
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
        void EmitApiDeps()
            => ApiMd.Emitter(ApiPack).EmitApiDeps(sys.array(ExecutingPart.Component));

        [CmdOp("api/etl")]
        void ApiEmit()
            => ApiMd.EmitDatasets(ApiPack);

        [CmdOp("api/emit/heap")]
        void ApiEmitHeaps()
            => ApiMemory.EmitSymHeap(Heaps.load(ApiMd.SymLits), ApiPack);

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
            => ApiMd.Emitter(ApiPack).EmitComments();
    }
}