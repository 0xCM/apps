//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial class XedRules
    {
        public Index<RulePatternInfo> LoadPatternInfo()
        {
            var path = XedPaths.RulePatterns();
            const byte FieldCount = RulePatternInfo.FieldCount;
            var result = Outcome.Success;
            var src = path.ReadLines();
            var buffer = list<RulePatternInfo>();
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
                var pattern = new RulePatternInfo();
                result = DataParser.parse(reader.Next(), out pattern.Seq);
                result = DataParser.parse(reader.Next(), out pattern.InstId);
                result = DataParser.parse(reader.Next(), out pattern.Hash);
                result = XedParsers.parse(reader.Next(), out pattern.Class);
                result = XedParsers.parse(reader.Next(), out pattern.OpCodeKind);
                result = DataParser.parse(reader.Next(), out pattern.BodyExpr);
                buffer.Add(pattern);
                return result;
            }

            path.ReadLines(Next);
            var dst = result ? buffer.ToArray() : sys.empty<RulePatternInfo>();
            if(result.Fail)
                Errors.Throw(result.Message);

            return dst;
        }
    }
}