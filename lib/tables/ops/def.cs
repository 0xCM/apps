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
        public static TableDef def(Type src)
        {
            var fields = @readonly(src.DeclaredInstanceFields());
            var count = fields.Length;
            if(count == 0)
                return new TableDef(TableId.identify(src), src.Name, sys.empty<TableFieldDef>());
            var specs = alloc<TableFieldDef>(count);
            for(var i=z16; i<count; i++)
            {
                var field = skip(fields,i);
                seek(specs,i) = new TableFieldDef(i, name(field), field.FieldType.CodeName());
            }

            return new TableDef(TableId.identify(src), src.Name, specs);
        }

        public static TableDef def<T>()
            where T : struct
                => def(typeof(T));
    }
}