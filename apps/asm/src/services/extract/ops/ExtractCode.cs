//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial class ApiExtractor
    {
        uint ExtractPart(ResolvedPart src, IApiPack pack)
        {
            var hosts = src.Hosts.View;
            var count = (uint)hosts.Length;
            if(count == 0)
                return 0;

            var counter = 0u;
            for(var i=0; i<count; i++)
            {
                ref readonly var host = ref skip(hosts,i);
                var extracted = ExtractHostDatast(host, pack);
                counter += extracted.Routines.Count;
                DatasetReceiver.Add(extracted);
            }
            return counter;
        }

        // public ApiHostCode ExtractCode(in ResolvedHost src, IApiPack pack)
        // {
        //     var host = src.Host;
        //     var rawPath = PackArchive.RawHexPath(host);
        //     var raw = ExtractHost(src).Sort();
        //     EmitRawHex(host, raw.View,rawPath);

        //     var parsed = ParseExtracts(raw.View);
        //     var packedPath = PackArchive.ParsedHexPath(host);
        //     var parsedPath = PackArchive.ParsedExtractPath(pack, host);
        //     EmitParsedHex(host, parsed.View, pack, packedPath, parsedPath);

        //     var dst = new ApiHostCode();
        //     dst.Resolved = src;
        //     dst.RawPath =rawPath;
        //     dst.PackedPath = packedPath;
        //     dst.ParsedPath = parsedPath;
        //     dst.Raw = raw;
        //     dst.Parsed = parsed;
        //     return dst;
        // }

        // uint EmitParsedHex(ApiHostUri host, ReadOnlySpan<ApiMemberCode> src, IApiPack pack, FS.FilePath packPath, FS.FilePath extractPath)
        // {
        //     var count = (uint)src.Length;
        //     if(count == 0)
        //         return 0;

        //     var buffer = alloc<MemoryBlock>(count);
        //     ref var target = ref first(buffer);
        //     for(var i=0; i<count; i++)
        //     {
        //         ref readonly var code = ref skip(src,i);
        //         seek(target, i) = new MemoryBlock(code.Address, code.Size, code.Encoded);
        //     }

        //     HexPacks.Emit(MemoryStore.pack(buffer), packPath);
        //     ApiHex.WriteBlocks(host, src, extractPath);

        //     return count;
        // }

        // ApiMemberBlocks ParseExtracts(ReadOnlySpan<ApiMemberExtract> src)
        // {
        //     var count = src.Length;
        //     var buffer = alloc<ApiMemberCode>(count);
        //     ref var parsed = ref first(buffer);
        //     for(var i=0; i<count; i++)
        //     {
        //         ref readonly var input = ref skip(src,i);
        //         ref var output = ref seek(parsed,i);
        //         if(Parser.Parse(input, out output))
        //             Channel.Raise(new MemberParsedEvent(input,output));
        //         else
        //             Error(string.Format("Extract parse failure for {0}", input.Member.OpUri));

        //     }
        //     return buffer;
        // }

        // void EmitRawHex(ApiHostUri host, ReadOnlySpan<ApiMemberExtract> src, FS.FilePath rawPath)
        // {
        //     var count = (uint)src.Length;
        //     if(count == 0)
        //         return;

        //     HexPacks.Emit(ApiHex.blocks(src), rawPath);
        // }

        // public ApiHostExtracts ExtractHost(in ResolvedHost src)
        // {
        //     var dst = list<ApiMemberExtract>();
        //     var flow = Running(Msg.ExtractingHost.Format(src.Host));
        //     var methods = src.Methods.View;
        //     var count = methods.Length;
        //     var counter = 0u;
        //     for(var i=0; i<count; i++)
        //     {
        //         Buffer.Clear();
        //         dst.Add(ApiExtracts.extract(skip(methods,i), Buffer));
        //         counter++;
        //     }

        //     Ran(flow, Msg.ExtractedHost.Format(counter, src.Host));
        //     return new ApiHostExtracts(src.Host, dst.ToArray());
        // }
    }
}