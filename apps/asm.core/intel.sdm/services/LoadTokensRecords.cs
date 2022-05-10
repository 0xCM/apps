//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using static core;

    partial class IntelSdm
    {
        public Index<AsmToken> LoadTokenRecords()
        {
            const byte FieldCount = AsmToken.FieldCount;
            var result = Outcome.Success;
            var buffer = list<AsmToken>();
            var path = SdmPaths.Tokens();
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
                var record = new AsmToken();
                DataParser.parse(skip(cells,i++), out record.Seq);
                DataParser.parse(skip(cells,i++), out record.Id);
                DataParser.parse(skip(cells,i++), out record.ClassName);
                DataParser.parse(skip(cells,i++), out record.KindName);
                DataParser.parse(skip(cells,i++), out record.KindValue);
                DataParser.parse(skip(cells,i++), out record.Index);
                DataParser.parse(skip(cells,i++), out record.Name);
                DataParser.parse(skip(cells,i++), out record.Value);
                DataParser.parse(skip(cells,i++), out record.Expression);
                buffer.Add(record);
            }

            return buffer.ToArray();
        }
    }
}