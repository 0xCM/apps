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
        void CalcEncAsmSource(WsContext context, in FileRef file, out Index<AsmEncodingRow> dst)
        {
            const string EncodingMarker = "# encoding:";
            var src = file.Path;
            var result = Outcome.Success;
            dst = sys.empty<AsmEncodingRow>();
            var lines = FS.readlines(src,true).View;
            var count = (uint)lines.Length;
            var buffer = list<AsmEncodingRow>();
            var ip = Address32.Zero;
            var seq = 0u;
            var record = default(AsmEncodingRow);
            var origin = file.Path.FileName.Format();
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

                    if(context.Root(file.Path, out var o))
                    {
                        record.OriginId = o.DocId;
                        record.OriginName = o.Path.FileName.Format();
                    }

                    record.Size = record.Encoded.Size;
                    record.DocSeq = seq++;
                    record.IP = ip;
                    record.InstructionId = AsmBytes.instid(record.OriginId, ip, record.Encoded.Bytes);
                    record.EncodingId = record.InstructionId.EncodingId;
                    record.Source = ((FS.FileUri)src).LineRef(line.LineNumber);
                    buffer.Add(record);

                    ip += record.Size;
                    record = default(AsmEncodingRow);
                }
            }
            dst = buffer.ToArray();
        }

        ConstLookup<FS.FilePath,Index<AsmEncodingRow>> CalcEncAsmSources(WsContext context)
        {
            var src = Projects.EncAsmSources(context.Project).View;
            var count = src.Length;
            var dst = dict<FS.FilePath,Index<AsmEncodingRow>>();
            var counter = 0u;
            for(var i=0; i<count; i++)
            {
                ref readonly var path = ref skip(src,i);
                var fref = context.FileRef(path);
                CalcEncAsmSource(context, fref, out var doc);
                var scount = doc.Count;
                var statements = doc.Edit;
                for(var j=0; j<scount; j++)
                    seek(statements,j).Seq = counter++;

                dst[path] = doc;
            }

            return dst;
        }
    }
}