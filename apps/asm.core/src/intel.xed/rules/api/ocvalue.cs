//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;

    using static core;

    partial class XedRules
    {
        // public static AsmOcValue ocvalue(ReadOnlySpan<RuleToken> src)
        // {
        //     var count = src.Length;
        //     var storage = ByteBlock4.Empty;
        //     var dst = storage.Bytes;
        //     var j=0;
        //     for(var i=0; i<count; i++)
        //     {
        //         ref readonly var token = ref skip(src,i);
        //         if(token.Kind == RuleTokenKind.HexLit)
        //             seek(dst,j++) = token.AsHexLit();
        //     }
        //     return new AsmOcValue(slice(dst,0,j));
        // }

        public static AsmOcValue ocvalue(InstPatternBody src)
        {
            var count = src.PartCount;
            var storage = ByteBlock4.Empty;
            var dst = storage.Bytes;
            var j=0;
            for(var i=0; i<count; i++)
            {
                ref readonly var seg = ref src[i];
                if(seg.Kind == DefSegKind.HexLiteral)
                    seek(dst,j++) = seg.AsHexLit();
            }
            return new AsmOcValue(slice(dst,0,j));
        }
    }
}