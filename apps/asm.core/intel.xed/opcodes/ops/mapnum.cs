//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;

    using static XedModels;

    using I = XedModels.OpCodeIndex;

    partial class XedOpCodes
    {
        public static bool mapnum(OpCodeIndex src, out byte dst)
        {
            var result = true;
            dst = default;
            switch(src)
            {
                case I.LegacyMap0:
                    dst = (byte)BaseMapKind.BaseMap0;
                break;
                case I.LegacyMap1:
                    dst = (byte)BaseMapKind.BaseMap1;
                break;
                case I.LegacyMap2:
                    dst = (byte)BaseMapKind.BaseMap2;
                break;
                case I.LegacyMap3:
                    dst = (byte)BaseMapKind.BaseMap3;
                break;
                case I.Amd3dNow:
                    dst = (byte)src;
                break;

                case I.Vex0F:
                    dst = (byte)VexMapKind.VEX_MAP_0F;
                break;
                case I.Vex0F38:
                    dst = (byte)VexMapKind.VEX_MAP_0F38;
                break;
                case I.Vex0F3A:
                    dst = (byte)VexMapKind.VEX_MAP_0F3A;
                break;
                case I.Evex0F:
                    dst = (byte)EvexMapKind.EVEX_MAP_0F;
                break;
                case I.Evex0F38:
                    dst = (byte)EvexMapKind.EVEX_MAP_0F38;
                break;
                case I.Evex0F3A:
                    dst = (byte)EvexMapKind.EVEX_MAP_0F3A;
                break;

                case I.Xop8:
                    dst = (byte)XopMapKind.Xop8;
                break;
                case I.Xop9:
                    dst = (byte)XopMapKind.Xop9;
                break;
                case I.XopA:
                    dst = (byte)XopMapKind.XopA;
                break;
                default:
                    result = false;
                break;

            }
            return result;
        }
    }
}