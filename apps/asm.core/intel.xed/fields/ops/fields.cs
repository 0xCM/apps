//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;
    using static XedRules;

    partial class XedFields
    {
        public static Fields fields()
            => new Fields(core.alloc<Field>(Fields.MaxCount));

        [MethodImpl(Inline), Op]
        public static Fields fields(Span<Field> buffer, Span<FieldKind> kinds)
            => new Fields(buffer, kinds);
    }
}