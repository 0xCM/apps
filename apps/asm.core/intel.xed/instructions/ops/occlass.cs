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
        public static OpCodeClass occlass(OpCodeIndex src)
            => occlass(ockind(src));

        [Op]
        public static OpCodeClass occlass(OpCodeKind src)
        {
            var result = C.None;
            switch(src)
            {
                case Base00:
                case Base0F:
                case Base0F38:
                case Base0F3A:
                    result = C.Base;
                    break;
                case Vex0F:
                case Vex0F38:
                case Vex0F3A:
                    result = C.Vex;
                    break;
                case Evex0F:
                case Evex0F38:
                case Evex0F3A:
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