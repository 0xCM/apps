//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedModels;
    using static XedModels.VexMapKind;
    using static XedModels.EvexMapKind;
    using static XedModels.XopMapKind;
    using static XedModels.BaseMapKind;

    using I = XedModels.OpCodeIndex;
    using K = XedModels.OpCodeKind;

    partial class XedPatterns
    {
        public static OpCodeIndex? ocindex(byte code)
        {
            var kind = basemap(code);
            if(kind != null)
                return ocindex(kind.Value);
            else
                return null;
        }

        [Op]
        public static OpCodeIndex? ocindex(VexClass @class, byte map)
        {
            var dst = default(OpCodeIndex?);
            switch(@class)
            {
                case VexClass.VV1:
                    dst = ocindex((VexMapKind)map);
                break;
                case VexClass.EVV:
                    dst = ocindex((EvexMapKind)map);
                break;
                case VexClass.XOPV:
                    dst = ocindex((XopMapKind)map);
                break;
            }
            return dst;
        }

        [Op]
        public static OpCodeIndex ocindex(OpCodeKind kind)
            => kind switch
            {
                K.Base00 => I.LegacyMap0,
                K.Base0F => I.LegacyMap1,
                K.Base0F38 => I.LegacyMap2,
                K.Base0F3A => I.LegacyMap3,
                K.AMD_3DNOW => I.Amd3dNow,
                K.XOP8 => I.Xop8,
                K.XOP9 => I.Xop9,
                K.XOPA => I.XopA,
                K.Vex0F => I.Vex0F,
                K.Vex0F38 => I.Vex0F38,
                K.Vex0F3A => I.Vex0F3A,
                K.Evex0F => I.Evex0F,
                K.Evex0F38 => I.Evex0F38,
                K.Evex0F3A => I.Evex0F3A,
                _ => 0
            };

        [Op]
        public static OpCodeIndex ocindex(VexMapKind kind)
            => kind switch
            {
                VEX_MAP_0F => I.Vex0F,
                VEX_MAP_0F38 => I.Vex0F38,
                VEX_MAP_0F3A => I.Vex0F3A,
                _ => 0
            };

        [Op]
        public static OpCodeIndex ocindex(EvexMapKind kind)
            => kind switch
            {
                EVEX_MAP_0F => I.Evex0F,
                EVEX_MAP_0F38 => I.Evex0F38,
                EVEX_MAP_0F3A => I.Evex0F3A,
                _ => 0
            };

        [Op]
        public static OpCodeIndex ocindex(XopMapKind kind)
            => kind switch
            {
                XOP8 => I.Xop8,
                XOP9 => I.Xop9,
                XOPA => I.XopA,
                _ => 0
            };

        [Op]
        public static OpCodeIndex ocindex(BaseMapKind kind)
            => kind switch
            {
                BaseMap0 => I.LegacyMap0,
                BaseMap1 => I.LegacyMap1,
                BaseMap2 => I.LegacyMap2,
                BaseMap3 => I.LegacyMap3,
                Amd3dNow => I.Amd3dNow,
                _ => 0
            };
    }
}