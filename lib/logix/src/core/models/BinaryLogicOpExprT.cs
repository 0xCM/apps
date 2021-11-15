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
    /// Defines a typed binary logical operator expression
    /// </summary>
    public readonly struct BinaryLogicOpExpr<T> : IBinaryLogicOpExpr<T>
        where T : unmanaged
    {
        /// <summary>
        /// The left operand
        /// </summary>
        public ILogicExpr<T> LeftArg {get;}

        /// <summary>
        /// The right operand
        /// </summary>
        public ILogicExpr<T> RightArg {get;}

        /// <summary>
        /// The operator kind
        /// </summary>
        public BinaryBitLogicKind ApiClass {get;}

        [MethodImpl(Inline)]
        public BinaryLogicOpExpr(BinaryBitLogicKind op, ILogicExpr<T> left, ILogicExpr<T> right)
        {
            ApiClass = op;
            LeftArg = left;
            RightArg = right;
        }

        ILogicExpr IBinaryOpExpr<ILogicExpr>.LeftArg
            => LeftArg;

        ILogicExpr IBinaryOpExpr<ILogicExpr>.RightArg
            => RightArg;

        public string Format()
            => ApiClass.Format(LeftArg,RightArg);

        public override string ToString()
            => Format();
    }
}