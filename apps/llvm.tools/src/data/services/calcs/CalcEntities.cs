//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    using System;

    using static core;
    using static Root;

    partial class LlvmDataCalcs
    {
        public Index<LlvmEntity> CalcEntities(ReadOnlySpan<DefRelations> rel, ReadOnlySpan<RecordField> fields)
        {
            var relations = rel.Map(x => (x.Name.Content, x)).ToDictionary();
            var entites = list<LlvmEntity>();
            var current = EmptyString;
            var buffer = list<RecordField>();
            var count = fields.Length;
            var relation = DefRelations.Empty;
            for(var i=0; i<count; i++)
            {
                ref readonly var field = ref skip(fields,i);
                if(field.RecordName != current)
                {
                    if(buffer.Count != 0)
                    {
                        entites.Add(new LlvmEntity(relation, buffer.ToArray()));
                        buffer.Clear();
                    }
                    current = field.RecordName;
                    relations.TryGetValue(current, out relation);
                    buffer.Add(field);
                }
                else
                    buffer.Add(field);
            }

            return entites.ToArray();
        }
    }
}