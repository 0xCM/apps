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

    partial class XedState
    {
        [MethodImpl(Inline), Op]
        public static ref readonly BCastKind bcast(in OperandState src)
            => ref @as<BCastKind>(src.BCAST);


        partial struct Edit
        {
            [MethodImpl(Inline), Op]
            public static ref BCastKind bcast(ref OperandState src)
                => ref @as<BCastKind>(src.BCAST);
        }
    }
}