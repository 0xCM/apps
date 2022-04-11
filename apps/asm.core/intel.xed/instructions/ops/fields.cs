//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedRules;
    using static XedFields;

    partial class XedPatterns
    {
        [MethodImpl(Inline), Op]
        public static FieldSet fields(in InstPatternBody src)
        {
            var dst = FieldSet.create();
            for(var j=0; j<src.FieldCount; j++)
                dst = dst.Include(src[j].FieldKind);
            return dst;
        }

        [MethodImpl(Inline), Op]
        public static FieldSet fields(in InstFields src, InstFieldClass @class)
        {
            var dst = FieldSet.create();
            for(var j=0; j<src.Count; j++)
            {
                ref readonly var field = ref src[j];
                if(field.DataClass.Test(@class))
                    dst = dst.Include(src[j].FieldKind);
            }
            return dst;
        }
    }
}