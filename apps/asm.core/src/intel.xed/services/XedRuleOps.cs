//-----------------------------------------------------------------------------
// Copyright   : Intel Corporation, 2020
// License     : Apache
// Source      : xed-iclass-enum.h
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Runtime.CompilerServices;

    using static Root;
    using static XedModels.RuleOpKind;
    using static XedModels;

    [ApiHost]
    public readonly struct XedRuleOps
    {
        [MethodImpl(Inline), Op]
        public static bool IsBaseReg(RuleOpKind src)
            => src >= RuleOpKind.BASE0 && src <= RuleOpKind.BASE1;

        [MethodImpl(Inline), Op]
        public static bool IsSegReg(RuleOpKind src)
            => src >= RuleOpKind.SEG0 && src <= RuleOpKind.SEG1;

        [MethodImpl(Inline), Op]
        public static bool IsIndexReg(RuleOpKind src)
            => src == RuleOpKind.INDEX;

        [MethodImpl(Inline), Op]
        public static bool IsScale(RuleOpKind src)
            => src == RuleOpKind.SCALE;

        [MethodImpl(Inline), Op]
        public static bool IsPointer(RuleOpKind src)
            => src == RuleOpKind.PTR;

        [MethodImpl(Inline), Op]
        public static bool IsCommonReg(RuleOpKind src)
            => src >= RuleOpKind.REG0 && src <= RuleOpKind.REG8;

        [MethodImpl(Inline), Op]
        public static bool IsRegOp(RuleOpKind src)
            => IsCommonReg(src) || IsBaseReg(src) || IsSegReg(src);

        [MethodImpl(Inline), Op]
        public static bool IsRelBranch(RuleOpKind src)
            => src == RuleOpKind.RELBR;

        [MethodImpl(Inline), Op]
        public static bool IsMemOp(RuleOpKind src)
            => (src >= RuleOpKind.MEM0 && src <= RuleOpKind.MEM1) || IsRelBranch(src);

        [MethodImpl(Inline), Op]
        public static bool IsImmOp(RuleOpKind src)
            => src >= RuleOpKind.IMM0 && src <= RuleOpKind.IMM2;

        [MethodImpl(Inline), Op]
        public static bool IsMemReg(RuleOpKind kind)
            => IsBaseReg(kind) || IsSegReg(kind) || IsIndexReg(kind);

        [Op]
        public static sbyte CommonRegIndex(RuleOpKind kind)
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
        public static sbyte BaseRegIndex(RuleOpKind kind)
            => kind switch
            {
                BASE0 => 0,
                BASE1 => 1,
                _ => -1,
            };

        [Op]
        public static sbyte SegRegIndex(RuleOpKind kind)
            => kind switch
            {
                SEG0 => 0,
                SEG1 => 1,
                _ => -1,
            };

        [Op]
        public static sbyte ImmIndex(RuleOpKind kind)
            => kind switch
            {
                IMM0 => 0,
                IMM1 => 1,
                _ => -1,
            };

        [Op]
        public static sbyte MemIndex(RuleOpKind kind)
            => kind switch
            {
                MEM0 => 0,
                MEM1 => 1,
                _ => -1,
            };

    }
}