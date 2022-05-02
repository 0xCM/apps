//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;
    using static XedModels;

    using K = XedModels.OpNameKind;

    partial class XedOperands
    {
        [MethodImpl(Inline), Op]
        public static bit IsRegLit(OpType src)
            => src == OpType.REG;

        [MethodImpl(Inline), Op]
        public static bit IsImmLit(OpType src)
            => src == OpType.IMM;

        [MethodImpl(Inline), Op]
        public static bit IsRule(OpType src)
            => src == OpType.NT_LOOKUP_FN || src == OpType.NT_LOOKUP_FN2 || src == OpType.NT_LOOKUP_FN4;

        public static OpIndicator indicator(OpNameKind src)
        {
            var dst = OpIndicator.Empty;
            switch(src)
            {
                case K.None:
                    dst = new(EmptyString);
                break;
                case K.REG0:
                    dst = new("r0");
                break;
                case K.REG1:
                    dst = new("r1");
                break;
                case K.REG2:
                    dst = new("r2");
                break;
                case K.REG3:
                    dst = new("r3");
                break;
                case K.REG4:
                    dst = new("r4");
                break;
                case K.REG5:
                    dst = new("r5");
                break;
                case K.REG6:
                    dst = new("r6");
                break;
                case K.REG7:
                    dst = new("r7");
                break;
                case K.REG8:
                    dst = new("r8");
                break;
                case K.REG9:
                    dst = new("r9");
                break;
                case K.MEM0:
                    dst = new("m0");
                break;
                case K.MEM1:
                    dst = new("m1");
                break;
                case K.IMM0:
                    dst = new("imm0");
                break;
                case K.IMM1:
                    dst = new("imm1");
                break;
                case K.IMM2:
                    dst = new("imm2");
                break;
                case K.RELBR:
                    dst = new("relbr");
                break;
                case K.BASE0:
                    dst = new("base0");
                break;
                case K.BASE1:
                    dst = new("base1");
                break;
                case K.SEG0:
                    dst = new("seg0");
                break;
                case K.SEG1:
                    dst = new("seg1");
                break;
                case K.AGEN:
                    dst = new("agen");
                break;
                case K.PTR:
                    dst = new("ptr");
                break;
                case K.INDEX:
                    dst = new("index");
                break;
                case K.SCALE:
                    dst = new("scale");
                break;
                case K.DISP:
                    dst = new("disp");
                break;
                default:
                    Errors.Throw($"Unhandled case {src}");
                break;
            }

            return dst;
        }
    }
}