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
        [Op]
        public static TableDef definition(Type src)
        {
            var fields = @readonly(src.DeclaredInstanceFields());
            var count = fields.Length;
            if(count == 0)
                return new TableDef(TableId.identify(src), src.Name, sys.empty<TableFieldDef>());

            var specs = alloc<TableFieldDef>(count);
            ref var spec = ref first(specs);
            for(ushort i=0; i<count; i++)
            {
                var field = skip(fields,i);
                seek(spec,i) = new TableFieldDef(i, name(field), field.FieldType.Spec());
            }

            return new TableDef(TableId.identify(src), src.Name, specs);
        }
    }
}