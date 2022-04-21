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
        public static ref readonly HintKind hint(in OperandState src)
            => ref @as<HintKind>(src.HINT);

        partial struct Edit
        {
            [MethodImpl(Inline), Op]
            public static ref HintKind hint(ref OperandState src)
                => ref @as<HintKind>(src.HINT);
        }
    }
}