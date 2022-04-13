//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;

    using static XedRules;

    partial class XedState
    {
        [MethodImpl(Inline), Op]
        public static RexPrefix rex(in RuleState src)
            => new RexPrefix(src.REXB, src.REXX, src.REXR, src.REXW);

        partial struct Edit
        {
            [MethodImpl(Inline), Op]
            public static ref readonly RexPrefix rex(in RexPrefix src, ref RuleState dst)
            {
                dst.REX = bit.On;
                dst.REXW = src.W;
                dst.REXR = src.R;
                dst.REXX = src.X;
                dst.REXB = src.B;
                return ref src;
            }
        }
    }
}