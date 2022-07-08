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

        ApiCode ApiCode => Wf.ApiCode();

        public ApiHostCode ExtractHostCode(in ResolvedHost src, IApiPack pack, IApiPackArchive dst)
        {
            var host = src.Host;
            var rawPath = dst.RawHexPath(host);
            var raw = ExtractHost(src).Sort();
            EmitRawHex(host, raw.View,rawPath);
            var parsed = ParseBlocks(raw.View);
            var packedPath = dst.ParsedHexPath(host);
            var parsedPath = dst.ParsedExtractPath(host);
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

        ApiHostExtracts ExtractHost(in ResolvedHost src)
        {
            var buffer = core.alloc<byte>(Pow2.T14 + Pow2.T08);
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

            ApiCode.Emit(dst.Sort(), packPath);
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