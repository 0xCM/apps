//-----------------------------------------------------------------------------
// Copyright   : Intel Corporation, 2020
// License     : Apache
// Sources     : all-map-descriptions.txt
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;
    using static core;

    using static XedModels.OpCodeMapIdentity;
    using OCM = XedModels.OpCodeMaps;


    partial struct XedModels
    {
        [SymSource(xed)]
        public enum OpCodeClass : byte
        {
            None = 0,

            [Symbol(OCM.LegacyMapClass)]
            LEGACY = 1,

            [Symbol(OCM.XopMapClass)]
            XOP = 2,

            [Symbol(OCM.VexMapClass)]
            VEX = 4,

            [Symbol(OCM.EvexMapClass)]
            EVEX = 8,
        }

        [SymSource(xed)]
        public enum LegacyMapKind : byte
        {
            [Symbol("legacy-map-0", EmptyString)]
            LEGACY_MAP0 = 0,

            [Symbol("legacy-map-1", OCM.LegacyPattern1)]
            LEGACY_MAP1 = 1,

            [Symbol("legacy-map-2", OCM.LegacyPattern2)]
            LEGACY_MAP2 = 2,

            [Symbol("legacy-map-3", OCM.LegacyPattern3)]
            LEGACY_MAP3 = 3,

            [Symbol("amd-3dnow", OCM.Amd3dNowPattern)]
            AMD_3DNOW = 4,
        }

        [SymSource(xed)]
        public enum XopMapKind : byte
        {
            [Symbol("amd-xop8", OCM.XopPattern8)]
            XOP8=8,

            [Symbol("amd-xop9", OCM.XopPattern9)]
            XOP9=9,

            [Symbol("amd-xopA", OCM.XopPatternA)]
            XOPA=10,
        }

        [SymSource(state)]
        public enum VexMapKind : byte
        {
            [Symbol("vex-map1", OCM.VexPattern0F)]
            VEX_MAP_0F = 1,

            [Symbol("vex-map2", OCM.VexPattern0F38)]
            VEX_MAP_0F38 = 2,

            [Symbol("vex-map3", OCM.VexPattern0F3A)]
            VEX_MAP_0F3A = 3
        }

        [SymSource(xed)]
        public enum EvexMapKind : byte
        {
            [Symbol("evex-map1", OCM.EvexPattern0F)]
            EVEX_MAP_0F=1,

            [Symbol("evex-map2", OCM.EvexPattern0F38)]
            EVEX_MAP_0F38=2,

            [Symbol("evex-map3", OCM.EvexPattern0F3A)]
            EVEX_MAP_0F3A=3,
        }

        [SymSource(xed)]
        public enum OpCodeMapIdentity : ushort
        {
            None = 0,

            LEGACY_MAP0 = OpCodeClass.LEGACY | (ushort)((byte)LegacyMapKind.LEGACY_MAP0 << 8),

            LEGACY_MAP1 = OpCodeClass.LEGACY | (ushort)((byte)LegacyMapKind.LEGACY_MAP1 << 8),

            LEGACY_MAP2 = OpCodeClass.LEGACY | (ushort)((byte)LegacyMapKind.LEGACY_MAP2 << 8),

            LEGACY_MAP3 = OpCodeClass.LEGACY | (ushort)((byte)LegacyMapKind.LEGACY_MAP3 << 8),

            AMD_3DNOW = OpCodeClass.LEGACY | (ushort)((byte)LegacyMapKind.AMD_3DNOW << 8),

            XOP8 = OpCodeClass.XOP | (ushort)((byte)XopMapKind.XOP8 << 8),

            XOP9 = OpCodeClass.XOP | (ushort)((byte)XopMapKind.XOP9 << 8),

            XOPA = OpCodeClass.XOP | (ushort)((byte)XopMapKind.XOPA << 8),

            VEX_MAP_0F = OpCodeClass.VEX | (ushort)((byte)VexMapKind.VEX_MAP_0F << 8),

            VEX_MAP_0F38 = OpCodeClass.VEX | (ushort)((byte)VexMapKind.VEX_MAP_0F38 << 8),

            VEX_MAP_0F3A = OpCodeClass.VEX | (ushort)((byte)VexMapKind.VEX_MAP_0F3A << 8),

            EVEX_MAP_0F = OpCodeClass.EVEX | (ushort)((byte)EvexMapKind.EVEX_MAP_0F << 8),

            EVEX_MAP_0F38 = OpCodeClass.EVEX | (ushort)((byte)EvexMapKind.EVEX_MAP_0F38 << 8),

            EVEX_MAP_0F3A = OpCodeClass.EVEX | (ushort)((byte)EvexMapKind.EVEX_MAP_0F3A << 8),
        }

        [Record(TableId)]
        public struct OpCodeMap
        {
            public const string TableId = "xed.rules.opcodemap";

            public const byte FieldCount = 6;

            public byte Seq;

            public OpCodeClass Class;

            public text15 Name;

            public byte Number;

            public OpCodeMapIdentity Identity;

            public text15 Pattern;

            public static ReadOnlySpan<byte> RenderWidths => new byte[FieldCount]{6,12,16,12,16,1};
        }

        public class OpCodeMaps
        {
            public const string LegacyMapClass = "LEGACY";

            public const string XopMapClass = "XOP";

            public const string VexMapClass = "VV1";

            public const string EvexMapClass = "EVV";

            public const string LegacyPattern1 = "0x0F";

            public const string LegacyPattern2 = "0x0F 0x38";

            public const string LegacyPattern3 = "0x0F 0x3A";

            public const string Amd3dNowPattern = "0x0F 0x0F";

            public const string XopPattern8 = "XMAP8";

            public const string XopPattern9 = "XMAP9";

            public const string XopPatternA = "XMAPA";

            public const string VexPattern0F = "V0F";

            public const string VexPattern0F38 = "V0F38";

            public const string VexPattern0F3A = "V0F3A";

            public const string EvexPattern0F = "V0F";

            public const string EvexPattern0F38 = "V0F38";

            public const string EvexPattern0F3A = "V0F3A";

            public static OpCodeMapIdentity identify(string pattern)
            {
                var content = pattern;
                var i = NotFound;
                var identity = OpCodeMapIdentity.None;

                i = text.index(content, OCM.VexMapClass);
                if(i >= 0)
                {
                    i = text.index(content, "V0F");
                    if(i>=0)
                        return VEX_MAP_0F;

                    i = text.index(content, "V0F38");
                    if(i>=0)
                        return VEX_MAP_0F38;

                    i = text.index(content, "V0F3A");
                    if(i>=0)
                        return VEX_MAP_0F3A;

                    return 0;
                }

                i = text.index(content, OCM.EvexMapClass);
                if(i >= 0)
                {
                    i = text.index(content, "V0F");
                    if(i>=0)
                        return EVEX_MAP_0F;

                    i = text.index(content, "V0F38");
                    if(i>=0)
                        return EVEX_MAP_0F38;

                    i = text.index(content, "V0F3A");
                    if(i>=0)
                        return EVEX_MAP_0F3A;

                    return 0;
                }

                i = text.index(content, OCM.LegacyPattern2);
                if(i >= 0)
                    return LEGACY_MAP2;

                i = text.index(content, OCM.LegacyPattern3);
                if(i >= 0)
                    return LEGACY_MAP3;

                i = text.index(content, OCM.Amd3dNowPattern);
                if(i >= 0)
                    return AMD_3DNOW;

                i = text.index(content, OCM.LegacyPattern1);
                if(i >= 0)
                    return LEGACY_MAP1;

                i = text.index(content, OCM.XopPattern8);
                if(i >= 0)
                    return XOP8;

                i = text.index(content, OCM.XopPattern9);
                if(i >= 0)
                    return XOP9;

                i = text.index(content, OCM.XopPatternA);
                if(i >= 0)
                    return XOPA;

                return LEGACY_MAP0;
            }

            Index<OpCodeMap> Data;

            public OpCodeMaps()
            {
                Data = derive();
            }

            public ReadOnlySpan<OpCodeMap> Records
            {
                [MethodImpl(Inline)]
                get => Data;
            }

            static Index<OpCodeMap> derive()
            {
                var counter = z8;
                var count = 0u;
                var legacy = Symbols.index<LegacyMapKind>();
                var xop = Symbols.index<XopMapKind>();
                var vex = Symbols.index<VexMapKind>();
                var evex = Symbols.index<EvexMapKind>();

                var counts = legacy.Count + xop.Count + vex.Count + evex.Count;
                var buffer = alloc<OpCodeMap>(counts);

                count = legacy.Count;
                for(var i=0u; i<count; i++)
                {
                    ref readonly var sym = ref legacy[i];
                    ref var dst = ref seek(buffer, counter);
                    dst.Seq = counter++;
                    dst.Class = OpCodeClass.LEGACY;
                    dst.Name = sym.Expr.Format();
                    dst.Number = (byte)sym.Kind;
                    dst.Identity = (OpCodeMapIdentity)((ushort)dst.Class | ((ushort)sym.Kind << 8));
                    dst.Pattern = sym.Description.Format();
                }

                count = xop.Count;
                for(var i=0u; i<count; i++)
                {
                    ref readonly var sym = ref xop[i];
                    ref var dst = ref seek(buffer,counter);
                    dst.Seq = counter++;
                    dst.Class = OpCodeClass.XOP;
                    dst.Name = sym.Expr.Format();
                    dst.Number = (byte)sym.Kind;
                    dst.Identity = (OpCodeMapIdentity)((ushort)dst.Class | ((ushort)sym.Kind << 8));
                    dst.Pattern = sym.Description.Format();
                }

                count = vex.Count;
                for(var i=0u; i<count; i++)
                {
                    ref readonly var sym = ref vex[i];
                    ref var dst = ref seek(buffer,counter);
                    dst.Seq = counter++;
                    dst.Class = OpCodeClass.VEX;
                    dst.Name = sym.Expr.Format();
                    dst.Number = (byte)sym.Kind;
                    dst.Identity = (OpCodeMapIdentity)((ushort)dst.Class | ((ushort)sym.Kind << 8));
                    dst.Pattern = sym.Description.Format();
                }

                count = evex.Count;
                for(var i=0u; i<count; i++)
                {
                    ref readonly var sym = ref evex[i];
                    ref var dst = ref seek(buffer,counter);
                    dst.Seq = counter++;
                    dst.Class = OpCodeClass.EVEX;
                    dst.Name = sym.Expr.Format();
                    dst.Number = (byte)sym.Kind;
                    dst.Identity = (OpCodeMapIdentity)((ushort)dst.Class | ((ushort)sym.Kind << 8));
                    dst.Pattern = sym.Description.Format();
                }

                return buffer;
            }
        }
    }
}