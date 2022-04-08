//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;

    using static XedRules;
    using static core;

    partial class XedState
    {
        [MethodImpl(Inline), Op]
        public static ref readonly ModRm modrm(in RuleState src)
            => ref @as<Hex8,ModRm>(src.MODRM_BYTE);

        [MethodImpl(Inline), Op]
        public static ref RuleState modrm(byte src, ref RuleState dst)
        {
            if(src!=0)
                dst.HAS_MODRM = bit.On;
            return ref dst;
        }
    }
}