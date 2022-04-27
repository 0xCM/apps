//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct Tables
    {
        [Op, Closures(Closure)]
        public static DynamicRow<T> dynarow<T>(ClrRecordFields fields)
            where T : struct
                => new DynamicRow<T>(fields, new dynamic[fields.Length]);

        [Op, Closures(Closure)]
        public static DynamicRow dynarow(ClrRecordFields fields)
            => new DynamicRow(fields, new dynamic[fields.Length]);
    }
}