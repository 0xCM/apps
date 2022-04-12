//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;

    using static core;
    using static XedModels;
    using static XedRules;
    using static XedModels.OpCodeKind;
    using static XedModels.VexMapKind;
    using static XedModels.EvexMapKind;
    using static XedModels.BaseMapKind;

    using I = XedModels.OpCodeIndex;
    using S = XedPatterns.OpCodeSymbols;
    using K = XedModels.OpCodeKind;
    using X = XedModels.XopMapKind;
    using V = XedModels.VexMapKind;
    using B = XedModels.BaseMapKind;
    using E = XedModels.EvexMapKind;

    public partial class XedOpCodes : AppService<XedOpCodes>
    {
        static AppData AppData
        {
            [MethodImpl(Inline)]
            get => AppData.get();
        }

        bool PllExec
        {
            [MethodImpl(Inline)]
            get => AppData.PllExec();
        }

        [MethodImpl(Inline), Op]
        public static EvexMapKind? evexmap(VexClass kind, byte code)
            => kind == VexClass.EVV ? (EvexMapKind)code : null;


        public static char indicator(OpCodeClass src)
            => src switch {
                OpCodeClass.Base => 'B',
                OpCodeClass.Xop => 'X',
                OpCodeClass.Vex => 'V',
                OpCodeClass.Evex => 'E',
                OpCodeClass.Amd3D => 'A',
                _ => (char)0
            };


        [Op]
        public static OpCodeKind ockind(OpCodeIndex src)
            => src switch {
                I.LegacyMap0 => Base00,
                I.LegacyMap1 => Base0F,
                I.LegacyMap2 => Base0F38,
                I.LegacyMap3 => Base0F3A,
                I.Amd3dNow => Amd3DNow,
                I.Xop8 => Xop8,
                I.Xop9 => Xop9,
                I.XopA => XopA,
                I.Vex0F => Vex0F,
                I.Vex0F38 => Vex0F38,
                I.Vex0F3A => Vex0F3A,
                I.Evex0F => Evex0F,
                I.Evex0F38 => Evex0F38,
                I.Evex0F3A => Evex0F3A,
                _=> OpCodeKind.None
            };

        [MethodImpl(Inline), Op]
        public static VexMapKind? vexmap(VexClass kind, byte code)
            => kind == VexClass.VV1 ? (VexMapKind)code : null;

        [MethodImpl(Inline), Op]
        public static XopMapKind? xopmap(VexClass kind, byte code)
            => kind == VexClass.XOPV ? (XopMapKind)code : null;

        public static Index<PatternOpCode> poc(Index<InstPattern> src)
        {
            var count = src.Count;
            var buffer = alloc<PatternOpCode>(count);
            for(var i=0; i<count; i++)
                poc(src[i], out seek(buffer,i));

            buffer.Sort();
            for(var i=0u; i<count; i++)
                seek(buffer,i).Seq = i;

            return buffer;
        }

        [MethodImpl(Inline), Op]
        public static ref readonly VexKind vexkind(in RuleState src)
            => ref @as<VexKind>(src.VEX_PREFIX);

        [MethodImpl(Inline), Op]
        public static ref readonly VexClass vexclass(in RuleState src)
            => ref @as<VexClass>(src.VEXVALID);

        [MethodImpl(Inline), Op]
        public static OpCodeIndex ocindex(in RuleState state)
        {
            var dst = OpCodeIndex.Amd3dNow;
            ref readonly var map = ref state.MAP;
            ref readonly var vc = ref vexclass(state);
            switch(vc)
            {
                case VexClass.VV1:
                    dst = XedOpCodes.ocindex((VexMapKind)map);
                    break;
                case VexClass.EVV:
                    dst = XedOpCodes.ocindex((EvexMapKind)map);
                    break;
                case VexClass.XOPV:
                    dst = XedOpCodes.ocindex((XopMapKind)map);
                    break;
                default:
                    dst = (OpCodeIndex)map;
                    break;
            }

            return dst;
        }

        public static void poc(InstPattern src, out PatternOpCode dst)
        {
            dst.Seq = 0;
            dst.PatternId = src.PatternId;
            dst.InstId = src.InstId;
            dst.OcKind = src.OpCode.Kind;
            dst.OcValue = src.OpCode.Value;
            dst.InstClass = src.InstClass;
            dst.Pattern = src.BodyExpr;
            dst.Mode = XedFields.mode(src.Fields);
            dst.Layout = src.Layout.Delimit(Chars.Space).Format();
        }

        [Op]
        public static OpCodeClass occlass(OpCodeIndex src)
            => occlass(ockind(src));

        [Op]
        public static OpCodeClass occlass(OpCodeKind src)
            => (OpCodeClass)(byte)src;

        public static Index<XedOpCode> opcodes(Index<InstPattern> src)
            => src.Map(x => x.Spec.OpCode).Sort();

        public static asci4 selector(OpCodeKind src)
            => src switch {
                Base00 => "0000",
                Base0F => "000F",
                Base0F38 => "0F38",
                Base0F3A => "0F3A",
                Amd3DNow => "003D",
                Xop8 => "0008",
                Xop9 => "0009",
                XopA => "000A",
                Vex0F => "000F",
                Vex0F38 => "0F38",
                Vex0F3A => "0F3A",
                Evex0F => "000F",
                Evex0F38 => "0F38",
                Evex0F3A => "0F3A",
                _ => asci4.Null,
            };

        [Op]
        public static string symbol(OpCodeKind src)
            => src switch
            {
                Base00 => S.B0,
                Base0F => S.B1,
                Base0F38 => S.B2,
                Base0F3A => S.B3,
                Amd3DNow => S.D3,
                Xop8 => S.X8,
                Xop9 => S.X9,
                XopA => S.XA,
                Vex0F => S.V1,
                Vex0F38 => S.V2,
                Vex0F3A => S.V3,
                Evex0F => S.E1,
                Evex0F38 => S.E2,
                Evex0F3A => S.E3,

                _ => EmptyString
            };

        [Op]
        public static OpCodeIndex ocindex(OpCodeKind kind)
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

        [Op]
        public static VexClass vexclass(OpCodeIndex src)
            => vexclass(XedOpCodes.occlass(src));

        [Op]
        public static VexClass vexclass(OpCodeClass src)
        {
            var vc = VexClass.None;
            switch(src)
            {
                case OpCodeClass.Vex:
                    vc = VexClass.VV1;
                break;
                case OpCodeClass.Evex:
                    vc = VexClass.VV1;
                break;
                case OpCodeClass.Xop:
                    vc = VexClass.XOPV;
                break;
            }
            return vc;
        }

        [Op]
        public static OpCodeMap ocmap(OpCodeKind kind)
        {
            var @class = XedOpCodes.occlass(kind);
            var selector = XedOpCodes.selector(kind);
            var indicator = XedOpCodes.indicator(@class);
            var index = XedOpCodes.ocindex(kind);
            return new OpCodeMap(kind, @class, index, indicator, selector);
        }

        public static bool mapcode(OpCodeIndex src, out byte dst)
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
                X.Xop8 => I.Xop8,
                X.Xop9 => I.Xop9,
                X.XopA => I.XopA,
                _ => 0
            };

        public static OpCodeIndex? ocindex(byte code)
        {
            var kind = basemap(code);
            if(kind != null)
                return ocindex(kind.Value);
            else
                return null;
        }

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


        [MethodImpl(Inline), Op]
        public static BaseMapKind? basemap(byte code)
            => code <= 4? (BaseMapKind)code : null;

        [MethodImpl(Inline), Op]
        public static BaseMapKind basemap(AsmOcValue value)
        {
            var dst = default(BaseMapKind);
            if(value[0] == 0x0F)
            {
                if(value[1] == 0x38)
                    dst = BaseMapKind.BaseMap2;
                else if(value[1] == 0x3A)
                    dst = BaseMapKind.BaseMap3;
                else
                    dst = BaseMapKind.BaseMap1;
            }
            else
                dst = BaseMapKind.BaseMap0;
            return dst;
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
                default:
                    dst = ocindex((BaseMapKind)map);
                break;
            }
            return dst;
        }

        public static AsmOcValue ocvalue(in InstFields src)
        {
            var count = src.Count;
            var storage = ByteBlock4.Empty;
            var dst = storage.Bytes;
            var j=0;
            for(var i=0; i<count; i++)
            {
                ref readonly var seg = ref src[i];
                if(seg.DataKind == InstFieldKind.HexLiteral)
                    seek(dst,j++) = seg.AsHexLit();
            }
            return new AsmOcValue(slice(dst,0,j));
        }

        public static XedOpCode opcode(in InstFields src)
        {
            var vc = VexClass.None;
            var number = z8;
            var value = ocvalue(src);
            var kind = OpCodeKind.None;
            for(var i=0; i<src.Count; i++)
            {
                ref readonly var part = ref src[i];
                if(part.IsFieldExpr && part.FieldKind == FieldKind.VEXVALID)
                    vc = (VexClass)part.AsFieldExpr().Value;
                if(part.IsFieldExpr && part.FieldKind == FieldKind.MAP)
                    number = part.AsFieldExpr().Value;
            }

            switch(vc)
            {
                case VexClass.VV1:
                    kind = XedOpCodes.ockind(XedOpCodes.ocindex((VexMapKind)number));
                break;
                case VexClass.XOPV:
                    kind = XedOpCodes.ockind(XedOpCodes.ocindex((XopMapKind)number));
                break;
                case VexClass.EVV:
                case VexClass.KVV:
                    kind = XedOpCodes.ockind(XedOpCodes.ocindex((EvexMapKind)number));
                break;
                default:
                    kind = XedOpCodes.ockind((OpCodeIndex)XedOpCodes.basemap(value));
                break;
            }

            return new XedOpCode(XedFields.mode(src), kind, value);
        }
    }
}