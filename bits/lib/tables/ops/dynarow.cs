//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct Tables
    {
        [Op, Closures(Closure)]
        public static DynamicRow<T> dynarow<T>(uint fields)
            where T : struct
                => new DynamicRow<T>(0, default(T), new dynamic[fields]);
    }
}