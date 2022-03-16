//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedRules;
    using static core;

    using R = XedRules;

    partial class XedFields
    {
        [MethodImpl(Inline)]
        public static R.FieldValue<T> value<T>(FieldKind kind, T value)
            where T : unmanaged
                => new R.FieldValue<T>(kind, value);

        [MethodImpl(Inline)]
        public static R.FieldValue value(FieldKind kind, NameResolver resolver)
            => new R.FieldValue(kind, (ulong)resolver);

        public ConstLookup<FieldKind,object> values<T>(in T src)
            where T : unmanaged
        {
            var dst = dict<FieldKind,object>();
            var kinds = new ReflectedFields();
            var fields = kinds.RightValues;
            foreach(var f in fields)
                dst.Add(kinds[f], f.GetValue(src));
            return dst;
        }
    }
}