//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    using System;
    using System.Collections.Concurrent;

    using static core;

    partial class LlvmDataProvider
    {
        public Index<ClassRelations> SelectClassRelations()
        {
            return (Index<ClassRelations>)DataSets.GetOrAdd(nameof(ClassRelations), key => Load());

            Index<ClassRelations> Load()
            {
                var running = Wf.Running(nameof(SelectClassRelations));
                var src = LlvmPaths.Table<ClassRelations>();
                var dst = list<ClassRelations>();
                var rows = src.ReadLines();
                var count = rows.Length;
                var result = Outcome.Success;
                for(var i=1; i<count; i++)
                {
                    var record = new ClassRelations();
                    ref readonly var row = ref rows[i];
                    var cells = @readonly(row.Split(Chars.Pipe).Select(x => x.Trim()));
                    if(cells.Length != llvm.ClassRelations.FieldCount)
                    {
                        Wf.Error(Tables.FieldCountMismatch.Format(llvm.ClassRelations.FieldCount, cells.Length));
                        Wf.Babble(row);
                        break;
                    }
                    var j=0;
                    result = DataParser.parse(skip(cells,j++), out record.SourceLine);
                    if(result.Fail)
                    {
                        Wf.Error(result.Message);
                        break;
                    }
                    result = DataParser.parse(skip(cells,j++), out record.Name);
                    if(result.Fail)
                    {
                        Wf.Error(result.Message);
                        break;
                    }
                    record.Ancestors = Lineage.parse(skip(cells, j++));
                    record.Parameters = skip(cells,j++);
                    dst.Add(record);
                }

                Wf.Ran(running);
                return dst.ToArray();
            }
        }
    }
}