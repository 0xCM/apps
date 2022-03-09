//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial class XedRules
    {
        public class FieldRender : IFieldFormatter
        {
            public static FieldRender create()
                => new FieldRender();

            FieldFormatters Formatters;

            FieldRender()
            {
                Formatters = new();
            }

            public string Format(FieldValue src)
                => Formatters[src.Kind](src);

            public FieldFormatter this[FieldKind kind]
            {
                get => Formatters[kind];
                set => Formatters[kind] = value;
            }

            public void Render(FieldValue src, ITextBuffer dst)
                => dst.Append(Format(src));
        }
    }
}