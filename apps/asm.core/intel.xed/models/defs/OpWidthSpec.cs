//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;
    using static NativeClass;

    using W = XedModels.OpWidthCode;
    using EK = XedModels.ElementKind;
    using WC = XedModels.OpWidthCode;

    partial struct XedModels
    {
        public readonly struct OpWidthSpec
        {
            public static ushort bitwidth(OpWidthCode code, ElementKind ekind)
            {
                var result = bitwidth(code);
                if(result != 0)
                    return result;

                switch(ekind)
                {
                    case EK.U8:
                    case EK.I8:
                        result = 8;
                        break;

                    case EK.U16:
                    case EK.I16:
                    case EK.F16:
                    case EK.BF16:
                        result = 16;
                        break;

                    case EK.U32:
                    case EK.I32:
                    case EK.F32:
                    case EK.INT:
                    case EK.UINT:
                        result = 32;
                        break;

                    case EK.U64:
                    case EK.I64:
                    case EK.F64:
                        result = 64;
                        break;

                    case EK.B80:
                    case EK.F80:
                        result = 80;
                        break;

                    case EK.U128:
                        result = 128;
                        break;

                    case EK.U256:
                        result = 256;
                        break;
                    default:
                    break;
                }

                return result;
            }

            static ushort bitwidth(OpWidthCode code)
            {
                var result = z16;
                switch(code)
                {
                    case WC.B:
                        result = 8;
                    break;

                    case WC.D:
                        result = 32;
                    break;

                    case WC.MSKW:
                    case WC.ZMSKW:
                    case WC.I1:
                        result = 1;
                    break;
                    case WC.I2:
                        result = 2;
                    break;
                    case WC.I3:
                        result = 3;
                    break;
                    case WC.I4:
                        result = 4;
                    break;
                    case WC.I5:
                        result = 5;
                    break;
                    case WC.I6:
                        result = 6;
                    break;
                    case WC.I7:
                        result = 7;
                    break;
                    case WC.I8:
                        result = 8;
                    break;

                    case WC.MEM16:
                    case WC.MEM16INT:
                        result = 16;
                        break;

                    case WC.MEM28:
                        result = 224;
                        break;

                    case WC.MEM14:
                        result=112;
                    break;

                    case WC.MEM94:
                        result=94;
                    break;

                    case WC.MEM108:
                        result=108;
                    break;

                    case WC.M512:
                        result = 512;
                        break;

                    case WC.M384:
                        result = 384;
                        break;

                    case WC.MFPXENV:
                        result = 4096;
                    break;

                    case WC.MXSAVE:
                        result = 4608;
                    break;
                }

                return result;
            }
            [Op]
            public static NativeClass @class(OpWidthCode src)
            {
                var dst = NativeClass.None;
                switch(src)
                {
                    case W.P:
                    case W.P2:
                    case W.MPREFETCH:
                    case W.VAR:
                    case W.PMMSZ16:
                    case W.PMMSZ32:
                    case W.VV:
                    case W.ZV:
                        dst = 0;
                        break;
                    case W.MSKW:
                    case W.ZMSKW:
                    case W.I1:
                        dst = B;
                        break;

                    case W.BND32:
                    case W.BND64:
                    case W.WRD:
                    case W.B:
                    case W.U8:
                    case W.U16:
                    case W.U32:
                    case W.U64:
                    case W.X128:
                    case W.XUB:
                    case W.XUW:
                    case W.XUD:
                    case W.XUQ:
                    case W.Y128:
                    case W.YUB:
                    case W.YUW:
                    case W.YUD:
                    case W.YUQ:
                    case W.ZUB:
                    case W.ZU8:
                    case W.ZU16:
                    case W.ZU32:
                    case W.ZU64:

                    case W.ZUD:
                    case W.ZUW:
                    case W.ZUQ:
                    case W.ZU128:

                    case W.MEM16:
                    case W.MEM28:
                    case W.MEM14:
                    case W.MEM94:
                    case W.MEM108:
                    case W.M512:
                    case W.M384:

                    case W.TMEMCOL:
                    case W.TMEMROW:
                    case W.TV:
                    case W.PTR:
                        dst = U;
                        break;

                    case W.A16:
                    case W.A32:
                    case W.ASZ:
                    case W.SSZ:

                    case W.PI:

                    case W.I2:
                    case W.I3:
                    case W.I4:
                    case W.I5:
                    case W.I6:
                    case W.I7:

                    case W.I8:
                    case W.I16:
                    case W.I32:
                    case W.I64:

                    case W.W:
                    case W.D:
                    case W.Q:

                    case W.V:
                    case W.Y:
                    case W.Z:

                    case W.DQ:
                    case W.QQ:
                    case W.MQ:

                    case W.MB:
                    case W.MW:
                    case W.MD:

                    case W.XB:
                    case W.XW:
                    case W.XD:
                    case W.XQ:

                    case W.YB:
                    case W.YW:
                    case W.YD:
                    case W.YQ:

                    case W.ZB:
                    case W.ZW:
                    case W.ZD:
                    case W.ZQ:

                    case W.ZI8:
                    case W.ZI16:
                    case W.ZI32:
                    case W.ZI64:

                    case W.SPW:
                    case W.SPW2:
                    case W.SPW3:
                    case W.SPW5:
                    case W.SPW8:

                    case W.MEM16INT:
                    case W.MEM32INT:
                    case W.M64INT:

                        dst = I;
                        break;

                    case W.F16:
                    case W.F32:
                    case W.F64:
                    case W.F80:

                    case W.SI:
                    case W.SD:

                    case W.YPS:
                    case W.YPD:
                    case W.ZBF16:

                    case W.PS:
                    case W.PD:
                    case W.ZF32:
                    case W.ZF64:
                    case W.S:
                    case W.S64:
                    case W.SS:
                    case W.MEM32REAL:
                    case W.M64REAL:
                    case W.MEM80REAL:
                        dst = F;
                        break;
                }

                return dst;
            }

            [MethodImpl(Inline)]
            public static OpWidthSpec define(GprWidth gpr)
            {
                var w0 = (ushort)gpr[w16].Width;
                var w1 = (ushort)gpr[w32].Width;
                var w2 = (ushort)gpr[w64].Width;
                return new OpWidthSpec(0, ModeClass.Default, gpr, ElementType.Empty, 1);
            }

            // static BitSegType segtype(@class(dst.Code), dst.Width64, dst.CellWidth)
            //     =>
            public static OpWidthSpecs define(Index<OpWidthInfo> src)
            {
                var count = src.Count*3;
                var dst = alloc<OpWidthSpec>(count);
                var k=0u;
                for(var i=0; i<src.Count; i++)
                {
                    ref readonly var info = ref src[i];
                    seek(dst,k++) = new OpWidthSpec(info.Code, ModeClass.Mode16, info.Name, info.SegType, 1, info.ElementType, info.CellWidth, info.Width16);
                    seek(dst,k++) = new OpWidthSpec(info.Code, ModeClass.Mode32, info.Name, info.SegType, 1, info.ElementType, info.CellWidth, info.Width32);
                    seek(dst,k++) = new OpWidthSpec(info.Code, ModeClass.Mode64, info.Name, info.SegType, 1, info.ElementType, info.CellWidth, info.Width64);
                }
                return new OpWidthSpecs(dst);
            }

            [MethodImpl(Inline)]
            OpWidthSpec(OpWidthCode code, MachineMode mode, text15 name, BitSegType seg, ushort n, ElementType t, ushort cw, ushort bw)
            {
                Code = code;
                Mode = mode;
                Name = name;
                Seg = seg;
                Gpr = GprWidth.Empty;
                N = n;
                CellType = t;
                CellWidth = cw;
                Width = bw;
            }

            [MethodImpl(Inline)]
            OpWidthSpec(OpWidthCode code, MachineMode mode, GprWidth gpr, ElementType ct, ushort n)
            {
                Code = code;
                Gpr = gpr;
                CellType = ct;
                CellWidth = default;
                Seg = BitSegType.Empty;
                N = n;
                Width = default;
                Mode = default;
                Name = default;
            }

            public readonly OpWidthCode Code;

            public readonly GprWidth Gpr;

            public readonly text15 Name;

            public readonly ElementType CellType;

            public readonly MachineMode Mode;

            public readonly BitSegType Seg;

            readonly ushort CellWidth;

            public readonly ushort N;

            public readonly ushort Width;

            public byte Count
            {
                [MethodImpl(Inline)]
                get => Gpr.IsEmpty ? (byte)1 : Gpr.Count;
            }

            public bool Invariant
            {
                [MethodImpl(Inline)]
                get => Gpr.IsInvariant;
            }

            public ushort W0
            {
                [MethodImpl(Inline)]
                get => Gpr.IsNonEmpty ? (ushort)Gpr[w16] : Width;
            }

            public ushort W1
            {
                [MethodImpl(Inline)]
                get => Gpr.IsNonEmpty ? (ushort)Gpr[w32] : Width;
            }

            public ushort W2
            {
                [MethodImpl(Inline)]
                get => Gpr.IsNonEmpty ?(ushort)Gpr[w64] : Width;
            }

            public ushort this[W16 w]
            {
                [MethodImpl(Inline)]
                get => W0;
            }

            public ushort this[W32 w]
            {
                [MethodImpl(Inline)]
                get => W1;
            }

            public ushort this[W64 w]
            {
                [MethodImpl(Inline)]
                get => W2;
            }

            public ushort OpBits
            {
                [MethodImpl(Inline)]
                get => (ushort)Width;
            }

            public static OpWidthSpec Empty => default;
        }
    }
}