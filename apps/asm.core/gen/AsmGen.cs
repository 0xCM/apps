//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using Asm;
    using Asm.Operands;

    using static core;
    using static AsmSigTokens;
    using static AsmSigTokens.RegLiteralToken;


    using GpRT = AsmSigTokens.GpRegToken;
    using VRT = AsmSigTokens.VRegToken;
    using TK = AsmSigTokenKind;
    using MT = AsmSigTokens.MemToken;
    using ImmT = AsmSigTokens.ImmToken;

    public partial class AsmGen : AppService<AsmGen>
    {
        public static uint concretize(in AsmSigOp src, Span<AsmOperand> dst)
        {
            var kind = src.Kind;
            var count = 0u;
            switch(kind)
            {
                case TK.GpReg:
                    count = concretize((GpRegToken)src.Value, dst);
                    break;
                case TK.VReg:
                    count = concretize((VRegToken)src.Value, dst);
                    break;
                case TK.KReg:
                    count = concretize((KRegToken)src.Value, dst);
                    break;
                case TK.Imm:
                    count = concretize((ImmToken)src.Value, dst);
                    break;
                case TK.Mem:
                    count = concretize((MemToken)src.Value, dst);
                    break;
                case TK.RegLiteral:
                    count = concretize((RegLiteralToken)src.Value, dst);
                    break;
            }

            return count;
        }


        public static uint concretize(GpRegToken src, Span<AsmOperand> dst)
        {
            switch(src)
            {
                case GpRT.r8:
                break;
                case GpRT.r16:
                break;
                case GpRT.r32:
                break;
                case GpRT.r64:
                break;
            }

            return 0;
        }

        public static uint concretize(VRegToken src, Span<AsmOperand> dst)
        {
            switch(src)
            {
                case VRT.xmm:
                break;
                case VRT.ymm:
                break;
                case VRT.zmm:
                break;
            }
            return 0;
        }

        public static uint concretize(KRegToken src, Span<AsmOperand> dst)
        {

            return 0;
        }

        public static uint concretize(RegLiteralToken src, Span<AsmOperand> dst)
        {
            switch(src)
            {
                case AL:
                break;
                case AX:
                break;
                case DX:
                break;
                case EAX:
                break;
                case EDX:
                break;
                case RAX:
                break;
                case DS:
                break;
                case ES:
                break;
                case FS:
                break;
                case GS:
                break;
                case SS:
                break;
                case CS:
                break;
                case CL:
                break;
            }

            return 0;
        }

        public static uint concretize(ImmToken src, Span<AsmOperand> dst)
        {
            switch(src)
            {
                case ImmT.imm8:
                break;
                case ImmT.imm16:
                break;
                case ImmT.imm32:
                break;
                case ImmT.imm64:
                break;
            }

            return 0;
        }

        public static uint concretize(MemToken src, Span<AsmOperand> dst)
        {
            switch(src)
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

        public static uint concretize(MmxRegToken src, Span<AsmOperand> dst)
        {

            return 0;
        }

    }
}