//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [StructLayout(LayoutKind.Sequential)]
    public class ReplaceRule<T> : IRuleExpr
    {
        /// <summary>
        /// The sequence term to match
        /// </summary>
        public T Match {get;}

        /// <summary>
        /// The replacement value when matched
        /// </summary>
        public T Replace {get;}

        [MethodImpl(Inline)]
        public ReplaceRule(T match, T replace)
        {
            Match = match;
            Replace = replace;
        }

        public string Format()
            => string.Format("{0} -> {1}", Match, Replace);

        public override string ToString()
            => Format();
    }
}