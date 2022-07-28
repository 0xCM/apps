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

        IApiPack ApiPack => ApiPacks.create();

        [CmdOp("api/packs/list")]
        void ListApiPacks()
        {
            var src = ApiPacks.discover();
            for(var i=0; i<src.Count; i++)
            {
                Write($"{i}", src[i].Timestamp);
            }
        }

        [CmdOp("api/pack/list")]
        Outcome ListApiPack(CmdArgs args)
        {
            var result = Outcome.Failure;
            var src = ApiPacks.discover();
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

        [CmdOp("api/emit/deps")]
        void EmitApiDeps()
            => ApiMd.Emitter().EmitApiDeps();

        [CmdOp("api/emit/heap")]
        void ApiEmitHeaps()
            => ApiMemory.EmitSymHeap(Heaps.load(ApiMd.SymLits), ApiPack);

        [CmdOp("api/emit/index")]
        void EmitApiIndex()
            => ApiMd.Emitter().EmitApiIndex();

        [CmdOp("api/parts")]
        void Parts()
            => iter(ApiMd.Parts, part => Write(part.Name));

        [CmdOp("api/components")]
        void Components()
            => iter(ApiMd.Components, part => Write(part.GetSimpleName()));

        [CmdOp("api/emit/comments")]
        void ApiEmitComments()
            => ApiMd.Emitter().EmitComments();
    }
}