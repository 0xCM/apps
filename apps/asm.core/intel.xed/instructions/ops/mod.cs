//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedModels;

    partial class XedPatterns
    {
        [MethodImpl(Inline), Op]
        public static ModKind mod(uint2 src)
            => new ModKind((ModIndicator)(byte)src + 1);

        [MethodImpl(Inline), Op]
        public static ModKind modNeq3()
            =>new ModKind(ModIndicator.NE3);
    }
}