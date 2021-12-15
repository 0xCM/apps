//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    using System;

    using static core;

    partial class LlvmDataEmitter
    {
        public Index<LlvmList> EmitLists()
        {
            return EmitLists(DataProvider.SelectEntities());
        }

        public Index<LlvmList> EmitLists(Index<LlvmEntity> entities)
        {
            FS.Files paths = LlvmPaths.ListNames().Map(x => LlvmPaths.ListImportPath(x));
            paths.Delete();
            return EmitLists(entities, DataProvider.SelectConfiguredListNames());
        }

        public Index<LlvmList> EmitLists(Index<LlvmEntity> src, ReadOnlySpan<string> classes)
        {
            var emitted = bag<LlvmList>();
            iter(classes, c => emitted.Add(EmitList(src,c)), true);
            return emitted.ToArray();
        }

        public Outcome EmitList(LlvmList src)
        {
            var dst = src.Path;
            return EmitList(src,dst);
        }

        public Outcome EmitList(LlvmList src, FS.FilePath dst)
        {
            var items = src.Items;
            var count = items.Length;
            var formatter = Tables.formatter<LlvmListItem>();
            var emitting = EmittingTable<LlvmListItem>(dst);
            using var writer = dst.AsciWriter();
            writer.WriteLine(formatter.FormatHeader());
            for(var i=0; i<count; i++)
                writer.WriteLine(formatter.Format(skip(items,i)));
            EmittedTable(emitting,count);
            return true;
        }

        public LlvmList EmitList(Index<LlvmEntity> src, string @class)
        {
            var dst = LlvmPaths.ListImportPath(@class);
            var emitting = EmittingTable<LlvmListItem>(dst);
            var formatter = Tables.formatter<LlvmListItem>();
            using var writer = dst.AsciWriter();
            writer.WriteLine(formatter.FormatHeader());
            var count = src.Length;
            var items = list<LlvmListItem>();
            var counter = 0u;
            for(var i=0; i<count; i++)
            {
                ref readonly var entity = ref src[i];
                ref readonly var def = ref entity.Def;
                var ancestors = def.AncestorNames;
                if(ancestors.Contains(@class))
                {
                    var item = new LlvmListItem(counter++, entity.EntityName);
                    items.Add(item);
                    writer.WriteLine(formatter.Format(item));
                }
            }

            EmittedTable(emitting, counter);
            return (dst,items.ToArray());
        }
    }
}