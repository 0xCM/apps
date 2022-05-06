//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static ArrayUtil;

    partial class XArray
    {
        [MethodImpl(Inline)]
        public static T Single<T>(this T[] src)
            => single(src);
    }
}