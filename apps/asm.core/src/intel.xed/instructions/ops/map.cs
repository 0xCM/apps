//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;
    using static XedModels;
    using static XedRules;

    partial class XedPatterns
    {
        [MethodImpl(Inline), Op]
        public static bool map(in InstDefPart src, out byte dst)
        {
            var result = false;
            dst = default;
            if(src.PartKind == DefSegKind.FieldAssign)
            {
                ref readonly var assign = ref src.AsAssign();
                if(assign.Field == FieldKind.MAP)
                {
                    dst = (byte)assign.Value;
                    result = true;
                }
            }

            return result;
        }
    }
}