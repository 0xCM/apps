//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{

    partial class sys
    {
        [MethodImpl(Options), Op]
        public static object value(object src, FieldInfo field)
            => field.GetValue(src);

        [MethodImpl(Options), Op, Closures(Closure)]
        public static T value<T>(object src, FieldInfo field)
            => (T)field.GetValue(src);
    }
}