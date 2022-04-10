//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial class XedFields
    {
        [MethodImpl(Inline), Op]
        public static InstFields sort(InstFields src)
        {
            var data = src.Data;
            var count = (byte)data.Count;
            var eCount = z8;
            var lCount = z8;
            for(var i=z8; i<count; i++)
            {
                ref var field = ref data[i];
                if(field.IsFieldExpr)
                    eCount++;
                else
                    lCount++;
            }

            var lIx = z8;
            var eIx = (byte)lCount;
            for(var i=z8; i<count; i++)
            {
                ref var field = ref data[i];
                if(field.IsFieldExpr)
                    field = field.WithIndex(eIx++);
                else
                    field = field.WithIndex(lIx++);
            }

            return new InstFields(data.Sort(), count);
        }
    }
}