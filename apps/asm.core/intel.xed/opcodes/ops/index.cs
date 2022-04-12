//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedModels;
    using static XedRules;
    using static XedModels.VexMapKind;
    using static XedModels.EvexMapKind;
    using static XedModels.BaseMapKind;

    using I = XedModels.OpCodeIndex;
    using K = XedModels.OpCodeKind;
    using X = XedModels.XopMapKind;

    partial class XedOpCodes
    {
        [Op]
        public static OpCodeIndex index(OpCodeKind kind)
            => kind switch
            {
                K.Base00 => I.LegacyMap0,
                K.Base0F => I.LegacyMap1,
                K.Base0F38 => I.LegacyMap2,
                K.Base0F3A => I.LegacyMap3,
                K.Amd3DNow => I.Amd3dNow,
                K.Xop8 => I.Xop8,
                K.Xop9 => I.Xop9,
                K.XopA => I.XopA,
                K.Vex0F => I.Vex0F,
                K.Vex0F38 => I.Vex0F38,
                K.Vex0F3A => I.Vex0F3A,
                K.Evex0F => I.Evex0F,
                K.Evex0F38 => I.Evex0F38,
                K.Evex0F3A => I.Evex0F3A,
                _ => 0
            };


        [MethodImpl(Inline), Op]
        public static OpCodeIndex index(in RuleState state)
        {
            var dst = OpCodeIndex.Amd3dNow;
            ref readonly var map = ref state.MAP;
            ref readonly var vc = ref vexclass(state);
            switch(vc)
            {
                case VexClass.VV1:
                    dst = XedOpCodes.index((VexMapKind)map);
                    break;
                case VexClass.EVV:
                    dst = XedOpCodes.index((EvexMapKind)map);
                    break;
                case VexClass.XOPV:
                    dst = XedOpCodes.index((XopMapKind)map);
                    break;
                default:
                    dst = (OpCodeIndex)map;
                    break;
            }

            return dst;
        }


        [Op]
        public static OpCodeIndex index(VexMapKind kind)
            => kind switch
            {
                VEX_MAP_0F => I.Vex0F,
                VEX_MAP_0F38 => I.Vex0F38,
                VEX_MAP_0F3A => I.Vex0F3A,
                _ => 0
            };

        [Op]
        public static OpCodeIndex index(EvexMapKind kind)
            => kind switch
            {
                EVEX_MAP_0F => I.Evex0F,
                EVEX_MAP_0F38 => I.Evex0F38,
                EVEX_MAP_0F3A => I.Evex0F3A,
                _ => 0
            };

        [Op]
        public static OpCodeIndex index(XopMapKind kind)
            => kind switch
            {
                X.Xop8 => I.Xop8,
                X.Xop9 => I.Xop9,
                X.XopA => I.XopA,
                _ => 0
            };

        public static OpCodeIndex? index(byte code)
        {
            var kind = basemap(code);
            if(kind != null)
                return index(kind.Value);
            else
                return null;
        }

        [Op]
        public static OpCodeIndex index(BaseMapKind kind)
            => kind switch
            {
                BaseMap0 => I.LegacyMap0,
                BaseMap1 => I.LegacyMap1,
                BaseMap2 => I.LegacyMap2,
                BaseMap3 => I.LegacyMap3,
                Amd3dNow => I.Amd3dNow,
                _ => 0
            };


        [Op]
        public static OpCodeIndex? index(VexClass @class, byte map)
        {
            var dst = default(OpCodeIndex?);
            switch(@class)
            {
                case VexClass.VV1:
                    dst = index((VexMapKind)map);
                break;
                case VexClass.EVV:
                    dst = index((EvexMapKind)map);
                break;
                case VexClass.XOPV:
                    dst = index((XopMapKind)map);
                break;
                default:
                    dst = index((BaseMapKind)map);
                break;
            }
            return dst;
        }
   }
}