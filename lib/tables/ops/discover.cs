//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Reflection;

    using static core;

    partial struct Tables
    {
        [Op, Closures(Closure)]
        static DataList<T> datalist<T>(uint? capacity = null)
            => DataList.create<T>(capacity);

        [Op]
        public static ReadOnlySpan<ReflectedTable> discover(ReadOnlySpan<Assembly> src)
        {
            var count = src.Length;
            var dst = datalist<ReflectedTable>();
            for(var i=0; i<count; i++)
                discover(skip(src,i), dst);
            return dst.View();
        }

        [Op]
        public static ReadOnlySpan<ReflectedTable> discover(Assembly src)
        {
            var types = @readonly(src.Types().Tagged<RecordAttribute>());
            var count = types.Length;
            var dst = datalist<ReflectedTable>();
            discover(src, dst);
            return dst.View();
        }

        [Op]
        static uint discover(Assembly src, DataList<ReflectedTable> dst)
        {
            var types = @readonly(src.Types().Tagged<RecordAttribute>());
            var count = types.Length;
            var counter = 0u;
            for(var i=0; i<count; i++)
            {
                dst.Add(reflected(skip(types,i)));
                counter++;
            }

            return counter;
        }
    }
}