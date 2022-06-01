//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    public class ApiCodeExtractor : AppService<ApiCodeExtractor>
    {
        ApiExtractParser Parser => ApiExtractParser.create();

        ApiResolver Resolver => Wf.ApiResolver();

        ApiCode ApiCode => Wf.ApiCode();

        ApiHex ApiHex => Service(Wf.ApiHex);

        public ApiPartCode ExtractPartCode(IPart src, IApiPack pack)
            => ExtractPartCode(src, pack, ApiPackArchive.create(pack.Root));

        public ApiPartCode ExtractPartCode(IPart src, IApiPack pack, ApiPackArchive dst)
        {
            var resolved = Resolver.ResolvePart(src);
            return new ApiPartCode(resolved, ExtractPartCode(resolved, pack, dst), dst);
        }

        public ApiHostCode ExtractHostCode(in ResolvedHost src, IApiPack pack, ApiPackArchive dst)
        {
            var host = src.Host;
            var rawPath = dst.RawHexPath(host);
            var raw = ExtractHost(src).Sort();
            EmitRawHex(host, raw.View,rawPath);
            var parsed = ParseBlocks(raw.View);
            var packedPath = dst.ParsedHexPath(host);
            var parsedPath = dst.ParsedExtractPath(pack, host);
            EmitParsedHex(host, parsed.View, pack, packedPath, parsedPath);
            var result = new ApiHostCode();
            result.Resolved = src;
            result.RawPath =rawPath;
            result.PackedPath = packedPath;
            result.ParsedPath = parsedPath;
            result.Raw = raw;
            result.Parsed = parsed;
            return result;
        }

        ApiMemberBlocks ParseBlocks(ReadOnlySpan<ApiMemberExtract> src)
        {
            var count = src.Length;
            var buffer = alloc<ApiMemberCode>(count);
            ref var parsed = ref first(buffer);
            for(var i=0; i<count; i++)
            {
                ref readonly var input = ref skip(src,i);
                ref var output = ref seek(parsed,i);
                if(!Parser.Parse(input, out output))
                    Error(string.Format("Extract parse failure for {0}", input.Member.OpUri));

            }
            return buffer;
        }

        Index<ApiHostCode> ExtractPartCode(ResolvedPart src, IApiPack pack, ApiPackArchive dst)
        {
            var hosts = src.Hosts.View;
            var count = (uint)hosts.Length;
            if(count == 0)
                return sys.empty<ApiHostCode>();
            var code = list<ApiHostCode>();

            for(var i=0; i<count; i++)
                code.Add(ExtractHostCode(skip(hosts,i), pack, dst));

            return code.ToArray();
        }

        ApiHostExtracts ExtractHost(in ResolvedHost src)
        {
            var buffer = ApiExtracts.buffer();
            var dst = list<ApiMemberExtract>();
            var flow = Running(Msg.ExtractingHost.Format(src.Host));
            var methods = src.Methods.View;
            var count = methods.Length;
            var counter = 0u;
            for(var i=0; i<count; i++)
            {
                buffer.Clear();
                dst.Add(ApiCode.extract(skip(methods,i), buffer));
                counter++;
            }

            Ran(flow, Msg.ExtractedHost.Format(counter, src.Host));

            return new ApiHostExtracts(src.Host, dst.ToArray());
        }

        uint EmitParsedHex(ApiHostUri host, ReadOnlySpan<ApiMemberCode> src, IApiPack pack, FS.FilePath packPath, FS.FilePath extractPath)
        {
            var count = (uint)src.Length;
            if(count == 0)
                return 0;

            var dst = alloc<MemoryBlock>(count);
            for(var i=0; i<count; i++)
            {
                ref readonly var code = ref skip(src,i);
                seek(dst, i) = new MemoryBlock(code.Address, code.Size, code.Encoded);
            }

            ApiCode.Emit(ApiCode.pack(dst), packPath);
            ApiCode.EmitApiHex(host, src, extractPath);
            return count;
        }

        void EmitRawHex(ApiHostUri host, ReadOnlySpan<ApiMemberExtract> src, FS.FilePath rawPath)
        {
            var count = (uint)src.Length;
            if(count == 0)
                return;

            ApiCode.Emit(ApiCode.memory(src), rawPath);
        }
    }
}