//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Ops.Logic
{
    using System.Runtime.CompilerServices;

    using static Root;

    /// <summary>
    /// Represents a boolean evaluation
    /// </summary>
    public readonly struct Test<C> : IExpr
        where C : IExpr
    {
        /// <summary>
        /// The test condition
        /// </summary>
        public C Condition {get;}

        [MethodImpl(Inline)]
        public Test(C condition)
            => Condition = condition;

        public string Format()
            => logic.format(this);

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator Test<C>(C src)
            => new Test<C>(src);
    }
}