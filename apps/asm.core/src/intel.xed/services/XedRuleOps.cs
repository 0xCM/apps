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

    using K = XedModels.OperandKind;

    [ApiHost]
    public readonly struct XedRuleOps
    {
        public static RuleOpName name(K kind)
        {
            var name = RuleOpName.None;
            switch(kind)
            {
                case K.REG0:
                    name = REG0;
                break;
                case K.REG1:
                    name = REG1;
                break;
                case K.REG2:
                    name = REG2;
                break;
                case K.REG3:
                    name = REG3;
                break;
                case K.REG4:
                    name = REG4;
                break;
                case K.REG5:
                    name = REG5;
                break;
                case K.REG6:
                    name = REG6;
                break;
                case K.REG7:
                    name = REG7;
                break;
                case K.REG8:
                    name = REG8;
                break;
                case K.MEM0:
                    name = MEM0;
                break;
                case K.MEM1:
                    name = MEM1;
                break;
                case K.IMM0:
                    name = IMM0;
                break;
                case K.IMM1:
                    name = IMM1;
                break;
                case K.RELBR:
                    name = RELBR;
                break;
                case K.BASE0:
                    name = BASE0;
                break;
                case K.BASE1:
                    name = BASE1;
                break;
                case K.SEG0:
                    name = SEG0;
                break;
                case K.SEG1:
                    name = SEG1;
                break;
                case K.AGEN:
                    name = AGEN;
                break;
                case K.PTR:
                    name = PTR;
                break;
                case K.INDEX:
                    name = INDEX;
                break;
                case K.SCALE:
                    name = SCALE;
                break;
            }
            return name;
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