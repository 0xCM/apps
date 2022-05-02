//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedModels;
    using static XedRules;
    using static core;

    partial class XedOperands
    {
        [MethodImpl(Inline), Op]
        public static ref readonly RepPrefix rep(in OperandState src)
            => ref @as<RepPrefix>(src.REP);

        partial struct Edit
        {
            [MethodImpl(Inline), Op]
            public static ref RepPrefix rep(ref OperandState src)
                => ref @as<RepPrefix>(src.REP);
        }
    }
}