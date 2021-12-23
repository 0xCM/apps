//-----------------------------------------------------------------------------
// Copyright   : Intel Corporation, 2020
// License     : Apache
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Runtime.CompilerServices;

    using static Root;

    partial struct XedModels
    {
        public readonly struct RuleOperand
        {
            public TextBlock Value {get;}

            [MethodImpl(Inline)]
            public RuleOperand(string value)
            {
                Value = value;
            }

            public string Format()
                => Value.Format();

            public override string ToString()
                => Format();
        }
    }
}