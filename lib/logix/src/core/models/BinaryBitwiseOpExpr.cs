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
    /// Captures a binary bitwise operator along with with its operands
    /// </summary>
    public readonly struct BinaryBitwiseOpExpr<T> : IBinaryBitwiseOpExpr<T>
        where T : unmanaged
    {
        /// <summary>
        /// The operator kind
        /// </summary>
        public BinaryBitLogicKind ApiClass {get;}

        /// <summary>
        /// The left operand
        /// </summary>
        public ILogixExpr<T> LeftArg {get;}

        /// <summary>
        /// The right operand
        /// </summary>
        public ILogixExpr<T> RightArg {get;}

        [MethodImpl(Inline)]
        public BinaryBitwiseOpExpr(BinaryBitLogicKind op, ILogixExpr<T> left, ILogixExpr<T> right)
        {
            ApiClass = op;
            LeftArg = left;
            RightArg = right;
        }

        /// <summary>
        /// Renders the expression in canonical form
        /// </summary>
        public string Format()
            => ApiClass.Format(LeftArg, RightArg);

        public override string ToString()
            => Format();
    }
}