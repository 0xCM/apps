//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedRules;

    partial class XedParsers
    {
        public static bool parse(string src, out RuleKeyword dst)
        {
            var result = false;
            var input = text.trim(src);
            dst = RuleKeyword.Empty;
            switch(input)
            {
                case "default":
                    dst = RuleKeyword.Default;
                    result = true;
                    break;
                case "otherwise":
                    dst = RuleKeyword.Else;
                    result = true;
                break;
                case "nothing":
                    dst = RuleKeyword.Null;
                    result = true;
                break;
                case "error":
                    dst = RuleKeyword.Error;
                    result = true;
                break;
                case "@":
                    dst = RuleKeyword.Wildcard;
                    result = true;
                break;
            }

            return result;
        }
    }
}