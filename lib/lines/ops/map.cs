//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct Lines
    {
        [MethodImpl(Inline)]
        public static LineMap<T> map<T>(LineInterval<T>[] src)
            => src;
    }
}