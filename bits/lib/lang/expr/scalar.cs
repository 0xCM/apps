//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct expr
    {
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ScalarValue<T> scalar<T>(T src, BitWidth content = default)
            where T : unmanaged, IEquatable<T>
                => new ScalarValue<T>(src,content);
    }
}