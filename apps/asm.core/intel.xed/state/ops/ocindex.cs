//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedModels;
    using static XedRules;
    using static core;

    partial class XedState
    {
        [MethodImpl(Inline), Op]
        public static OpCodeIndex ocindex(in RuleState state)
        {
            var dst = OpCodeIndex.Amd3dNow;
            ref readonly var map = ref state.MAP;
            ref readonly var vc = ref vexclass(state);
            switch(vc)
            {
                case VexClass.VV1:
                    dst = XedPatterns.ocindex((VexMapKind)map);
                    break;
                case VexClass.EVV:
                    dst = XedPatterns.ocindex((EvexMapKind)map);
                    break;
                case VexClass.XOPV:
                    dst = XedPatterns.ocindex((XopMapKind)map);
                    break;
                default:
                    dst = (OpCodeIndex)map;
                    break;
            }

            return dst;
        }

        [MethodImpl(Inline), Op]
        public static ref RuleState set(OpCodeIndex src, ref RuleState dst)
        {
            XedPatterns.mapcode(src, out dst.MAP);
            dst.VEXVALID = (byte)XedPatterns.vexclass(src);
            return ref dst;
        }
    }
}