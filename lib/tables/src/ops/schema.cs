//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    using static core;

    partial struct Tables
    {
        [Op]
        public static TableSchema schema(Type src)
        {
            var fields = @readonly(src.DeclaredInstanceFields());
            var count = fields.Length;
            if(count == 0)
                return TableSchema.Empty;
            var specs = alloc<RecordFieldSpec>(count);
            ref var spec = ref first(specs);
            for(ushort i=0; i<count; i++)
            {
                ref readonly var field = ref skip(fields,i);
                seek(spec,i) = new RecordFieldSpec(i, field.Name, field.FieldType.Name);
            }
            return new TableSchema(TableId.identify(src), specs);
        }
    }
}