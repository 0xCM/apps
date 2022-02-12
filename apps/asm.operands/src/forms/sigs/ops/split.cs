//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using static core;
    using static AsmSigTokens;
    using static AsmSigTokens.BCastComposite;
    using static AsmSigTokens.KRmToken;
    using static AsmSigTokens.GpRmToken;
    using static AsmSigTokens.VecRmToken;

    using K = AsmSigTokenKind;

    partial class AsmSigs
    {
        public static bool split(in AsmSig src, out AsmSig a, out AsmSig b)
        {
            var result = nonterminal(src, out var index, out var termcount);
            if(result)
            {
                var count = src.OpCount;
                var opsA = AsmSigOps.Empty;
                var opsB = AsmSigOps.Empty;
                for(byte i=0; i<count; i++)
                {
                    var op = src[i];
                    if(i == index)
                    {
                        if(split(op, out var opA, out var opB))
                        {
                            opsA[i] = opA;
                            opsB[i] = opB;
                        }
                        else
                            Errors.Throw(string.Format("{0} is terminal", src));
                    }
                    else
                    {
                        opsA[i] = op;
                        opsB[i] = op;
                    }
                }
                a = new AsmSig(src.Mnemonic, opsA);
                b = new AsmSig(src.Mnemonic, opsB);
            }
            else
            {
                a = AsmSig.Empty;
                b = AsmSig.Empty;
            }
            return result;
        }

        public static bool split(in AsmSig src, out AsmSig a, out AsmSig b, out AsmSig c)
        {
            var result = nonterminal(src, out var index, out var termcount);
            if(result)
            {
                var count = src.OpCount;
                var opsA = AsmSigOps.Empty;
                var opsB = AsmSigOps.Empty;
                var opsC = AsmSigOps.Empty;
                for(byte i=0; i<count; i++)
                {
                    var op = src[i];
                    if(i == index)
                    {
                        if(split(op, out var opA, out var opB, out var opC))
                        {
                            opsA[i] = opA;
                            opsB[i] = opB;
                            opsC[i] = opC;
                        }
                        else
                            Errors.Throw(string.Format("{0} is terminal", src));
                    }
                    else
                    {
                        opsA[i] = op;
                        opsB[i] = op;
                        opsC[i] = op;
                    }
                }
                a = new AsmSig(src.Mnemonic, opsA);
                b = new AsmSig(src.Mnemonic, opsB);
                c = new AsmSig(src.Mnemonic, opsC);
            }
            else
            {
                a = AsmSig.Empty;
                b = AsmSig.Empty;
                c = AsmSig.Empty;
            }
            return result;
        }


        public static bool split(in AsmSigOp src, out AsmSigOp a, out AsmSigOp b, out AsmSigOp c)
        {
            var result = false;
            a = AsmSigOp.Empty;
            b = AsmSigOp.Empty;
            c = AsmSigOp.Empty;
            if(nonterminal(src, out var termcount))
            {
                switch(src.Kind)
                {
                    case K.GpRmTriple:
                    {
                        result = split((GpRmTriple)src.Value, out var reg0, out var reg1, out var mem);
                        a = new AsmSigOp(K.GpReg, (byte)reg0, src.Modifier);
                        b = new AsmSigOp(K.GpReg, (byte)reg1, src.Modifier);
                        c = new AsmSigOp(K.Mem, (byte)mem, src.Modifier);
                    }
                    break;

                    case K.GpRegTriple:
                    {
                        result = split((GpRegTriple)src.Value, out var reg0, out var reg1, out var reg2);
                        a = new AsmSigOp(K.GpReg, (byte)reg0, src.Modifier);
                        b = new AsmSigOp(K.GpReg, (byte)reg1, src.Modifier);
                        c = new AsmSigOp(K.GpReg, (byte)reg2, src.Modifier);
                    }
                    break;

                    case K.BCastComposite:
                    {
                        result = split((BCastComposite)src.Value, out var vreg, out var mem, out var bcast);
                        a = new AsmSigOp(K.VecReg, (byte)vreg, src.Modifier);
                        b = new AsmSigOp(K.Mem, (byte)mem, src.Modifier);
                        c = new AsmSigOp(K.BCastMem, (byte)bcast, src.Modifier);
                    }
                    break;
                }
            }
            return result;
        }

        public static bool split(in AsmSigOp src, out AsmSigOp a, out AsmSigOp b)
        {
            var result = false;
            a = AsmSigOp.Empty;
            b = AsmSigOp.Empty;
            if(nonterminal(src, out var termcount))
            {
                switch(src.Kind)
                {
                    case K.VecRm:
                    {
                        result = split((VecRmToken)src.Value, out var vreg, out var mem);
                        a = new AsmSigOp(K.VecReg, (byte)vreg, src.Modifier);
                        b = new AsmSigOp(K.Mem, (byte)mem, src.Modifier);
                    }
                    break;

                    case K.KRm:
                    {
                        result = split((KRmToken)src.Value, out var kreg, out var mem);
                        a = new AsmSigOp(K.MaskReg, (byte)kreg, src.Modifier);
                        b = new AsmSigOp(K.Mem, (byte)mem, src.Modifier);
                    }
                    break;

                    case K.GpRm:
                    {
                        result = split((GpRmToken)src.Value, out var reg, out var mem);
                        a = new AsmSigOp(K.GpReg, (byte)reg, src.Modifier);
                        b = new AsmSigOp(K.Mem, (byte)mem, src.Modifier);
                    }
                    break;

                    case K.MmxRm:
                    {
                        result = split((MmxRmToken)src.Value, out var mmx, out var mem);
                        a = new AsmSigOp(K.MmxReg, (byte)mmx, src.Modifier);
                        b = new AsmSigOp(K.Mem, (byte)mem, src.Modifier);
                    }
                    break;
                }
            }
            return result;
        }

        public static bool split(GpRmTriple src, out GpRegToken a, out GpRegToken b, out MemToken c)
        {
            var result = false;
            switch(src)
            {
                case GpRmTriple.r16r32m16:
                    a = GpRegToken.r16;
                    b = GpRegToken.r32;
                    c = MemToken.m16;
                    result = true;
                break;
                default:
                    a = default;
                    b = default;
                    c = default;
                break;
            }
            return result;
        }

        public static bool split(GpRegTriple src, out GpRegToken a, out GpRegToken b, out GpRegToken c)
        {
            var result = false;
            switch(src)
            {
                case GpRegTriple.r16r32r64:
                    a = GpRegToken.r16;
                    b = GpRegToken.r32;
                    c = GpRegToken.r64;
                    result = true;
                break;
                default:
                    a = default;
                    b = default;
                    c = default;
                break;
            }

            return result;
        }

        public static bool split(GpRmToken src, out GpRegToken a, out MemToken b)
        {
            var result = false;
            switch(src)
            {
                case rm8:
                    a = GpRegToken.r8;
                    b = MemToken.m8;
                    result = true;
                break;
                case rm16:
                    a = GpRegToken.r16;
                    b = MemToken.m16;
                    result = true;
                break;
                case rm32:
                    a = GpRegToken.r32;
                    b = MemToken.m32;
                    result = true;
                break;
                case rm64:
                    a = GpRegToken.r64;
                    b = MemToken.m64;
                    result = true;
                break;
                case r16m16:
                    a = GpRegToken.r16;
                    b = MemToken.m16;
                    result = true;
                break;
                case r32m8:
                    a = GpRegToken.r32;
                    b = MemToken.m8;
                    result = true;
                break;
                case r32m16:
                    a = GpRegToken.r32;
                    b = MemToken.m16;
                    result = true;
                break;
                case r32m32:
                    a = GpRegToken.r32;
                    b = MemToken.m32;
                    result = true;
                break;
                case r64m16:
                    a = GpRegToken.r64;
                    b = MemToken.m16;
                    result = true;
                break;
                case r64m32:
                    a = GpRegToken.r64;
                    b = MemToken.m32;
                    result = true;
                break;
                case r64m64:
                    a = GpRegToken.r64;
                    b = MemToken.m64;
                    result = true;
                break;
                case regm8:
                    a = GpRegToken.r8;
                    b = MemToken.m8;
                    result = true;
                break;
                case regm16:
                    a = GpRegToken.r16;
                    b = MemToken.m16;
                    result = true;
                break;
                default:
                    a = default;
                    b = default;
                break;
            }
            return result;
        }

        public static bool split(VecRmToken src, out VRegToken a, out MemToken b)
        {
            var result = false;
            switch(src)
            {
                case xmm8:
                    a = VRegToken.xmm;
                    b = MemToken.m8;
                    result = true;
                break;
                case xmm16:
                    a = VRegToken.xmm;
                    b = MemToken.m16;
                    result = true;
                break;
                case xmm32:
                    a = VRegToken.xmm;
                    b = MemToken.m32;
                    result = true;
                break;
                case xmm64:
                    a = VRegToken.xmm;
                    b = MemToken.m64;
                    result = true;
                break;
                case xmm128:
                    a = VRegToken.xmm;
                    b = MemToken.m128;
                    result = true;
                break;
                case ymm256:
                    a = VRegToken.ymm;
                    b = MemToken.m256;
                    result = true;
                break;
                case zmm512:
                    a = VRegToken.zmm;
                    b = MemToken.m512;
                    result = true;
                break;
                default:
                    a = default;
                    b = default;
                break;
            }
            return result;
        }

        public static bool split(MmxRmToken src, out MmxRegToken a, out MemToken b)
        {
            var result = false;
            switch(src)
            {
                case MmxRmToken.mm32:
                    a = MmxRegToken.mm;
                    b = MemToken.m32;
                    result = true;
                break;
                case MmxRmToken.mm64:
                    a = MmxRegToken.mm;
                    b = MemToken.m64;
                    result = true;
                break;
                default:
                    a = default;
                    b = default;
                break;
            }
            return result;
        }

        public static bool split(KRmToken src, out MaskRegToken a, out MemToken b)
        {
            var result = false;
            switch(src)
            {
                case km8:
                    a = MaskRegToken.k1;
                    b = MemToken.m8;
                    result = true;
                    break;
                case km16:
                    a = MaskRegToken.k1;
                    b = MemToken.m16;
                    result = true;
                    break;
                case km32:
                    a = MaskRegToken.k1;
                    b = MemToken.m32;
                    result = true;
                    break;
                case km64:
                    a = MaskRegToken.k1;
                    b = MemToken.m64;
                    result = true;
                break;
                default:
                    a = default;
                    b = default;
                    break;
            }
            return result;
        }

        public static bool split(BCastComposite src, out VRegToken a, out MemToken b, out BCastMem c)
        {
            var result = false;

            switch(src)
            {
                case x128x32bcst:
                    a = VRegToken.xmm;
                    b = MemToken.m128;
                    c = BCastMem.m32bcst;
                    result = true;
                    break;
                case x128x64bcst:
                    a = VRegToken.xmm;
                    b = MemToken.m128;
                    c = BCastMem.m64bcst;
                    result = true;
                    break;
                case y256x32bcst:
                    a = VRegToken.ymm;
                    b = MemToken.m256;
                    c = BCastMem.m32bcst;
                    result = true;
                    break;
                case y256x64bcst:
                    a = VRegToken.ymm;
                    b = MemToken.m256;
                    c = BCastMem.m64bcst;
                    result = true;
                    break;
                case z512x32bcst:
                    a = VRegToken.zmm;
                    b = MemToken.m256;
                    c = BCastMem.m32bcst;
                    result = true;
                    break;
                case z512x64bcst:
                    a = VRegToken.zmm;
                    b = MemToken.m256;
                    c = BCastMem.m64bcst;
                    result = true;
                    break;
                default:
                    a = default;
                    b = default;
                    c = default;
                    break;
            }
            return result;
        }
    }
}