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
    /// Definesan untyped binary logical operator expression
    /// </summary>
    public readonly struct BinaryLogicOpExpr : IBinaryLogicOpExpr
    {
        /// <summary>
        /// The operator kind
        /// </summary>
        public BinaryBitLogicKind ApiClass {get;}

        /// <summary>
        /// The left operand
        /// </summary>
        public ILogicExpr Left {get;}

        /// <summary>
        /// The right operand
        /// </summary>
        public ILogicExpr Right {get;}

        [MethodImpl(Inline)]
        public BinaryLogicOpExpr(BinaryBitLogicKind op, ILogicExpr lhs, ILogicExpr rhs)
        {
            ApiClass = op;
            Left = lhs;
            Right = rhs;
        }

        public string Format()
            => ApiClass.Format(Left,Right);

        public override string ToString()
            => Format();
    }
}