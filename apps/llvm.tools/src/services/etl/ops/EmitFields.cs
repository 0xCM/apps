//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    using System;

    using static core;

    using F = llvm.RecordField;

    partial class LlvmEtl
    {

        Outcome EmitFields(ReadOnlySpan<RecordField> src, string dstid)
        {
            var fields = src;
            var parts = partition(fields);
            var count = fields.Length;
            var dst = LlvmPaths.Table(dstid);
            var emitting = EmittingTable<RecordField>(dst);
            using var writer = dst.AsciWriter();
            writer.WriteLine(F.RowHeader);
            for(var i=0; i<count; i++)
            {
                ref readonly var field = ref skip(fields,i);
                writer.WriteLine(string.Format(F.RowFormat, field.RecordName, field.DataType, field.Name, field.Value));
            }

            EmittedTable(emitting, count);
            return true;
        }

        static ReadOnlySpan<RecordFields> partition(ReadOnlySpan<RecordField> src)
        {
            var count = src.Length;
            var dst = list<RecordFields>();
            var subset = list<RecordField>();
            var current = Identifier.Empty;
            for(var i=0; i<count; i++)
            {
                ref readonly var f = ref skip(src,i);
                ref readonly var id = ref f.RecordName;
                if(id != current)
                {
                    if(subset.Count != 0)
                    {
                        dst.Add(new RecordFields(current, subset.ToArray()));
                        subset.Clear();
                        current = id;
                    }
                }
                subset.Add(f);
            }

            if(subset.Count != 0)
                dst.Add(new RecordFields(current, subset.ToArray()));
            return dst.ViewDeposited();
        }
    }
}