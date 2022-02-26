//-----------------------------------------------------------------------------
// Copyright   : Intel Corporation, 2020
// License     : Apache
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedModels;

    partial struct XedModels
    {
        public enum RuleKind : byte
        {
            None,

            Nonterminal,

            RegProduction
        }
    }
}