//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedRules
    {
        public static RuleTableName tablename(RuleSig sig)
        {
            var data = ByteBlock48.Empty;
            data[46] = (byte)sig.TableKind;
            data[47] = (byte)Asci.encode(sig.Name, 0u, data.Bytes);
            return new (data);
        }

        public static string identifier(in RuleTableName name)
        {
            var dst = name.Format();
            var kind = name.TableKind;
            if(kind == RuleTableKind.Enc)
            {
                if(dst.EndsWith("_ENCODE"))
                    dst = dst.Remove("_ENCODE");
                else if(dst.EndsWith("_ENC"))
                    dst = dst.Remove("_ENC");
                dst = dst + "_ENC";
            }
            else if(kind == RuleTableKind.Dec)
            {
                dst = dst + "_DEC";
            }
            return dst;
        }
    }
}