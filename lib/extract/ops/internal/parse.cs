//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static core;
    using static ExtractTermCode;

    using EP = EncodingParser;

    partial struct ApiExtracts
    {
        [Op]
        internal static Index<ApiMemberCode> parse(EP parser, ReadOnlySpan<ApiMemberExtract> src)
        {
            var count = src.Length;
            if(count == 0)
                return default;

            var buffer = alloc<ApiMemberCode>(count);
            ref var dst = ref first(buffer);
            for(var i=0u; i<count; i++)
            {
                var outcome = parse(parser, skip(src,i), i);
                if(outcome)
                    seek(dst, i) = outcome.Data;
                else
                    seek(dst, i) = ApiMemberCode.Empty;
            }
            return buffer;
        }

        internal static bool parse(EP parser, in ApiMemberExtract src, out ApiMemberCode dst)
        {
            const int Zx7Cut = 7;
            var status = parser.Parse(src.Block.Encoded);
            var term = failed(status) ? Fail : termcode(parser.Result);
            if(term != Fail)
            {
                var code = locate(src.BaseAddress, parser.Parsed, term == CTC_Zx7 ? Zx7Cut : 0);
                dst = new ApiMemberCode(src.Member, new ApiCodeBlock(src.BaseAddress, src.OpUri, code));
                return true;
            }
            else
            {
                dst = ApiMemberCode.Empty;
                return false;
            }
        }

        [Op]
        internal static Outcome<ApiMemberCode> parse(EP parser, in ApiMemberExtract src, uint seq)
        {
            const int Zx7Cut = 7;

            try
            {
                var status = parser.Parse(src.Block.Encoded.View);
                var term = failed(status) ? Fail : termcode(parser.Result);
                if(term != Fail)
                {
                    var code = locate(src.Block.BaseAddress, parser.Parsed, term == CTC_Zx7 ? Zx7Cut : 0);
                    return new ApiMemberCode(src.Member, new ApiCodeBlock(code.BaseAddress, src.OpUri, code), seq, term);
                }
                else
                    return Outcomes.fail<ApiMemberCode>(term.ToString());
            }
            catch(Exception e)
            {
                return e;
            }
        }

        [Op]
        static CodeBlock locate(MemoryAddress address, byte[] src, int cut)
        {
            if(cut == 0)
                return new CodeBlock(address, src);
            else
            {
                Span<byte> data = src;
                var len = extractSize(data, cut, 0xC3);
                var keep = data.Slice(0, len);
                return new CodeBlock(address, keep.ToArray());
            }
        }

        [Op]
        static int extractSize(Span<byte> src, int maxcut, byte code)
        {
            var srcLen = src.Length;
            var cut = 0;
            if(srcLen > maxcut)
            {
                var start = srcLen - maxcut - 1;
                ref readonly var lead = ref skip(src, maxcut);
                ref readonly var current = ref lead;
                for(var i=start; i<srcLen && cut < maxcut; i++, cut++)
                {
                    current = ref skip(lead, i);
                    if(current == code)
                        break;
                }
            }
            var dstLen = src.Length - cut;
            return dstLen <= 0 ? src.Length : dstLen;
        }
    }
}