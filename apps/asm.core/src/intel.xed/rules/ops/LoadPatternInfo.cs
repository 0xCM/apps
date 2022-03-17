//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;
    using static XedModels;

    using Asm;

    partial class XedRules
    {
        public Index<PatternInfo> LoadPatternInfo()
        {
            const byte FieldCount = PatternInfo.FieldCount;
            var src = XedPaths.DocTarget(XedDocKind.PatternInfo);
            var result = Outcome.Success;
            var buffer = list<PatternInfo>();
            bool Next(TextLine src)
            {
                if(src.LineNumber == 1)
                    return true;

                var cells = text.trim(text.split(src.Content, Chars.Pipe));
                var count = cells.Length;
                if(count != FieldCount)
                {
                    result = (false,AppMsg.CsvDataMismatch.Format(FieldCount, count, src.Content));
                    return false;
                }

                var reader = cells.Reader();
                var dst = new PatternInfo();
                result = DataParser.parse(reader.Next(), out dst.PatternId);
                result = DataParser.parse(reader.Next(), out dst.InstId);
                result = XedParsers.parse(reader.Next(), out dst.OcKind);
                result = DataParser.parse(reader.Next(), out dst.OcIndex);
                result = XedParsers.parse(reader.Next(), out dst.Class);
                AsmParser.parse(reader.Next(), out dst.OpCode);
                result = DataParser.parse(reader.Next(), out dst.Body);
                buffer.Add(dst);
                return result;
            }

            src.ReadLines(Next);
            var dst = result ? buffer.ToArray() : sys.empty<PatternInfo>();
            if(result.Fail)
                Errors.Throw(result.Message);

            return dst;
        }
    }
}