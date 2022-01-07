//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    using static core;

    partial class ApiExtractor
    {
        ApiHex ApiHex => Service(Wf.ApiHex);


        uint EmitParsedHex(ApiHostUri host, ReadOnlySpan<ApiMemberCode> src, IApiPack pack)
        {
            var count = (uint)src.Length;
            if(count == 0)
                return 0;

            var dst = PackArchive.ParsedHexPath(host);
            var buffer = alloc<MemoryBlock>(count);
            ref var target = ref first(buffer);
            for(var i=0; i<count; i++)
            {
                ref readonly var code = ref skip(src,i);
                seek(target, i) = new MemoryBlock(code.Address, code.Size, code.Encoded);
            }
            HexPacks.Emit(MemoryStore.pack(buffer),dst);
            ApiHex.WriteBlocks(host, src, ParsedExtractPath(pack, host));

            return count;
        }
    }
}