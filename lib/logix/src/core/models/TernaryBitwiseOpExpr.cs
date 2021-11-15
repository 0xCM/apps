//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    /// <summary>
    /// Defines a typed ternary bitwise operator expression
    /// </summary>
    public readonly struct TernaryBitwiseOpExpr<T> : ITernaryBitwiseOpExpr<T>
        where T : unmanaged
    {
        /// <summary>
        /// The operator kind
        /// </summary>
        public TernaryBitLogicKind ApiClass {get;}

        /// <summary>
        /// The first operand
        /// </summary>
        public ILogixExpr<T> FirstArg {get;}

        /// <summary>
        /// The second operand
        /// </summary>
        public ILogixExpr<T> SecondArg {get;}

        /// <summary>
        /// The third operand
        /// </summary>
        public ILogixExpr<T> ThirdArg {get;}

        [MethodImpl(Inline)]
        public TernaryBitwiseOpExpr(TernaryBitLogicKind op, ILogixExpr<T> first, ILogixExpr<T> second, ILogixExpr<T> third)
        {
            ApiClass = op;
            FirstArg = first;
            SecondArg = second;
            ThirdArg = third;
        }

        public string Format()
            => ApiClass.Format(FirstArg,SecondArg,ThirdArg);

        public override string ToString()
            => Format();
    }
}