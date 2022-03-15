//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;
    using static XedModels;
    using static XedRender;

    partial class XedRules
    {
        public delegate string FieldFormatter(FieldValue src);

        public delegate string FieldFormatter<T>(FieldValue<T> src)
            where T : unmanaged;

        public sealed class FieldFormatters : Dictionary<FieldKind,FieldFormatter>
        {
            public FieldFormatters()
            {
                [MethodImpl(Inline)]
                static string format(FieldValue src)
                    => XedRender.format(src);

                iter(new ReflectedFields().LeftValues, k => this[k] = format);
            }
        }
    }
}