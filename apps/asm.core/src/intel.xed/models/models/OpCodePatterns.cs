//-----------------------------------------------------------------------------
// Copyright   : Intel Corporation, 2020
// License     : Apache
// Sources     : all-map-descriptions.txt
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial struct XedModels
    {
        public class OpCodePatterns
        {
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
                    dst.Index = counter++;
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
                    dst.Index = counter++;
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
                    dst.Index = counter++;
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
                    dst.Index = counter++;
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