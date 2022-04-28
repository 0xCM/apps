//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedRules;
    using static core;

    partial class XedState
    {
        [MethodImpl(Inline), Op]
        public static ref readonly MemoryScale scale(in OperandState src)
            => ref @as<MemoryScale>(src.SCALE);

        partial struct Edit
        {
            [MethodImpl(Inline), Op]
            public static ref MemoryScale scale(in OperandState src)
                => ref @as<MemoryScale>(src.SCALE);
        }
    }
}