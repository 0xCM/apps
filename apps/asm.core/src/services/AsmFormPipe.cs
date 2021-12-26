//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;
    using static core;
    using static Msg;

    public class AsmFormPipe : RecordPipe<AsmFormPipe,AsmFormRecord>
    {
        public AsmFormPipe()
        {

        }


        public void Emit(ReadOnlySpan<AsmFormInfo> src, FS.FilePath dst)
        {
            var count = src.Length;
            if(count == 0)
            {
                Warn("No work to do");
                return;
            }

            var flow = EmittingTable<AsmFormRecord>(dst);
            using var writer = dst.Writer();
            writer.WriteLine(FormatHeader());
            for(ushort i=0; i<count; i++)
            {
                var data = NewRecord();
                writer.WriteLine(Format(Fill(i, skip(src,i), ref data)));
            }
            EmittedTable(flow, count);
        }

        ReadOnlySpan<HashEntry> HashPerfect(ReadOnlySpan<AsmFormInfo> src)
        {
            Status($"Attempting to find perfect hashes for {src.Length} expressions");
            var perfect = HashFunctions.perfect(src, x => x.Format(), HashFunctions.strings()).Codes;
            var count = (uint)perfect.Length;

            Status($"Found {count} distinct hash codes for {src.Length} expressions");

            var dst = Db.AsmCatalogTable<HashEntry>();
            var buffer = alloc<HashEntry>(count);
            ref var records = ref first(buffer);
            for(var i=0u; i<count; i++)
            {
                ref var record = ref seek(records,i);
                ref readonly var hash = ref skip(perfect,i);
                record.Key = (hash.Hash % count);
                record.Content = hash.Source.Format();
                record.Code = hash.Hash;
            }
            var emitting = EmittingTable<HashEntry>(dst);
            var ecount = Tables.emit(@readonly(buffer), dst);
            EmittedTable(emitting, ecount);
            return buffer;
        }

        [MethodImpl(Inline)]
        ref AsmFormRecord Fill(ushort seq, AsmFormInfo src, ref AsmFormRecord dst)
        {
            dst.Seq = seq;
            dst.OpCode = src.OpCode;
            dst.Sig = src.Sig;
            dst.FormExpr = src;
            return ref dst;
        }

        public ReadOnlySpan<AsmFormRecord> LoadForms(in TextGrid src)
        {
            var rows = src.Rows;
            var count = rows.Length;
            var buffer = alloc<AsmFormRecord>(count);
            ref var dst = ref first(buffer);
            for(var i=0; i<count; i++)
            {
                if(i==0)
                    continue;

                ref readonly var row = ref skip(rows,i);
                if(row.CellCount != FieldCount)
                {
                    Wf.Error(FieldCountMismatch.Format(TableId, row.CellCount, FieldCount));
                    return array<AsmFormRecord>();
                }
                AsmParser.row(row, ref seek(dst,i));
            }
            return buffer;
        }

        public ReadOnlySpan<AsmFormRecord> LoadForms(FS.FilePath src)
        {
            var dst = list<AsmFormRecord>();
            if(src.Exists)
            {
                var flow = Running($"Loading form records from {src.ToUri()}");
                var doc = TextGrids.parse(src);
                if(doc.Failed)
                {
                    Error(doc.Reason);
                    return array<AsmFormRecord>();
                }

                var forms = LoadForms(doc.Value);
                Ran(flow, LoadedForms.Format(forms.Length, src));
                return forms;
            }
            else
            {
                Error($"The file <{src.ToUri()}> does not exist");
                return array<AsmFormRecord>();
            }
        }

        public Outcome ParseRow(TextLine src, out AsmFormRecord dst)
        {
            var parts = Cells(src.Content);
            var count = parts.Length;
            if(count == FieldCount)
            {
                var i = 0u;
                DataParser.parse(NextCell(parts, ref i), out dst.Seq);
                dst.OpCode = new AsmOpCodeString(NextCell(parts, ref i));
                AsmParser.siginfo(NextCell(parts, ref i), out dst.Sig);
                dst.FormExpr = new AsmFormInfo(dst.OpCode, dst.Sig);
                return true;
            }
            else
            {
                dst = default;
                return (false, FieldCountMismatch.Format(TableId, count, FieldCount));
            }
        }

        [MethodImpl(Inline)]
        ref readonly string NextCell(ReadOnlySpan<string> src, ref uint i)
            => ref skip(src, i++);
    }
}