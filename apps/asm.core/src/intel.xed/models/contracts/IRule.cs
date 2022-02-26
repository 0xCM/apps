//-----------------------------------------------------------------------------
// Copyright   : Intel Corporation, 2020
// License     : Apache
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct XedModels
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