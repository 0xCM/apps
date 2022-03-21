//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;

    using static XedModels;
    using static XedModels.VexMapKind;
    using static XedModels.EvexMapKind;
    using static XedModels.XopMapKind;
    using static XedModels.LegacyMapKind;
    using static XedRules;

    using I = XedModels.OpCodeIndex;
    using K = XedModels.OpCodeKind;

    partial class XedPatterns
    {
        public static OpCodeIndex ocindex(in InstDefPart src)
        {
            XedPatterns.map(src, out var m);
            XedPatterns.vexclass(src, out var vc);
            switch(vc)
            {
                case VexClass.VV1:
                    return ocindex((VexMapKind)m);
                case VexClass.EVV:
                    return ocindex((EvexMapKind)m);
                case VexClass.XOPV:
                    return ocindex((XopMapKind)m);
                default:
                    return (OpCodeIndex)m;
            }
        }

        public static OpCodeIndex ocindex(in InstPatternBody src)
        {
            var dst = default(OpCodeIndex);
            var _vex = XedPatterns.vex(src);
            var _map = z8;
            for(var i=0; i<src.PartCount; i++)
            {
                if(XedPatterns.map(src[i], out _map))
                {
                    switch(_vex)
                    {
                        case VexClass.VV1:
                            var vv1 = (VexMapKind)_map;
                            break;
                        case VexClass.EVV:
                            var evv = (EvexMapKind)_map;
                            break;
                        case VexClass.XOPV:
                            var xop = (XopMapKind)_map;
                            break;
                        default:
                            var legacy = (LegacyMapKind)_map;
                            break;
                    }
                }
            }
            return dst;
        }

        [Op]
        public static OpCodeIndex ocindex(AsmOcValue src)
        {
            var dst = default(OpCodeIndex);
            if(src[0] == 0x0F)
            {
                if(src[1] == 0x38)
                    dst = OpCodeIndex.LegacyMap2;
                else if(src[1] == 0x3A)
                    dst = OpCodeIndex.LegacyMap3;
                else
                    dst = OpCodeIndex.LegacyMap1;
            }
            else
                dst = OpCodeIndex.LegacyMap0;
            return dst;
        }

        [MethodImpl(Inline), Op]
        public static VexMapKind? vexmap(VexClass kind, byte code)
            => kind == VexClass.VV1 ? (VexMapKind)code : null;

        [MethodImpl(Inline), Op]
        public static EvexMapKind? evexmap(VexClass kind, byte code)
            => kind == VexClass.EVV ? (EvexMapKind)code : null;

        [MethodImpl(Inline), Op]
        public static XopMapKind? xopmap(VexClass kind, byte code)
            => kind == VexClass.XOPV ? (XopMapKind)code : null;

        [MethodImpl(Inline), Op]
        public static LegacyMapKind? lmap(byte code)
            => code <= 4? (LegacyMapKind)code : null;

        public static OpCodeIndex? ocindex(byte code)
        {
            var kind = lmap(code);
            if(kind != null)
                return ocindex(kind.Value);
            else
                return null;
        }

        [Op]
        public static OpCodeIndex? ocindex(VexClass @class, byte code)
        {
            var dst = default(OpCodeIndex?);
            switch(@class)
            {
                case VexClass.VV1:
                    dst = ocindex((VexMapKind)code);
                break;
                case VexClass.EVV:
                    dst = ocindex((EvexMapKind)code);
                break;
                case VexClass.XOPV:
                    dst = ocindex((XopMapKind)code);
                break;
            }
            return dst;
        }

        [Op]
        public static OpCodeIndex ocindex(OpCodeKind kind)
            => kind switch
            {
                K.LEGACY_00 => I.LegacyMap0,
                K.LEGACY_0F => I.LegacyMap1,
                K.LEGACY_0F38 => I.LegacyMap2,
                K.LEGACY_0F3A => I.LegacyMap3,
                K.AMD_3DNOW => I.Amd3dNow,
                K.XOP8 => I.Xop8,
                K.XOP9 => I.Xop9,
                K.XOPA => I.XopA,
                K.VEX_0F => I.Vex0F,
                K.VEX_0F38 => I.Vex0F38,
                K.VEX_0F3A => I.Vex0F3A,
                K.EVEX_0F => I.Evex0F,
                K.EVEX_0F38 => I.Evex0F38,
                K.EVEX_0F3A => I.Evex0F3A,
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
        public static OpCodeIndex ocindex(LegacyMapKind kind)
            => kind switch
            {
                LEGACY_MAP0 => I.LegacyMap0,
                LEGACY_MAP1 => I.LegacyMap1,
                LEGACY_MAP2 => I.LegacyMap2,
                LEGACY_MAP3 => I.LegacyMap3,
                AMD_3DNOW => I.Amd3dNow,
                _ => 0
            };
    }
}