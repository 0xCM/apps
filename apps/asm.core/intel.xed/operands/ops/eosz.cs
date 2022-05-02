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
        public static ref readonly EOSZ eosz(in OperandState src)
            => ref @as<EOSZ>(src.EOSZ);

        partial struct Edit
        {
            [MethodImpl(Inline), Op]
            public static ref EOSZ eosz(ref OperandState src)
                => ref @as<EOSZ>(src.EOSZ);
        }
    }
}