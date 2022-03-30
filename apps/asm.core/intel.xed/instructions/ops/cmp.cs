//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedModels;
    using static XedModels.OpCodeKind;

    partial class XedPatterns
    {
        [MethodImpl(Inline)]
        public static int cmp(ModeKind a, ModeKind b)
        {
            return order(a).CompareTo(order(b));

            static int order(ModeKind src)
                => src switch
                {   ModeKind.Mode16 => 0,
                    ModeKind.Mode32 => 1,
                    ModeKind.Not64 => 2,
                    ModeKind.Default => 3,
                    ModeKind.Mode64 => 4,
                    _ => 0,
                };
        }

        public static int cmp(OpCodeKind a, OpCodeKind b)
        {
            return order(a).CompareTo(order(b));

            static int order(OpCodeKind src)
                => src switch
                {   Base00 => 0,
                    Base0F => 1,
                    Base0F38 => 2,
                    Base0F3A => 3,
                    Amd3DNow => 4,
                    Vex0F => 5,
                    Vex0F38 => 6,
                    Vex0F3A => 7,
                    Evex0F => 8,
                    Evex0F38 => 9,
                    Evex0F3A => 10,
                    Xop8 => 11,
                    Xop9 => 12,
                    XopA => 13,
                    _ => 0,
                };

        }
    }
}