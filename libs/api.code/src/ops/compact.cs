//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static Algs;
    using static Spans;
    using static Arrays;

    partial class ApiCode
    {
        [Op]
        public static BinaryCode compact(uint size, ReadOnlySpan<ApiEncoded> src)
        {
            var dst = sys.alloc<byte>(size);
            var k = 0u;
            for(var i=0; i<src.Length; i++)
            {
                ref readonly var code = ref src[i].Code;
                for(var j=0; j<code.Length; j++, k++)
                    seek(dst,k) = code[j];
            }
            return dst;
        }

        [Op]
        public static BinaryCode compact(ReadOnlySpan<BinaryCode> src)
        {
            var count = src.Length;
            if(count == 0)
                return BinaryCode.Empty;
            var dst = sys.alloc<byte>(size(src));
            var k = 0u;
            for(var i=0u; i<count; i++)
            {
                var data = skip(src,i).View;
                for(var j=0u; j<data.Length; j++, k++)
                    seek(dst, k) = skip(data, j);
            }
            return dst;
        }

        [Op]
        public static BinaryCode compact(ReadOnlySpan<HexDataRow> src)
        {
            var count = src.Length;
            if(count == 0)
                return BinaryCode.Empty;

            var size = ApiHex.size(src);
            var dst = sys.alloc<byte>(size);
            var offset = 0u;
            for(var i=0; i<count; i++)
            {
                var data = skip(src,i).Data.View;
                for(var j=0; j<data.Length; j++)
                    seek(dst, offset++) = skip(data,j);
            }
            return dst;
        }
    }
}