//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public sealed class RuleValueExpr<T> : RuleExpr<T>
    {
        public RuleValueExpr(T src, bool terminal = false)
            : base(src)
        {
            IsTerminal = terminal;
        }

        public override bool IsTerminal {get;}
        public override string Format()
            => Content.ToString();

        public static implicit operator RuleValueExpr<T>(T src)
            => new RuleValueExpr<T>(src);
    }
}