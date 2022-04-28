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
        public static Sib sib(in OperandState src)
            => new Sib(src.SIBBASE, src.SIBINDEX, src.SIBSCALE);

        partial struct Edit
        {
            public static ref readonly Sib sib(in Sib src, ref OperandState dst)
            {
                dst.HAS_SIB = bit.On;
                dst.SIBSCALE = src.Scale;
                dst.SIBINDEX = src.Index;
                dst.SIBBASE = src.Base;
                return ref src;
            }
        }
    }
}