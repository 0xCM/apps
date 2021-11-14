//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static core;

    public sealed class EnumDataEmitter : AppService<EnumDataEmitter>
    {
        public Index<ClrEnumRecord> EmitEnumRecords(ClrAssemblyAdapter src, FS.FilePath dst)
        {
            var records = Enums.records(src);
            if(records.Length != 0)
            {
                var t = default(ClrEnumRecord);
                var formatter = Tables.formatter<ClrEnumRecord>(32);
                var flow = Wf.EmittingTable<ClrEnumRecord>(dst);
                var counter = 0u;
                Execute(records, ref counter, formatter, dst);
                Wf.EmittedTable(flow, counter);
            }
            return records;
        }

        void Execute(ReadOnlySpan<ClrEnumRecord> src,  ref uint counter, in IRecordFormatter<ClrEnumRecord> formatter, FS.FilePath Target)
        {
            var t = default(ClrEnumRecord);
            var count = src.Length;
            using var dst = Target.Writer();
            dst.WriteLine(formatter.FormatHeader());

            for(var i=0u; i<count; i++)
            {
                ref readonly var record = ref skip(src,i);
                try
                {
                    dst.WriteLine(formatter.Format(record));
                    counter++;
                }
                catch(Exception)
                {
                    var msg = $"Error emitting row {i}/{count}";
                    dst.WriteLine(msg);
                    Wf.Warn(msg);
                }
            }
        }
    }
}