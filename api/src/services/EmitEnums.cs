//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;
    using static core;

    ref struct EmitEnumsStep
    {
        readonly IWfRuntime Wf;

        public readonly ClrAssemblyAdapter Source;

        public readonly FS.FilePath Target;

        readonly WfHost Host;

        public ClrEnumRecord[] Records;

        [MethodImpl(Inline)]
        public EmitEnumsStep(IWfRuntime wf, WfHost host, ClrAssemblyAdapter src)
        {
            Wf = wf;
            Host = host;
            Source = src;
            Target = Wf.Db().Table(ClrEnumRecord.TableId, Source.Part);
            Records = default;
        }

        public void Dispose()
        {
        }

        public void Run()
        {
            Records = Enums.records(Source);
            if(Records.Length != 0)
            {
                var t = default(ClrEnumRecord);
                var formatter = Z0.Tables.formatter<ClrEnumRecord>(RenderWidths);
                var flow = Wf.EmittingTable<ClrEnumRecord>(Target);
                var counter = 0u;
                Execute(ref counter, formatter);
                Wf.EmittedTable(flow, counter);
            }
        }

        void Execute(ref uint counter, IRecordFormatter<ClrEnumRecord> formatter)
        {
            var src = @readonly(Records);
            var t = default(ClrEnumRecord);
            var count = src.Length;
            using var dst = Target.Writer();
            dst.WriteLine(formatter.FormatHeader());

            for(var i=0u; i<count; i++)
            {
                ref readonly var record = ref skip(src,i);
                try
                {
                    var row = formatter.Format(record);
                    dst.WriteLine(row);
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

        static ReadOnlySpan<byte> RenderWidths
            => new byte[ClrEnumRecord.FieldCount]{16, 36, 16, 24, 16, 16, 24, 16};
    }
}