//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedModels;
    using static XedRules;

    partial class XedState
    {
        [MethodImpl(Inline), Op]
        public static OpCodeIndex ocindex(in RuleState state)
        {
            var dst = OpCodeIndex.Amd3dNow;
            var map = state.MAP;
            var vc = vexclass(state);

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
    }
}