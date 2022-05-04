//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedModels;

    partial class XedOperands
    {
        [MethodImpl(Inline), Op]
        public static ModIndicator mod(uint2 src)
            => new ModIndicator((ModKind)(byte)src + 1);
    }
}