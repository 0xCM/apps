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
        public static MachineMode mode(in InstPatternBody src)
        {
            var result = ModeKind.Default;
            for(var i=0; i<src.FieldCount; i++)
            {
                ref readonly var f = ref src[i];
                if(f.FieldClass == DefFieldClass.FieldAssign && f.FieldKind == FieldKind.MODE)
                    result = f.AsAssignment().Value;
            }
            return result;
        }
    }
}