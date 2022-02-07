//-----------------------------------------------------------------------------
// Copyright   : Intel Corporation, 2020
// License     : Apache
// Source      : xed-iclass-enum.h
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Runtime.CompilerServices;

    using static Root;
    using static XedModels.RuleOpName;
    using static XedModels;

    using OK = XedModels.OpKind;
    using ROK = XedModels.RuleOpKind;

    [ApiHost]
    public readonly struct XedRuleOps
    {
        [Op]
        public static RuleOpName name(OK kind)
        {
            var name = RuleOpName.None;
            switch(kind)
            {
                case OK.REG0:
                    name = REG0;
                break;
                case OK.REG1:
                    name = REG1;
                break;
                case OK.REG2:
                    name = REG2;
                break;
                case OK.REG3:
                    name = REG3;
                break;
                case OK.REG4:
                    name = REG4;
                break;
                case OK.REG5:
                    name = REG5;
                break;
                case OK.REG6:
                    name = REG6;
                break;
                case OK.REG7:
                    name = REG7;
                break;
                case OK.REG8:
                    name = REG8;
                break;
                case OK.MEM0:
                    name = MEM0;
                break;
                case OK.MEM1:
                    name = MEM1;
                break;
                case OK.IMM0:
                    name = IMM0;
                break;
                case OK.IMM1:
                    name = IMM1;
                break;
                case OK.RELBR:
                    name = RELBR;
                break;
                case OK.BASE0:
                    name = BASE0;
                break;
                case OK.BASE1:
                    name = BASE1;
                break;
                case OK.SEG0:
                    name = SEG0;
                break;
                case OK.SEG1:
                    name = SEG1;
                break;
                case OK.AGEN:
                    name = AGEN;
                break;
                case OK.PTR:
                    name = PTR;
                break;
                case OK.INDEX:
                    name = INDEX;
                break;
                case OK.SCALE:
                    name = SCALE;
                break;
                case OK.DISP:
                    name = DISP;
                break;
            }
            return name;
        }

        [Op]
        public static RuleOpKind kind(RuleOpName src)
        {
            var dst = RuleOpKind.None;
            switch(src)
            {
                case REG0:
                case REG1:
                case REG2:
                case REG3:
                case REG4:
                case REG5:
                case REG6:
                case REG7:
                case REG8:
                case REG9:
                    dst = ROK.Reg;
                break;
                case MEM0:
                case MEM1:
                    dst = ROK.Mem;
                break;
                case IMM0:
                case IMM1:
                case IMM2:
                    dst = ROK.Imm;
                break;
                case RELBR:
                    dst = ROK.RelBr;
                break;
                case SEG0:
                case SEG1:
                    dst = ROK.Seg;
                break;
                case AGEN:
                    dst = ROK.Agen;
                break;
                case PTR:
                    dst = ROK.Ptr;
                break;
                case INDEX:
                    dst = ROK.Index;
                break;
                case SCALE:
                    dst = ROK.Scale;
                break;
                case DISP:
                    dst = ROK.Disp;
                break;
            }
            return dst;
        }

        [MethodImpl(Inline), Op]
        public static bool IsBaseReg(RuleOpName src)
            => src >= RuleOpName.BASE0 && src <= RuleOpName.BASE1;

        [MethodImpl(Inline), Op]
        public static bool IsSegReg(RuleOpName src)
            => src >= RuleOpName.SEG0 && src <= RuleOpName.SEG1;

        [MethodImpl(Inline), Op]
        public static bool IsIndexReg(RuleOpName src)
            => src == RuleOpName.INDEX;

        [MethodImpl(Inline), Op]
        public static bool IsScale(RuleOpName src)
            => src == RuleOpName.SCALE;

        [MethodImpl(Inline), Op]
        public static bool IsPointer(RuleOpName src)
            => src == RuleOpName.PTR;

        [MethodImpl(Inline), Op]
        public static bool IsCommonReg(RuleOpName src)
            => src >= RuleOpName.REG0 && src <= RuleOpName.REG8;

        [MethodImpl(Inline), Op]
        public static bool IsRegOp(RuleOpName src)
            => IsCommonReg(src) || IsBaseReg(src) || IsSegReg(src);

        [MethodImpl(Inline), Op]
        public static bool IsRelBranch(RuleOpName src)
            => src == RuleOpName.RELBR;

        [MethodImpl(Inline), Op]
        public static bool IsMemOp(RuleOpName src)
            => (src >= RuleOpName.MEM0 && src <= RuleOpName.MEM1) || IsRelBranch(src);

        [MethodImpl(Inline), Op]
        public static bool IsImmOp(RuleOpName src)
            => src >= RuleOpName.IMM0 && src <= RuleOpName.IMM2;

        [MethodImpl(Inline), Op]
        public static bool IsMemReg(RuleOpName kind)
            => IsBaseReg(kind) || IsSegReg(kind) || IsIndexReg(kind);

        [Op]
        public static sbyte CommonRegIndex(RuleOpName kind)
            => kind switch
            {
                REG0 => 0,
                REG1 => 1,
                REG2 => 2,
                REG3 => 3,
                REG4 => 4,
                REG5 => 5,
                REG6 => 6,
                REG7 => 7,
                REG8 => 8,
                _ => -1,
            };

        [Op]
        public static sbyte BaseRegIndex(RuleOpName kind)
            => kind switch
            {
                BASE0 => 0,
                BASE1 => 1,
                _ => -1,
            };

        [Op]
        public static sbyte SegRegIndex(RuleOpName kind)
            => kind switch
            {
                SEG0 => 0,
                SEG1 => 1,
                _ => -1,
            };

        [Op]
        public static sbyte ImmIndex(RuleOpName kind)
            => kind switch
            {
                IMM0 => 0,
                IMM1 => 1,
                _ => -1,
            };

        [Op]
        public static sbyte MemIndex(RuleOpName kind)
            => kind switch
            {
                MEM0 => 0,
                MEM1 => 1,
                _ => -1,
            };
    }
}