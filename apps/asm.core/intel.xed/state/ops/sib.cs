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
        public static Sib sib(in RuleState src)
            => new Sib(src.SIBBASE, src.SIBINDEX, src.SIBSCALE);

        [MethodImpl(Inline), Op]
        public static bool sib(in RuleState src, out Sib dst)
        {
            if(src.HAS_SIB)
            {
                dst = Sib.init();
                dst.Base = src.SIBBASE;
                dst.Index = src.SIBINDEX;
                dst.Scale = src.SIBSCALE;
                return true;
            }
            else
            {
                dst = Sib.Empty;
                return false;
            }
        }

        [MethodImpl(Inline), Op]
        public static ref RuleState set(Sib src, ref RuleState dst)
        {
            dst.HAS_SIB = bit.On;
            dst.SIBBASE = src.Base;
            dst.SIBINDEX = src.Index;
            dst.SIBSCALE = src.Scale;
            return ref dst;
        }

        [MethodImpl(Inline), Op]
        public static ref RuleState sib(byte src, ref RuleState dst)
            => ref set((Sib)src, ref dst);
    }
}