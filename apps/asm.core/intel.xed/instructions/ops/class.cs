//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedModels.OpCodeKind;
    using static XedModels;
    using C = XedModels.OpCodeClass;

    partial class XedPatterns
    {
        [Op]
        public static OpCodeClass @class(OpCodeKind src)
        {
            var result = C.None;
            switch(src)
            {
                case LEGACY_00:
                case LEGACY_0F:
                case LEGACY_0F38:
                case LEGACY_0F3A:
                    result = C.Base;
                    break;
                case VEX_0F:
                case VEX_0F38:
                case VEX_0F3A:
                    result = C.Vex;
                    break;
                case EVEX_0F:
                case EVEX_0F38:
                case EVEX_0F3A:
                    result = C.Evex;
                    break;
                case AMD_3DNOW:
                    result = C.Amd3D;
                    break;
                case XOP8:
                case XOP9:
                case XOPA:
                    result = C.Xop;
                break;
            }
            return result;
        }
    }
}