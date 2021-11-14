//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    using static core;

    using ST = llvm.stringtables;

    partial class LlvmRecordEtl
    {
        public Outcome ValidateStringTables()
        {
            var result = Outcome.Success;
            var runtime = strings.memory(ST.AVX512.Offsets, ST.AVX512.Data);
            var offsets = runtime.Offsets;
            var count = runtime.EntryCount;
            var formatter = Tables.formatter<MemoryStrings>();
            Write(formatter.Format(runtime, RecordFormatKind.KeyValuePairs));
            var symbols = Symbols.index<ST.AVX512.Index>();
            Write(string.Format("Symbols:{0}", symbols.Length));
            for(var i=0; i<offsets.Length; i++)
            {
                var l = strings.length(runtime, i);
                if(l == 0)
                    break;
                var k = (ST.AVX512.Index)i;
                var o = skip(offsets,i);
                var c = text.format(runtime[i]);
                Write(string.Format("{0}[{1}]='{2}'", typeof(ST.AVX512).Name, i, c));
            }
            return result;
        }
    }
}