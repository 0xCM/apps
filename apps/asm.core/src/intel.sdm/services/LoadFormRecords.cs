//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using static core;

    partial class IntelSdm
    {
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