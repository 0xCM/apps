//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using static core;

    partial class IntelSdm
    {
        public Outcome LoadForms(out Index<AsmForm> dst)
        {
            var result = LoadFormRecords(out var records);
            dst = sys.empty<AsmForm>();
            if(result.Fail)
                return result;

            var count = records.Count;
            dst = alloc<AsmForm>(count);
            for(var i=0; i<count; i++)
            {
                ref readonly var record = ref records[i];
                dst[i] = AsmForm.define(record.Sig, record.OpCode);
            }

            return result;
        }

        public Outcome LoadFormRecords(out Index<AsmFormRecord> dst)
        {
            const byte FieldCount = AsmFormRecord.FieldCount;
            var result = Outcome.Success;
            var buffer = list<AsmFormRecord>();
            var path = SdmPaths.Forms();
            using var reader = path.Utf8LineReader();
            reader.Next(out _);
            while(reader.Next(out var line))
            {
                var cells = text.trim(text.split(line.Content, Chars.Pipe));
                var count = cells.Length;
                if(count != FieldCount)
                {
                    result = (false, AppMsg.CsvDataMismatch.Format(count, FieldCount, line.Content));
                    break;
                }

                var i=0u;
                var record = new AsmFormRecord();
                result = DataParser.parse(skip(cells,i++), out record.Seq);
                if(result.Fail)
                    break;

                result = AsmSigs.parse(skip(cells,i++), out record.Sig);
                if(result.Fail)
                    break;

                result = AsmOpCodes.parse(skip(cells,i++), out record.OpCode);
                if(result.Fail)
                    break;

                buffer.Add(record);
            }

            dst = result ? buffer.ToArray() : sys.empty<AsmFormRecord>();

            return result;
        }
    }
}