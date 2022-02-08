//-----------------------------------------------------------------------------
// Copyright   : Intel Corporation, 2020
// License     : Apache
// Sources     : all-map-descriptions.txt
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;
    using static XedRecords.OpCodeKind;
    using static XedRecords;

    using OCP = XedRecords.OcPatternNames;

    partial struct XedModels
    {
        public class OpCodePatterns
        {
            public static OpCodeKind kind(string rule)
            {
                var content = rule;
                var i = NotFound;
                var identity = OpCodeKind.None;

                i = text.index(content, OCP.VexMapClass);
                if(i >= 0)
                {
                    i = text.index(content, OCP.VexPattern0F38);
                    if(i>=0)
                        return VEX_MAP_0F38;

                    i = text.index(content, OCP.VexPattern0F3A);
                    if(i>=0)
                        return VEX_MAP_0F3A;

                    i = text.index(content, OCP.VexPattern0F);
                    if(i>=0)
                        return VEX_MAP_0F;

                    return 0;
                }

                i = text.index(content, OCP.EvexMapClass);
                if(i >= 0)
                {
                    i = text.index(content, OCP.EvexPattern0F38);
                    if(i>=0)
                        return EVEX_MAP_0F38;

                    i = text.index(content, OCP.EvexPattern0F3A);
                    if(i>=0)
                        return EVEX_MAP_0F3A;

                    i = text.index(content, OCP.EvexPattern0F);
                    if(i>=0)
                        return EVEX_MAP_0F;

                    return 0;
                }

                i = text.index(content, OCP.LegacyPattern2);
                if(i >= 0)
                    return LEGACY_MAP2;

                i = text.index(content, OCP.LegacyPattern3);
                if(i >= 0)
                    return LEGACY_MAP3;

                i = text.index(content, OCP.Amd3dNowPattern);
                if(i >= 0)
                    return AMD_3DNOW;

                i = text.index(content, OCP.LegacyPattern1);
                if(i >= 0)
                    return LEGACY_MAP1;

                i = text.index(content, OCP.XopPattern8);
                if(i >= 0)
                    return XOP8;

                i = text.index(content, OCP.XopPattern9);
                if(i >= 0)
                    return XOP9;

                i = text.index(content, OCP.XopPatternA);
                if(i >= 0)
                    return XOPA;

                return LEGACY_MAP0;
            }

            Index<OpCodePattern> Data;

            public OpCodePatterns()
            {
                Data = derive();
            }

            public ReadOnlySpan<OpCodePattern> Records
            {
                [MethodImpl(Inline)]
                get => Data;
            }

            static Index<OpCodePattern> derive()
            {
                var counter = z8;
                var count = 0u;
                var legacy = Symbols.index<LegacyMapKind>();
                var xop = Symbols.index<XopMapKind>();
                var vex = Symbols.index<VexMapKind>();
                var evex = Symbols.index<EvexMapKind>();

                var counts = legacy.Count + xop.Count + vex.Count + evex.Count;
                var buffer = alloc<OpCodePattern>(counts);

                count = legacy.Count;
                for(var i=0u; i<count; i++)
                {
                    ref readonly var sym = ref legacy[i];
                    ref var dst = ref seek(buffer, counter);
                    dst.Seq = counter++;
                    dst.Class = OpCodeClass.LEGACY;
                    dst.Name = sym.Expr.Format();
                    dst.Number = (byte)sym.Kind;
                    dst.Identity = (OpCodeKind)((ushort)dst.Class | ((ushort)sym.Kind << 8));
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
                    dst.Identity = (OpCodeKind)((ushort)dst.Class | ((ushort)sym.Kind << 8));
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
                    dst.Identity = (OpCodeKind)((ushort)dst.Class | ((ushort)sym.Kind << 8));
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
                    dst.Identity = (OpCodeKind)((ushort)dst.Class | ((ushort)sym.Kind << 8));
                    dst.Pattern = sym.Description.Format();
                }

                return buffer;
            }
        }
    }
}