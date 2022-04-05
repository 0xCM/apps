//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static ExprPatterns;

    partial struct Rules
    {
    [StructLayout(LayoutKind.Sequential)]
    public class BetweenRule<T> : RuleExpr<Pair<T>>
    {
        public T Left => Content.Left;

        public T Right => Content.Right;

        public BetweenRule(T min, T max)
            : base((min,max))
        {

        }

        public override string Format()
           => string.Format(InclusiveRange, Left, Right);

        [MethodImpl(Inline)]
        public static implicit operator BetweenRule<T>((T min, T max) src)
            => new BetweenRule<T>(src.min, src.max);
    }
    }


}