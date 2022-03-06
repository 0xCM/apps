//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedRules
    {
        public readonly struct RuleSig : IEquatable<RuleSig>
        {
            public readonly Identifier Name;

            public readonly Identifier ReturnType;

            [MethodImpl(Inline)]
            public RuleSig(Identifier name, Identifier ret)
            {
                Name = name;
                ReturnType = ret;
            }

            public override int GetHashCode()
                => Name.GetHashCode();

            public bool Equals(RuleSig src)
                => Name.Equals(src.Name);

            public override bool Equals(object src)
                => src is RuleSig x && Equals(x);

            public string Format()
                => string.Format("{0} {1}()", ReturnType, Name);

            public override string ToString()
                => Format();
        }
    }
}