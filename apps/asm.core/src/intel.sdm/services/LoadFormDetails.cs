//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using static core;

    partial class IntelSdm
    {
        public Index<AsmFormDetail> LoadFormDetails()
        {
            const byte FieldCount = AsmFormDetail.FieldCount;
            var result = Outcome.Success;
            var buffer = list<AsmFormDetail>();
            var path = SdmPaths.FormDetailPath();
            using var reader = path.Utf8LineReader();
            reader.Next(out _);
            while(reader.Next(out var line))
            {
                if(line.IsEmpty)
                    continue;

                var src = line.Cells(Chars.Pipe, AsmFormDetail.FieldCount).Reader();
                var dst = new AsmFormDetail();
                Throw.OnError(DataParser.parse(src.Next(), out dst.Seq));
                Throw.OnError(DataParser.parse(src.Next(), out dst.Id));
                Throw.OnError(DataParser.parse(src.Next(), out dst.Name));
                Throw.OnError(AsmSigs.parse(src.Next(), out dst.Sig));
                Throw.OnError(AsmOpCodes.parse(src.Next(), out dst.OpCode));
                Throw.OnError(DataParser.parse(src.Next(), out dst.Mode64));
                Throw.OnError(DataParser.parse(src.Next(), out dst.Mode32));
                Throw.OnError(DataParser.parse(src.Next(), out dst.IsRex));
                Throw.OnError(DataParser.parse(src.Next(), out dst.IsEvex));
                Throw.OnError(DataParser.parse(src.Next(), out dst.Description));
                buffer.Add(dst);
            }

            return buffer.ToArray();
        }
    }
}