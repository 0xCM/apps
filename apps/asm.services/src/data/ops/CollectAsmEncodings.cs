//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;

    using static core;

    partial class ProjectDataServices
    {
        public ConstLookup<FS.FilePath,Index<AsmEncodingRow>> CollectAsmEncodings(WsContext context)
        {
            var project = context.Project;
            var result = Outcome.Success;
            var _docs = CalcEncAsmSources(context);
            var paths = _docs.Keys.ToArray().Sort();
            var dst = Projects.AsmEncodingTable(context.Project);
            var counter=0u;
            var record = AsmEncodingRow.Empty;
            var formatter = Tables.formatter<AsmEncodingRow>(AsmEncodingRow.RenderWidths);
            var emitting = EmittingTable<AsmEncodingRow>(dst);
            using var writer = dst.Utf8Writer();
            writer.WriteLine(formatter.FormatHeader());
            foreach(var path in paths)
            {
                var doc = _docs[path];
                var fref = context.FileRef(path);
                var encoded = doc.View;
                var count = encoded.Length;
                for(var i=0u; i<count; i++)
                {
                    ref readonly var e = ref skip(encoded,i);

                    record = AsmEncodingRow.Empty;
                    if(context.Root(path, out var source))
                    {
                        record.OriginId = source.DocId;
                        record.OriginName = source.Path.FileName.Format();
                    }
                    record.Seq = counter++;
                    record.DocSeq = i;
                    record.IP = e.IP;
                    record.EncodingId = e.EncodingId;
                    record.InstructionId = (record.OriginId, record.EncodingId);
                    Require.equal(record.InstructionId, e.InstructionId);
                    record.Asm = e.Asm;
                    record.Size = e.Size;
                    record.Encoded = e.Encoded;
                    record.Source = e.Source;
                    writer.WriteLine(formatter.Format(record));
                }
            }
            EmittedTable(emitting, counter);
            context.Receiver.Collected(_docs);
            return _docs;
        }
    }
}