//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    using static core;

    partial class LlvmTableLoader
    {
        public Index<RecordField> LoadFields(string dsid)
        {
            var running = Running("Loading " + dsid);
            var src = LlvmPaths.Table(dsid);
            var count = FS.linecount(src);
            var result = Outcome.Success;
            var dst = alloc<RecordField>(count.Lines);
            var counter = 0u;
            using var reader = src.Utf8LineReader();
            var id = Identifier.Empty;
            var i = 0u;
            var j = 0u;
            while(reader.Next(out var line))
            {
                result = RecordFieldParser.parse(line, out var field);
                if(result.Fail)
                {
                    Error(result.Message);
                    break;
                }
                dst[counter++] = field;
            }

            Ran(running);
            return dst;
        }
    }
}