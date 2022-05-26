//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;

    using static core;

    partial class ApiCode
    {
        [Parser]
        public static Outcome parse(string src, out EncodedMember dst)
        {
            const byte FieldCount = EncodedMember.FieldCount;
            dst = default;
            var cells = text.split(src, Chars.Pipe);
            var count = cells.Length;
            if(count != FieldCount)
                return (false, AppMsg.CsvDataMismatch.Format(FieldCount,count, src));

            var result = Outcome.Success;
            var i=0;
            result = DataParser.parse(skip(cells,i++), out dst.Id);
            result = DataParser.parse(skip(cells,i++), out dst.EntryAddress);
            result = DataParser.parse(skip(cells,i++), out dst.EntryRebase);
            result = DataParser.parse(skip(cells,i++), out dst.TargetAddress);
            result = DataParser.parse(skip(cells,i++), out dst.TargetRebase);
            result = DataParser.parse(skip(cells,i++), out dst.StubAsm);
            result = Disp32.parse(skip(cells,i++), out dst.Disp);
            result = DataParser.parse(skip(cells,i++), out dst.CodeSize);
            dst.Host = text.trim(skip(cells,i++));
            dst.Sig = text.trim(skip(cells,i++));
            dst.Uri = text.trim(skip(cells,i++));
            return result;
        }

        // static Outcome parse(string src, out EncodedMember dst)
        // {
        //     const byte FieldCount = EncodedMember.FieldCount;
        //     dst = default;
        //     var cells = text.split(src, Chars.Pipe);
        //     var count = cells.Length;
        //     if(count != FieldCount)
        //         return (false, AppMsg.CsvDataMismatch.Format(FieldCount,count, src));

        //     var result = Outcome.Success;
        //     var i=0;
        //     result = DataParser.parse(skip(cells,i++), out dst.Id);
        //     result = DataParser.parse(skip(cells,i++), out dst.EntryAddress);
        //     result = DataParser.parse(skip(cells,i++), out dst.EntryRebase);
        //     result = DataParser.parse(skip(cells,i++), out dst.TargetAddress);
        //     result = DataParser.parse(skip(cells,i++), out dst.TargetRebase);
        //     result = DataParser.parse(skip(cells,i++), out dst.StubAsm);
        //     result = Disp32.parse(skip(cells,i++), out dst.Disp);
        //     result = DataParser.parse(skip(cells,i++), out dst.CodeSize);
        //     dst.Host = text.trim(skip(cells,i++));
        //     dst.Sig = text.trim(skip(cells,i++));
        //     dst.Uri = text.trim(skip(cells,i++));
        //     return result;
        // }
    }
}