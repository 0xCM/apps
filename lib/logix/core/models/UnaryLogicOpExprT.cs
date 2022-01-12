//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public readonly struct UnaryLogicOpExpr<T> :  IUnaryLogicOpExpr<T>
        where T : unmanaged
    {
        public UnaryBitLogicKind ApiClass {get;}

        public ILogicExpr<T> Operand {get;}

        [MethodImpl(Inline)]
        public UnaryLogicOpExpr(UnaryBitLogicKind kind, ILogicExpr<T> arg)
        {
            Operand = arg;
            ApiClass = kind;
        }

        ILogicExpr IUnaryOpExpr<ILogicExpr>.Operand
            => Operand;

        public string Format()
            => ApiClass.Format(Operand);
    }
}