//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedModels;

    using I = XedModels.OpCodeIndex;

    partial class XedOpCodes
    {
        [Op]
        public static OpCodeMap map(OpCodeKind src)
            => new OpCodeMap(src, @class(src), index(src), symbol(src), selector(src));

        [MethodImpl(Inline), Op]
        public static OpCodeMap map(OpCodeIndex src)
            => map(kind(src));

        public static bool map(OpCodeIndex src, out MAP dst)
        {
            var result = true;
            dst = default;
            switch(src)
            {
                case I.LegacyMap0:
                    dst = (MAP)BaseMapKind.BaseMap0;
                break;
                case I.LegacyMap1:
                    dst = (MAP)BaseMapKind.BaseMap1;
                break;
                case I.LegacyMap2:
                    dst = (MAP)BaseMapKind.BaseMap2;
                break;
                case I.LegacyMap3:
                    dst = (MAP)BaseMapKind.BaseMap3;
                break;
                case I.Amd3dNow:
                    dst = (MAP)src;
                break;

                case I.Vex0F:
                    dst = (MAP)VexMapKind.VEX_MAP_0F;
                break;
                case I.Vex0F38:
                    dst = (MAP)VexMapKind.VEX_MAP_0F38;
                break;
                case I.Vex0F3A:
                    dst = (MAP)VexMapKind.VEX_MAP_0F3A;
                break;
                case I.Evex0F:
                    dst = (MAP)EvexMapKind.EVEX_MAP_0F;
                break;
                case I.Evex0F38:
                    dst = (MAP)EvexMapKind.EVEX_MAP_0F38;
                break;
                case I.Evex0F3A:
                    dst = (MAP)EvexMapKind.EVEX_MAP_0F3A;
                break;

                case I.Xop8:
                    dst = (MAP)XopMapKind.Xop8;
                break;
                case I.Xop9:
                    dst = (MAP)XopMapKind.Xop9;
                break;
                case I.XopA:
                    dst = (MAP)XopMapKind.XopA;
                break;
                default:
                    result = false;
                break;

            }
            return result;
        }
    }
}