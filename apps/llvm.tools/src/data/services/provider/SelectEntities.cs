//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    using System;
    using static core;
    using static Root;

    partial class LlvmDataProvider
    {
        public Index<LlvmEntity> SelectEntities(Func<LlvmEntity,bool> predicate)
            => SelectEntities().Where(predicate);

        public Index<LlvmEntity> SelectEntities()
        {
            return (Index<LlvmEntity>)DataSets.GetOrAdd("Entities", key => Load());

            Index<LlvmEntity> Load()
            {
                var running = Wf.Running(nameof(SelectEntities));
                var relations = SelectDefRelations().Map(x => (x.Name.Content, x)).ToDictionary();
                var entites = list<LlvmEntity>();
                var current = EmptyString;
                var fields = list<RecordField>();
                var src = SelectDefFields().View;
                var count = src.Length;
                var relation = default(DefRelations);
                for(var i=0; i<count; i++)
                {
                    ref readonly var field = ref skip(src,i);
                    if(field.RecordName != current)
                    {
                        if(fields.Count != 0)
                        {
                            entites.Add(new LlvmEntity(relation, fields.ToArray()));
                            fields.Clear();
                        }
                        current = field.RecordName;
                        relations.TryGetValue(current, out relation);
                        fields.Add(field);
                    }
                    else
                        fields.Add(field);
                }

                Wf.Ran(running);

                return entites.ToArray();
            }
        }
    }
}