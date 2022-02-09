//-----------------------------------------------------------------------------
// Copyright   : Intel Corporation, 2020
// License     : Apache
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct XedRecords
    {
        [SymSource(xed)]
        public enum RuleOperator
        {
            [Symbol("")]
            None,

            [Symbol("=")]
            Eq,

            [Symbol("!=")]
            Neq,

            [Symbol(":=")]
            Assign
        }
    }
}