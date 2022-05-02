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
        public static ref readonly InstClass iclass(in OperandState src)
            => ref @as<IClass,InstClass>(src.ICLASS);

        partial struct Edit
        {
            [MethodImpl(Inline), Op]
            public static ref InstClass iclass(ref OperandState src)
                => ref @as<IClass,InstClass>(src.ICLASS);
        }
    }
}