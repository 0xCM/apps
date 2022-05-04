//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedRules;
    using static XedModels;
    using static core;

    partial class XedOperands
    {
        [MethodImpl(Inline), Op]
        public static ref readonly bit mask(in OperandState src)
            => ref src.MASK;

        partial struct Edit
        {
            [MethodImpl(Inline), Op]
            public static ref bit mask(ref OperandState src)
                => ref src.MASK;
        }
    }
}