//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedRules
    {
        public static bool parse(string src, out FieldLiteral dst)
        {
            var result = true;
            var input = text.trim(src);
            dst = FieldLiteral.Empty;
            switch(input)
            {
                case "default":
                    dst = FieldLiteral.Default;
                    break;
                case "else":
                case "otherwise":
                    dst = FieldLiteral.Branch;
                break;
                case "nothing":
                case "null":
                    dst = FieldLiteral.Null;
                break;
                case "error":
                    dst = FieldLiteral.Error;
                break;
                case "@":
                    dst = FieldLiteral.Wildcard;
                break;
                default:
                    if(src.Length <= 8)
                        dst = FieldLiteral.Text(input);
                    else
                        result = false;
                break;
            }

            return result;
        }
    }
}