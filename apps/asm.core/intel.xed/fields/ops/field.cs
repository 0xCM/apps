//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedModels;
    using static XedRules;

    partial class XedFields
    {
        [MethodImpl(Inline), Op]
        public static Field field<T>(FieldKind kind, T value)
            where T : unmanaged
                => Field.init(kind, core.bw16(value));

        [MethodImpl(Inline), Op]
        public static Field field(FieldKind kind, Register value)
            => Field.init(kind, value);
    }
}