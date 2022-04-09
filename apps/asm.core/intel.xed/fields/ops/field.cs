//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedModels;

    partial class XedRules
    {
        [MethodImpl(Inline), Op]
        public static Field field(FieldKind kind, ushort value)
            => Field.init(kind,value);

        [MethodImpl(Inline), Op]
        public static Field field(FieldKind kind, Register value)
            => Field.init(kind,value);
    }
}