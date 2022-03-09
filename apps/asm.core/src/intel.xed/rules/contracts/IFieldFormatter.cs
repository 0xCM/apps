//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedRules
    {
        public interface IFieldFormatter
        {
            string Format(FieldValue src);
        }

        public interface IFieldFormatter<T> : IFieldFormatter
            where T : unmanaged
        {
            string Format(FieldValue<T> src);

            string IFieldFormatter.Format(FieldValue src)
                => Format(src);
        }
    }
}