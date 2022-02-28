//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedRules
    {
        public interface IRule : ITextual
        {
            RuleTable Def {get;}
        }

        public interface IRule<K> : IRule
            where K : unmanaged
        {
            K Kind {get;}
        }
    }
}