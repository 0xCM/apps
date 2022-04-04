//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedRules
    {
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static FieldAssign assign<T>(FieldKind field, T fv)
            where T : unmanaged
                => new (new FieldValue(field, core.bw64(fv)));
    }
}