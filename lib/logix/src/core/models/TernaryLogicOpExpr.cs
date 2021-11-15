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
    /// Defines the application of an untyped ternary logic operator
    /// </summary>
    public readonly struct TernaryLogicOpExpr : ITernaryLogicOpExpr
    {
        /// <summary>
        /// The operator kind
        /// </summary>
        public TernaryBitLogicKind ApiClass {get;}

        /// <summary>
        /// The first operand
        /// </summary>
        public ILogicExpr FirstArg {get;}

        /// <summary>
        /// The second operand
        /// </summary>
        public ILogicExpr SecondArg {get;}

        /// <summary>
        /// The third operand
        /// </summary>
        public ILogicExpr ThirdArg {get;}

        [MethodImpl(Inline)]
        public TernaryLogicOpExpr(TernaryBitLogicKind op, ILogicExpr arg1, ILogicExpr arg2, ILogicExpr arg3)
        {
            ApiClass = op;
            FirstArg = arg1;
            SecondArg = arg2;
            ThirdArg = arg3;
        }

        public string Format()
            => ApiClass.Format(FirstArg,SecondArg,ThirdArg);

        public override string ToString()
            => Format();
    }
}