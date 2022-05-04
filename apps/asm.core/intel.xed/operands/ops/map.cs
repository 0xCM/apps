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
        public static ref readonly MAP map(in OperandState src)
            => ref @as<MAP>(src.MAP);

        partial struct Edit
        {
            public static ref MAP map(ref OperandState src)
                => ref @as<MAP>(src.MAP);
        }
    }
}