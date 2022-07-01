//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    using static core;

    partial class LlvmTableLoader
    {
        public Index<DefRelations> LoadDefRelations()
        {
            var running = Running(nameof(LoadDefRelations));
            var src = LlvmPaths.DbTable<DefRelations>();
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
                    Error(Tables.FieldCountMismatch.Format(llvm.DefRelations.FieldCount, cells.Length));
                    Babble(row);
                    break;
                }
                var j=0;
                result = DataParser.parse(skip(cells, j++), out record.SourceLine);
                if(result.Fail)
                {
                    Error(result.Message);
                    break;
                }
                result = DataParser.parse(skip(cells, j++), out record.Name);
                if(result.Fail)
                {
                    Error(result.Message);
                    break;
                }
                record.Ancestors = Lineage.parse(skip(cells, j++));
                dst.Add(record);
            }
            Ran(running);
            return dst.ToArray();
        }
    }
}