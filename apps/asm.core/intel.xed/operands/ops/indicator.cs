//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;
    using static XedModels;

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

        [MethodImpl(Inline), Op]
        static OpIndicator i(string src)
            => new OpIndicator(src);

        static Index<OpNameKind,OpIndicator> _Indicators = new OpIndicator[]{
            i(""),
            i("r0"),
            i("r1"),
            i("r2"),
            i("r3"),
            i("r4"),
            i("r5"),
            i("r6"),
            i("r7"),
            i("r8"),
            i("r9"),
            i("m0"),
            i("m1"),
            i("imm0"),
            i("imm1"),
            i("imm2"),
            i("relbr"),
            i("base0"),
            i("base1"),
            i("seg0"),
            i("seg1"),
            i("agen"),
            i("ptr"),
            i("index"),
            i("scale"),
            i("disp"),
        };

        [MethodImpl(Inline), Op]
        public static OpIndicator indicator(OpNameKind src)
            => _Indicators[src];
    }
}