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
        public static ModRm modrm(in RuleState src)
            => src.HAS_MODRM ? new (src.MODRM_BYTE) : ModRm.Empty;

        [MethodImpl(Inline), Op]
        public static ref RuleState set(ModRm src, ref RuleState dst)
        {
            dst.MODRM_BYTE = src;
            dst.HAS_MODRM = bit.On;
            return ref dst;
        }

        [MethodImpl(Inline), Op]
        public static ref RuleState modrm(byte src, ref RuleState dst)
            => ref set((ModRm)src, ref dst);
    }
}