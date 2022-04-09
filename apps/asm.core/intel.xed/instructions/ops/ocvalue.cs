//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;

    using static core;
    using static XedRules;

    partial class XedPatterns
    {
        public static AsmOcValue ocvalue(InstPatternBody src)
        {
            var count = src.FieldCount;
            var storage = ByteBlock4.Empty;
            var dst = storage.Bytes;
            var j=0;
            for(var i=0; i<count; i++)
            {
                ref readonly var seg = ref src[i];
                if(seg.FieldClass == InstFieldClass.HexLiteral)
                    seek(dst,j++) = seg.AsHexLit();
            }
            return new AsmOcValue(slice(dst,0,j));
        }
    }
}