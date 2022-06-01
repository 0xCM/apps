//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial struct ApiExtracts
    {
        [Op]
        public static unsafe Index<ApiMemberExtract> extract(ReadOnlySpan<ApiMember> src, Span<byte> buffer)
        {
            var count = src.Length;
            var dst = alloc<ApiMemberExtract>(count);
            ref var target = ref first(dst);
            for(var i=0u; i<count; i++)
                seek(target, i) = extract(skip(src, i), sys.clear(buffer));
            return dst;
        }

        [Op]
        public static unsafe ApiMemberExtract extract(ApiMember src, Span<byte> buffer)
        {
            var @base = src.BaseAddress;
            var size = Bytes.readz(MaxZeroCount, @base, buffer);
            var extracted = sys.array(slice(buffer,0,size));
            return new ApiMemberExtract(src, new ApiExtractBlock(@base, src.OpUri.Format(), extracted));
        }

        [Op]
        public static unsafe ApiMemberExtract extract(in ResolvedMethod src, Span<byte> buffer)
        {
            var size = Bytes.readz(MaxZeroCount, src.EntryPoint, buffer);
            var block = new ApiExtractBlock(src.EntryPoint, src.Uri.Format(), slice(buffer,0, size).ToArray());
            return new ApiMemberExtract(src.ToApiMember(), block);
        }

        [Op]
        public static ApiExtractBlock extract(MethodInfo src, Span<byte> buffer)
        {
            var method = ApiResolver.method(src);
            var result = extract2(method.EntryPoint, buffer);
            if(result > 0)
                return new ApiExtractBlock(method.EntryPoint, method.Uri.Format(), slice(buffer, 0, result));
            else
                return new ApiExtractBlock(method.EntryPoint, method.Uri.Format(), buffer.ToArray());
        }

        [Op]
        public static ApiExtractBlock extract2(in ResolvedMethod src, Span<byte> buffer)
        {
            var result = extract2(src.EntryPoint, buffer);
            if(result > 0)
                return new ApiExtractBlock(src.EntryPoint, src.Uri.Format(), slice(buffer, 0, result));
            else
                return new ApiExtractBlock(src.EntryPoint, src.Uri.Format(), buffer.ToArray());
        }

        [Op]
        static unsafe int extract2(MemoryAddress src, Span<byte> dst)
        {
            var reader = MemoryReader.create(src.Pointer<byte>(), dst.Length);
            var counter = 0;
            while(reader.Read(ref seek(dst, counter++)))
            {
                var term = terminal(slice(dst,0,counter));
                if(term.TerminalFound)
                    return counter + term.Modifier;
            }
            return NotFound;
        }
    }
}