//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedModels;

    partial class XedRules
    {
        public readonly struct RuleSig
        {
            public readonly Identifier Name;

            public readonly Identifier ReturnType;

            [MethodImpl(Inline)]
            public RuleSig(Identifier name, Identifier ret)
            {
                Name = name;
                ReturnType = ret;
            }

            public string Format()
                => string.Format("{0} {1}()", ReturnType, Name);

            public override string ToString()
                => Format();
        }
    }
}