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
        public static Index<ReflectedTable> reflected(ReadOnlySpan<Assembly> src)
        {
            var count = src.Length;
            var dst = list<ReflectedTable>();
            for(var i=0; i<count; i++)
                discover(skip(src,i), dst);
            return dst.ToArray();
        }

        [Op]
        public static Index<ReflectedTable> reflected(Assembly src)
        {
            var types = @readonly(src.Types().Tagged<RecordAttribute>());
            var count = types.Length;
            var dst = list<ReflectedTable>();
            discover(src, dst);
            return dst.ToArray();
        }

        [Op]
        static uint discover(Assembly src, List<ReflectedTable> dst)
        {
            var types = src.Types().Tagged<RecordAttribute>().Index();
            for(var i=0; i<types.Count; i++)
                dst.Add(reflected(types[i]));
            return types.Count;
        }
    }
}