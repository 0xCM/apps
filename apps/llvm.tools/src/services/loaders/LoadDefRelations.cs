//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    using System;

    using static core;

    partial class LlvmDataLoader
    {
        public Index<DefRelations> LoadDefRelations()
        {
            return (Index<DefRelations>)DataSets.GetOrAdd(nameof(DefRelations), key => Load());

            Index<DefRelations> Load()
            {
                var running = Wf.Running(nameof(LoadDefRelations));
                var src = LlvmPaths.Table<DefRelations>();
                var dst = list<DefRelations>();
                var rows = src.ReadLines();
                var count = rows.Length;
                var result = Outcome.Success;
                for(var i=1; i<count; i++)
                {
                    var record = new DefRelations();
                    ref readonly var row = ref rows[i];
                    var cells = @readonly(row.Split(Chars.Pipe).Select(x => x.Trim()));
                    if(cells.Length != llvm.DefRelations.FieldCount)
                    {
                        Wf.Error(Tables.FieldCountMismatch.Format(llvm.DefRelations.FieldCount, cells.Length));
                        Wf.Babble(row);
                        break;
                    }
                    var j=0;
                    result = DataParser.parse(skip(cells, j++), out record.SourceLine);
                    if(result.Fail)
                    {
                        Wf.Error(result.Message);
                        break;
                    }
                    result = DataParser.parse(skip(cells, j++), out record.Name);
                    if(result.Fail)
                    {
                        Wf.Error(result.Message);
                        break;
                    }
                    record.Ancestors = Lineage.parse(skip(cells, j++));
                    dst.Add(record);
                }
                Wf.Ran(running);
                return dst.ToArray();
            }
        }
    }
}