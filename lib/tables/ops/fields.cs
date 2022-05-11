//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial struct Tables
    {
        /// <summary>
        /// Discerns a <see cref='ClrRecordFields'/> for a parametrically-identified record type
        /// </summary>
        /// <typeparam name="T">The record type</typeparam>
        [Op, Closures(Closure)]
        public static ClrTableField[] fields<T>()
            where T : struct
                => fields(typeof(T));

        /// <summary>
        /// Discerns a <see cref='ClrRecordFields'/> for a specified record type
        /// </summary>
        /// <param name="src">The record type</typeparam>
        [Op]
        public static ClrTableField[] fields(Type src)
        {
            var fields = src.DeclaredPublicInstanceFields().Ignore().Index();
            var count = fields.Count;
            var dst = alloc<ClrTableField>(count);
            for(var i=z16; i<count; i++)
            {
                ref readonly var field = ref fields[i];
                var render = field.Tag<RenderAttribute>();
                if(render)
                {
                    var tag = render.Require();
                    seek(dst,i) = new ClrTableField(new RenderSpec(i, tag.Width, tag.Selector, text.Formatter(field.FieldType, tag.Selector)), field);
                }
                else
                    seek(dst, i) = new ClrTableField(i, field);

            }
            return dst;
        }
    }
}