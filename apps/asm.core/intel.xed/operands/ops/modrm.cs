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

    partial class XedOperands
    {
        [MethodImpl(Inline), Op]
        public static ref readonly ModRm modrm(in OperandState src)
            => ref @as<Hex8,ModRm>(src.MODRM_BYTE);

        partial struct Edit
        {
            [MethodImpl(Inline), Op]
            public static ref ModRm modrm(ref OperandState dst)
                => ref @as<Hex8,ModRm>(dst.MODRM_BYTE);
        }
    }
}