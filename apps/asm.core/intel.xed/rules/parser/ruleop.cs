//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedRules
    {
        partial struct CellParser
        {
            static bool ruleop(string src, out OperatorKind dst)
            {
                if(IsNeq(src))
                {
                    dst = OperatorKind.Neq;
                    return true;
                }
                else if(IsEq(src))
                {
                    dst = OperatorKind.Eq;
                    return true;
                }
                else if(IsImpl(src))
                {
                    dst = OperatorKind.Impl;
                    return true;
                }
                else
                {
                    dst = 0;
                    return false;
                }
            }

            static bool ruleop(string src, out RuleOperator dst)
            {
                if(ruleop(src, out OperatorKind k))
                {
                    dst = k;
                    return true;
                }
                else
                {
                    dst = default;
                    return false;
                }
            }
        }
    }
}