//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct Numeric
    {
        [MethodImpl(Inline), Op, Closures(AllNumeric)]
        public static string indicator<T>()
            where T : unmanaged
                => NumericIndicators.indicator<T>();
    }
}