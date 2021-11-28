//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    using System;

    using static core;

    partial class LlvmEtl
    {
        public Index<LlvmList> EmitLists(RecordEntitySet src, ReadOnlySpan<string> classes)
        {
            var emitted = bag<LlvmList>();
            iter(classes, c => emitted.Add(EmitList(src,c)), true);
            return emitted.ToArray();
        }

        public LlvmList EmitList(RecordEntitySet src, string @class)
        {
            var dst = LlvmPaths.Table(string.Format("llvm.lists.{0}", @class));
            var emitting = EmittingTable<LlvmListItem>(dst);
            var formatter = Tables.formatter<LlvmListItem>();
            using var writer = dst.AsciWriter();
            writer.WriteLine(formatter.FormatHeader());
            var members = src.Members;
            var count = members.Length;
            var items = list<LlvmListItem>();
            var counter = 0u;
            for(var i=0; i<count; i++)
            {
                ref readonly var entity = ref skip(members,i);
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