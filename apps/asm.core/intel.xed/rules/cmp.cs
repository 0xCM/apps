//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedRules
    {
        [MethodImpl(Inline), Op]
        public static int cmp(RuleTableKind a, RuleTableKind b)
            => ((byte)b).CompareTo((byte)a);

        [MethodImpl(Inline), Op]
        public static int cmp(FieldKind a, FieldKind b)
            => ((byte)a).CompareTo((byte)b);
    }
}