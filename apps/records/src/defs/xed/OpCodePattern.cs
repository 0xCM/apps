//-----------------------------------------------------------------------------
// Copyright   : Intel Corporation, 2020
// License     : Apache
// Sources     : all-map-descriptions.txt
//-----------------------------------------------------------------------------
namespace Z0
{
    using OCP = XedRecords.OcPatternNames;

    partial struct XedRecords
    {
        public readonly struct OcPatternNames
        {
            public const string LegacyMapClass = "LEGACY";

            public const string XopMapClass = "XOP";

            public const string XOPV = "XOPV";

            public const string VV1 = "VV1";

            public const string EVV = "EVV";

            public const string VexMapClass = VV1;

            public const string EvexMapClass = EVV;

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
        }

        [Record(TableId)]
        public struct OpCodePattern
        {
            public const string TableId = "xed.rules.ocpattern";

            public const byte FieldCount = 6;

            public byte Seq;

            public OpCodeClass Class;

            public text15 Name;

            public byte Number;

            public OpCodeKind Identity;

            public text15 Pattern;

            public static ReadOnlySpan<byte> RenderWidths => new byte[FieldCount]{6,12,16,12,16,1};
        }

        [SymSource(xed)]
        public enum OpCodeClass : byte
        {
            None = 0,

            [Symbol(OCP.LegacyMapClass)]
            LEGACY = 1,

            [Symbol(OCP.XopMapClass)]
            XOP = 2,

            [Symbol(OCP.VexMapClass)]
            VEX = 4,

            [Symbol(OCP.EvexMapClass)]
            EVEX = 8,
        }

        [SymSource(xed)]
        public enum LegacyMapKind : byte
        {
            [Symbol("legacy-map-0", EmptyString)]
            LEGACY_MAP0 = 0,

            [Symbol("legacy-map-1", OCP.LegacyPattern1)]
            LEGACY_MAP1 = 1,

            [Symbol("legacy-map-2", OCP.LegacyPattern2)]
            LEGACY_MAP2 = 2,

            [Symbol("legacy-map-3", OCP.LegacyPattern3)]
            LEGACY_MAP3 = 3,

            [Symbol("amd-3dnow", OCP.Amd3dNowPattern)]
            AMD_3DNOW = 4,
        }

        [SymSource(xed)]
        public enum XopMapKind : byte
        {
            [Symbol("amd-xop8", OCP.XopPattern8)]
            XOP8=8,

            [Symbol("amd-xop9", OCP.XopPattern9)]
            XOP9=9,

            [Symbol("amd-xopA", OCP.XopPatternA)]
            XOPA=10,
        }

        [SymSource(xed_state)]
        public enum VexMapKind : byte
        {
            [Symbol("vex-map1", OCP.VexPattern0F)]
            VEX_MAP_0F = 1,

            [Symbol("vex-map2", OCP.VexPattern0F38)]
            VEX_MAP_0F38 = 2,

            [Symbol("vex-map3", OCP.VexPattern0F3A)]
            VEX_MAP_0F3A = 3
        }

        [SymSource(xed)]
        public enum EvexMapKind : byte
        {
            [Symbol("evex-map1", OCP.EvexPattern0F)]
            EVEX_MAP_0F=1,

            [Symbol("evex-map2", OCP.EvexPattern0F38)]
            EVEX_MAP_0F38=2,

            [Symbol("evex-map3", OCP.EvexPattern0F3A)]
            EVEX_MAP_0F3A=3,
        }

        [SymSource(xed)]
        public enum OpCodeKind : ushort
        {
            None = 0,

            [Symbol("gp:0")]
            LEGACY_MAP0 = OpCodeClass.LEGACY | (ushort)((byte)LegacyMapKind.LEGACY_MAP0 << 8),

            [Symbol("gp:1")]
            LEGACY_MAP1 = OpCodeClass.LEGACY | (ushort)((byte)LegacyMapKind.LEGACY_MAP1 << 8),

            [Symbol("gp:2")]
            LEGACY_MAP2 = OpCodeClass.LEGACY | (ushort)((byte)LegacyMapKind.LEGACY_MAP2 << 8),

            [Symbol("gp:3")]
            LEGACY_MAP3 = OpCodeClass.LEGACY | (ushort)((byte)LegacyMapKind.LEGACY_MAP3 << 8),

            [Symbol("3DNow")]
            AMD_3DNOW = OpCodeClass.LEGACY | (ushort)((byte)LegacyMapKind.AMD_3DNOW << 8),

            [Symbol("xop:8")]
            XOP8 = OpCodeClass.XOP | (ushort)((byte)XopMapKind.XOP8 << 8),

            [Symbol("xop:9")]
            XOP9 = OpCodeClass.XOP | (ushort)((byte)XopMapKind.XOP9 << 8),

            [Symbol("xop:A")]
            XOPA = OpCodeClass.XOP | (ushort)((byte)XopMapKind.XOPA << 8),

            [Symbol("vex:0F")]
            VEX_MAP_0F = OpCodeClass.VEX | (ushort)((byte)VexMapKind.VEX_MAP_0F << 8),

            [Symbol("vex:0F38")]
            VEX_MAP_0F38 = OpCodeClass.VEX | (ushort)((byte)VexMapKind.VEX_MAP_0F38 << 8),

            [Symbol("vex:0F3A")]
            VEX_MAP_0F3A = OpCodeClass.VEX | (ushort)((byte)VexMapKind.VEX_MAP_0F3A << 8),

            [Symbol("evex:0F")]
            EVEX_MAP_0F = OpCodeClass.EVEX | (ushort)((byte)EvexMapKind.EVEX_MAP_0F << 8),

            [Symbol("evex:0F38")]
            EVEX_MAP_0F38 = OpCodeClass.EVEX | (ushort)((byte)EvexMapKind.EVEX_MAP_0F38 << 8),

            [Symbol("evex:0F3A")]
            EVEX_MAP_0F3A = OpCodeClass.EVEX | (ushort)((byte)EvexMapKind.EVEX_MAP_0F3A << 8),
        }
    }
}