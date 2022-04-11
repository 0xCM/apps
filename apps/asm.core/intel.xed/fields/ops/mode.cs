//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedModels;
    using static XedRules;
    using static XedFields;

    partial class XedFields
    {
        [MethodImpl(Inline), Op]
        public static MachineMode mode(in InstFields src)
        {
            var result = ModeKind.Default;
            for(var i=0; i<src.Count; i++)
            {
                ref readonly var f = ref src[i];
                if(f.DataKind == InstFieldKind.Expr && f.FieldKind == FieldKind.MODE)
                    result = f.AsFieldExpr().Value;
            }
            return result;
        }
    }
}