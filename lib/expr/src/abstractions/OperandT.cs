//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public abstract class Operand<T> : IOperand<T>
    {
        public abstract string Format();

        public abstract T Resolve(IContext context);
    }

    public abstract class OperandValue<T> : Operand<T>
    {

    }

    public abstract class OperandVar<T> : Operand<T>
    {

    }
}