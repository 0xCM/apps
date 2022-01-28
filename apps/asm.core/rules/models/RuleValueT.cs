//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Runtime.CompilerServices;

    using static Root;

    public sealed class RuleValue<T> : RuleExpr<T>
    {
        public RuleValue(T src, bool terminal = false)
            : base(src)
        {
            IsTerminal = terminal;
        }

        public override bool IsTerminal {get;}

        public override string Format()
            => Content.ToString();

        [MethodImpl(Inline)]
        public static implicit operator RuleValue<T>(T src)
            => new RuleValue<T>(src);

        [MethodImpl(Inline)]
        public static implicit operator T (RuleValue<T> src)
            => src.Content;
    }
}