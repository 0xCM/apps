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
        const byte ZeroLimit = 10;

        public static ReadOnlySpan<byte> parse(in RawMemberCode src, Span<byte> dst)
        {
            if(src.StubCode != src.Stub.Encoding)
                Errors.Throw("Stub code mismatch");
            return slice(dst,0, Bytes.readz(ZeroLimit, src.Target, dst));
        }

        [Parser]
        public static Outcome parse(LineNumber line, string src, out EncodedMember dst)
        {
            const byte FieldCount = EncodedMember.FieldCount;
            dst = default;
            var cells = text.split(src, Chars.Pipe);
            var count = cells.Length;
            if(count != FieldCount)
                return (false,string.Format("\n{0,-12} \n{1}", line, text.trim(cells).Delimit('\n').Format()));

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
    }


    partial class XTend
    {
        public static Index<EncodedMember> EncodedMemberTable(this FS.FilePath src)
        {
            ApiCode.index(src, out var dst);
            return dst;
        }

        public static Index<string> EncodedMemberAsm(this FS.FilePath src)
            => src.ReadLines(false);
    }
}