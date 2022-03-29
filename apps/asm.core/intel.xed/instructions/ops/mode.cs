//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedModels;
    using static XedRules;

    partial class XedPatterns
    {
        public static MachineMode mode(in InstPatternBody src)
        {
            var result = ModeKind.Default;
            for(var i=0; i<src.FieldCount; i++)
            {
                ref readonly var f = ref src[i];
                if(f.FieldClass == DefFieldClass.FieldExpr && f.FieldKind == FieldKind.MODE)
                    result = f.AsFieldExpr().Value;
            }
            return result;
        }
    }
}