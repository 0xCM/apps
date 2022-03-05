//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedRules
    {
        public readonly struct OpRefinement
        {
            public readonly @string Expression;

            [MethodImpl(Inline)]
            public OpRefinement(string expr)
            {
                Expression = expr;
            }

            [MethodImpl(Inline)]
            public static implicit operator OpRefinement(string src)
                => new OpRefinement(src);

            public string Format()
                => Expression;

            public override string ToString()
                => Format();

            public static OpRefinement Empty => new OpRefinement(EmptyString);
        }
   }
}