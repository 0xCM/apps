//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;

    using static XedRules;

    partial class XedFields
    {
        [MethodImpl(Inline), Op]
        public static ModRm modrm(in RuleState src)
            => new (src.MODRM_BYTE);
    }
}