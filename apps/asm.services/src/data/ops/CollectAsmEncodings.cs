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
        public Index<AsmEncodingRow> CollectAsmEncodings(WsContext context)
        {
            var project = context.Project;
            var result = Outcome.Success;
            var buffer = list<AsmEncodingRow>();
            CalcAsmEncodings(context,buffer);
            var dst = Projects.AsmEncodingTable(context.Project);
            var counter=0u;
            var record = AsmEncodingRow.Empty;
            var records = buffer.ToArray().Sort();
            for(var i=0u; i<records.Length; i++)
                seek(records,i).Seq = i;
            TableEmit(@readonly(records), AsmEncodingRow.RenderWidths, Projects.AsmEncodingTable(context.Project));
            context.Receiver.Collected(records);
            return records;
        }

        void CalcAsmEncodings(WsContext context, List<AsmEncodingRow> buffer)
        {
            var src = Projects.EncAsmSources(context.Project).View;
            var count = src.Length;
            var counter = 0u;
            for(var i=0; i<count; i++)
            {
                ref readonly var path = ref skip(src,i);
                var fref = context.FileRef(path);
                CalcAsmEncodings(context, fref, buffer);
            }
        }

        void CalcAsmEncodings(WsContext context, in FileRef src, List<AsmEncodingRow> dst)
        {
            const string EncodingMarker = "# encoding:";
            var result = Outcome.Success;
            var lines = FS.readlines(src.Path,true).View;
            var count = (uint)lines.Length;
            var ip = Address32.Zero;
            var seq = 0u;
            var record = default(AsmEncodingRow);
            var origin = src.Path.FileName.Format();
            for(var i=0u; i<count; i++)
            {
                ref readonly var line = ref skip(lines,i);
                if(line.Contains(EncodingMarker))
                {
                    var content = line.Content.Replace(Chars.Tab, Chars.Space);
                    var j = text.index(content, Chars.Hash);
                    record.Asm = text.trim(text.left(content,j));

                    var enc = text.right(content, j + EncodingMarker.Length);
                    result = AsmParser.asmhex(enc, out record.Encoded);
                    if(result.Fail)
                        Errors.Throw(result.Message);

                    if(context.Root(src.Path, out var o))
                    {
                        record.OriginId = o.DocId;
                        record.OriginName = o.Path.FileName.Format();
                    }

                    record.Size = record.Encoded.Size;
                    record.DocSeq = seq++;
                    record.IP = ip;
                    record.InstructionId = AsmBytes.instid(record.OriginId, ip, record.Encoded.Bytes);
                    record.EncodingId = record.InstructionId.EncodingId;
                    record.Source = ((FS.FileUri)src.Path).LineRef(line.LineNumber);
                    dst.Add(record);

                    ip += record.Size;
                    record = AsmEncodingRow.Empty;
                }
            }
        }
    }
}