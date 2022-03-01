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
        public Index<RulePattern> LoadEncRulePatterns()
        {
            const byte FieldCount = RulePattern.FieldCount;
            var result = Outcome.Success;
            var path = XedPaths.DocTarget(XedDocKind.EncRulePatterns);
            var src = path.ReadLines();
            var buffer = list<RulePattern>();

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
                var pattern = new RulePattern();
                result = DataParser.parse(reader.Next(), out pattern.Seq);
                result = DataParser.parse(reader.Next(), out pattern.Hash);
                result = DataParser.eparse(reader.Next(), out pattern.Class);
                result = DataParser.eparse(reader.Next(), out pattern.OpCodeKind);
                result = DataParser.parse(reader.Next(), out pattern.Expression);
                buffer.Add(pattern);
                return result;
            }

            path.ReadLines(Next);
            var dst = result ? buffer.ToArray() : sys.empty<RulePattern>();
            if(result.Fail)
                Errors.Throw(result.Message);

            return dst;
        }
    }
}