//-----------------------------------------------------------------------------
// Copyright   : Intel Corporation, 2020
// License     : Apache
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    partial struct XedModels
    {
        public readonly struct PatternOperands
        {
            public TextBlock Pattern {get;}

            public Index<RuleOperand> Operands {get;}

            [MethodImpl(Inline)]
            public PatternOperands(string pattern, RuleOperand[] operands)
            {
                Pattern = text.despace(pattern);
                Operands = operands;
            }

            public string Format()
                => string.Format("Pattern:{0}\nOperands:{1}", Pattern, Operands);

            public override string ToString()
                => Format();
        }
    }
}