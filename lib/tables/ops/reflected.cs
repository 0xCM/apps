//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial struct Tables
    {
        [Op]
        public static ReflectedTable reflected(Type src)
            => ReflectedTable.load(src);

        [Op]
        public static ReadOnlySpan<ReflectedTable> reflected(ReadOnlySpan<Assembly> src)
        {
            var count = src.Length;
            var dst = list<ReflectedTable>();
            for(var i=0; i<count; i++)
                discover(skip(src,i), dst);
            return dst.ViewDeposited();
        }

        [Op]
        public static ReadOnlySpan<ReflectedTable> reflected(Assembly src)
        {
            var types = @readonly(src.Types().Tagged<RecordAttribute>());
            var count = types.Length;
            var dst = list<ReflectedTable>();
            discover(src, dst);
            return dst.ViewDeposited();
        }

        [Op]
        static uint discover(Assembly src, List<ReflectedTable> dst)
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