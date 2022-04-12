//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;
    using static XedModels;

    partial class XedRules
    {
        public class OpCodeKinds
        {
            Index<OcMapKind> Data;

            public OpCodeKinds()
            {
                Data = derive();
            }

            public ReadOnlySpan<OcMapKind> Records
            {
                [MethodImpl(Inline)]
                get => Data;
            }

            static Index<OcMapKind> derive()
            {
                var counter = z8;
                var count = 0u;
                var legacy = Symbols.index<BaseMapKind>();
                var xop = Symbols.index<XopMapKind>();
                var vex = Symbols.index<VexMapKind>();
                var evex = Symbols.index<EvexMapKind>();

                var counts = legacy.Count + xop.Count + vex.Count + evex.Count;
                var buffer = alloc<OcMapKind>(counts);

                count = legacy.Count;
                for(var i=0u; i<count; i++)
                {
                    ref readonly var sym = ref legacy[i];
                    ref var dst = ref seek(buffer, counter);
                    dst.Index = counter++;
                    dst.Class = OpCodeClass.Base;
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
                    dst.Class = OpCodeClass.Xop;
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
                    dst.Class = OpCodeClass.Vex;
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
                    dst.Class = OpCodeClass.Evex;
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