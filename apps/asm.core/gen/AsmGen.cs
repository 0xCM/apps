//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using static core;
    using static AsmSigTokens;
    using static AsmSigTokens.RegLiteralToken;

    using GpRT = AsmSigTokens.GpRegToken;
    using VRT = AsmSigTokens.VRegToken;
    using TK = AsmSigTokenKind;
    using MT = AsmSigTokens.MemToken;
    using ImmT = AsmSigTokens.ImmToken;

    public class AsmGenContext
    {

    }

    public class AsmGen
    {
        public static AsmGen generator()
            => new AsmGen(new AsmGenContext());

        AsmRegSets RegSets;

        AsmGenContext Context;

        AsmGen(AsmGenContext context)
        {
            RegSets = AsmRegSets.create();
            Context = context;
        }

        public void Concretize(Identifier name, in AsmForm form)
        {

        }

        public uint Concretize(in AsmSigOp src, ref uint i, Span<AsmOperand> dst)
        {
            var i0 = i;
            var kind = src.Kind;
            switch(kind)
            {
                case TK.GpReg:
                    GpRegs(src, ref i, dst);
                    break;
                case TK.VReg:
                    VRegs(src, ref i, dst);
                    break;
                case TK.MmxReg:
                    MmxRegs(src, ref i, dst);
                    break;
                case TK.KReg:
                    KRegs(src, ref i, dst);
                    break;
                case TK.Imm:
                    ImmValues(src, ref i, dst);
                    break;
                case TK.Mem:
                    MemValues(src, ref i, dst);
                    break;
                case TK.RegLiteral:
                    RegLiterals(src, ref i, dst);
                    break;
            }

            return i-i0;
        }

        uint GpRegs(AsmSigOp src, ref uint i, Span<AsmOperand> dst)
        {
            var i0 = i;
            var set = Regs((GpRegToken)src.Value);
            convert(set, ref i, dst);
            return i-i0;
        }

        uint KRegs(AsmSigOp src, ref uint i, Span<AsmOperand> dst)
        {
            var i0 = i;
            var regs = RegSets.KRegs();
            if(src.IsMasked)
                Apply(MaskKind(src.Modifier), regs, ref i, dst);
            else
                convert(regs, ref i, dst);
            return i-i0;
        }

        uint VRegs(AsmSigOp src, ref uint i, Span<AsmOperand> dst)
        {
            var i0 = i;
            var token = (VRegToken)src.Value;
            var regs = Regs(token);
            if(src.IsMasked)
                Apply(MaskKind(src.Modifier), regs, ref i, dst);
            else
                convert(regs, ref i, dst);
            return i-i0;
        }

        uint RegLiterals(AsmSigOp src, ref uint i, Span<AsmOperand> dst)
        {
            var i0 = i;
            var token = (RegLiteralToken)src.Value;
            switch(token)
            {
                case AL:
                    seek(dst, i++) = AsmRegOps.al;
                break;
                case CL:
                    seek(dst, i++) = AsmRegOps.cl;
                break;
                case AX:
                    seek(dst, i++) = AsmRegOps.ax;
                break;
                case DX:
                    seek(dst, i++) = AsmRegOps.dx;
                break;
                case EAX:
                    seek(dst, i++) = AsmRegOps.eax;
                break;
                case EDX:
                    seek(dst, i++) = AsmRegOps.edx;
                break;
                case RAX:
                    seek(dst, i++) = AsmRegOps.rax;
                break;
                case CS:
                    seek(dst, i++) = AsmRegOps.cs;
                break;
                case DS:
                    seek(dst, i++) = AsmRegOps.ds;
                break;
                case SS:
                    seek(dst, i++) = AsmRegOps.ss;
                break;
                case ES:
                    seek(dst, i++) = AsmRegOps.es;
                break;
                case FS:
                    seek(dst, i++) = AsmRegOps.fs;
                break;
                case GS:
                    seek(dst, i++) = AsmRegOps.gs;
                break;
            }

            return i-i0;
        }

        uint ImmValues(AsmSigOp src, ref uint i, Span<AsmOperand> dst)
        {
            var i0 = i;
            switch((ImmToken)src.Value)
            {
                case ImmT.imm8:
                    for(var j=0; j<byte.MaxValue; j++)
                        seek(dst,i++) = asm.imm8((byte)j);
                break;
                case ImmT.imm16:
                break;
                case ImmT.imm32:
                break;
                case ImmT.imm64:
                break;
            }

            return i-i0;
        }

        uint MemValues(AsmSigOp src, ref uint i, Span<AsmOperand> dst)
        {
            var i0 = i;
            switch((MemToken)src.Value)
            {
                case MT.m8:
                break;
                case MT.m16:
                break;
                case MT.m32:
                break;
                case MT.m64:
                break;
                case MT.m128:
                break;
                case MT.m256:
                break;
                case MT.m512:
                break;
            }

            return 0;
        }

        uint MmxRegs(AsmSigOp src, ref uint i,Span<AsmOperand> dst)
        {
            var i0 = i;
            var sets = AsmRegSets.create();
            var set = sets.MmxRegs();
            convert(set, ref i, dst);
            return i-i0;
        }

        RegOpSeq Regs(GpRegToken src)
        {
            var set = RegOpSeq.Empty;
            switch(src)
            {
                case GpRT.r8:
                    set = RegSets.Gp8Regs();
                break;
                case GpRT.r16:
                    set = RegSets.Gp16Regs();
                break;
                case GpRT.r32:
                    set = RegSets.Gp32Regs();
                break;
                case GpRT.r64:
                    set = RegSets.Gp64Regs();
                break;
            }
            return set;
        }

        RegOpSeq Regs(VRegToken src)
        {
            var set = RegOpSeq.Empty;
            switch(src)
            {
                case VRT.xmm:
                    set = RegSets.XmmRegs();
                break;
                case VRT.ymm:
                    set = RegSets.YmmRegs();
                break;
                case VRT.zmm:
                    set = RegSets.ZmmRegs();
                break;
            }
            return set;
        }

        void Apply(RegMaskKind mask, RegOpSeq regs, ref uint i, Span<AsmOperand> dst)
        {
            var kregs = RegSets.KRegs();
            for(var j=0; j<regs.Count; j++)
            {
                ref readonly var target = ref regs[j];
                for(var k=0; k<kregs.Count; k++)
                    seek(dst,i++) = asm.regmask(target, kregs[k].Index, mask);
            }
        }

        static RegMaskKind MaskKind(AsmModifierKind src)
        {
            var dst = RegMaskKind.None;
            switch(src)
            {
                case AsmModifierKind.k1:
                    dst = RegMaskKind.k1;
                break;
                case AsmModifierKind.k1z:
                    dst = RegMaskKind.k1z;
                break;
                case AsmModifierKind.z:
                    dst = RegMaskKind.z;
                break;
                case AsmModifierKind.k2:
                    dst = RegMaskKind.k2;
                break;
            }
            return dst;
        }

        static void convert(RegOpSeq src, ref uint i, Span<AsmOperand> dst)
        {
            var count = src.Count;
            for(var j=0; j<count; j++)
                seek(dst,i++) = src[j];
        }
    }
}