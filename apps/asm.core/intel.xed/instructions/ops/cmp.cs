//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedModels;

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
    }
}