//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    using static XedRules;
    using static XedModels;

    partial class XedPatterns
    {
        public static void poc(InstPattern src, out PatternOpCode dst)
        {
            dst = default;
            (var fields, var layout) = split(src.Body);
            dst.PatternId = src.PatternId;
            dst.OcKind = src.OpCode.Kind;
            dst.OcValue = src.OpCode.Value;
            dst.InstClass = src.InstClass;
            dst.Pattern = src.BodyExpr;

            for(byte j=0; j<fields.FieldCount; j++)
            {
                ref readonly var part = ref fields[j];

                if(part.FieldClass == DefFieldClass.FieldAssign)
                {
                    var a = part.AsAssignment();
                    switch(a.Field)
                    {
                        case FieldKind.MODE:
                            dst.Mode = (ModeKind)a.Value;
                        break;
                        default:
                        break;
                    }
                }
            }

            dst.Layout = layout.Format();
        }
    }
}