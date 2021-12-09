//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    using System;

    using static core;

    partial class LlvmDataProvider
    {
        Index<RecordField> SelectEmittedFields(string dsid)
        {
            return (Index<RecordField>)DataSets.GetOrAdd(dsid + ".fields", key => Load());

            Index<RecordField> Load()
            {
                var running = Wf.Running("Loading " + dsid);

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
                        Wf.Error(result.Message);
                        break;
                    }
                    dst[counter++] = field;
                }
                Wf.Ran(running);
                return dst;
            }
        }
    }
}