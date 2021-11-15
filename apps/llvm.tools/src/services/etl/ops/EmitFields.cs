//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    using System;

    using records;

    using static core;

    using F = llvm.records.RecordField;

    partial class LlvmRecordEtl
    {
        Outcome EmitFields(ReadOnlySpan<RecordField> src, string dstid)
        {
            var fields = src;
            var parts = etl.partition(fields);
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
    }
}