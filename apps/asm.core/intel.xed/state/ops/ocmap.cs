//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedRules;

    partial class XedState
    {
        [MethodImpl(Inline), Op]
        public static ref readonly byte ocmap(in RuleState src)
            => ref src.MAP;

        partial struct Edit
        {
            [MethodImpl(Inline), Op]
            public static ref byte ocmap(ref RuleState src)
                => ref src.MAP;
        }
    }
}