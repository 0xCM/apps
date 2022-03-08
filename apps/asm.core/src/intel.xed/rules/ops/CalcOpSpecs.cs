//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedModels;
    using static core;

    partial class XedRules
    {
        Outcome ParseOperand(RuleOpName name, string[] attribs, out RuleOpSpec dst)
        {
            var result = Outcome.Success;
            dst = new RuleOpSpec();
            dst.Name = name;
            dst.Kind = XedRules.opkind(name);
            dst.Name = name;
            dst.Properties = attribs;
            return result;
        }

        Outcome ParseOpName(string src, out RuleOpName dst)
        {
            var result = Outcome.Success;
            var i = text.index(src, Chars.Eq, Chars.Colon);
            dst = RuleOpName.None;
            if(i > 0)
            {
                var name = text.left(src,i);
                result = OpNames.ExprKind(name, out dst);
                if(result.Fail)
                    result = (false, Msg.ParseFailure.Format(nameof(RuleOpName), src));
            }
            return result;
        }

        Outcome ExtractOpAttributes(string src, out string[] dst)
        {
            var result = Outcome.Success;
            var i = text.index(src,Chars.Eq, Chars.Colon);
            dst = sys.empty<string>();
            if(i > 0)
            {
                var attribs = text.right(src,i);
                if(text.empty(attribs))
                    result = (false, string.Format("No attributes found in {0}", src));
                else
                    dst = text.split(attribs, Chars.Colon).Where(text.nonempty);
            }
            return result;
        }

        Outcome ParseOperand(string src, out RuleOpSpec dst)
        {
            var result = Outcome.Success;
            dst = default;
            var name = RuleOpName.None;
            var attribs = sys.empty<string>();

            result = ParseOpName(src, out name);

            if(result)
                result = ExtractOpAttributes(src, out attribs);

            if(result)
                result = ParseOperand(name, attribs, out dst);

            dst.Expression = src;

            return result;
        }
    }
}