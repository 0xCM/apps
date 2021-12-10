//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    using static core;

    partial class LlvmDataProvider
    {
        public Index<LlvmInstPattern> SelectInstPatterns()
        {
            return (Index<LlvmInstPattern>)DataSets.GetOrAdd(nameof(SelectInstPatterns), key => Load());

            Index<LlvmInstPattern> Load()
            {
                const byte FieldCount = LlvmInstPattern.FieldCount;
                var src = LlvmPaths.Table<LlvmInstPattern>();
                var buffer = list<LlvmInstPattern>();
                using var reader = src.Utf8LineReader();
                reader.Next(out var header);
                var cols = header.Split(Chars.Pipe);
                if(cols.Length != FieldCount)
                {
                    Wf.Error(Tables.FieldCountMismatch.Format(cols.Length, FieldCount));
                    return sys.empty<LlvmInstPattern>();
                }

                while(reader.Next(out var line))
                {
                    var row = new LlvmInstPattern();
                    cols = line.Split(Chars.Pipe);
                    if(cols.Length != FieldCount)
                    {
                        Wf.Error(Tables.FieldCountMismatch.Format(cols.Length, FieldCount));
                        return sys.empty<LlvmInstPattern>();
                    }

                    var i=0;
                    DataParser.parse(skip(cols,i++), out row.AsmId);
                    row.InstName = skip(cols,i++);
                    row.Mnemonic = skip(cols,i++);
                    row.FormatPattern = skip(cols,i++);
                    buffer.Add(row);
                }
                return buffer.ToArray();
            }
        }
    }
}