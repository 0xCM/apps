//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;
    using static XedRules;
    using static XedModels;

    partial class XedPatterns
    {
        [MethodImpl(Inline), Op]
        public static InstField part(Seg src)
            => new(src);

        [MethodImpl(Inline), Op]
        public static InstField part(Nonterminal src)
            => new(src);

        [MethodImpl(Inline), Op]
        public static InstField part(CellExpr src)
            => new(src);

        [MethodImpl(Inline), Op]
        public static InstField part(Hex8 src)
            => new(src);

        public static InstField part(uint5 src)
            => new(src);
    }
}